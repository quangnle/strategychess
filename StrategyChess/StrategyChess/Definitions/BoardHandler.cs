using StrategyChess.Definitions.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess.Definitions
{
    public class BoardHandler
    {
        private Board _board;
        public Board Board
        {
            get { return _board; }
        }

        public Team UpperTeam { get; set; }
        public Team LowerTeam { get; set; }

        public BoardHandler(Board board)
        {
            _board = board;
        }


        public Team GetTeamByName(string teamName)
        {
            if (UpperTeam.Name == teamName) return UpperTeam;
            else if (LowerTeam.Name == teamName) return LowerTeam;
            return null;
        }

        public Team GetTeam(IUnit unit)
        {
            if (UpperTeam.Units.Any(p => p.Id == unit.Id)) return UpperTeam;
            else if (LowerTeam.Units.Any(p => p.Id == unit.Id)) return LowerTeam;
            return null;
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

        public List<IUnit> GetEnemyAround(IUnit unit, int radius)
        {
            var team = GetTeam(unit);
            var aroundUnits = GetBlocksAround(_board[unit.Id], radius, false).Where(b => b.Unit != null).Select(b => b.Unit);
            var enemies = aroundUnits.Where(u => !team.Units.Exists(un => un.Id == u.Id)).ToList();
            return enemies;
        }

        public Team GetWinner()
        {
            if (UpperTeam.Units.Where(p => p is Camp) == null) return LowerTeam;
            if (LowerTeam.Units.Where(p => p is Camp) == null) return UpperTeam;
            return null;
        }
    }
}
