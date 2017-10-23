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
        public Color MovableColor { get; set; }
        public Color SelectedColor { get; set; }
        public bool Selected { get; set; }
        public bool Movable { get; set; }
        public bool Attackable { get; set; }
        public Color AttackableColor { get; set; }

        public ChessPiece ChessPiece { get; internal set; }
        
        public Block Block
        {
            get { return _block; }
            set { _block = value; }
        }

        public void InitChecssPiece(Image chessPieceImage, Color selectedColor, Color movableColor)
        {
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

                ChessPiece.ChessPieceImage = chessPieceImage;
                ChessPiece.SelectedColor = selectedColor;
                ChessPiece.MovableColor = movableColor;
            }
        }

        public Cell(Block block, Rectangle rect, bool selected = false)
        {
            Block = block;
            _rect = rect;
            this.Selected = selected;
            this.MovableColor = Global.MovableBlueColor;
            this.SelectedColor = Global.SelectedBlueColor;
            this.AttackableColor = Global.AttackableColor;
        }

        public void Draw(Graphics g)
        {
            var pen = new Pen(Color.Black);
            g.DrawRectangle(pen, _rect);
            pen.Dispose();

            Brush br;
            if (Selected)
            {
                if (ChessPiece != null)
                    br = new SolidBrush(ChessPiece.SelectedColor);
                else
                    br = new SolidBrush(SelectedColor);

                g.FillRectangle(br, _rect);
            }
            else
            {
                if (Attackable)
                {
                    br = new SolidBrush(this.AttackableColor);
                    g.FillRectangle(br, _rect.Location.X + 1, _rect.Location.Y + 1, _rect.Width - 2, _rect.Height - 2);
                }
                else if (Movable)
                {
                    br = new SolidBrush(this.MovableColor);
                    g.FillRectangle(br, _rect.Location.X + 1, _rect.Location.Y + 1, _rect.Width - 2, _rect.Height - 2);
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

        public void RemoveChessPiece()
        {
            this.ChessPiece = null;
        }
    }
}
