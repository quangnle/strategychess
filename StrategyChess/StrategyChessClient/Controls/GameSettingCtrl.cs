﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StrategyChessCore.Definitions;
using StrategyChessGraphics;
using StrategyChessClient.ViewModels;

namespace StrategyChessClient.Controls
{
    public delegate void StartClickHandler(object sender);
    public delegate void StopClickHandler(object sender);
    public delegate void ChessPieceColorChangeHandler(ChessPieceColor type);
    public partial class GameSettingCtrl : UserControl
    {
        #region Members
        public event StartClickHandler OnStartClick;
        public event StopClickHandler OnStopClick;
        public event ChessPieceColorChangeHandler OnChessPieceColorChanged;
        private DateTime _dtTime = DateTime.Now.Date;
        #endregion

        #region Constructor
        public GameSettingCtrl()
        {
            InitializeComponent();
            this.BackColor = Color.White;
        }
        #endregion

        #region Properties
        public GameMode GameMode
        {
            get
            {
                if (raSingleMode.Checked)
                    return GameMode.Single;

                return GameMode.Network;
            }
        }

        public ChessPieceColor ChessPieceColor
        {
            get
            {
                if (raPiece1.Checked)
                    return ChessPieceColor.Blue;
                return ChessPieceColor.Green;
            }
        }
        #endregion

        #region UI Command
        private void UpdateLabelTimer()
        {
            lbTime.Text = _dtTime.ToString("HH:mm:ss");
        }

        public void StartTimer()
        {
            _timer.Enabled = true;
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();
            _timer.Enabled = false;
        }
        #endregion

        #region Window Event Handlers
        private void raPiece1_CheckedChanged(object sender, EventArgs e)
        {
            if (OnChessPieceColorChanged != null)
            {
                if (raPiece1.Checked)
                    OnChessPieceColorChanged(ChessPieceColor.Blue);
                else
                    OnChessPieceColorChanged(ChessPieceColor.Green);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (OnStartClick != null)
                OnStartClick(sender);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (OnStopClick != null)
                OnStopClick(sender);
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _dtTime = _dtTime.AddSeconds(1);
            UpdateLabelTimer();
        }
        #endregion
    }
}
