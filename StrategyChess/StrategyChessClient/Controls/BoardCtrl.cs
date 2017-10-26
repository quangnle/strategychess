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
    public delegate void PlaceUnitHandler(UnitType type, string teamName);
    public delegate void RemoveUnitHandler(UnitType type, string teamName);
    public delegate void NextTeamHandler(string teamName);
    public class BoardCtrl : CustomPanel
    {
        #region Members
        public event PlaceUnitHandler OnPlaceUnitEvent;
        public event RemoveUnitHandler OnRemoveUnitEvent;
        public event NextTeamHandler OnNextTeamEvent;
        private BoardGr _boardGr;
        public TeamViewModel UpperTeamVM { get; set; }
        public TeamViewModel LowerTeamVM { get; set; }
        private List<ChessPiece> _chessPieces = new List<ChessPiece>();

        private Cell _selectedCell;

        private Cell _beginCell;
        private IUnit _beginUnit;
        private bool _onlyAttack = false;
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
        public void ClearAllChessPieces()
        {
            _chessPieces.Clear();
            Invalidate();
        }

        private void GenerateChessPiece(IUnit unit, Cell cell, TeamViewModel model)
        {
            ChessPiece chessPiece;
            if (unit == null) return;
            if (unit is Ranger)
                chessPiece = new RangerGr(unit, cell.Rect);
            else if (unit is Tanker)
                chessPiece = new TankerGr(unit, cell.Rect);
            else if (unit is Ambusher)
                chessPiece = new AmbusherGr(unit, cell.Rect);
            else
                chessPiece = new CampGr(unit, cell.Rect);

            chessPiece.ChessPieceImage = model.SelectedChessPieceImage;
            chessPiece.SelectedColor = model.SelectedColor;
            chessPiece.MovableColor = model.MovableColor;

            _chessPieces.Add(chessPiece);
        }

        private void UpdateChessPiece(IUnit unit, Cell cell)
        {
            var chessPiece = _chessPieces.FirstOrDefault(x => x.Unit.Id == unit.Id);
            chessPiece.Rect = cell.Rect;
            chessPiece.Unit = unit;
            cell.Selected = false;
            _boardGr.RefreshState();
        }
        
        private void RemoveChessPiece(int row, int col)
        {
            var removeChessPiece = _chessPieces.FirstOrDefault(x => x.Unit.Row == row &&
                        x.Unit.Column == col);

            if (removeChessPiece != null)
            {
                _chessPieces.Remove(removeChessPiece);

                if (OnRemoveUnitEvent != null)
                {
                    var type = UnitType.Tanker;
                    if (removeChessPiece.Unit is Ambusher)
                        type = UnitType.Ambusher;
                    else if (removeChessPiece.Unit is Ranger)
                        type = UnitType.Ranger;
                    else if (removeChessPiece.Unit is Camp)
                        type = UnitType.Camp;

                    OnRemoveUnitEvent(type, removeChessPiece.Unit.Team.Name);
                }
            }
        }

        private TeamViewModel GetTeamViewModel(Team team)
        {
            if (UpperTeamVM.Team.Name == team.Name)
                return UpperTeamVM;

            return LowerTeamVM;
        }

        public void DisplayInitAreaLocation()
        {
            //Upper team
            var blocks = GameController.GetInitArea(UpperTeamVM.Team);
            if (blocks != null)
            {
                foreach (var block in blocks)
                {
                    var cell = _boardGr[block.Row, block.Column];
                    if (cell != null)
                    {
                        cell.Movable = true;
                        cell.MovableColor = UpperTeamVM.MovableColor;
                    }
                }
            }

            //Lower team
            blocks = GameController.GetInitArea(LowerTeamVM.Team);
            if (blocks != null)
            {
                foreach (var block in blocks)
                {
                    var cell = _boardGr[block.Row, block.Column];
                    if (cell != null)
                    {
                        cell.Movable = true;
                        cell.MovableColor = LowerTeamVM.MovableColor;
                    }
                }
            }

            Invalidate();
        }

        public void RemoveInitAreaLocation()
        {
            var cells = _boardGr.Cells.Where(x => x.Movable).ToList();
            foreach (var cell in cells)
            {
                cell.Movable = false;
            }

            Invalidate();
        }

        public void RefreshState()
        {
            _selectedCell = null;
            _beginCell = null;
            _beginUnit = null;
            _boardGr.RefreshState();
            Invalidate();
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
                if (GameController.RemoveUnitAt(_selectedCell.Row, _selectedCell.Column))
                {
                    RemoveChessPiece(_selectedCell.Row, _selectedCell.Column);
                    Invalidate();
                }
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
                var model = GetTeamViewModel(unit.Team);
                _boardGr[bl.Row, bl.Column].Movable = true;
                _boardGr[bl.Row, bl.Column].MovableColor = model.MovableColor;
            }
        }

        private void UpdateTargetCells(IUnit unit)
        {
            // draw attackable targets
            var targets = GameController.GetEnemyAround(unit);
            foreach (var target in targets)
            {
                var model = GetTeamViewModel(unit.Team);
                _boardGr[target.Row, target.Column].Attackable = true;
                _boardGr[target.Row, target.Column].AttackableColor = model.AttackableColor;
            }
        }

        private void NextTeam(Team team)
        {
            GameController.NextTeam();
            if (OnNextTeamEvent != null)
                OnNextTeamEvent(team.Name);
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
                        var model = GetTeamViewModel(team);
                        var unit = GenerateUnit(model.SelectedUnitType, Guid.NewGuid());
                        if (GameController.PlaceUnit(team.Name, unit, _selectedCell.Row, _selectedCell.Column))
                        {
                            GenerateChessPiece(unit, _selectedCell, model);
                            if (OnPlaceUnitEvent != null)
                                OnPlaceUnitEvent(model.SelectedUnitType, model.Team.Name);
                        }
                    }
                }
            }
            else if (GameController.State == GameState.Playing)
            {   
                if (_selectedCell != null)
                {
                    if (_beginCell == null) //Select unit
                    {
                        var unit = GameController.GetUnitAt(_selectedCell.Row, _selectedCell.Column);
                        if (unit == null || unit.GetType() == typeof(Camp) || 
                            unit.Team.Name != GameController.CurrentTeam.Name)
                            return;

                        _onlyAttack = false;
                        _beginCell = _selectedCell;
                        _beginCell.Selected = true;
                        _beginUnit = unit;
                        UpdateMovableCells(_beginUnit);
                        UpdateTargetCells(_beginUnit);
                    }
                    else
                    {
                        var unit = GameController.GetUnitAt(_selectedCell.Row, _selectedCell.Column);
                        if (unit == null)
                        {
                            if (!_onlyAttack)
                            {
                                var result = GameController.MakeAMove(_beginUnit, _selectedCell.Row, _selectedCell.Column);
                                if (result) //can move
                                {
                                    //chessPiece
                                    UpdateChessPiece(_beginUnit, _selectedCell);
                                    UpdateTargetCells(_beginUnit);

                                    var enemyUnits = GameController.GetEnemyAround(_beginUnit);
                                    if (enemyUnits == null || enemyUnits.Count <= 0)
                                        NextTeam(_beginUnit.Team);
                                    else //Only attack enemy or next turn
                                    {
                                        _onlyAttack = true;
                                        _selectedCell.Selected = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (unit.Team.Name == GameController.CurrentTeam.Name)
                            {
                                if (!(unit is Camp) && !_onlyAttack)
                                {
                                    if (unit == _beginUnit) //Unselect unit
                                        RefreshState();
                                    else //Change select unit
                                    {
                                        _boardGr.RefreshState();
                                        _beginCell = _selectedCell;
                                        _beginCell.Selected = true;
                                        _beginUnit = unit;
                                        UpdateMovableCells(_beginUnit);
                                        UpdateTargetCells(_beginUnit);
                                    }
                                }
                            }
                            else //attack
                            {
                                if (_beginUnit is Tanker)
                                    GameController.MakeAMove(_beginUnit, -1, -1); // AOE
                                else
                                    GameController.MakeAMove(_beginUnit, _selectedCell.Row, _selectedCell.Column); // single attack

                                RemoveChessPiece(_selectedCell.Row, _selectedCell.Column);
                                UpdateMovableCells(_beginUnit);
                                NextTeam(_beginUnit.Team);
                            }
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
