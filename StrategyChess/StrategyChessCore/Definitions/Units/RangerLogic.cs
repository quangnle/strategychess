using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions.Units
{
    public class RangerLogic : BaseLogic
    {
        public override List<Block> GetAllMoveableBlocks(IUnit unit)
        {
            return BoardHandler.GetEmptyGroundBlocksWithinDistance(BoardHandler.Board[unit.Id], unit.Speed);
        }

        /// <summary>
        /// A ranger wont be able to shoot if there is an enemy adjacent to it
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public override List<IUnit> GetAllTargets(IUnit unit)
        {
            var adjacents = BoardHandler.GetEnemyAround(unit, 1);

            // if there's enemy adjacent to the unit
            if (adjacents != null)
                return null;

            return BoardHandler.GetEnemyAround(unit, unit.Range);
        }
    }
}
