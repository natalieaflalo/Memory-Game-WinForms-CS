using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            LogicForUI.CreatePlayers(i_FirstPlayerName, i_SecondPlayerName);

            InitializeComponent();
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
                    memoryCardButton.Click += new EventHandler(this.memoryCardButton_Click);
                    this.Controls.Add(memoryCardButton);
                    r_ButtonMatrix[i, j] = memoryCardButton;
                }
            }

            currentPlayerLabel.Location = new Point(15,20+ r_RowsAmount*100);
            firstPlayerScoreLabel.Location = new Point(15, currentPlayerLabel.Location.Y + 25);
            secondPlayerScoreLabel.Location = new Point(15, firstPlayerScoreLabel.Location.Y + 25);
            this.ClientSize = new Size(r_ColumnsAmount * 100 + 20, secondPlayerScoreLabel.Location.Y + 30);
        }

        private void turnManager()
        {

        }

        private void playerTurn()
        {

        }

        private void computerTurn()
        {

        }

        private void memoryCardButton_Click(object sender, EventArgs e)
        {
            Button memoryCard = sender as Button;

            memoryCard.Text = memoryCard.Tag.ToString();
            memoryCard.BackColor = m_IsFirstPlayerTurn ? Color.LightGreen : Color.MediumSlateBlue;
        }

        private void unflipMemoryCardButton(object sender, EventArgs e)
        {
            Button memoryCard = sender as Button;

            memoryCard.Text = string.Empty;
            memoryCard.BackColor = DefaultBackColor;
        }
    }
}
