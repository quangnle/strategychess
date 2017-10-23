using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StrategyChessGraphics;
using StrategyChessCore.Definitions.Units;
using StrategyChessClient.Controls;
using StrategyChessCore.Definitions;

namespace StrategyChessClient
{
    public partial class MainForm : Form
    {
        #region Members
        private BoardGr _board;
        private Point _currentPos = Point.Empty;
        private bool _isMouseLeft = false;
        private Cell _currentCell = null;
        private bool _isStartGame = false;
        private DateTime _dtTime = DateTime.Now.Date;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();

            if (this.DesignMode) return;
            if (Application.ExecutablePath.EndsWith("devenv.exe")) return;

            InitGame();
        }
        #endregion

        #region UI Command
        private void InitGame()
        {
            _lowerTeamCtrl.OnReadyEvent += teamCtrl_OnReadyEvent;
            _upperTeamCtrl.OnReadyEvent += teamCtrl_OnReadyEvent;

            pGameSetting.BackColor = Global.GameSettingBackgroundColor;

            _board = new BoardGr(20, 6, 2);

            _lowerTeamCtrl.BoardGr = _board;
            _lowerTeamCtrl.TeamColor = Global.TeamGreenColor;
            _lowerTeamCtrl.TeamTitle = "YOU";
            _lowerTeamCtrl.TeamName = "Player 1";
            _lowerTeamCtrl.AmbusherImage = ResourceUtility.Ambusher_Green;
            _lowerTeamCtrl.RangerImage = ResourceUtility.Ranger_Green;
            _lowerTeamCtrl.TankerImage = ResourceUtility.Tanker_Green;
            _lowerTeamCtrl.CampImage = ResourceUtility.Camp_Green;

            _upperTeamCtrl.BoardGr = _board;
            _upperTeamCtrl.TeamColor = Global.TeamBlueColor;
            _upperTeamCtrl.TeamTitle = "COMPETITOR";
            _upperTeamCtrl.TeamName = "Player 2";
            _upperTeamCtrl.AmbusherImage = ResourceUtility.Ambusher_Blue;
            _upperTeamCtrl.RangerImage = ResourceUtility.Ranger_Blue;
            _upperTeamCtrl.TankerImage = ResourceUtility.Tanker_Blue;
            _upperTeamCtrl.CampImage = ResourceUtility.Camp_Blue;
        }

        private void StartTimer()
        {
            _timer.Enabled = true;
            _timer.Start();
        }

        private void StopTimer()
        {
            _timer.Stop();
            _timer.Enabled = false;
        }

        private void OnPlay()
        {
            try
            {
                if (!_lowerTeamCtrl.CheckInfo())
                    return;

                if (raSingleMode.Checked && !_upperTeamCtrl.CheckInfo())
                    return;

                btnPlay.Enabled = false;
                btnStop.Enabled = true;
                raSingleMode.Enabled = false;
                raNetworkMode.Enabled = false;
                raPiece1.Enabled = false;
                raPiece2.Enabled = false;
                _lowerTeamCtrl.EnableName = false;
                _lowerTeamCtrl.VisibleReadyButton = true;

                if (raSingleMode.Checked)
                {
                    _upperTeamCtrl.EnableName = false;
                    _upperTeamCtrl.VisibleReadyButton = true;
                }

                _board.Register(_upperTeamCtrl.TeamName);
                _board.Register(_lowerTeamCtrl.TeamName);

                _board.GameMode = raSingleMode.Checked ? GameMode.Single : GameMode.Network;
                _board.ChessPieceType = raPiece1.Checked ? ChessPieceType.Blue : ChessPieceType.Green;
                _board.CompetitorName = _upperTeamCtrl.TeamName;
                _board.MyName = _lowerTeamCtrl.TeamName;
                _board.MyTeamColor = _lowerTeamCtrl.TeamColor;
                _board.CompetitorTeamColor = _upperTeamCtrl.TeamColor;
                _board.ShowInitArea();
                pBoard.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnStop()
        {
            try
            {
                if (MessageBox.Show("Do you want to stop the game ?", "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                btnPlay.Enabled = true;
                btnStop.Enabled = false;

                raSingleMode.Enabled = true;
                raNetworkMode.Enabled = true;
                raPiece1.Enabled = true;
                raPiece2.Enabled = true;

                _lowerTeamCtrl.EnableName = true;
                _lowerTeamCtrl.VisibleReadyButton = false;

                if (raSingleMode.Checked)
                {
                    _upperTeamCtrl.EnableName = true;
                    _upperTeamCtrl.VisibleReadyButton = false;
                }

                _upperTeamCtrl.ClearAll();
                _lowerTeamCtrl.ClearAll();

                _upperTeamCtrl.VisibleTurn = false;
                _lowerTeamCtrl.VisibleTurn = false;

                _board = new BoardGr(20, 6, 2);
                _upperTeamCtrl.BoardGr = _board;
                _lowerTeamCtrl.BoardGr = _board;
                StopTimer();
                _dtTime = DateTime.Now.Date;
                UpdateLabelTimer();
                pBoard.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLabelTimer()
        {
            lbTime.Text = _dtTime.ToString("HH:mm:ss");
        }
        #endregion

        #region Window Event Handles
        private void pBoard_Paint(object sender, PaintEventArgs e)
        {
            _board.Draw(e.Graphics);
        }

        private void pBoard_DoubleClick(object sender, EventArgs e)
        {
            if (_currentCell == null || _isStartGame) return;

            var team = _board.GetTeamInitArea(_currentCell.Block.Row, _currentCell.Block.Column);
            if (team == null) return;
            if (_currentCell.Block.Unit == null) return;

            var unit = _currentCell.Block.Unit;

            if (_board.RemoveUnitAt(_currentCell.Block.Row, _currentCell.Block.Column))
            {
                _currentCell.Selected = false;
                _currentCell.RemoveChessPiece();
                
                if (team.Name == _lowerTeamCtrl.TeamName)
                    _lowerTeamCtrl.RemoveUnit(unit);
                else
                    _upperTeamCtrl.RemoveUnit(unit);

                _currentCell = null;
                pBoard.Invalidate();
            }
        }

        private void pBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                _isMouseLeft = false;
                _currentCell = null;
                return;
            }

            _isMouseLeft = true;

            var cell = _board.GetCell(e.X, e.Y);
            if (cell == null) return;

            //Place Chess Pieces
            if ((!_lowerTeamCtrl.StartReady || !_upperTeamCtrl.StartReady))
            {
                var team = _board.GetTeamInitArea(cell.Block.Row, cell.Block.Column);
                if (team == null) return;

                if (cell.Block.Unit == null)
                {
                    var unit = (team.Name == _lowerTeamCtrl.TeamName) ? _lowerTeamCtrl.SelectedUnit :
                        _upperTeamCtrl.SelectedUnit;

                    var image = (team.Name == _lowerTeamCtrl.TeamName) ? _lowerTeamCtrl.SelectedChessPieceImage :
                        _upperTeamCtrl.SelectedChessPieceImage;

                    var selectedColor = Global.SelectedBlueColor;
                    var movableColor = Global.MovableBlueColor;
                    if (team.Name == _lowerTeamCtrl.TeamName)
                    {
                        if (_board.ChessPieceType == ChessPieceType.Blue)
                        {
                            selectedColor = Global.SelectedBlueColor;
                            movableColor = Global.MovableBlueColor;
                        }
                        else
                        {
                            selectedColor = Global.SelectedGreenColor;
                            movableColor = Global.MovableGreenColor;
                        }
                    }
                    else
                    {
                        if (_board.ChessPieceType == ChessPieceType.Blue)
                        {
                            selectedColor = Global.SelectedGreenColor;
                            movableColor = Global.MovableGreenColor;
                        }
                        else
                        {
                            selectedColor = Global.SelectedBlueColor;
                            movableColor = Global.MovableBlueColor;
                        }
                    }

                    if (unit == null) return;

                    if (_board.PlaceUnit(team, unit, cell.Block.Row, cell.Block.Column))
                    {
                        cell.InitChecssPiece(image, selectedColor, movableColor);

                        if (team.Name == _lowerTeamCtrl.TeamName)
                            _lowerTeamCtrl.PlaceUnit(unit);
                        else
                            _upperTeamCtrl.PlaceUnit(unit);
                    }
                }
                else //Select
                    _currentCell = cell;
            }

            if (_isStartGame)
            {
                _currentCell = _board.GetCellHasUnitByTeam(e.X, e.Y);
                if (_currentCell != null)
                {
                    _board.ClearAllSelectOfTeam(_board.CurrentTeam);
                    _currentCell.Selected = true;
                }
            }

            pBoard.Invalidate();
        }

        private void pBoard_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void raPiece1_CheckedChanged(object sender, EventArgs e)
        {
            if (raPiece1.Checked)
            {
                _lowerTeamCtrl.TeamColor = Global.TeamBlueColor;
                _lowerTeamCtrl.AmbusherImage = ResourceUtility.Ambusher_Blue;
                _lowerTeamCtrl.RangerImage = ResourceUtility.Ranger_Blue;
                _lowerTeamCtrl.TankerImage = ResourceUtility.Tanker_Blue;
                _lowerTeamCtrl.CampImage = ResourceUtility.Camp_Blue;

                _upperTeamCtrl.TeamColor = Global.TeamGreenColor;
                _upperTeamCtrl.AmbusherImage = ResourceUtility.Ambusher_Green;
                _upperTeamCtrl.RangerImage = ResourceUtility.Ranger_Green;
                _upperTeamCtrl.TankerImage = ResourceUtility.Tanker_Green;
                _upperTeamCtrl.CampImage = ResourceUtility.Camp_Green;
            }
            else
            {
                _lowerTeamCtrl.TeamColor = Global.TeamGreenColor;
                _lowerTeamCtrl.AmbusherImage = ResourceUtility.Ambusher_Green;
                _lowerTeamCtrl.RangerImage = ResourceUtility.Ranger_Green;
                _lowerTeamCtrl.TankerImage = ResourceUtility.Tanker_Green;
                _lowerTeamCtrl.CampImage = ResourceUtility.Camp_Green;

                _upperTeamCtrl.TeamColor = Global.TeamBlueColor;
                _upperTeamCtrl.AmbusherImage = ResourceUtility.Ambusher_Blue;
                _upperTeamCtrl.RangerImage = ResourceUtility.Ranger_Blue;
                _upperTeamCtrl.TankerImage = ResourceUtility.Tanker_Blue;
                _upperTeamCtrl.CampImage = ResourceUtility.Camp_Blue;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            OnPlay();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            OnStop();
        }

        private void teamCtrl_OnReadyEvent(TeamCtrl team)
        {
            if (_lowerTeamCtrl.StartReady && _upperTeamCtrl.StartReady)
            {
                _board.ClearShowInitArea();
                _board.ClearAllSelects();
                _currentCell = null;
                _isStartGame = _board.StartGame();
                if (_isStartGame)
                {
                    _lowerTeamCtrl.VisibleReadyButton = false;
                    _upperTeamCtrl.VisibleReadyButton = false;
                    _lowerTeamCtrl.VisibleTurn = true;
                    _upperTeamCtrl.VisibleTurn = true;

                    _lowerTeamCtrl.Attack();
                    _upperTeamCtrl.Waiting();

                    StartTimer();
                }

                pBoard.Invalidate();
            }   
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _dtTime = _dtTime.AddSeconds(1);
            UpdateLabelTimer();
        }
        #endregion
    }
}
