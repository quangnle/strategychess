using System;
using System.Collections.Generic;

namespace StrategyChessCore.Definitions.Units
{
    public interface IUnit
    {
        Guid Id { get; set; }
        int HP { get; set; }
        int Speed { get; set; }
        int Range { get; set; }
        int CoolDown { get; set; }
        int CurrentCoolDown { get; set; }

        int Row { get; set; }
        int Column { get; set; }

        Team Team { get; set; }
    }
}