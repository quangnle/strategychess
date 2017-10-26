using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StrategyChessCore.Definitions.Units;
using StrategyChessGraphics;
using StrategyChessCore;
using StrategyChessCore.Definitions;
using StrategyChessClient.ViewModels;

namespace StrategyChessClient.Controls
{
    public delegate void ReadyHandler(TeamCtrl sender);
    public delegate void SkipHandler(string teamName);

    public partial class TeamCtrl : UserControl
    {
        #region Members
        public event ReadyHandler OnReadyEvent;
        public event SkipHandler OnSkipEvent;
        private int _ambusherCount = 0;
        private int _rangerCount = 0;
        private int _tankerCount = 0;
        private int _campCount = 0;
        private int _maxUnits = 6;
        private int _maxCamps = 2;
        private TeamViewModel _model;

        public TeamViewModel Model
        {
            get { return _model; }
            set
            {
                if (value != null)
                {
                    _model = value;

                    switch (_model.SelectedUnitType)
                    {
                        case UnitType.Camp:
                            this.picCamp.IsSelected = true;
                            break;
                        case UnitType.Ambusher:
                            this.picAmbusher.IsSelected = true;
                            break;
                        case UnitType.Ranger:
                            this.picRanger.IsSelected = true;
                            break;
                        case UnitType.Tanker:
                            this.picTanker.IsSelected = true;
                            break;
                    }

                    SetTeamColor(_model.Color);
                }
            }
        }
        public GameController GameController { get; set; }

        #endregion

        #region Constructor
        public TeamCtrl()
        {
            InitializeComponent();

            if (this.DesignMode) return;
            if (Application.ExecutablePath.EndsWith("devenv.exe")) return;

            this.picAmbusher.OnSelectChanged += PictureBox_OnSelectChanged;
            this.picRanger.OnSelectChanged += PictureBox_OnSelectChanged;
            this.picTanker.OnSelectChanged += PictureBox_OnSelectChanged;
            this.picCamp.OnSelectChanged += PictureBox_OnSelectChanged;
        }
        #endregion

        #region Properties
        public bool StartReady
        {
            get { return btnReady.Text == "Ready" && !btnReady.Enabled; }
        }

        public int MaxUnits { get; set; }
        public int MaxCamps { get; set; }
        
        public bool VisibleReadyButton
        {
            set
            {
                btnReady.Visible = value;
                if (value)
                {
                    btnReady.Text = "Waiting";
                    picTanker.IsSelected = true;
                }
            }
        }

        public bool EnableReadyButton
        {
            set { btnReady.Enabled = value; }
        }

        public bool EnableName
        {
            set { txtName.Enabled = value; }
        }
        
        public string TeamName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public string TeamTitle
        {
            set { lbTeam.Text = value; }
        }

        public int AmbusherCount
        {
            get { return _ambusherCount; }
            set
            {
                if (value < 0) return;
                _ambusherCount = value;
                RefreshCount(lbAmpusher, _ambusherCount);
                RefreshSelectUnit();
            }
        }

        public int RangerCount
        {
            get { return _rangerCount; }
            set
            {
                if (value < 0) return;
                _rangerCount = value;
                RefreshCount(lbRanger, _rangerCount);
                RefreshSelectUnit();
            }
        }

        public int TankerCount
        {
            get { return _tankerCount; }
            set
            {
                if (value < 0) return;
                _tankerCount = value;
                RefreshCount(lbTanker, _tankerCount);
                RefreshSelectUnit();
            }
        }

        public int CampCount
        {
            get { return _campCount; }
            set
            {
                if (value < 0) return;
                _campCount = value;
                RefreshCount(lbCamp, _campCount);
                RefreshSelectUnit();
            }
        }

        public Bitmap AmbusherImage
        {
            get { return picAmbusher.Image as Bitmap; }
            set { picAmbusher.Image = value; }
        }

        public Bitmap RangerImage
        {
            get { return picRanger.Image as Bitmap; }
            set { picRanger.Image = value; }
        }

        public Bitmap TankerImage
        {
            get { return picTanker.Image as Bitmap; }
            set { picTanker.Image = value; }
        }

        public Bitmap CampImage
        {
            get { return picCamp.Image as Bitmap; }
            set { picCamp.Image = value; }
        }

        public bool VisibleTurn
        {
            set { picTurn.Visible = value; }
        }

        public Button ReadyButton
        {
            get { return btnReady; }
        }
        #endregion

        #region UI Command

        public void SetTeamColor(ChessPieceColor color)
        {
            var cl = Global.TeamBlueColor;
            var tankerImage = Properties.Resources.Tanker_Blue;
            var rangerImage = Properties.Resources.Ranger_Blue;
            var ambusherImage = Properties.Resources.Ambusher_Blue;
            var campImage = Properties.Resources.Camp_Blue;

            if (color == ChessPieceColor.Green)
            {
                cl = Global.TeamGreenColor;

                tankerImage = Properties.Resources.Tanker_Green;
                rangerImage = Properties.Resources.Ranger_Green;
                ambusherImage = Properties.Resources.Ambusher_Green;
                campImage = Properties.Resources.Camp_Green;
            }

            this.AmbusherImage = ambusherImage;
            this.RangerImage = rangerImage;
            this.TankerImage = tankerImage;
            this.CampImage = campImage;

            lbTeam.BackColor = cl;
            picTanker.SelectedColor = cl;
            picRanger.SelectedColor = cl;
            picAmbusher.SelectedColor = cl;
            picCamp.SelectedColor = cl;
            btnReady.BackColor = cl;
        }

        public void AllowSelectUnit(bool allow)
        {
            picAmbusher.AllowSelect = allow;
            picRanger.AllowSelect = allow;
            picTanker.AllowSelect = allow;
            picCamp.AllowSelect = allow;

            if (!allow)
            {
                picAmbusher.IsSelected = false;
                picRanger.IsSelected = false;
                picCamp.IsSelected = false;
                picTanker.IsSelected = true;
            }
        }

        public void Attack()
        {
            picTurn.Image = Properties.Resources.attack;
        }

        public void Waiting()
        {
            picTurn.Image = Properties.Resources.waiting;
        }

        public void PlaceUnit(IUnit unit)
        {
            if (unit is Ambusher)
                AmbusherCount++;
            else if (unit is Ranger)
                RangerCount++;
            else if (unit is Tanker)
                TankerCount++;
            else if (unit is Camp)
                CampCount++;
        }

        public void RemoveUnit(IUnit unit)
        {
            if (unit is Ambusher)
                AmbusherCount--;
            else if (unit is Ranger)
                RangerCount--;
            else if (unit is Tanker)
                TankerCount--;
            else if (unit is Camp)
                CampCount--;
        }

        public void ClearAll()
        {
            this.AmbusherCount = 0;
            this.RangerCount = 0;
            this.TankerCount = 0;
            this.CampCount = 0;
            this.btnReady.Enabled = true;
        }

        private void RefreshCount(Label lb, int count)
        {
            lb.Text = $"x {count}";
        }

        private void RefreshSelectUnit()
        {
            if (picCamp.IsSelected)
            {
                if (_campCount == _maxCamps)
                {
                    picCamp.IsSelected = false;

                    if (_ambusherCount + _rangerCount + _tankerCount < _maxUnits)
                        picTanker.IsSelected = true;
                }
            }
            else
            {
                if (_ambusherCount + _rangerCount + _tankerCount == _maxUnits)
                {
                    picAmbusher.IsSelected = false;
                    picRanger.IsSelected = false;
                    picTanker.IsSelected = false;

                    if (_campCount < _maxCamps)
                        picCamp.IsSelected = true;
                }
            }

            if (Model != null)
            {
                var ready = GameController.Ready(Model.Team);
                btnReady.Text = ready ? "Ready" : "Waiting";

                picTanker.AllowSelect = !ready;
                picRanger.AllowSelect = !ready;
                picAmbusher.AllowSelect = !ready;
                picCamp.AllowSelect = !ready;

                if (!ready && !picAmbusher.IsSelected && !picRanger.IsSelected &&
                    !picTanker.IsSelected && !picCamp.IsSelected)
                {
                    picTanker.IsSelected = true;
                }
            }
        }
        
        public bool CheckInfo()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter player's name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }

            return true;
        }

        private void PictureBox_OnSelectChanged(PictureBox sender, bool selected)
        {
            if (sender == picAmbusher)
            {
                picRanger.IsSelected = false;
                picTanker.IsSelected = false;
                picCamp.IsSelected = false;
                Model.SelectedChessPieceImage = this.AmbusherImage;
                Model.SelectedUnitType = UnitType.Ambusher;
            }
            else if (sender == picRanger)
            {
                picAmbusher.IsSelected = false;
                picTanker.IsSelected = false;
                picCamp.IsSelected = false;
                Model.SelectedChessPieceImage = this.RangerImage;
                Model.SelectedUnitType = UnitType.Ranger;
            }
            else if (sender == picTanker)
            {
                picAmbusher.IsSelected = false;
                picRanger.IsSelected = false;
                picCamp.IsSelected = false;
                Model.SelectedChessPieceImage = this.TankerImage;
                Model.SelectedUnitType = UnitType.Tanker;
            }
            else
            {
                picAmbusher.IsSelected = false;
                picRanger.IsSelected = false;
                picTanker.IsSelected = false;
                Model.SelectedChessPieceImage = this.CampImage;
                Model.SelectedUnitType = UnitType.Camp;
            }
        }
        #endregion

        #region Window Event Handlers
        private void TeamCtrl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            if (Application.ExecutablePath.EndsWith("devenv.exe")) return;
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (btnReady.Text == "Waiting")
                return;

            if (btnReady.Text == "Skip")
            {
                GameController.NextTeam();
                if (OnSkipEvent != null)
                    OnSkipEvent(this.TeamName);

                return;
            }

            btnReady.Enabled = false;
            picAmbusher.AllowSelect = false;
            picRanger.AllowSelect = false;
            picTanker.AllowSelect = false;
            picCamp.AllowSelect = false;

            if (OnReadyEvent != null)
                OnReadyEvent(this);
        }
        #endregion
    }
}
