using System;
using System.Collections.Generic;

namespace StrategyChessCore.Definitions.Units
{
    public class Ranger : IUnit
    {
        public Guid Id { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public int CoolDown { get; set; }
        public int CurrentCoolDown { get; set; }

        public Ranger(Guid id)
        {
            Id = id;

            // default values
            HP = 2;
            Speed = 3;
            Range = 5;
            CoolDown = 2;
            CurrentCoolDown = 0;
        }
    }
}
