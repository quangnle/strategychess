﻿using System;
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
        private int _cellWidth = 35;
        private int _cellHeight = 35;
        private int _width;
        private int _height;
        private List<Cell> _cells;
        private Font _font = new Font("Arial", 9);

        public List<Cell> Cells
        {
            get { return _cells; }
        }

        public Cell this[int row, int col]
        {
            get { return _cells.FirstOrDefault(x => x.Row == row && x.Column == col); }
        }

        public BoardGr(int width, int height, int cellWidth, int cellHeight)
        {
            _width = width;
            _height = height;
            _cellWidth = cellWidth;
            _cellHeight = cellHeight;
            Init();
        }

        private void Init()
        {
            _cells = new List<Cell>();

            var y = 0;
            for (int r = 0; r < _height; r++)
            {
                var x = 0;
                for (int c = 0; c < _width; c++)
                {
                    var rect = new Rectangle(x, y, _cellWidth, _cellHeight);
                    var cell = new Cell(rect, r, c);
                    _cells.Add(cell);
                    x += _cellWidth;
                }

                y += _cellHeight;
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
            var right = (_width * _cellWidth) + 5;
            var bottom = (_height * _cellHeight) + 5;
            
            for (int i = 0; i < _height; i++)
            {
                var yy = y + (_cellHeight / 2) - 5;
                g.DrawString($"{i + 1}", _font, Brushes.Black, new Point(right, yy));
                y += _cellHeight;
            }

            for (int i = 0; i < _width; i++)
            {
                var xx = x + (_cellWidth / 2) - 10;
                g.DrawString($"{i + 1}", _font, Brushes.Black, new Point(xx, bottom));
                x += _cellWidth;
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

        public void RefreshState()
        {
            foreach (var cell in _cells)
            {
                cell.Selected = false;
                cell.Movable = false;
                cell.Attackable = false;
            }
        }
    }
}
