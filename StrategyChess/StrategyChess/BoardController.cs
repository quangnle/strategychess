using StrategyChess.UnitDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess
{
    public class BoardController
    {
        private Board _board;
        public Board Board
        {
            get { return _board; }
        }

        public BoardController(Board board)
        {
            _board = board;
        }

        public Team GetTeam(IUnit unit)
        {
            if (_board.UpperTeam.Units.Any(p => p.Id == unit.Id)) return _board.UpperTeam;
            return _board.LowerTeam;
        }

        public List<Block> GetEmptyGroundBlocksWithinDistance(Block orgBlock, int distance)
        {   
            var queue = new Queue<Block>();

            var dx = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
            var dy = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            var dict = new Dictionary<Block, int>();

            queue.Enqueue(orgBlock);

            while (queue.Count > 0)
            {
                var b = queue.Dequeue();
                for (int i = 0; i < 8; i++)
                {
                    var aBlock = _board[b.Row + dx[i], b.Column + dy[i]];
                    if (aBlock != null && aBlock.Unit == null && !dict.ContainsKey(aBlock))
                    {                        
                        if (dict[b] + 1 <= distance)
                        {
                            queue.Enqueue(aBlock);
                            dict.Add(aBlock, dict[b] + 1);
                        }   
                    }   
                }
            }

            return dict.Select(db => db.Key).ToList();
        }

        public List<Block> GetBlocksAround(Block block, int radius, bool emptyBlocksOnly)
        {   
            var inRangeBlocks = _board.Blocks.Where(b => (block.Column - radius <= 0) && (block.Row - radius <= 0));
            if (emptyBlocksOnly)
                inRangeBlocks = inRangeBlocks.Where(b => b.Unit == null);
            return inRangeBlocks.ToList();
        }

        public List<IUnit> GetAllyAround(IUnit unit, int radius)
        {
            var team = GetTeam(unit);
            var aroundUnits = GetBlocksAround(_board[unit.Id], radius, false).Where(b => b.Unit != null).Select(b => b.Unit);
            var allies = aroundUnits.Where(u => team.Units.Exists(un => un.Id == u.Id)).ToList();
            return allies;
        }

        public List<IUnit> GetEnemyAround(IUnit unit, int radius)
        {
            var team = GetTeam(unit);
            var aroundUnits = GetBlocksAround(_board[unit.Id], radius, false).Where(b => b.Unit != null).Select(b => b.Unit);
            var enemies = aroundUnits.Where(u => !team.Units.Exists(un => un.Id == u.Id)).ToList();
            return enemies;
        }

        public Team GetWinner()
        {
            if (_board.UpperTeam.Units.Where(p => p is Base) == null) return _board.LowerTeam;
            if (_board.LowerTeam.Units.Where(p => p is Base) == null) return _board.UpperTeam;
            return null;
        }
    }
}
