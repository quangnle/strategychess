using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using StrategyChessCore;
using StrategyChessCore.Definitions;
using StrategyChessCore.Definitions.Units;

namespace StrategyChessGraphics
{
    public class Cell
    {
        private Rectangle _rect;
        public Color MovableColor { get; set; }
        public Color SelectedColor { get; set; }
        public bool Selected { get; set; }
        public bool Movable { get; set; }
        public bool Attackable { get; set; }
        public Color AttackableColor { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public Rectangle Rect
        {
            get { return _rect; }
        }
        
        public Cell(Rectangle rect, int row, int col)
        {
            _rect = rect;
            Row = row;
            Column = col;
            this.MovableColor = Global.MovableBlueColor;
            this.SelectedColor = Global.SelectedBlueColor;
            this.AttackableColor = Global.AttackableColor;
        }

        public void Draw(Graphics g)
        {
            Brush br = Brushes.White;
            if (Selected)
                br = new SolidBrush(SelectedColor);
            else
            {
                if (Attackable)
                    br = new SolidBrush(this.AttackableColor);
                else if (Movable)
                    br = new SolidBrush(this.MovableColor);
            }
            
            g.FillRectangle(br, _rect);

            var pen = new Pen(Color.Black);
            g.DrawRectangle(pen, _rect);
            pen.Dispose();
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
