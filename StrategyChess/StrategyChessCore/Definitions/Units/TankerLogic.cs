using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions.Units
{
    public class TankerLogic : BaseLogic
    {
        public TankerLogic(Tanker unit, BoardHandler boardHandler) : base(unit, boardHandler) { }

        public override bool Attack(int row, int col)
        {
            if (row == - 1 && col == -1)
            {
                var targets = GetAllTargets();
                if (targets != null)
                {
                    foreach (var target in targets)
                    {
                        target.HP--;
                        if (target.HP == 0)
                        {
                            var team = target.Team;
                            team.Units.Remove(target);
                        }
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
