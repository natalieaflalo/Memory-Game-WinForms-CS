using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public static class LogicForUI
    {
        private static Player s_FirstPlayer;
        private static Player s_SecondPlayer;
        private static Dictionary<int, char> s_AIMemoryDict;

        public static void CreatePlayers(string i_FirstName, string i_SecondName)
        {
            s_FirstPlayer = new Player(i_FirstName);
            s_SecondPlayer = new Player(i_SecondName);
        }

        public static Player FirstPlayer
        {
            get { return s_FirstPlayer; }
        }

        public static Player SecondPlayer
        {
            get { return s_SecondPlayer; }
        }

        public static void InitiateAIDictionary()
        {
            s_AIMemoryDict = new Dictionary<int, char>();
        }

        public static void UpdateAIDictionary(int i_BlockID, char i_ValueInMatrix)
        {
            if (!s_AIMemoryDict.ContainsKey(i_BlockID))
            {
                s_AIMemoryDict.Add(i_BlockID, i_ValueInMatrix);
            }
        }

        public static void ClearFlippedPairFromAIMatrix(int i_FirstBlockID, int i_SecondBlockID)
        {
            if (s_AIMemoryDict.ContainsKey(i_FirstBlockID))
            {
                s_AIMemoryDict.Remove(i_FirstBlockID);
            }

            if (s_AIMemoryDict.ContainsKey(i_SecondBlockID))
            {
                s_AIMemoryDict.Remove(i_SecondBlockID);
            }
        }

        public static bool IsFindAIPair(out int o_FirstBlockID, out int o_SecondBlockID)
        {
            bool isFindAIPair = false;
            o_FirstBlockID = -1;
            o_SecondBlockID = -1;

            foreach (KeyValuePair<int, char> firstBlockFromMemory in s_AIMemoryDict)
            {
                foreach (KeyValuePair<int, char> secondBlockFromMemory in s_AIMemoryDict)
                {
                    if (!firstBlockFromMemory.Key.Equals(secondBlockFromMemory.Key))
                    {
                        if (firstBlockFromMemory.Value == secondBlockFromMemory.Value)
                        {
                            o_FirstBlockID = firstBlockFromMemory.Key;
                            o_SecondBlockID = secondBlockFromMemory.Key;

                            isFindAIPair = true;
                        }
                    }
                }
            }

            return isFindAIPair;
        }

        public static bool ComputerTurn(ref MemoryGameBoard io_GameBoard, out List<int> io_FlippedBlockID)
        {
            Random randomIndexNumber = new Random();
            int randomRow;
            int randomColumn;
            int firstAIPairBlockID;
            int secondAIPairBlockID;
            int numOfFlips = 0;
            int numOfRows = io_GameBoard.NumberOfRows;
            int numOfColumns = io_GameBoard.NumberOfColumns;
            bool isComputerTurn;

            io_FlippedBlockID = new List<int>();

            do
            {
                if (!IsFindAIPair(out firstAIPairBlockID, out secondAIPairBlockID))
                {
                    randomRow = randomIndexNumber.Next(numOfRows);
                    randomColumn = randomIndexNumber.Next(numOfColumns);
                    if (IsAnUnflippedBlock(ref io_GameBoard, (randomRow * 10) + randomColumn))
                    {
                        io_FlippedBlockID.Add((randomRow * 10) + randomColumn);
                        io_GameBoard.FlipOrUnflipBlock(io_FlippedBlockID[numOfFlips], true);
                        UpdateAIDictionary(io_FlippedBlockID[0], io_GameBoard.MatrixGameBoard[randomRow, randomColumn]);
                        numOfFlips++;
                    }
                }
                else
                {
                    io_FlippedBlockID.Clear();
                    io_FlippedBlockID.Add(firstAIPairBlockID);
                    io_FlippedBlockID.Add(secondAIPairBlockID);
                    io_GameBoard.FlipOrUnflipBlock(io_FlippedBlockID[0], true);
                    io_GameBoard.FlipOrUnflipBlock(io_FlippedBlockID[1], true);
                    numOfFlips = 2;
                }
            }
            while (numOfFlips < 2);

            if (!IsGoodPair(io_GameBoard, io_FlippedBlockID[0], io_FlippedBlockID[1]))
            {
                io_GameBoard.FlipOrUnflipBlock(io_FlippedBlockID[0], false);
                io_GameBoard.FlipOrUnflipBlock(io_FlippedBlockID[1], false);

                isComputerTurn = false;
            }
            else
            {
                ClearFlippedPairFromAIMatrix(io_FlippedBlockID[0], io_FlippedBlockID[1]);
                s_SecondPlayer.UpdateScore();
                isComputerTurn = true;
            }
            
            if(io_GameBoard.IsAllBlocksFlipped)
            {
                isComputerTurn = false;
            }

            return isComputerTurn;
        }

        public static bool IsGoodPair(MemoryGameBoard i_GameBoard, int i_FirstBlockID, int i_SecondBlockID)
        {
            return i_GameBoard.MatrixGameBoard[i_FirstBlockID / 10, i_FirstBlockID % 10] == i_GameBoard.MatrixGameBoard[i_SecondBlockID / 10, i_SecondBlockID % 10];
        }

        public static bool IsAnUnflippedBlock(ref MemoryGameBoard io_GameBoard, int i_BlockID)
        {
            return !io_GameBoard.MatrixFlippedBlocks[i_BlockID / 10, i_BlockID % 10];
        }

        public static StringBuilder GetGameResult()
        {
            StringBuilder resultOutput = new StringBuilder();
            string firstPlayerName = s_FirstPlayer.GetName;
            string secondPlayerName = s_SecondPlayer.GetName;
            int firstPlayerScore = s_FirstPlayer.GetScore;
            int secondPlayerScore = s_SecondPlayer.GetScore;

            if (firstPlayerScore > secondPlayerScore)
            {
                resultOutput.Append(string.Format("{0} wins! {1}", firstPlayerName, Environment.NewLine));
            }
            else if (firstPlayerScore < secondPlayerScore)
            {
                resultOutput.Append(string.Format("{0} wins! {1}", secondPlayerName, Environment.NewLine));
            }
            else
            {
                resultOutput.Append(string.Format("Tie! {0}", Environment.NewLine));
            }

            resultOutput.Append(string.Format("The scores are: {0} - {1}, {2} - {3}{4}", firstPlayerName, firstPlayerScore, secondPlayerName, secondPlayerScore, Environment.NewLine));
            InitiateAIDictionary();
            CreatePlayers(firstPlayerName, secondPlayerName);

            return resultOutput;
        }
    }
}
