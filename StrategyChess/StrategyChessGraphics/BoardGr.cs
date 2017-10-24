using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyChessCore;
using StrategyChessCore.Definitions;
using System.Drawing;
using System.Windows.Forms;
using StrategyChessCore.Definitions.Units;

namespace StrategyChessGraphics
{
    public class BoardGr
    {
        private int _cellSize = 35;
        private int _size;
        private GameController _gameController;
        private List<Cell> _cells;
        private List<Block> _initAreaBlocks;
        private List<Cell> _emptyGroundCells;

        public string CompetitorName { get; set; }
        public string MyName { get; set; }
        public Color MyTeamColor { get; set; }
        public Color CompetitorTeamColor { get; set; }
        
        public GameMode GameMode { get; set; }

        public ChessPieceType ChessPieceType { get; set; }

        public Cell this[int row, int col]
        {
            get { return _cells.FirstOrDefault(x => x.Block.Row == row && x.Block.Column == col); }
        }

        public BoardGr(int size, int maxUnits, int maxCamps)
        {
            _gameController = new GameController(size, maxUnits, maxCamps);
            _size = size;
            Init();
        }

        private void Init()
        {
            _cells = new List<Cell>();

            var y = 0;
            for (int r = 0; r < _size; r++)
            {
                var x = 0;
                for (int c = 0; c < _size; c++)
                {
                    var block = _gameController.GetBlockAt(r, c);
                    var rect = new Rectangle(x, y, _cellSize, _cellSize);
                    var cell = new Cell(block, rect);
                    _cells.Add(cell);
                    x += _cellSize;
                }

                y += _cellSize;
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var cell in _cells)
            {
                cell.Draw(g);
            }

            // draw units
            foreach (var cell in _cells)
            {
                if (cell.ChessPiece != null)
                    cell.ChessPiece.Draw(g);
            }

            // draw hp & cooldown
            foreach (var cell in _cells)
            {
                if (cell.ChessPiece != null)
                    cell.ChessPiece.DrawExt(g);
            }
        }

        public Cell GetCell(Point p)
        {
            return _cells.FirstOrDefault(x => x.Contains(p));
        }

        public Cell GetCell(int x, int y)
        {
            return GetCell(new Point(x, y));
        }

        public Cell GetCellHasUnitByTeam(int x, int y)
        {
            var cell = GetCell(x, y);
            if (cell == null || cell.Block.Unit == null ||
                cell.Block.Unit.Speed == 0) return null;

            if (this.CurrentTeam == null || this.CurrentTeam.Units == null || 
                this.CurrentTeam.Units.Count <= 0) return null;

            if (this.CurrentTeam.Units.Any(u => u.Id == cell.Block.Unit.Id))
            {
                if (_emptyGroundCells != null)
                {
                    foreach (var emptyCell in _emptyGroundCells)
                    {
                        emptyCell.Movable = false;
                    }

                    _emptyGroundCells.Clear();
                    _emptyGroundCells = null;
                }

                var emptyGroundBlocks = _gameController.GetMovableBlocks(cell.Block.Unit);
                if (emptyGroundBlocks != null && emptyGroundBlocks.Count > 0)
                {
                    _emptyGroundCells = _cells.Where(u => emptyGroundBlocks.Any(e => e.Row == u.Block.Row &&
                        e.Column == u.Block.Column)).ToList();

                    foreach  (var c in _emptyGroundCells)
                    {
                        c.Movable = true;
                        c.MovableColor = cell.ChessPiece.MovableColor;
                    }
                }

                return cell;
            }

            return null;
        }
        
        public Team CurrentTeam
        {
            get { return _gameController.CurrentTeam; }
        }

        public void ShowInitArea()
        {
            var team = _gameController.GetTeamByName(this.MyName);
            if (team != null)
                _initAreaBlocks = _gameController.GetInitArea(team);

            if (_initAreaBlocks == null)
                _initAreaBlocks = new List<Block>();

            if (this.GameMode == GameMode.Single)
            {
                team = _gameController.GetTeamByName(this.CompetitorName);
                if (team != null)
                {
                    var blocks = _gameController.GetInitArea(team);
                    if (blocks != null)
                        _initAreaBlocks.AddRange(blocks);
                }
            }

            foreach (var block in _initAreaBlocks)
            {
                var cell = _cells.FirstOrDefault(x => x.Block.Row == block.Row && x.Block.Column == block.Column);
                if (cell != null)
                {
                    cell.Movable = true;
                    if (cell.Block.Row < 5)
                    {
                        cell.MovableColor = this.ChessPieceType == ChessPieceType.Blue ? Global.MovableGreenColor :
                            Global.MovableBlueColor;
                    }
                    else
                    {
                        cell.MovableColor = this.ChessPieceType == ChessPieceType.Blue ? Global.MovableBlueColor :
                            Global.MovableGreenColor;
                    }
                }
            }
        }

        public void ClearShowInitArea()
        {
            if (_initAreaBlocks != null && _initAreaBlocks.Count > 0)
            {
                foreach (var block in _initAreaBlocks)
                {
                    var cell = _cells.FirstOrDefault(x => x.Block.Row == block.Row && x.Block.Column == block.Column);
                    if (cell != null)
                        cell.Movable = false;
                }
            }
        }

        public Team GetTeamByName(string teamName)
        {
            return _gameController.GetTeamByName(teamName);
        }

        public Team GetTeamInitArea(int row, int col)
        {
            if (_initAreaBlocks != null)
            {
                var block = _initAreaBlocks.FirstOrDefault(x => x.Row == row && x.Column == col);
                if (block != null)
                {
                    if (row < 5)
                        return _gameController.GetTeamByName(this.CompetitorName);
                    else
                        return _gameController.GetTeamByName(this.MyName);
                }
            }

            return null;
        }

        public void Register(string teamName)
        {
            _gameController.Register(teamName);
        }

        public bool GetReady(Team team)
        {
            return _gameController.GetReady(team);
        }

        public bool PlaceUnit(Team team, IUnit unit, int row, int col)
        {
            return _gameController.PlaceUnit(team.Name, unit, row, col);
        }

        public bool RemoveUnitAt(int row, int col)
        {
            return _gameController.RemoveUnitAt(row, col);
        }

        public bool MakeAMove(IUnit unit, int row, int col)
        {
            return _gameController.MakeAMove(unit, row, col);
        }

        public bool StartGame()
        {
            return _gameController.StartGame();
        }

        public void ClearAllSelectOfTeam(Team team)
        {
            if (team.Units == null || team.Units.Count <= 0)
                return;

            var cells = _cells.Where(x => x.Block.Unit != null &&
                team.Units.Contains(x.Block.Unit) && x.Selected).ToList();

            foreach (var cell in cells)
            {
                cell.Selected = false;
            }
        }

        public void ClearAllSelects()
        {
            var cells = _cells.Where(x => x.Block.Unit != null && x.Selected).ToList();
            foreach (var cell in cells)
            {
                cell.Selected = false;
            }
        }
    }
}
