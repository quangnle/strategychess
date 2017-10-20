using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions.Units
{
    public class TankerLogic : BaseLogic
    {
        public override List<Block> GetAllMoveableBlocks(IUnit unit)
        {
            return BoardHandler.GetEmptyGroundBlocksWithinDistance(BoardHandler.Board[unit.Id], unit.Speed);
        }

        public override List<IUnit> GetAllTargets(IUnit unit)
        {
            return BoardHandler.GetEnemyAround(unit, unit.Range);
        }
    }
}
