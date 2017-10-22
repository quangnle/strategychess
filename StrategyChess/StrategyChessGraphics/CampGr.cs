using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyChessCore.Definitions;

namespace StrategyChessGraphics
{
    public class CampGr : ChessPiece
    {
        public CampGr(Block block, Rectangle rect, bool selected = false) : base(block, rect, selected)
        {
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            if (this.ChessPieceImage != null)
                g.DrawImage(this.ChessPieceImage, _rect.Location);
        }
    }
}
