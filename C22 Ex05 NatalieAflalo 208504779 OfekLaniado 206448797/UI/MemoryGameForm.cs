using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Logic;

namespace UI
{
    public partial class MemoryGameForm : Form
    {
        private readonly int r_RowsAmount;
        private readonly int r_ColumnsAmount;
        private readonly Button[,] r_ButtonMatrix;
        private MemoryGameBoard m_MemoryGameBoard;
        private bool m_IsFirstPlayerTurn = true;
        private readonly bool r_IsPlayingAgainstComputer;
        private readonly List<Button> r_PlayerTurnButtons;

        public int RowsAmount { get => this.r_RowsAmount; }

        public int ColumnsAmount { get => this.r_ColumnsAmount; }

        public MemoryGameForm(int i_RowsAmount, int i_ColumnsAmount, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            r_RowsAmount = i_RowsAmount;
            r_ColumnsAmount = i_ColumnsAmount;
            r_ButtonMatrix = new Button[r_RowsAmount, r_ColumnsAmount];
            m_MemoryGameBoard = new MemoryGameBoard(r_RowsAmount, r_ColumnsAmount);
            r_PlayerTurnButtons = new List<Button>();
            i_FirstPlayerName = i_FirstPlayerName == string.Empty ? "Player 1" : i_FirstPlayerName;
            i_SecondPlayerName = i_SecondPlayerName == string.Empty ? "Player 2" : i_SecondPlayerName;
            r_IsPlayingAgainstComputer = i_SecondPlayerName == "Computer";
            LogicForUI.CreatePlayers(i_FirstPlayerName, i_SecondPlayerName);
            LogicForUI.InitiateAIDictionary();
            InitializeComponent();
            firstPlayerScoreLabel.Text = updatePlayerLabel(i_FirstPlayerName, 0);
            secondPlayerScoreLabel.Text = updatePlayerLabel(i_SecondPlayerName, 0);
            updateCurrentPlayerLabel(firstPlayerScoreLabel.BackColor, i_FirstPlayerName);
        }

        private void MemoryGameForm_Load(object sender, EventArgs e)
        {
            char[,] randomMatrix = m_MemoryGameBoard.MatrixGameBoard;

            for (int i = 0; i < r_RowsAmount; i++)
            {
                for (int j = 0; j < r_ColumnsAmount; j++)
                {
                    Button memoryCardButton = new Button();

                    memoryCardButton.Size = new Size(90, 90);
                    memoryCardButton.Location = new Point(15 + j * 100, 15 + i * 100);
                    memoryCardButton.Tag = randomMatrix[i, j];
                    memoryCardButton.Click += new EventHandler(memoryCardButton_Click);
                    Controls.Add(memoryCardButton);
                    r_ButtonMatrix[i, j] = memoryCardButton;
                }
            }

            currentPlayerLabel.Location = new Point(15,20+ r_RowsAmount*100);
            firstPlayerScoreLabel.Location = new Point(15, currentPlayerLabel.Location.Y + 25);
            secondPlayerScoreLabel.Location = new Point(15, firstPlayerScoreLabel.Location.Y + 25);
            ClientSize = new Size(r_ColumnsAmount * 100 + 20, secondPlayerScoreLabel.Location.Y + 30);
        }

        private void initiateAnotherGame()
        {
            m_MemoryGameBoard = new MemoryGameBoard(r_RowsAmount, r_ColumnsAmount);
            firstPlayerScoreLabel.Text = updatePlayerLabel(LogicForUI.FirstPlayer.GetName, 0);
            secondPlayerScoreLabel.Text = updatePlayerLabel(LogicForUI.SecondPlayer.GetName, 0);
            updateCurrentPlayerLabel(firstPlayerScoreLabel.BackColor, LogicForUI.FirstPlayer.GetName);
            m_IsFirstPlayerTurn = true;

            char[,] randomMatrix = m_MemoryGameBoard.MatrixGameBoard;

            for (int i = 0; i < r_RowsAmount; i++)
            {
                for (int j = 0; j < r_ColumnsAmount; j++)
                {
                    r_ButtonMatrix[i, j].Tag = randomMatrix[i, j];
                    unflipMemoryCardButton(r_ButtonMatrix[i, j]);
                }
            }
        }

        private void turnManager(Button i_MemoryCard)
        {
            if(m_IsFirstPlayerTurn)
            {
                playerTurn(LogicForUI.FirstPlayer, i_MemoryCard);
                if (r_IsPlayingAgainstComputer && !m_IsFirstPlayerTurn)
                {
                    computerTurn(LogicForUI.SecondPlayer);
                    m_IsFirstPlayerTurn = true;
                    updateCurrentPlayerLabel(firstPlayerScoreLabel.BackColor, LogicForUI.FirstPlayer.GetName);
                }
            }
            else
            {
                playerTurn(LogicForUI.SecondPlayer, i_MemoryCard);
            }

            if(m_MemoryGameBoard.IsAllBlocksFlipped)
            {
                finishGame();
            }
        }

        private string updatePlayerLabel(string i_PlayerName, int i_PlayerScore)
        {
            return string.Format("{0}: {1}", i_PlayerName, i_PlayerScore);
        }

        private void playerTurn(Player i_Player, Button i_MemoryCard)
        {
            if (LogicForUI.IsAnUnflippedBlock(ref m_MemoryGameBoard, getButtonMatrixIndex(i_MemoryCard)))
            {
                m_MemoryGameBoard.FlipOrUnflipBlock(getButtonMatrixIndex(i_MemoryCard), true);
                r_PlayerTurnButtons.Add(i_MemoryCard);
                i_MemoryCard.Text = i_MemoryCard.Tag.ToString();
                LogicForUI.UpdateAIDictionary(getButtonMatrixIndex(i_MemoryCard), char.Parse(i_MemoryCard.Text));
                i_MemoryCard.BackColor = m_IsFirstPlayerTurn ? firstPlayerScoreLabel.BackColor : secondPlayerScoreLabel.BackColor;
            }

            if (r_PlayerTurnButtons.Count == 2) 
            {
                if (LogicForUI.IsGoodPair(m_MemoryGameBoard, getButtonMatrixIndex(r_PlayerTurnButtons[0]), getButtonMatrixIndex(r_PlayerTurnButtons[1])))
                {
                    LogicForUI.ClearFlippedPairFromAIMatrix(getButtonMatrixIndex(r_PlayerTurnButtons[0]), getButtonMatrixIndex(r_PlayerTurnButtons[1]));
                    if (m_IsFirstPlayerTurn)
                    {
                        LogicForUI.FirstPlayer.UpdateScore();
                        firstPlayerScoreLabel.Text = updatePlayerLabel(i_Player.GetName, i_Player.GetScore);
                    }
                    else
                    {
                        LogicForUI.SecondPlayer.UpdateScore();
                        secondPlayerScoreLabel.Text = updatePlayerLabel(i_Player.GetName, i_Player.GetScore);
                    }
                }
                else
                {
                    wait(600);
                    foreach (Button memoryCard in r_PlayerTurnButtons)
                    {
                        m_MemoryGameBoard.FlipOrUnflipBlock(getButtonMatrixIndex(memoryCard), false);
                        unflipMemoryCardButton(memoryCard);
                    }

                    Color nextPlayerColor = m_IsFirstPlayerTurn ? secondPlayerScoreLabel.BackColor : firstPlayerScoreLabel.BackColor;
                    string nextPlayerName = m_IsFirstPlayerTurn ? LogicForUI.SecondPlayer.GetName : LogicForUI.FirstPlayer.GetName;
                    
                    updateCurrentPlayerLabel(nextPlayerColor, nextPlayerName);
                    m_IsFirstPlayerTurn = !m_IsFirstPlayerTurn;
                }

                r_PlayerTurnButtons.Clear();
            }
        }

        private void computerTurn(Player i_ComputerPlayer)
        {
            bool isComputerTurn = true;
            List<int> memoryCardsIDToFlip = new List<int>();

            while (isComputerTurn)
            {
                isComputerTurn = LogicForUI.ComputerTurn(ref m_MemoryGameBoard, out memoryCardsIDToFlip);
                foreach(int cardID in memoryCardsIDToFlip)
                {
                    flipMemoryCardButton(r_ButtonMatrix[cardID / 10, cardID % 10], secondPlayerScoreLabel.BackColor);
                    wait(1000);
                }
                secondPlayerScoreLabel.Text = updatePlayerLabel(i_ComputerPlayer.GetName, i_ComputerPlayer.GetScore);
            }

            foreach (int cardID in memoryCardsIDToFlip)
            {
                unflipMemoryCardButton(r_ButtonMatrix[cardID / 10, cardID % 10]);
            }
            
            secondPlayerScoreLabel.Text = updatePlayerLabel(i_ComputerPlayer.GetName, i_ComputerPlayer.GetScore);
        }

        private void updateCurrentPlayerLabel(Color i_LabelBackColor, string i_CurrentPlayerName)
        {
            currentPlayerLabel.BackColor = i_LabelBackColor;
            currentPlayerLabel.Text = string.Format("Current Player: {0}", i_CurrentPlayerName);
        }

        private void memoryCardButton_Click(object sender, EventArgs e)
        {
            Button memoryCard = sender as Button;

            turnManager(memoryCard);
        }

        private int getButtonMatrixIndex(Button i_ButtonToFind)
        {
            int indexResult = 0;
            for (int i = 0; i < r_RowsAmount; ++i)
            {
                for (int j = 0; j < r_ColumnsAmount; ++j)
                {
                    if (r_ButtonMatrix[i, j].Equals(i_ButtonToFind))
                        indexResult = i * 10 + j;
                }
            }

            return indexResult;
        }

        private void unflipMemoryCardButton(Button i_MemoryCard)
        {
            i_MemoryCard.Text = string.Empty;
            i_MemoryCard.BackColor = DefaultBackColor;
        }

        private void flipMemoryCardButton(Button i_MemoryCard, Color i_PlayerColor)
        {
            i_MemoryCard.Text = i_MemoryCard.Tag.ToString();
            i_MemoryCard.BackColor = i_PlayerColor;
        }

        private void finishGame()
        {
            const string caption = "Game Over!";
            StringBuilder message = new StringBuilder();

            message.Append(LogicForUI.GetGameResult());
            message.Append("Would you like to play another game?");

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message.ToString(), caption, buttons);
            if (result == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                initiateAnotherGame();
            }
        }

        private void wait(int milliseconds)
        {
            Timer timer = new Timer();

            timer.Interval = milliseconds;
            timer.Enabled = true;
            timer.Start();

            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer.Stop();
            };

            while (timer.Enabled)
            {
                Application.DoEvents();
            }
        }
    }
}
