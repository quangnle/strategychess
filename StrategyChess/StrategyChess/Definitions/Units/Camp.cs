using System;
using System.Collections.Generic;

namespace StrategyChess.Definitions.Units
{
    public class Camp : IUnit
    {
        public int Id { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public int CoolDown { get; set; }
        public int CurrentCoolDown { get; set; }

        public Camp(int id, int row, int col)
        {
            Id = id;

            // default values
            HP = 5;
            Speed = 0;
            Range = 0;
            CoolDown = 0;
            CurrentCoolDown = 0;
        }
    }
}
