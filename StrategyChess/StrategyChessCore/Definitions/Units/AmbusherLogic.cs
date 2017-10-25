using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions.Units
{
    public class AmbusherLogic : BaseLogic
    {
        public AmbusherLogic(Ambusher unit, BoardHandler boardHandler) : base(unit, boardHandler) { }
    }
}
