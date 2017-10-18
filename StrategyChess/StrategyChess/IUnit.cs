using System.Collections.Generic;

namespace StrategyChess
{
    public interface IUnit
    {
        int Id { get; set; }
        int HP { get; set; }
        int Speed { get; set; }
        int Range { get; set; }
        int CoolDown { get; set; }
        int CurrentCoolDown { get; set; }

        List<IUnit> GetTargets(BoardController controller);
        List<Block> GetMovableBlocks(BoardController controller);
    }
}