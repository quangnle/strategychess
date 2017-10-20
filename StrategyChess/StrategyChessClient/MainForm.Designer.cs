namespace StrategyChessClient
{
    partial class MainForm
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
            this.pPlayer = new StrategyChessClient.Controls.CustomPanel();
            this.pBoard = new StrategyChessClient.Controls.CustomPanel();
            this.SuspendLayout();
            // 
            // pPlayer
            // 
            this.pPlayer.BackColor = System.Drawing.Color.White;
            this.pPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPlayer.Location = new System.Drawing.Point(701, 0);
            this.pPlayer.Name = "pPlayer";
            this.pPlayer.Size = new System.Drawing.Size(307, 701);
            this.pPlayer.TabIndex = 0;
            // 
            // pBoard
            // 
            this.pBoard.BackColor = System.Drawing.Color.White;
            this.pBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.pBoard.Location = new System.Drawing.Point(0, 0);
            this.pBoard.Name = "pBoard";
            this.pBoard.Size = new System.Drawing.Size(701, 701);
            this.pBoard.TabIndex = 1;
            this.pBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pBoard_Paint);
            this.pBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoard_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 701);
            this.Controls.Add(this.pPlayer);
            this.Controls.Add(this.pBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Strategy Chess";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CustomPanel pPlayer;
        private Controls.CustomPanel pBoard;
    }
}

