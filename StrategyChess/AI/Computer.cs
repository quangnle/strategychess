using StrategyChessCore.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class Computer
    {
        public Computer(int boardHeight, int boardWidth)
        {

        }

        public Node GetNextMove(string teamName, Team upperTeam, Team lowerTeam)
        {
            return null;
        }

        private List<Node> GenNextNodes(Node node)
        {
            return null;
        }

        private int Heuristic(Node node)
        {
            return -1;
        }
    }
}