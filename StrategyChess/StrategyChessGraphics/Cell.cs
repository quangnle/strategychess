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
        private Block _block;

        public bool Selected { get; set; }
        public bool Movable { get; set; }
        public bool Attackable { get; set; }

        public ChessPiece ChessPiece { get; internal set; }
        
        public Block Block
        {
            get { return _block; }
            set
            {
                _block = value;
                if (_block.Unit != null)
                {
                    if (_block.Unit is Ranger)
                        ChessPiece = new RangerGr(_block, new Rectangle(_rect.Location, _rect.Size));
                    else if (_block.Unit is Tanker)
                        ChessPiece = new TankerGr(_block, new Rectangle(_rect.Location, _rect.Size));
                    else if (_block.Unit is Ambusher)
                        ChessPiece = new AmbusherGr(_block, new Rectangle(_rect.Location, _rect.Size));
                    else
                        ChessPiece = new CampGr(_block, new Rectangle(_rect.Location, _rect.Size));
                }
            }
        }

        public Cell(Block block, Rectangle rect, bool selected = false)
        {
            Block = block;
            _rect = rect;
            this.Selected = selected;
        }

        public void Draw(Graphics g)
        {
            var pen = new Pen(Color.Black);
            g.DrawRectangle(pen, _rect);
            pen.Dispose();

            Brush br;
            if (Selected)
            {
                br = Brushes.Blue;
            }
            else
            {
                if (Movable)
                {
                    br = Brushes.LightGreen;
                }
                else if (Attackable)
                {
                    br = Brushes.Red;
                }
            }
            
            // draw a filled rectangle here with selected brush

            if (ChessPiece != null)
            {
                ChessPiece.Draw(g);
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
