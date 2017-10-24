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
        private List<Cell> _cells;
        private List<Block> _initAreaBlocks;
        private List<Cell> _emptyGroundCells;
        private Font _font = new Font("Arial", 9);

        public Team OwnTeam { get; set; }
        public Team Opponent { get; set; }

        public string CompetitorName { get; set; }
        public string MyName { get; set; }
        public Color MyTeamColor { get; set; }
        public Color CompetitorTeamColor { get; set; }
        
        public GameMode GameMode { get; set; }

        public ChessPieceType ChessPieceType { get; set; }

        public Cell this[int row, int col]
        {
            get { return _cells.FirstOrDefault(x => x.Row == row && x.Column == col); }
        }

        public BoardGr(int size)
        {
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
                    var rect = new Rectangle(x, y, _cellSize, _cellSize);
                    var cell = new Cell(rect, r, c);
                    _cells.Add(cell);
                    x += _cellSize;
                }

                y += _cellSize;
            }
        }

        public void Draw(Graphics g)
        {
            // draw cells
            foreach (var cell in _cells)
            {
                cell.Draw(g);
            }

            // draw index
            var x = 0;
            var y = 0;
            var right = (_size * _cellSize) + 5;
            var bottom = (_size * _cellSize) + 5;
            
            for (int i = 0; i < _size; i++)
            {
                g.DrawString($"{i + 1}", _font, Brushes.Black, new Point(right, y + 8));
                g.DrawString($"{i + 1}", _font, Brushes.Black, new Point(x + 8, bottom));
                y += _cellSize;
                x += _cellSize;
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
    }
}
