using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions.Units
{
    public delegate void CampDestroyedHandler(Team team);

    public abstract class BaseLogic
    {
        protected IUnit Unit { get; set; }
        protected BoardHandler BoardHandler { get; set; }

        public CampDestroyedHandler OnCampDestroyed;

        public BaseLogic(IUnit unit, BoardHandler boardHandler)
        {
            Unit = unit;
            BoardHandler = boardHandler;
        }

        public virtual List<IUnit> GetAllTargets(int row, int col)
        {
            if (Unit.CurrentCoolDown > 0) return null;
            var team = BoardHandler.GetOpponent(Unit.Team);
            var enemies = TeamHandler.GetUnitsAround(team, row, col, Unit.Range);
            return enemies;
        }

        public virtual List<IUnit> GetAllTargets()
        {
            if (Unit.CurrentCoolDown > 0) return null;
            return BoardHandler.GetEnemyAround(Unit, Unit.Range);
        }

        public virtual List<Block> GetAllMovableBlocks(int row, int col)
        {
            return BoardHandler.GetEmptyGroundBlocksWithinDistance(BoardHandler.Board[row, col], Unit.Speed);
        }

        public virtual List<Block> GetAllMoveableBlocks()
        {
            return BoardHandler.GetEmptyGroundBlocksWithinDistance(BoardHandler.Board[Unit.Row, Unit.Column], Unit.Speed);
        }

        public virtual bool Attack(int row, int col)
        {   
            var target = GetAllTargets().FirstOrDefault(u => u.Row == row && u.Column == col);
            if (target != null)
            {
                target.HP--;
                if (target.HP == 0)
                {
                    if (target is Camp && OnCampDestroyed != null)
                    {
                        OnCampDestroyed(Unit.Team);
                    }

                    var team = target.Team;
                    team.Units.Remove(target);
                }
                Unit.CurrentCoolDown = Unit.CoolDown;
                return true;
            }

            return false;
        }

        public virtual bool Move(int row, int col)
        {
            var moveableBlocks = GetAllMoveableBlocks();
            if (moveableBlocks.Exists(b => b.Row == row && b.Column == col))
            {
                Unit.Row = row;
                Unit.Column = col;
                return true;
            }

            return false;
        }
    }
}
