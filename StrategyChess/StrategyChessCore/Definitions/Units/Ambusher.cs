using System;
using System.Collections.Generic;

namespace StrategyChessCore.Definitions.Units
{
    public class Ambusher : IUnit
    {
        public Guid Id { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public int CoolDown { get; set; }
        public int CurrentCoolDown { get; set; }

        public Ambusher(Guid id)
        {
            Id = id;

            // default values
            HP = 3;
            Speed = 4;
            Range = 1;
            CoolDown = 2;
            CurrentCoolDown = 0;
        }
    }
}
