using StrategyChessCore.Definitions.Units;
using System.Collections.Generic;

namespace StrategyChessCore.Definitions
{
    public class Team
    {
        public string Name { get; set; }
        public List<IUnit> Units { get; set; }
        public bool Ready { get; set; }

        public List<IUnit> ActionableUnits { get; set; }

        public bool CanMoveUnit { get; set; }

        public Team()
        {
            this.Units = new List<IUnit>();
            this.ActionableUnits = new List<IUnit>();
        }
    }
}