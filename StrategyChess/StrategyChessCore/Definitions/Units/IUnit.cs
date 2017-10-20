using System.Collections.Generic;

namespace StrategyChessCore.Definitions.Units
{
    public interface IUnit
    {
        int Id { get; set; }
        int HP { get; set; }
        int Speed { get; set; }
        int Range { get; set; }
        int CoolDown { get; set; }
        int CurrentCoolDown { get; set; }
    }
}