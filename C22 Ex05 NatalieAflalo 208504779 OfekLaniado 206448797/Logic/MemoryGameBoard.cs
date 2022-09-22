using System;

namespace Logic
{
    public class MemoryGameBoard
    {
        private readonly char[,] r_MatrixGameBoard;
        private readonly bool[,] r_FlippedBlocksMatrix;
        private readonly int[] r_RandomLettersCounter;
        private int m_NumOfColumns;
        private int m_NumOfRows;
        private bool m_IsAllBlocksFlipped;

        public MemoryGameBoard(int i_InputRows, int i_InputColumns)
        {
            m_NumOfRows = i_InputRows;
            m_NumOfColumns = i_InputColumns;
            r_MatrixGameBoard = new char[m_NumOfRows, m_NumOfColumns];
            r_FlippedBlocksMatrix = new bool[m_NumOfRows, m_NumOfColumns];
            r_RandomLettersCounter = new int[m_NumOfColumns * m_NumOfRows / 2];
            createRandomMatrix();
        }

        public int NumberOfRows
        {
            get { return m_NumOfRows; }
        }

        public int NumberOfColumns
        {
            get { return m_NumOfColumns; }
        }

        public char[,] MatrixGameBoard
        {
            get { return r_MatrixGameBoard; }
        }

        public bool[,] MatrixFlippedBlocks
        {
            get { return r_FlippedBlocksMatrix; }
        }

        public bool IsAllBlocksFlipped
        {
            get { return m_IsAllBlocksFlipped; }
        }

        private void createRandomMatrix()
        {
            int counterOfCorrectValuesInMatrix = 0;
            Random rndCharForMatrix = new Random();
            char randomChar;

            for (int currentRow = 0; currentRow < m_NumOfRows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < m_NumOfColumns; currentColumn++)
                {
                    while (r_MatrixGameBoard[currentRow, currentColumn] == '\0')
                    {
                        randomChar = (char)rndCharForMatrix.Next(65, 65 + (m_NumOfColumns * m_NumOfRows / 2));

                        if (r_RandomLettersCounter[((int)randomChar) - 65] < 2)
                        {
                            r_RandomLettersCounter[((int)randomChar) - 65]++;
                            r_MatrixGameBoard[currentRow, currentColumn] = randomChar;
                            counterOfCorrectValuesInMatrix++;
                        }
                    }
                }
            }
        }

        public void FlipOrUnflipBlock(int i_MatrixIndex, bool i_IsFlip)
        {
            r_FlippedBlocksMatrix[i_MatrixIndex / 10, i_MatrixIndex % 10] = i_IsFlip;
            isAllBlocksFlipped();
        }

        private void isAllBlocksFlipped()
        {
            m_IsAllBlocksFlipped = true;

            for (int i = 0; i < m_NumOfRows; i++)
            {
                for (int j = 0; j < m_NumOfColumns; j++)
                {
                    if (!r_FlippedBlocksMatrix[i, j])
                    {
                        m_IsAllBlocksFlipped = false;
                    }
                }
            }
        }
    }
}
