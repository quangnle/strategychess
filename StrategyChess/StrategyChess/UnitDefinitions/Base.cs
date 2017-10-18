using System;
using System.Collections.Generic;

namespace StrategyChess.UnitDefinitions
{
    public class Base : IUnit
    {
        public int Id { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public int CoolDown { get; set; }
        public int CurrentCoolDown { get; set; }

        public Base(int id, int row, int col)
        {
            Id = id;

            // default values
            HP = 5;
            Speed = 0;
            Range = 0;
            CoolDown = 0;
            CurrentCoolDown = 0;
        }

        public List<IUnit> GetTargets(BoardController controller)
        {
            return null;
        }

        public List<Block> GetMovableBlocks(BoardController controller)
        {
            return null;
        }
    }
}
