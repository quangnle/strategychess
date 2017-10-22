using StrategyChessCore.Definitions;
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
        public bool Selected { get; set; }
        public Image ChessPieceImage { get; set; }
        public Color SelectedColor { get; set; }

        protected Block _block;
        protected Rectangle _rect;
        public Block Block
        {
            get { return _block; }
        }

        public ChessPiece(Block block, Rectangle rect, bool selected = false)
        {
            _block = block;
            _rect = rect;
            this.Selected = selected;
        }

        public virtual void Draw(Graphics g)
        {   
            DrawHPBar(g);
            DrawCoolDown(g);

            if (Selected)
                DrawBorder(g);
        }

        private void DrawBorder(Graphics g)
        {
            
        }

        private void DrawCoolDown(Graphics g)
        {
            
        }

        private void DrawHPBar(Graphics g)
        {
            
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
