using System;
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
        private readonly MemoryGameBoard r_memoryGameBoard;
        private bool m_IsFirstPlayerTurn = true;

        public int RowsAmount { get => this.r_RowsAmount; }

        public int ColumnsAmount { get => this.r_ColumnsAmount; }

        public MemoryGameForm(int i_RowsAmount, int i_ColumnsAmount, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            r_RowsAmount = i_RowsAmount;
            r_ColumnsAmount = i_ColumnsAmount;
            r_ButtonMatrix = new Button[r_RowsAmount, r_ColumnsAmount];
            r_memoryGameBoard = new MemoryGameBoard(r_RowsAmount, r_ColumnsAmount);
            i_FirstPlayerName = i_FirstPlayerName == string.Empty ? "Player 1" : i_FirstPlayerName;
            i_SecondPlayerName = i_SecondPlayerName == string.Empty ? "Player 2" : i_SecondPlayerName;
            LogicForUI.CreatePlayers(i_FirstPlayerName, i_SecondPlayerName);
            InitializeComponent();
            firstPlayerScoreLabel.Text = updatePlayerLabel(i_FirstPlayerName, 0);
            secondPlayerScoreLabel.Text = updatePlayerLabel(i_SecondPlayerName, 0);
            updateCurrentPlayerLabel(firstPlayerScoreLabel.BackColor, i_FirstPlayerName);
        }

        private void MemoryGameForm_Load(object sender, EventArgs e)
        {
            char[,] randomMatrix = r_memoryGameBoard.MatrixGameBoard;

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

        private void turnManager()
        {

            if(m_IsFirstPlayerTurn)
            {
                playerTurn(LogicForUI.FirstPlayer);
            }
            else
            {
                if(LogicForUI.SecondPlayer.GetName == "Computer")
                {
                    computerTurn(LogicForUI.SecondPlayer);
                }
                else
                {
                    playerTurn(LogicForUI.SecondPlayer);
                }
            }
        }

        private string updatePlayerLabel(string i_PlayerName, int i_PlayerScore)
        {
            return string.Format("{0}: {1}", i_PlayerName, i_PlayerScore);
        }

        private void playerTurn(Player i_Player)
        {
            if(m_IsFirstPlayerTurn)
            {
                firstPlayerScoreLabel.Text = updatePlayerLabel(i_Player.GetName, i_Player.GetScore);
            }
            else
            {
                secondPlayerScoreLabel.Text = updatePlayerLabel(i_Player.GetName, i_Player.GetScore);
            }
        }

        private void computerTurn(Player i_ComputerPlayer)
        {
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

            if(memoryCard.Text == memoryCard.Tag.ToString())
            {
                unflipMemoryCardButton(memoryCard);
            }
            else
            {
                memoryCard.Text = memoryCard.Tag.ToString();
                memoryCard.BackColor = m_IsFirstPlayerTurn ? Color.LightGreen : Color.MediumSlateBlue;
            }
        }

        private void unflipMemoryCardButton(Button i_MemoryCard)
        {
            i_MemoryCard.Text = string.Empty;
            i_MemoryCard.BackColor = DefaultBackColor;
        }

        private void MemoryGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string caption = "Game Over!";
            StringBuilder message = new StringBuilder();
            message.Append(LogicForUI.GetGameResult());
            message.Append("Would you like to play another game?");
            var result = MessageBox.Show(message.ToString(), caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                MemoryGameForm_Load(sender, e);
            }
        }
    }
}
