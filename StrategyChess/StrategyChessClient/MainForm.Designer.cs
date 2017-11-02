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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pPlayer = new StrategyChessClient.Controls.CustomPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customPanel3 = new StrategyChessClient.Controls.CustomPanel();
            this._lowerTeamCtrl = new StrategyChessClient.Controls.TeamCtrl();
            this.customPanel2 = new StrategyChessClient.Controls.CustomPanel();
            this._upperTeamCtrl = new StrategyChessClient.Controls.TeamCtrl();
            this.pGameSetting = new StrategyChessClient.Controls.CustomPanel();
            this._gameSettingCtrl = new StrategyChessClient.Controls.GameSettingCtrl();
            this._boardCtrl = new StrategyChessClient.Controls.BoardCtrl();
            this.pPlayer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.customPanel3.SuspendLayout();
            this.customPanel2.SuspendLayout();
            this.pGameSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // pPlayer
            // 
            this.pPlayer.BackColor = System.Drawing.Color.White;
            this.pPlayer.Controls.Add(this.tableLayoutPanel1);
            this.pPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPlayer.Location = new System.Drawing.Point(583, 0);
            this.pPlayer.Name = "pPlayer";
            this.pPlayer.Size = new System.Drawing.Size(305, 689);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 689);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // customPanel3
            // 
            this.customPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel3.Controls.Add(this._lowerTeamCtrl);
            this.customPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel3.Location = new System.Drawing.Point(3, 399);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(299, 287);
            this.customPanel3.TabIndex = 2;
            // 
            // _lowerTeamCtrl
            // 
            this._lowerTeamCtrl.AmbusherCount = 0;
            this._lowerTeamCtrl.AmbusherImage = ((System.Drawing.Bitmap)(resources.GetObject("_lowerTeamCtrl.AmbusherImage")));
            this._lowerTeamCtrl.BackColor = System.Drawing.Color.White;
            this._lowerTeamCtrl.CampCount = 0;
            this._lowerTeamCtrl.CampImage = null;
            this._lowerTeamCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lowerTeamCtrl.GameController = null;
            this._lowerTeamCtrl.Location = new System.Drawing.Point(0, 0);
            this._lowerTeamCtrl.MaxCamps = 0;
            this._lowerTeamCtrl.MaxUnits = 0;
            this._lowerTeamCtrl.Model = null;
            this._lowerTeamCtrl.Name = "_lowerTeamCtrl";
            this._lowerTeamCtrl.RangerCount = 0;
            this._lowerTeamCtrl.RangerImage = null;
            this._lowerTeamCtrl.Size = new System.Drawing.Size(297, 285);
            this._lowerTeamCtrl.TabIndex = 1;
            this._lowerTeamCtrl.TankerCount = 0;
            this._lowerTeamCtrl.TankerImage = null;
            this._lowerTeamCtrl.TeamName = "";
            // 
            // customPanel2
            // 
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.Controls.Add(this._upperTeamCtrl);
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel2.Location = new System.Drawing.Point(3, 3);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(299, 286);
            this.customPanel2.TabIndex = 1;
            // 
            // _upperTeamCtrl
            // 
            this._upperTeamCtrl.AmbusherCount = 0;
            this._upperTeamCtrl.AmbusherImage = ((System.Drawing.Bitmap)(resources.GetObject("_upperTeamCtrl.AmbusherImage")));
            this._upperTeamCtrl.BackColor = System.Drawing.Color.White;
            this._upperTeamCtrl.CampCount = 0;
            this._upperTeamCtrl.CampImage = null;
            this._upperTeamCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._upperTeamCtrl.GameController = null;
            this._upperTeamCtrl.Location = new System.Drawing.Point(0, 0);
            this._upperTeamCtrl.MaxCamps = 0;
            this._upperTeamCtrl.MaxUnits = 0;
            this._upperTeamCtrl.Model = null;
            this._upperTeamCtrl.Name = "_upperTeamCtrl";
            this._upperTeamCtrl.RangerCount = 0;
            this._upperTeamCtrl.RangerImage = null;
            this._upperTeamCtrl.Size = new System.Drawing.Size(297, 284);
            this._upperTeamCtrl.TabIndex = 0;
            this._upperTeamCtrl.TankerCount = 0;
            this._upperTeamCtrl.TankerImage = null;
            this._upperTeamCtrl.TeamName = "";
            // 
            // pGameSetting
            // 
            this.pGameSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGameSetting.Controls.Add(this._gameSettingCtrl);
            this.pGameSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGameSetting.Location = new System.Drawing.Point(3, 295);
            this.pGameSetting.Name = "pGameSetting";
            this.pGameSetting.Size = new System.Drawing.Size(299, 98);
            this.pGameSetting.TabIndex = 0;
            // 
            // _gameSettingCtrl
            // 
            this._gameSettingCtrl.BackColor = System.Drawing.Color.White;
            this._gameSettingCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gameSettingCtrl.Location = new System.Drawing.Point(0, 0);
            this._gameSettingCtrl.Name = "_gameSettingCtrl";
            this._gameSettingCtrl.Size = new System.Drawing.Size(297, 96);
            this._gameSettingCtrl.TabIndex = 0;
            // 
            // _boardCtrl
            // 
            this._boardCtrl.BackColor = System.Drawing.Color.White;
            this._boardCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            this._boardCtrl.GameController = null;
            this._boardCtrl.Location = new System.Drawing.Point(0, 0);
            this._boardCtrl.LowerTeamVM = null;
            this._boardCtrl.Name = "_boardCtrl";
            this._boardCtrl.Size = new System.Drawing.Size(583, 689);
            this._boardCtrl.TabIndex = 1;
            this._boardCtrl.UpperTeamVM = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 689);
            this.Controls.Add(this.pPlayer);
            this.Controls.Add(this._boardCtrl);
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
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CustomPanel pPlayer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.CustomPanel customPanel3;
        private Controls.CustomPanel customPanel2;
        private Controls.TeamCtrl _lowerTeamCtrl;
        private Controls.TeamCtrl _upperTeamCtrl;
        private Controls.BoardCtrl _boardCtrl;
        private Controls.CustomPanel pGameSetting;
        private Controls.GameSettingCtrl _gameSettingCtrl;
    }
}

