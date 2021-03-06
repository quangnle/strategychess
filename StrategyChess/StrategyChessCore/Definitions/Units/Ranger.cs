﻿using System;
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

        public int Row { get; set; }
        public int Column { get; set; }

        public Team Team { get; set; }

        public Ranger(Guid id)
        {
            Id = id;

            // default values
            HP = GameConfig.RangerHp;
            Speed = GameConfig.RangerSpeed;
            Range = GameConfig.RangerRange;
            CoolDown = GameConfig.RangerCoolDown;
            CurrentCoolDown = 0;
        }
    }
}
