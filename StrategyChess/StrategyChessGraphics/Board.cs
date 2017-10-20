using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyChess;
using StrategyChess.Definitions;
using System.Drawing;
using System.Windows.Forms;

namespace StrategyChessGraphics
{
    public class Board
    {
        private int _cellSize = 35;
        private int _size;
        private GameController _gameController;
        private List<Cell> _cells;


        
        public Team CurrentTeam
        {
            get { return _gameController.CurrentTeam; }
        }

        public Cell this[int row, int col]
        {
            get { return _cells.FirstOrDefault(x => x.Block.Row == row && x.Block.Column == col); }
        }

        public Board(int size, int maxUnits)
        {
            _gameController = new GameController(size, maxUnits);
            _size = _gameController.BoardSize;
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
                    var block = _gameController.GetBlock(r, c);
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
            var pen = new Pen(Color.Red, 3);
            //Draw base line
            g.DrawLine(pen, 0, _cellSize * 5, _cellSize * _size, _cellSize * 5);

            pen.Color = Color.Blue;
            g.DrawLine(pen, 0, _cellSize * 15, _cellSize * _size, _cellSize * 15);

            foreach (var cell in _cells)
            {
                cell.Draw(g);
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
