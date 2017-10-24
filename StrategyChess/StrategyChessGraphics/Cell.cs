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
        public ChessPiece ChessPiece { get; set; }
        public void InitChecssPiece(IUnit unit, Image chessPieceImage, Color selectedColor, Color movableColor)
        {
            if (unit == null) return;
            if (unit is Ranger)
                ChessPiece = new RangerGr(unit, new Rectangle(_rect.Location, _rect.Size));
            else if (unit is Tanker)
                ChessPiece = new TankerGr(unit, new Rectangle(_rect.Location, _rect.Size));
            else if (unit is Ambusher)
                ChessPiece = new AmbusherGr(unit, new Rectangle(_rect.Location, _rect.Size));
            else
                ChessPiece = new CampGr(unit, new Rectangle(_rect.Location, _rect.Size));

            ChessPiece.ChessPieceImage = chessPieceImage;
            ChessPiece.SelectedColor = selectedColor;
            ChessPiece.MovableColor = movableColor;
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
            {
                if (ChessPiece != null)
                    br = new SolidBrush(ChessPiece.SelectedColor);
                else
                    br = new SolidBrush(SelectedColor);
            }
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

        public void RemoveChessPiece()
        {
            this.ChessPiece = null;
        }
    }
}
