using System.Collections.Generic;

namespace StrategyChess.Definitions.Units
{
    public class Ambusher : IUnit
    {
        public int Id { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public int CoolDown { get; set; }
        public int CurrentCoolDown { get; set; }

        public Ambusher(int id, int row, int col)
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
