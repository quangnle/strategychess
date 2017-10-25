using System;
using System.Collections.Generic;

namespace StrategyChessCore.Definitions.Units
{
    public class Camp : IUnit
    {
        public Guid Id { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public int CoolDown { get; set; }
        public int CurrentCoolDown { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }

        public Team Team { get; set; }

        public Camp(Guid id)
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
