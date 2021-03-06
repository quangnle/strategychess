﻿using System;
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
using StrategyChessCore;
using StrategyChessClient.ViewModels;
using System.Configuration;

namespace StrategyChessClient
{
    public partial class MainForm : Form
    {
        #region Members
        private GameController _gameController;
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
        private void LoadConfiguration()
        {
            GameConfig.BoardWidth = Convert.ToInt32(ConfigurationManager.AppSettings["width"]);
            GameConfig.BoardHeight = Convert.ToInt32(ConfigurationManager.AppSettings["height"]);
            GameConfig.InitHeight = Convert.ToInt32(ConfigurationManager.AppSettings["initheight"]);
            GameConfig.MaxCamps = Convert.ToInt32(ConfigurationManager.AppSettings["maxcamps"]);
            GameConfig.MaxUnits = Convert.ToInt32(ConfigurationManager.AppSettings["maxunits"]);

            Global.CellHeight = Convert.ToInt32(ConfigurationManager.AppSettings["cellheight"]);
            Global.CellWidth = Convert.ToInt32(ConfigurationManager.AppSettings["cellwidth"]);

            GameConfig.CampHp = Convert.ToInt32(ConfigurationManager.AppSettings["camp.hp"]); ;
            GameConfig.CampSpeed = Convert.ToInt32(ConfigurationManager.AppSettings["camp.speed"]); ;
            GameConfig.CampRange = Convert.ToInt32(ConfigurationManager.AppSettings["camp.range"]); ;
            GameConfig.CampCoolDown = Convert.ToInt32(ConfigurationManager.AppSettings["camp.cooldown"]); ;

            GameConfig.RangerHp = Convert.ToInt32(ConfigurationManager.AppSettings["ranger.hp"]); ;
            GameConfig.RangerSpeed = Convert.ToInt32(ConfigurationManager.AppSettings["ranger.speed"]); ;
            GameConfig.RangerRange = Convert.ToInt32(ConfigurationManager.AppSettings["ranger.range"]); ;
            GameConfig.RangerCoolDown = Convert.ToInt32(ConfigurationManager.AppSettings["ranger.cooldown"]); ;

            GameConfig.TankerHp = Convert.ToInt32(ConfigurationManager.AppSettings["tanker.hp"]); ;
            GameConfig.TankerSpeed = Convert.ToInt32(ConfigurationManager.AppSettings["tanker.speed"]); ;
            GameConfig.TankerRange = Convert.ToInt32(ConfigurationManager.AppSettings["tanker.range"]); ;
            GameConfig.TankerCoolDown = Convert.ToInt32(ConfigurationManager.AppSettings["tanker.cooldown"]); ;

            GameConfig.AmbusherHp = Convert.ToInt32(ConfigurationManager.AppSettings["ambusher.hp"]); ;
            GameConfig.AmbusherSpeed = Convert.ToInt32(ConfigurationManager.AppSettings["ambusher.speed"]); ;
            GameConfig.AmbusherRange = Convert.ToInt32(ConfigurationManager.AppSettings["ambusher.range"]); ;
            GameConfig.AmbusherCoolDown = Convert.ToInt32(ConfigurationManager.AppSettings["ambusher.cooldown"]); ;
        }

        private void InitGame()
        {
            LoadConfiguration();

            _gameController = new GameController(GameConfig.BoardWidth, GameConfig.BoardHeight, GameConfig.MaxUnits, GameConfig.MaxCamps);
            _boardCtrl.InitBoard();
            _boardCtrl.GameController = _gameController;
            _boardCtrl.OnPlaceUnitEvent += _boardCtrl_OnPlaceUnitEvent;
            _boardCtrl.OnRemoveUnitEvent += _boardCtrl_OnRemoveUnitEvent;
            _boardCtrl.OnNextTeamEvent += teamCtrl_OnSkipEvent;

            _gameSettingCtrl.OnStartClick += _gameSettingCtrl_OnStartClick;
            _gameSettingCtrl.OnStopClick += _gameSettingCtrl_OnStopClick;
            _gameSettingCtrl.OnChessPieceColorChanged += _gameSettingCtrl_OnChessPieceColorChanged;

            _lowerTeamCtrl.OnReadyEvent += teamCtrl_OnReadyEvent;
            _lowerTeamCtrl.OnSkipEvent += teamCtrl_OnSkipEvent;
            _upperTeamCtrl.OnReadyEvent += teamCtrl_OnReadyEvent;
            _upperTeamCtrl.OnSkipEvent += teamCtrl_OnSkipEvent;

            var lowerModel = new TeamViewModel()
            {
                Color = ChessPieceColor.Green,
                SelectedColor = Global.SelectedGreenColor,
                MovableColor = Global.MovableGreenColor,
                AttackableColor = Global.AttackableColor,
                SelectedUnitType = UnitType.Tanker,
                SelectedChessPieceImage = Properties.Resources.Tanker_Green
            };

            _lowerTeamCtrl.MaxUnits = GameConfig.MaxUnits;
            _lowerTeamCtrl.MaxCamps = GameConfig.MaxCamps;
            _lowerTeamCtrl.Model = lowerModel;
            _lowerTeamCtrl.GameController = _gameController;
            _lowerTeamCtrl.AllowSelectUnit(false);
            _lowerTeamCtrl.TeamTitle = "YOU";
            _lowerTeamCtrl.TeamName = "Player 1";

            var upperModel = new TeamViewModel()
            {
                Color = ChessPieceColor.Blue,
                SelectedColor = Global.SelectedBlueColor,
                MovableColor = Global.MovableBlueColor,
                AttackableColor = Global.AttackableColor,
                SelectedUnitType = UnitType.Tanker,
                SelectedChessPieceImage = Properties.Resources.Tanker_Blue
            };

            _upperTeamCtrl.MaxUnits = GameConfig.MaxUnits;
            _upperTeamCtrl.MaxCamps = GameConfig.MaxCamps;
            _upperTeamCtrl.GameController = _gameController;
            _upperTeamCtrl.Model = upperModel;
            _upperTeamCtrl.AllowSelectUnit(false);
            _upperTeamCtrl.TeamTitle = "COMPETITOR";
            _upperTeamCtrl.TeamName = "Player 2";

            _boardCtrl.UpperTeamVM = upperModel;
            _boardCtrl.LowerTeamVM = lowerModel;
        }
        
        private void OnPlay()
        {
            try
            {
                if (!_lowerTeamCtrl.CheckInfo())
                    return;

                if (_gameSettingCtrl.GameMode == GameMode.Single && !_upperTeamCtrl.CheckInfo())
                    return;

                _gameSettingCtrl.RefreshUI(true);

                _lowerTeamCtrl.EnableName = false;
                _lowerTeamCtrl.VisibleReadyButton = true;
                _lowerTeamCtrl.AllowSelectUnit(true);

                if (_gameSettingCtrl.GameMode == GameMode.Single)
                {
                    _upperTeamCtrl.EnableName = false;
                    _upperTeamCtrl.VisibleReadyButton = true;
                    _upperTeamCtrl.AllowSelectUnit(true);
                }

                _gameController.Register(_upperTeamCtrl.TeamName);
                _gameController.Register(_lowerTeamCtrl.TeamName);

                _lowerTeamCtrl.Model.Team = _gameController.GetTeamByName(_lowerTeamCtrl.TeamName);
                _upperTeamCtrl.Model.Team = _gameController.GetTeamByName(_upperTeamCtrl.TeamName);

                _boardCtrl.DisplayInitAreaLocation();
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
                _upperTeamCtrl.ClearAll();
                _lowerTeamCtrl.ClearAll();

                _lowerTeamCtrl.EnableName = true;
                _lowerTeamCtrl.VisibleReadyButton = false;
                _lowerTeamCtrl.AllowSelectUnit(false);

                if (_gameSettingCtrl.GameMode == GameMode.Single)
                {
                    _upperTeamCtrl.EnableName = true;
                    _upperTeamCtrl.VisibleReadyButton = false;
                    _upperTeamCtrl.AllowSelectUnit(false);
                }

                _upperTeamCtrl.VisibleTurn = false;
                _lowerTeamCtrl.VisibleTurn = false;
                _gameController = new GameController(GameConfig.BoardWidth, GameConfig.BoardHeight, GameConfig.MaxUnits, GameConfig.MaxCamps);
                _boardCtrl.GameController = _gameController;
                _boardCtrl.ClearAllChessPieces();
                _boardCtrl.RefreshState();
                _upperTeamCtrl.GameController = _gameController;
                _lowerTeamCtrl.GameController = _gameController;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TeamCtrl GetTeamCtrlByName(string teamName)
        {
            if (_upperTeamCtrl.TeamName == teamName)
                return _upperTeamCtrl;

            return _lowerTeamCtrl;
        }
        #endregion

        #region Window Event Handles
        private void _gameSettingCtrl_OnChessPieceColorChanged(ChessPieceColor type)
        {
            _lowerTeamCtrl.SetTeamColor(type);

            if (type == ChessPieceColor.Blue)
                _upperTeamCtrl.SetTeamColor(ChessPieceColor.Green);
            else                
                _upperTeamCtrl.SetTeamColor(ChessPieceColor.Blue);
        }

        private void _gameSettingCtrl_OnStopClick(object sender)
        {
            OnStop();
        }

        private void _gameSettingCtrl_OnStartClick(object sender)
        {
            OnPlay();
        }

        private void teamCtrl_OnReadyEvent(TeamCtrl team)
        {
            if (_lowerTeamCtrl.StartReady && _upperTeamCtrl.StartReady)
            {
                var isStartGame = _gameController.StartGame();
                if (isStartGame)
                {
                    _boardCtrl.RemoveInitAreaLocation();

                    _lowerTeamCtrl.EnableReadyButton = true;
                    _upperTeamCtrl.EnableReadyButton = true;

                    _lowerTeamCtrl.ReadyButton.Text = "Next";
                    _upperTeamCtrl.ReadyButton.Text = "Waiting";

                    _lowerTeamCtrl.VisibleTurn = true;
                    _upperTeamCtrl.VisibleTurn = true;

                    _lowerTeamCtrl.Attack();
                    _upperTeamCtrl.Waiting();

                    _gameSettingCtrl.StartTimer();
                }
            }   
        }

        private void _boardCtrl_OnPlaceUnitEvent(UnitType type, string teamName)
        {
            var teamCtrl = GetTeamCtrlByName(teamName);
            switch (type)
            {
                case UnitType.Camp:
                    teamCtrl.CampCount++;
                    break;
                case UnitType.Ambusher:
                    teamCtrl.AmbusherCount++;
                    break;
                case UnitType.Ranger:
                    teamCtrl.RangerCount++;
                    break;
                case UnitType.Tanker:
                    teamCtrl.TankerCount++;
                    break;
            }
        }

        private void _boardCtrl_OnRemoveUnitEvent(UnitType type, string teamName)
        {
            var teamCtrl = GetTeamCtrlByName(teamName);
            switch (type)
            {
                case UnitType.Camp:
                    teamCtrl.CampCount--;
                    break;
                case UnitType.Ambusher:
                    teamCtrl.AmbusherCount--;
                    break;
                case UnitType.Ranger:
                    teamCtrl.RangerCount--;
                    break;
                case UnitType.Tanker:
                    teamCtrl.TankerCount--;
                    break;
            }
        }

        private void teamCtrl_OnSkipEvent(string teamName)
        {
            if (_lowerTeamCtrl.TeamName == teamName)
            {
                _lowerTeamCtrl.Waiting();
                _upperTeamCtrl.Attack();
                _lowerTeamCtrl.ReadyButton.Text = "Waiting";
                _upperTeamCtrl.ReadyButton.Text = "Next";
            }
            else
            {
                _upperTeamCtrl.Waiting();
                _lowerTeamCtrl.Attack();
                _lowerTeamCtrl.ReadyButton.Text = "Next";
                _upperTeamCtrl.ReadyButton.Text = "Waiting";
            }
            
            _boardCtrl.RefreshState();
        }
        #endregion
    }
}
