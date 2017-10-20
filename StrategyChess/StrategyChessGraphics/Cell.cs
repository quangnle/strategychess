using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using StrategyChess;
using StrategyChess.Definitions;

namespace StrategyChessGraphics
{
    public class Cell
    {
        public bool Selected { get; set; }
        private Block _block;
        public Block Block
        {
            get { return _block; }
        }

        private Rectangle _rect;
        public Cell(Block block, Rectangle rect, bool selected = false)
        {
            _block = block;
            _rect = rect;
            this.Selected = selected;
        }

        public void Draw(Graphics g)
        {
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
