﻿
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

        public int Row { get; set; }
        public int Column { get; set; }

        public Team Team { get; set; }

        public Tanker(Guid id)
        {
            Id = id;

            // default values
            HP = GameConfig.TankerHp;
            Speed = GameConfig.TankerSpeed;
            Range = GameConfig.TankerRange;
            CoolDown = GameConfig.TankerCoolDown;
            CurrentCoolDown = 0;
        }
    }
}
