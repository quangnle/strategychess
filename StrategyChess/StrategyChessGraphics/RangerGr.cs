using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyChessCore.Definitions;
using StrategyChessCore.Definitions.Units;

namespace StrategyChessGraphics
{
    public class RangerGr : ChessPiece
    {
        public RangerGr(IUnit unit, Rectangle rect) : base(unit, rect)
        {
        }

        public override void Draw(Graphics g)
        {
            if (this.ChessPieceImage != null)
                g.DrawImage(this.ChessPieceImage, _rect.Location);
        }
    }
}
