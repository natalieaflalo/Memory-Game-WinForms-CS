using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MemoryGameForm : Form
    {
        private readonly int r_RowsAmount;
        private readonly int r_ColumnsAmount;

        public int RowsAmount { get => this.r_RowsAmount; }

        public int ColumnsAmount { get => this.r_ColumnsAmount; }

        public MemoryGameForm(int i_RowsAmount, int i_ColumnsAmount)
        {
            r_RowsAmount = i_RowsAmount;
            r_ColumnsAmount = i_ColumnsAmount;
            InitializeComponent();
        }

        private void MemoryGameForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < r_RowsAmount; i++)
            {
                for (int j = 0; j < r_ColumnsAmount; j++)
                {
                    Button memoryCardButton = new Button();

                    memoryCardButton.Size = new Size(90, 90);
                    memoryCardButton.Location = new Point(15 + j * 100, 15 + i * 100);
                    this.Controls.Add(memoryCardButton);
                }
            }

            currentPlayerLabel.Location = new Point(15,20+ r_RowsAmount*100);
            firstPlayerScoreLabel.Location = new Point(15, currentPlayerLabel.Location.Y + 25);
            secondPlayerScoreLabel.Location = new Point(15, firstPlayerScoreLabel.Location.Y + 25);
            this.ClientSize = new Size(r_ColumnsAmount * 100 + 20, secondPlayerScoreLabel.Location.Y + 30);
        }
    }
}
