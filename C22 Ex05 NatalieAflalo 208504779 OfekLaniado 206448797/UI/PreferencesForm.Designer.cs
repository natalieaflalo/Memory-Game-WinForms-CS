
namespace UI
{
    partial class PreferencesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.firstPlayerNameLabel = new System.Windows.Forms.Label();
            this.secondPlayerNameLabel = new System.Windows.Forms.Label();
            this.secondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.againstAFriendButton = new System.Windows.Forms.Button();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.sizeOptionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstPlayerNameTextBox
            // 
            this.firstPlayerNameTextBox.Location = new System.Drawing.Point(122, 12);
            this.firstPlayerNameTextBox.Name = "firstPlayerNameTextBox";
            this.firstPlayerNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstPlayerNameTextBox.TabIndex = 0;
            // 
            // firstPlayerNameLabel
            // 
            this.firstPlayerNameLabel.AutoSize = true;
            this.firstPlayerNameLabel.Location = new System.Drawing.Point(12, 16);
            this.firstPlayerNameLabel.Name = "firstPlayerNameLabel";
            this.firstPlayerNameLabel.Size = new System.Drawing.Size(92, 13);
            this.firstPlayerNameLabel.TabIndex = 1;
            this.firstPlayerNameLabel.Text = "First Player Name:";
            // 
            // secondPlayerNameLabel
            // 
            this.secondPlayerNameLabel.AutoSize = true;
            this.secondPlayerNameLabel.Location = new System.Drawing.Point(12, 41);
            this.secondPlayerNameLabel.Name = "secondPlayerNameLabel";
            this.secondPlayerNameLabel.Size = new System.Drawing.Size(110, 13);
            this.secondPlayerNameLabel.TabIndex = 2;
            this.secondPlayerNameLabel.Text = "Second Player Name:";
            // 
            // secondPlayerNameTextBox
            // 
            this.secondPlayerNameTextBox.Enabled = false;
            this.secondPlayerNameTextBox.Location = new System.Drawing.Point(122, 39);
            this.secondPlayerNameTextBox.Name = "secondPlayerNameTextBox";
            this.secondPlayerNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.secondPlayerNameTextBox.TabIndex = 3;
            this.secondPlayerNameTextBox.Text = "- computer -";
            // 
            // againstAFriendButton
            // 
            this.againstAFriendButton.Location = new System.Drawing.Point(229, 38);
            this.againstAFriendButton.Name = "againstAFriendButton";
            this.againstAFriendButton.Size = new System.Drawing.Size(118, 23);
            this.againstAFriendButton.TabIndex = 4;
            this.againstAFriendButton.Text = "Against A Friend";
            this.againstAFriendButton.UseVisualStyleBackColor = true;
            this.againstAFriendButton.Click += new System.EventHandler(this.againstAFriendButton_Click);
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Location = new System.Drawing.Point(12, 74);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(61, 13);
            this.boardSizeLabel.TabIndex = 5;
            this.boardSizeLabel.Text = "Board Size:";
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.LimeGreen;
            this.startButton.Location = new System.Drawing.Point(272, 153);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // sizeOptionsButton
            // 
            this.sizeOptionsButton.BackColor = System.Drawing.Color.MediumPurple;
            this.sizeOptionsButton.Location = new System.Drawing.Point(12, 90);
            this.sizeOptionsButton.Name = "sizeOptionsButton";
            this.sizeOptionsButton.Size = new System.Drawing.Size(137, 86);
            this.sizeOptionsButton.TabIndex = 7;
            this.sizeOptionsButton.Text = "4 X 4";
            this.sizeOptionsButton.UseVisualStyleBackColor = false;
            this.sizeOptionsButton.Click += new System.EventHandler(this.sizeOptionsButton_Click);
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 183);
            this.Controls.Add(this.sizeOptionsButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.boardSizeLabel);
            this.Controls.Add(this.againstAFriendButton);
            this.Controls.Add(this.secondPlayerNameTextBox);
            this.Controls.Add(this.secondPlayerNameLabel);
            this.Controls.Add(this.firstPlayerNameLabel);
            this.Controls.Add(this.firstPlayerNameTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Memory Game - Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PreferencesForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstPlayerNameTextBox;
        private System.Windows.Forms.Label firstPlayerNameLabel;
        private System.Windows.Forms.Label secondPlayerNameLabel;
        private System.Windows.Forms.TextBox secondPlayerNameTextBox;
        private System.Windows.Forms.Button againstAFriendButton;
        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button sizeOptionsButton;
    }
}