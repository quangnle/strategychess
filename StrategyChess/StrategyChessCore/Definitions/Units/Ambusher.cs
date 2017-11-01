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

        public int Row { get; set; }
        public int Column { get; set; }

        public Team Team { get; set; }

        public Ambusher(Guid id)
        {
            Id = id;

            // default values
            HP = GameConfig.AmbusherHp;
            Speed = GameConfig.AmbusherSpeed;
            Range = GameConfig.AmbusherRange;
            CoolDown = GameConfig.AmbusherCoolDown;
            CurrentCoolDown = 0;
        }
    }
}
