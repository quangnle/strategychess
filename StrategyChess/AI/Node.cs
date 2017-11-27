using StrategyChessCore.Definitions;
using StrategyChessCore.Definitions.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class Node
    {
        public int Heuristic { get; set; }
        public IUnit SelectedUnit { get; set; }
        public Team OwnTeam { get; set; }
        public Team Oponent { get; set; }
        public List<Node> Children { get; set; }
    }
}
