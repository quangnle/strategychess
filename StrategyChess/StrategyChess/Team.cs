using System.Collections.Generic;

namespace StrategyChess
{
    public class Team
    {
        public string Name { get; set; }
        public List<IChessPiece> Pieces { get; set; }
    }
}