using StrategyChess.Definitions.Units;
using System.Collections.Generic;

namespace StrategyChess.Definitions
{
    public class Team
    {
        public string Name { get; set; }
        public List<IUnit> Units { get; set; }
    }
}