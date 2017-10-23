namespace StrategyChessClient.Controls
{
    partial class TeamCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamCtrl));
            this.lbTeam = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReady = new System.Windows.Forms.Button();
            this.lbAmpusher = new System.Windows.Forms.Label();
            this.lbRanger = new System.Windows.Forms.Label();
            this.lbTanker = new System.Windows.Forms.Label();
            this.lbCamp = new System.Windows.Forms.Label();
            this.picTurn = new System.Windows.Forms.PictureBox();
            this.picCamp = new StrategyChessClient.Controls.CustomPictureBox();
            this.picTanker = new StrategyChessClient.Controls.CustomPictureBox();
            this.picRanger = new StrategyChessClient.Controls.CustomPictureBox();
            this.picAmbusher = new StrategyChessClient.Controls.CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTanker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRanger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAmbusher)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTeam
            // 
            this.lbTeam.BackColor = System.Drawing.Color.Red;
            this.lbTeam.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeam.ForeColor = System.Drawing.Color.White;
            this.lbTeam.Location = new System.Drawing.Point(0, 0);
            this.lbTeam.Name = "lbTeam";
            this.lbTeam.Size = new System.Drawing.Size(313, 35);
            this.lbTeam.TabIndex = 1;
            this.lbTeam.Text = "Competitor";
            this.lbTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(49, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(234, 20);
            this.txtName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name:";
            // 
            // btnReady
            // 
            this.btnReady.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReady.ForeColor = System.Drawing.Color.White;
            this.btnReady.Location = new System.Drawing.Point(0, 331);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(313, 35);
            this.btnReady.TabIndex = 12;
            this.btnReady.Text = "Waiting";
            this.btnReady.UseVisualStyleBackColor = true;
            this.btnReady.Visible = false;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // lbAmpusher
            // 
            this.lbAmpusher.AutoSize = true;
            this.lbAmpusher.Location = new System.Drawing.Point(186, 136);
            this.lbAmpusher.Name = "lbAmpusher";
            this.lbAmpusher.Size = new System.Drawing.Size(21, 13);
            this.lbAmpusher.TabIndex = 19;
            this.lbAmpusher.Text = "x 0";
            // 
            // lbRanger
            // 
            this.lbRanger.AutoSize = true;
            this.lbRanger.Location = new System.Drawing.Point(121, 136);
            this.lbRanger.Name = "lbRanger";
            this.lbRanger.Size = new System.Drawing.Size(21, 13);
            this.lbRanger.TabIndex = 20;
            this.lbRanger.Text = "x 0";
            // 
            // lbTanker
            // 
            this.lbTanker.AutoSize = true;
            this.lbTanker.Location = new System.Drawing.Point(60, 136);
            this.lbTanker.Name = "lbTanker";
            this.lbTanker.Size = new System.Drawing.Size(21, 13);
            this.lbTanker.TabIndex = 21;
            this.lbTanker.Text = "x 0";
            // 
            // lbCamp
            // 
            this.lbCamp.AutoSize = true;
            this.lbCamp.Location = new System.Drawing.Point(249, 136);
            this.lbCamp.Name = "lbCamp";
            this.lbCamp.Size = new System.Drawing.Size(21, 13);
            this.lbCamp.TabIndex = 22;
            this.lbCamp.Text = "x 0";
            // 
            // picTurn
            // 
            this.picTurn.Image = global::StrategyChessClient.Properties.Resources.attack;
            this.picTurn.Location = new System.Drawing.Point(132, 171);
            this.picTurn.Name = "picTurn";
            this.picTurn.Size = new System.Drawing.Size(48, 48);
            this.picTurn.TabIndex = 23;
            this.picTurn.TabStop = false;
            this.picTurn.Visible = false;
            // 
            // picCamp
            // 
            this.picCamp.AllowSelect = true;
            this.picCamp.BackColor = System.Drawing.Color.White;
            this.picCamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCamp.Image = ((System.Drawing.Image)(resources.GetObject("picCamp.Image")));
            this.picCamp.IsSelected = false;
            this.picCamp.Location = new System.Drawing.Point(238, 87);
            this.picCamp.Name = "picCamp";
            this.picCamp.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(75)))), ((int)(((byte)(157)))));
            this.picCamp.Size = new System.Drawing.Size(45, 45);
            this.picCamp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picCamp.TabIndex = 18;
            this.picCamp.TabStop = false;
            // 
            // picTanker
            // 
            this.picTanker.AllowSelect = true;
            this.picTanker.BackColor = System.Drawing.Color.White;
            this.picTanker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTanker.Image = ((System.Drawing.Image)(resources.GetObject("picTanker.Image")));
            this.picTanker.IsSelected = false;
            this.picTanker.Location = new System.Drawing.Point(49, 87);
            this.picTanker.Name = "picTanker";
            this.picTanker.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(75)))), ((int)(((byte)(157)))));
            this.picTanker.Size = new System.Drawing.Size(45, 45);
            this.picTanker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picTanker.TabIndex = 17;
            this.picTanker.TabStop = false;
            // 
            // picRanger
            // 
            this.picRanger.AllowSelect = true;
            this.picRanger.BackColor = System.Drawing.Color.White;
            this.picRanger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRanger.Image = ((System.Drawing.Image)(resources.GetObject("picRanger.Image")));
            this.picRanger.IsSelected = false;
            this.picRanger.Location = new System.Drawing.Point(112, 87);
            this.picRanger.Name = "picRanger";
            this.picRanger.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(75)))), ((int)(((byte)(157)))));
            this.picRanger.Size = new System.Drawing.Size(45, 45);
            this.picRanger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picRanger.TabIndex = 16;
            this.picRanger.TabStop = false;
            // 
            // picAmbusher
            // 
            this.picAmbusher.AllowSelect = true;
            this.picAmbusher.BackColor = System.Drawing.Color.White;
            this.picAmbusher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAmbusher.Image = ((System.Drawing.Image)(resources.GetObject("picAmbusher.Image")));
            this.picAmbusher.IsSelected = false;
            this.picAmbusher.Location = new System.Drawing.Point(175, 87);
            this.picAmbusher.Name = "picAmbusher";
            this.picAmbusher.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(75)))), ((int)(((byte)(157)))));
            this.picAmbusher.Size = new System.Drawing.Size(45, 45);
            this.picAmbusher.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAmbusher.TabIndex = 15;
            this.picAmbusher.TabStop = false;
            // 
            // TeamCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picTurn);
            this.Controls.Add(this.lbCamp);
            this.Controls.Add(this.lbTanker);
            this.Controls.Add(this.lbRanger);
            this.Controls.Add(this.lbAmpusher);
            this.Controls.Add(this.picCamp);
            this.Controls.Add(this.picTanker);
            this.Controls.Add(this.picRanger);
            this.Controls.Add(this.picAmbusher);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTeam);
            this.Name = "TeamCtrl";
            this.Size = new System.Drawing.Size(313, 366);
            this.Load += new System.EventHandler(this.TeamCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTanker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRanger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAmbusher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTeam;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReady;
        private CustomPictureBox picCamp;
        private CustomPictureBox picTanker;
        private CustomPictureBox picRanger;
        private CustomPictureBox picAmbusher;
        private System.Windows.Forms.Label lbAmpusher;
        private System.Windows.Forms.Label lbRanger;
        private System.Windows.Forms.Label lbTanker;
        private System.Windows.Forms.Label lbCamp;
        private System.Windows.Forms.PictureBox picTurn;
    }
}
