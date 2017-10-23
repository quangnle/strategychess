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

namespace StrategyChessClient.Controls
{
    public delegate void ReadyHandler(TeamCtrl sender);
    public partial class TeamCtrl : UserControl
    {
        #region Members
        public event ReadyHandler OnReadyEvent;
        private int _ambusherCount = 0;
        private int _rangerCount = 0;
        private int _tankerCount = 0;
        private int _campCount = 0;
        private int _maxUnits = 6;
        private int _maxCamps = 2;
        public BoardGr BoardGr { get; set; }
        #endregion

        #region Constructor
        public TeamCtrl()
        {
            InitializeComponent();

            if (this.DesignMode) return;
            if (Application.ExecutablePath.EndsWith("devenv.exe")) return;

            this.picTanker.IsSelected = true;
            this.TeamColor = Global.TeamBlueColor;
            this.btnReady.BackColor = Global.TeamBlueColor;

            this.picAmbusher.OnSelectChanged += PictureBox_OnSelectChanged;
            this.picRanger.OnSelectChanged += PictureBox_OnSelectChanged;
            this.picTanker.OnSelectChanged += PictureBox_OnSelectChanged;
            this.picCamp.OnSelectChanged += PictureBox_OnSelectChanged;
        }
        #endregion

        #region Properties
        public bool IsReady
        {
            get { return btnReady.Text == "Ready"; }
        }

        public bool StartReady
        {
            get { return btnReady.Text == "Ready" && !btnReady.Enabled; }
        }

        public int MaxUnits { get; set; }
        public int MaxCamps { get; set; }

        public IUnit SelectedUnit
        {
            get
            {
                if (picAmbusher.IsSelected)
                    return new Ambusher(Guid.NewGuid());
                else if (picRanger.IsSelected)
                    return new Ranger(Guid.NewGuid());
                else if (picTanker.IsSelected)
                    return new Tanker(Guid.NewGuid());
                else if (picCamp.IsSelected)
                    return new Camp(Guid.NewGuid());

                return null;
            }
        }

        public Image SelectedChessPieceImage
        {
            get
            {
                if (picAmbusher.IsSelected)
                    return AmbusherImage;
                else if (picRanger.IsSelected)
                    return RangerImage;
                else if (picTanker.IsSelected)
                    return TankerImage;
                else if (picCamp.IsSelected)
                    return CampImage;

                return null;
            }
        }

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

        public Color TeamColor
        {
            get { return lbTeam.BackColor; }
            set
            {
                lbTeam.BackColor = value;
                picTanker.SelectedColor = value;
                picRanger.SelectedColor = value;
                picAmbusher.SelectedColor = value;
                picCamp.SelectedColor = value;
                btnReady.BackColor = value;
            }
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
        #endregion

        #region UI Command
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

            if (this.BoardGr != null)
            {
                var team = this.BoardGr.GetTeamByName(this.TeamName);
                if (team != null)
                {
                    var ready = this.BoardGr.GetReady(team);
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
            }
            else if (sender == picRanger)
            {
                picAmbusher.IsSelected = false;
                picTanker.IsSelected = false;
                picCamp.IsSelected = false;
            }
            else if (sender == picTanker)
            {
                picAmbusher.IsSelected = false;
                picRanger.IsSelected = false;
                picCamp.IsSelected = false;
            }
            else
            {
                picAmbusher.IsSelected = false;
                picRanger.IsSelected = false;
                picTanker.IsSelected = false;
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
