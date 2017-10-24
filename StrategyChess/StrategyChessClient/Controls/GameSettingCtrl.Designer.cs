namespace StrategyChessClient.Controls
{
    partial class GameSettingCtrl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettingCtrl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.raPiece1 = new System.Windows.Forms.RadioButton();
            this.raPiece2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.raNetworkMode = new System.Windows.Forms.RadioButton();
            this.raSingleMode = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.raPiece1);
            this.panel1.Controls.Add(this.raPiece2);
            this.panel1.Location = new System.Drawing.Point(102, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 23);
            this.panel1.TabIndex = 20;
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
            this.label3.Location = new System.Drawing.Point(26, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Chess piece:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Mode:";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbTime.Location = new System.Drawing.Point(214, 68);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(63, 15);
            this.lbTime.TabIndex = 17;
            this.lbTime.Text = "00:00:00";
            // 
            // raNetworkMode
            // 
            this.raNetworkMode.AutoSize = true;
            this.raNetworkMode.Location = new System.Drawing.Point(175, 5);
            this.raNetworkMode.Name = "raNetworkMode";
            this.raNetworkMode.Size = new System.Drawing.Size(65, 17);
            this.raNetworkMode.TabIndex = 13;
            this.raNetworkMode.Text = "Network";
            this.raNetworkMode.UseVisualStyleBackColor = true;
            // 
            // raSingleMode
            // 
            this.raSingleMode.AutoSize = true;
            this.raSingleMode.Checked = true;
            this.raSingleMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raSingleMode.ForeColor = System.Drawing.Color.Black;
            this.raSingleMode.Location = new System.Drawing.Point(105, 5);
            this.raSingleMode.Name = "raSingleMode";
            this.raSingleMode.Size = new System.Drawing.Size(54, 17);
            this.raSingleMode.TabIndex = 12;
            this.raSingleMode.TabStop = true;
            this.raSingleMode.Text = "Single";
            this.raSingleMode.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(170, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(68, 57);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(36, 36);
            this.btnStop.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnStop, "Stop");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Location = new System.Drawing.Point(27, 57);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(36, 36);
            this.btnPlay.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnPlay, "Play");
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // _timer
            // 
            this._timer.Interval = 1000;
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // GameSettingCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.raNetworkMode);
            this.Controls.Add(this.raSingleMode);
            this.Name = "GameSettingCtrl";
            this.Size = new System.Drawing.Size(301, 98);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton raPiece1;
        private System.Windows.Forms.RadioButton raPiece2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.RadioButton raNetworkMode;
        private System.Windows.Forms.RadioButton raSingleMode;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer _timer;
    }
}
