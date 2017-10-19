using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess.Definitions.Units
{
    public abstract class BaseLogic
    {
        public BoardHandler BoardHandler { get; set; }

        public void Attack(IUnit unit, int row, int col)
        {
            var targets = GetAllTargets(unit);

            if (targets != null && targets.Count > 0)
            {

                if (row == -1 && col == -1)
                {
                    for (int i = 0; i < targets.Count; i++)
                    {
                        targets[i].HP -= 1;
                        if (targets[i].HP <= 0)
                        {
                            BoardHandler.Board[targets[i].Id].Unit = null;
                            BoardHandler.GetTeam(targets[i]).Units.Remove(targets[i]);
                        }
                    }
                }
                else
                {
                    var tUnit = BoardHandler.Board[row, col].Unit;
                    var target = targets.FirstOrDefault(t => t.Id == tUnit.Id);

                    target.HP -= 1;
                    if (target.HP <= 0)
                    {
                        BoardHandler.Board[target.Id].Unit = null;
                        BoardHandler.GetTeam(target).Units.Remove(target);
                    }
                }
            } 

            unit.CurrentCoolDown = 0;
        }

        public abstract List<IUnit> GetAllTargets(IUnit unit);

        public abstract List<Block> GetAllMoveableBlocks(IUnit unit);

        internal void Move(IUnit unit, int row, int col)
        {
            throw new NotImplementedException();
        }
    }
}
