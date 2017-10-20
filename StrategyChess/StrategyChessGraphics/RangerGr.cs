using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyChessCore.Definitions;

namespace StrategyChessGraphics
{
    public class RangerGr : ChessPiece
    {
        public RangerGr(Block block, Rectangle rect, bool selected = false) : base(block, rect, selected)
        {
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
