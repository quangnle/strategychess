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
            if (Unit.CurrentCoolDown > 0) return null;

            var adjacents = BoardHandler.GetEnemyAround(Unit, 1);

            // if there's enemy adjacent to the unit
            if (adjacents != null && adjacents.Count > 0)
            {
                Unit.CurrentCoolDown = Unit.CurrentCoolDown == Unit.CoolDown ? Unit.CoolDown : 2;
                return null;
            }

            return BoardHandler.GetEnemyAround(Unit, Unit.Range);
        }
    }
}
