using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyChessCore.Definitions;

namespace StrategyChessGraphics
{
    public class TankerGr : ChessPiece
    {
        public TankerGr(Block block, Rectangle rect, bool selected = false) : base(block, rect, selected)
        {
        }

        public override void Draw(Graphics g)
        {
            var img = Image.FromFile("tanker.png");
            g.DrawImage(img, _rect);
        }
    }
}
