using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions
{
    public class Board
    {
        public Block this[int row, int column]
        {
            get { return Blocks.FirstOrDefault(b => b.Row == row && b.Column == column); }
        }

        public int Width { get; internal set; }
        public int Height { get; internal set; }

        public List<Block> Blocks { get; set; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Blocks = new List<Block>();
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    var b = new Block { Row = r, Column = c};
                    Blocks.Add(b);
                }
            }
        }
    }
}
