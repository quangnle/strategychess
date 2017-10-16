using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess
{
    public class Block
    {   
        public IChessPiece ChessPiece { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
