using StrategyChessClient.ViewModels;
using StrategyChessCore;
using StrategyChessCore.Definitions;
using StrategyChessCore.Definitions.Units;
using StrategyChessGraphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessClient.Controls
{
    public class BoardCtrl : CustomPanel
    {
        #region Members
        private BoardGr _boardGr;
        public TeamViewModel UpperTeamVM { get; set; }
        public TeamViewModel LowerTeamVM { get; set; }
        private List<ChessPiece> _chessPieces = new List<ChessPiece>();

        private Cell _selectedCell;
        private IUnit _selectedUnit;
        #endregion

        #region Constructor
        public BoardCtrl()
        {
            _boardGr = new BoardGr(20);
            this.BackColor = System.Drawing.Color.White;
            this.Paint += BoardCtrl_Paint;
            this.DoubleClick += BoardCtrl_DoubleClick;
            this.MouseDown += BoardCtrl_MouseDown;
        }
        #endregion

        #region Properties
        public GameController GameController { get; set; }
        #endregion

        #region UI Command
        //private void GenerateChessPiece(IUnit unit, Image chessPieceImage, Color selectedColor, Color movableColor)
        //{
        //    if (unit == null) return;
        //    if (unit is Ranger)
        //        ChessPiece = new RangerGr(unit, new Rectangle(_rect.Location, _rect.Size));
        //    else if (unit is Tanker)
        //        ChessPiece = new TankerGr(unit, new Rectangle(_rect.Location, _rect.Size));
        //    else if (unit is Ambusher)
        //        ChessPiece = new AmbusherGr(unit, new Rectangle(_rect.Location, _rect.Size));
        //    else
        //        ChessPiece = new CampGr(unit, new Rectangle(_rect.Location, _rect.Size));

        //    ChessPiece.ChessPieceImage = chessPieceImage;
        //    ChessPiece.SelectedColor = selectedColor;
        //    ChessPiece.MovableColor = movableColor;
        //}
        private TeamViewModel GetTeamViewModel(Team team)
        {
            if (UpperTeamVM.Team.Name == team.Name)
                return UpperTeamVM;

            return LowerTeamVM;
        }

        public void DisplayInitAreaLocation()
        {
            var blocks = GameController.GetInitArea(UpperTeamVM.Team);
            foreach (var block in blocks)
            {

            }
        }
        #endregion

        #region Window Event Handlers
        private void BoardCtrl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _boardGr.Draw(e.Graphics);

            //Draw chess piece
            foreach (var chessPiece in _chessPieces)
            {
                chessPiece.Draw(e.Graphics);
            }

            //Draw HP & Cooldown
            foreach (var chessPiece in _chessPieces)
            {
                chessPiece.DrawExt(e.Graphics);
            }
        }

        private void BoardCtrl_DoubleClick(object sender, EventArgs e)
        {
            if (GameController.State == GameState.Init && _selectedCell != null)
            {
                GameController.RemoveUnitAt(_selectedCell.Row, _selectedCell.Column);
                Invalidate();
            }
        }

        private IUnit GenerateUnit(UnitType type, Guid id)
        {
            if (type == UnitType.Camp) return new Camp(id);
            else if (type == UnitType.Ambusher) return new Ambusher(id);
            else if (type == UnitType.Ranger) return new Ranger(id);
            else return new Tanker(id);
        }

        private void UpdateMovableCells(IUnit unit)
        {
            var availMoves = GameController.GetMovableBlocks(unit);
            foreach (var bl in availMoves)
            {
                _boardGr[bl.Row, bl.Column].Movable = true;
            }
        }

        private void UpdateTargetCells(IUnit unit)
        {
            // draw attackable targets
            var targets = GameController.GetEnemyAround(unit, unit.Range);
            foreach (var target in targets)
            {
                _boardGr[target.Row, target.Column].Attackable = true;
            }
        }
        
        private void BoardCtrl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _selectedCell = _boardGr.GetCell(new System.Drawing.Point(e.X, e.Y));
            if (GameController.State == GameState.Init)
            {   
                if (_selectedCell != null)
                {
                    var team = GameController.GetTeamByInitAreaLocation(_selectedCell.Row, _selectedCell.Column);
                    if (team != null)
                    {
                        var unit = GenerateUnit(GetTeamViewModel(team).SelectedUnitType, Guid.NewGuid());
                        GameController.PlaceUnit(team.Name, unit, _selectedCell.Row, _selectedCell.Column);
                    }
                }
            }
            else if (GameController.State == GameState.Playing)
            {   
                if (_selectedCell != null)
                {   
                    if (_selectedUnit == null) 
                    {
                        var unit = GameController.GetUnitAt(_selectedCell.Row, _selectedCell.Column);
                        if (unit != null) // select the unit
                        {
                            _selectedUnit = unit;
                            // draw movable area
                            _selectedCell.Selected = true;

                            UpdateMovableCells(_selectedUnit);
                            UpdateTargetCells(_selectedUnit);
                        }
                    }
                    else
                    {
                        GameController.MakeAMove(_selectedUnit, _selectedCell.Row, _selectedCell.Column);
                        var unit = GameController.GetUnitAt(_selectedCell.Row, _selectedCell.Column);
                        if (unit == null) // move
                        {
                            var result = GameController.MakeAMove(_selectedUnit, _selectedCell.Row, _selectedCell.Column);
                            if (result)
                            {
                                UpdateTargetCells(_selectedUnit);
                            }
                        } 
                        else
                        {
                            var result = GameController.MakeAMove(_selectedUnit, _selectedCell.Row, _selectedCell.Column);
                        }
                    }
                }
            }
            else if (GameController.State == GameState.CampDestroyed)
            {
                if (_selectedCell != null)
                {
                    var unit = GenerateUnit(GetTeamViewModel(GameController.CurrentTeam).SelectedUnitType, Guid.NewGuid());
                    GameController.PlaceUnit(GameController.CurrentTeam.Name, unit, _selectedCell.Row, _selectedCell.Column);
                }
            }

            Invalidate();
        }

        #endregion
    }
}
