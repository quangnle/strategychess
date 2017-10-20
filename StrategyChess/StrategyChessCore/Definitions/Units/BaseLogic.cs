using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions.Units
{
    public abstract class BaseLogic
    {
        public BoardHandler BoardHandler { get; set; }

        public abstract List<IUnit> GetAllTargets(IUnit unit);

        public abstract List<Block> GetAllMoveableBlocks(IUnit unit);
    }
}
