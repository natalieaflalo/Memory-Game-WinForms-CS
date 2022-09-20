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
    public partial class PreferencesForm : Form
    {
        private readonly List<string> r_sizeOptionsList = new List<string>(new string[] { "4 X 4", "4 X 5", "4 X 6", "5 X 4", "5 X 6", "6 X 4", "6 X 5", "6 X 6" });

        public PreferencesForm()
        {
            InitializeComponent();
            secondPlayerNameTextBox.GotFocus += removeTextFromTextBox;
            secondPlayerNameTextBox.LostFocus += AddTextFromTextBox;
        }

        private void removeTextFromTextBox(object sender, EventArgs e)
        {
            TextBox secondPlayerSettings = sender as TextBox;

            if (secondPlayerSettings.Text == "- computer -")
            {
                secondPlayerSettings.Text = string.Empty;
            }
        }

        public void AddTextFromTextBox(object sender, EventArgs e)
        {
            TextBox secondPlayerSettings = sender as TextBox;

            if (string.IsNullOrWhiteSpace(secondPlayerSettings.Text))
            {
                secondPlayerSettings.Text = "- computer -";
            }   
        }

        private void againstAFriendButton_Click(object sender, EventArgs e)
        {
            Button secondPlayerSettings = sender as Button;

            if (secondPlayerSettings.Text == "Against A Friend")
            {
                secondPlayerNameTextBox.Enabled = true;
                secondPlayerSettings.Text = "Against Computer";
            }
            else
            {
                secondPlayerNameTextBox.Enabled = false;
                secondPlayerSettings.Text = "Against A Friend";
            }
        }

        private void sizeOptionsButton_Click(object sender, EventArgs e)
        {
            Button sizeOptions = sender as Button;

            if(r_sizeOptionsList.IndexOf(sizeOptions.Text) != 7)
            {
                sizeOptions.Text = r_sizeOptionsList[r_sizeOptionsList.IndexOf(sizeOptions.Text) + 1];
            }
            else
            {
                sizeOptions.Text = r_sizeOptionsList[0];
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            openMemoryGameForm();
        }

        private void PreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            openMemoryGameForm();
        }

        private void openMemoryGameForm()
        {
            this.Hide();
            string sizeString = string.Format("{0}{1}", sizeOptionsButton.Text[0], sizeOptionsButton.Text[4]);
            int size = int.Parse(sizeString);

            MemoryGameForm memoryGameForm = new MemoryGameForm(size / 10, size % 10);
            memoryGameForm.ShowDialog();
        }
    }
}
