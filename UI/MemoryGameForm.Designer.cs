namespace UI
{
    public partial class MemoryGameForm
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
            this.currentPlayerLabel = new System.Windows.Forms.Label();
            this.firstPlayerScoreLabel = new System.Windows.Forms.Label();
            this.secondPlayerScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentPlayerLabel
            // 
            this.currentPlayerLabel.AutoSize = true;
            this.currentPlayerLabel.Location = new System.Drawing.Point(23, 339);
            this.currentPlayerLabel.Name = "currentPlayerLabel";
            this.currentPlayerLabel.Size = new System.Drawing.Size(0, 13);
            this.currentPlayerLabel.TabIndex = 0;
            // 
            // firstPlayerScoreLabel
            // 
            this.firstPlayerScoreLabel.AutoSize = true;
            this.firstPlayerScoreLabel.BackColor = System.Drawing.Color.LightGreen;
            this.firstPlayerScoreLabel.Location = new System.Drawing.Point(23, 371);
            this.firstPlayerScoreLabel.Name = "firstPlayerScoreLabel";
            this.firstPlayerScoreLabel.Size = new System.Drawing.Size(45, 13);
            this.firstPlayerScoreLabel.TabIndex = 1;
            this.firstPlayerScoreLabel.Text = "Player 1";
            // 
            // secondPlayerScoreLabel
            // 
            this.secondPlayerScoreLabel.AutoSize = true;
            this.secondPlayerScoreLabel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.secondPlayerScoreLabel.Location = new System.Drawing.Point(23, 402);
            this.secondPlayerScoreLabel.Name = "secondPlayerScoreLabel";
            this.secondPlayerScoreLabel.Size = new System.Drawing.Size(45, 13);
            this.secondPlayerScoreLabel.TabIndex = 2;
            this.secondPlayerScoreLabel.Text = "Player 2";
            // 
            // MemoryGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.secondPlayerScoreLabel);
            this.Controls.Add(this.firstPlayerScoreLabel);
            this.Controls.Add(this.currentPlayerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemoryGameForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Memory Game";
            this.Load += new System.EventHandler(this.MemoryGameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentPlayerLabel;
        private System.Windows.Forms.Label firstPlayerScoreLabel;
        private System.Windows.Forms.Label secondPlayerScoreLabel;
    }
}