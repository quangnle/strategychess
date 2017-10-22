
using System;
using System.Collections.Generic;

namespace StrategyChessCore.Definitions.Units
{
    public class Tanker : IUnit
    {
        public Guid Id { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public int CoolDown { get; set; }
        public int CurrentCoolDown { get; set; }

        public Tanker(Guid id)
        {
            Id = id;

            // default values
            HP = 5;
            Speed = 1;
            CoolDown = 2;
            CurrentCoolDown = 0;
        }
    }
}
