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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.pPlayer = new StrategyChessClient.Controls.CustomPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customPanel3 = new StrategyChessClient.Controls.CustomPanel();
            this._lowerTeamCtrl = new StrategyChessClient.Controls.TeamCtrl();
            this.customPanel2 = new StrategyChessClient.Controls.CustomPanel();
            this._upperTeamCtrl = new StrategyChessClient.Controls.TeamCtrl();
            this.pGameSetting = new StrategyChessClient.Controls.CustomPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.raPiece1 = new System.Windows.Forms.RadioButton();
            this.raPiece2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.raNetworkMode = new System.Windows.Forms.RadioButton();
            this.raSingleMode = new System.Windows.Forms.RadioButton();
            this.pBoard = new StrategyChessClient.Controls.CustomPanel();
            this.pPlayer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.customPanel3.SuspendLayout();
            this.customPanel2.SuspendLayout();
            this.pGameSetting.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _timer
            // 
            this._timer.Interval = 1000;
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // pPlayer
            // 
            this.pPlayer.BackColor = System.Drawing.Color.White;
            this.pPlayer.Controls.Add(this.tableLayoutPanel1);
            this.pPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPlayer.Location = new System.Drawing.Point(701, 0);
            this.pPlayer.Name = "pPlayer";
            this.pPlayer.Size = new System.Drawing.Size(307, 701);
            this.pPlayer.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.customPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.customPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pGameSetting, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 701);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // customPanel3
            // 
            this.customPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel3.Controls.Add(this._lowerTeamCtrl);
            this.customPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel3.Location = new System.Drawing.Point(3, 405);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(301, 293);
            this.customPanel3.TabIndex = 2;
            // 
            // _lowerTeamCtrl
            // 
            this._lowerTeamCtrl.AmbusherCount = 0;
            this._lowerTeamCtrl.AmbusherImage = ((System.Drawing.Bitmap)(resources.GetObject("_lowerTeamCtrl.AmbusherImage")));
            this._lowerTeamCtrl.BackColor = System.Drawing.Color.White;
            this._lowerTeamCtrl.BoardGr = null;
            this._lowerTeamCtrl.CampCount = 0;
            this._lowerTeamCtrl.CampImage = null;
            this._lowerTeamCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lowerTeamCtrl.Location = new System.Drawing.Point(0, 0);
            this._lowerTeamCtrl.MaxCamps = 0;
            this._lowerTeamCtrl.MaxUnits = 0;
            this._lowerTeamCtrl.Name = "_lowerTeamCtrl";
            this._lowerTeamCtrl.RangerCount = 0;
            this._lowerTeamCtrl.RangerImage = null;
            this._lowerTeamCtrl.Size = new System.Drawing.Size(299, 291);
            this._lowerTeamCtrl.TabIndex = 1;
            this._lowerTeamCtrl.TankerCount = 0;
            this._lowerTeamCtrl.TankerImage = null;
            this._lowerTeamCtrl.TeamColor = System.Drawing.Color.Red;
            this._lowerTeamCtrl.TeamName = "";
            // 
            // customPanel2
            // 
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.Controls.Add(this._upperTeamCtrl);
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel2.Location = new System.Drawing.Point(3, 3);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(301, 292);
            this.customPanel2.TabIndex = 1;
            // 
            // _upperTeamCtrl
            // 
            this._upperTeamCtrl.AmbusherCount = 0;
            this._upperTeamCtrl.AmbusherImage = ((System.Drawing.Bitmap)(resources.GetObject("_upperTeamCtrl.AmbusherImage")));
            this._upperTeamCtrl.BackColor = System.Drawing.Color.White;
            this._upperTeamCtrl.BoardGr = null;
            this._upperTeamCtrl.CampCount = 0;
            this._upperTeamCtrl.CampImage = null;
            this._upperTeamCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._upperTeamCtrl.Location = new System.Drawing.Point(0, 0);
            this._upperTeamCtrl.MaxCamps = 0;
            this._upperTeamCtrl.MaxUnits = 0;
            this._upperTeamCtrl.Name = "_upperTeamCtrl";
            this._upperTeamCtrl.RangerCount = 0;
            this._upperTeamCtrl.RangerImage = null;
            this._upperTeamCtrl.Size = new System.Drawing.Size(299, 290);
            this._upperTeamCtrl.TabIndex = 0;
            this._upperTeamCtrl.TankerCount = 0;
            this._upperTeamCtrl.TankerImage = null;
            this._upperTeamCtrl.TeamColor = System.Drawing.Color.Red;
            this._upperTeamCtrl.TeamName = "";
            // 
            // pGameSetting
            // 
            this.pGameSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGameSetting.Controls.Add(this.panel1);
            this.pGameSetting.Controls.Add(this.label3);
            this.pGameSetting.Controls.Add(this.label2);
            this.pGameSetting.Controls.Add(this.lbTime);
            this.pGameSetting.Controls.Add(this.pictureBox1);
            this.pGameSetting.Controls.Add(this.btnStop);
            this.pGameSetting.Controls.Add(this.btnPlay);
            this.pGameSetting.Controls.Add(this.raNetworkMode);
            this.pGameSetting.Controls.Add(this.raSingleMode);
            this.pGameSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGameSetting.Location = new System.Drawing.Point(3, 301);
            this.pGameSetting.Name = "pGameSetting";
            this.pGameSetting.Size = new System.Drawing.Size(301, 98);
            this.pGameSetting.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.raPiece1);
            this.panel1.Controls.Add(this.raPiece2);
            this.panel1.Location = new System.Drawing.Point(106, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 23);
            this.panel1.TabIndex = 11;
            // 
            // raPiece1
            // 
            this.raPiece1.AutoSize = true;
            this.raPiece1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raPiece1.Location = new System.Drawing.Point(3, 3);
            this.raPiece1.Name = "raPiece1";
            this.raPiece1.Size = new System.Drawing.Size(46, 17);
            this.raPiece1.TabIndex = 9;
            this.raPiece1.Text = "Blue";
            this.raPiece1.UseVisualStyleBackColor = true;
            this.raPiece1.CheckedChanged += new System.EventHandler(this.raPiece1_CheckedChanged);
            // 
            // raPiece2
            // 
            this.raPiece2.AutoSize = true;
            this.raPiece2.Checked = true;
            this.raPiece2.Location = new System.Drawing.Point(73, 3);
            this.raPiece2.Name = "raPiece2";
            this.raPiece2.Size = new System.Drawing.Size(54, 17);
            this.raPiece2.TabIndex = 10;
            this.raPiece2.TabStop = true;
            this.raPiece2.Text = "Green";
            this.raPiece2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Chess piece:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mode:";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbTime.Location = new System.Drawing.Point(218, 67);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(63, 15);
            this.lbTime.TabIndex = 6;
            this.lbTime.Text = "00:00:00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(174, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Time");
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(72, 56);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 36);
            this.btnStop.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnStop, "Stop");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Location = new System.Drawing.Point(31, 56);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(36, 36);
            this.btnPlay.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnPlay, "Play");
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // raNetworkMode
            // 
            this.raNetworkMode.AutoSize = true;
            this.raNetworkMode.Location = new System.Drawing.Point(179, 4);
            this.raNetworkMode.Name = "raNetworkMode";
            this.raNetworkMode.Size = new System.Drawing.Size(65, 17);
            this.raNetworkMode.TabIndex = 1;
            this.raNetworkMode.Text = "Network";
            this.raNetworkMode.UseVisualStyleBackColor = true;
            // 
            // raSingleMode
            // 
            this.raSingleMode.AutoSize = true;
            this.raSingleMode.Checked = true;
            this.raSingleMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raSingleMode.ForeColor = System.Drawing.Color.Black;
            this.raSingleMode.Location = new System.Drawing.Point(109, 4);
            this.raSingleMode.Name = "raSingleMode";
            this.raSingleMode.Size = new System.Drawing.Size(54, 17);
            this.raSingleMode.TabIndex = 0;
            this.raSingleMode.TabStop = true;
            this.raSingleMode.Text = "Single";
            this.raSingleMode.UseVisualStyleBackColor = true;
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
            this.pBoard.DoubleClick += new System.EventHandler(this.pBoard_DoubleClick);
            this.pBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoard_MouseDown);
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
            this.pPlayer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.customPanel3.ResumeLayout(false);
            this.customPanel2.ResumeLayout(false);
            this.pGameSetting.ResumeLayout(false);
            this.pGameSetting.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CustomPanel pPlayer;
        private Controls.CustomPanel pBoard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.CustomPanel customPanel3;
        private Controls.CustomPanel customPanel2;
        private Controls.CustomPanel pGameSetting;
        private System.Windows.Forms.RadioButton raNetworkMode;
        private System.Windows.Forms.RadioButton raSingleMode;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton raPiece2;
        private System.Windows.Forms.RadioButton raPiece1;
        private System.Windows.Forms.Panel panel1;
        private Controls.TeamCtrl _lowerTeamCtrl;
        private Controls.TeamCtrl _upperTeamCtrl;
        private System.Windows.Forms.Timer _timer;
    }
}

