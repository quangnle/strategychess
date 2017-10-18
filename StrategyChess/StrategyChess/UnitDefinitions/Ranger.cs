using System;
using System.Collections.Generic;

namespace StrategyChess.UnitDefinitions
{
    public class Ranger : IUnit
    {
        public int Id { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public int CoolDown { get; set; }
        public int CurrentCoolDown { get; set; }

        public Ranger(int id, int row, int col)
        {
            Id = id;

            // default values
            HP = 2;
            Speed = 3;
            Range = 5;
            CoolDown = 2;
            CurrentCoolDown = 0;
        }

        /// <summary>
        /// A ranger wont be able to shoot if there is an enemy adjacent to it
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public List<IUnit> GetTargets(BoardController controller)
        {
            var adjacents = controller.GetEnemyAround(this, 1);

            // if there's enemy adjacent to the unit
            if (adjacents != null)
                return null;

            return controller.GetEnemyAround(this, Range);
        }

        public List<Block> GetMovableBlocks(BoardController controller)
        {
            // there might be some logics here
            return controller.GetEmptyGroundBlocksWithinDistance(controller.Board[Id], Speed);
        }
    }
}
