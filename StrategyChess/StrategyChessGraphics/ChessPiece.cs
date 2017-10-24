using StrategyChessCore.Definitions;
using StrategyChessCore.Definitions.Units;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessGraphics
{
    public abstract class ChessPiece
    {
        public Image ChessPieceImage { get; set; }
        public Color SelectedColor { get; set; }
        public Color MovableColor { get; set; }
        protected IUnit _unit;
        protected Rectangle _rect;

        public IUnit Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public ChessPiece(IUnit unit, Rectangle rect)
        {
            _unit = unit;
            _rect = rect;
        }

        public abstract void Draw(Graphics g);

        public void DrawExt(Graphics g)
        {
            DrawCoolDown(g);
            DrawHPBar(g);
        }

        private void DrawCoolDown(Graphics g)
        {
            Brush br = Brushes.Black;
            var xMargin = 1;
            var yMargin = 1;
            var size = 3;
            var yGap = 1;
            for (int i = 0; i < _unit.CurrentCoolDown; i++)
            {
                var x = _rect.X + xMargin;
                var y = (_rect.Y + _rect.Width - yMargin) - (i + 1) * (size * yGap);
                g.FillRectangle(br, new Rectangle(x, y, size, size));
            }
        }

        private void DrawHPBar(Graphics g)
        {
            Brush br = Brushes.Red;
            var xMargin = 1;
            var yMargin = 1;
            var size = 3;
            var yGap = 1;
            for (int i = 0; i < _unit.HP; i++)
            {
                var x = _rect.X + _rect.Width - size - xMargin;
                var y = (_rect.Y + _rect.Width - yMargin) - (i + 1) * (size + yGap);
                g.FillRectangle(br, new Rectangle(x, y, size, size));
            }
        }

        public bool Contains(Point p)
        {
            return _rect.Contains(p);
        }

        public bool Contains(int x, int y)
        {
            return Contains(new Point(x, y));
        }
    }
}
