using StrategyChessCore.Definitions.Units;
using System.Collections.Generic;

namespace StrategyChessCore.Definitions
{
    public class Team
    {
        public string Name { get; set; }
        public List<IUnit> Units { get; set; }
        public bool Ready { get; set; }
    }
}