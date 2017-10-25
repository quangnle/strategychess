using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore
{
    public enum GameState : int
    {
        Init = 0,
        Playing = 1,
        CampDestroyed = 2,
        End = 3
    }
}
