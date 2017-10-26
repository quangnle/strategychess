using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions.Units
{
    public class RangerLogic : BaseLogic
    {
        public RangerLogic(Ranger unit, BoardHandler boardHandler) : base(unit, boardHandler) { }

        /// <summary>
        /// A ranger wont be able to shoot if there is an enemy adjacent to it
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public override List<IUnit> GetAllTargets()
        {
            var adjacents = BoardHandler.GetEnemyAround(Unit, 1);

            // if there's enemy adjacent to the unit
            if (adjacents != null && adjacents.Count > 0)
            {
                Unit.CurrentCoolDown = Unit.CurrentCoolDown == 2 ? 2 : 1;
                return null;
            }

            return BoardHandler.GetEnemyAround(Unit, Unit.Range);
        }
    }
}
