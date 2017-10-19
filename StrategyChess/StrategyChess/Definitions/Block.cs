using StrategyChess.Definitions.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess.Definitions
{
    public class Block
    {   
        public IUnit Unit { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
