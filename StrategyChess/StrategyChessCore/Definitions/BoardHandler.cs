using StrategyChessCore.Definitions.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions
{
    public class BoardHandler
    {
        private Board _board;
        private Team _upperTeam;
        private Team _lowerTeam;

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

        public IUnit GetUnitAt(int row, int col)
        {
            var unit = TeamHandler.GetUnitAt(_upperTeam, row, col);
            if (unit == null)
                unit = TeamHandler.GetUnitAt(_lowerTeam, row, col);

            return unit;
        }

        public IUnit GetUnitAt(Block block)
        {
            return GetUnitAt(block.Row, block.Column);
        }

        public List<Block> GetInitArea(Team team)
        {   
            int fromRow, toRow, fromCol, toCol;

            if (team.Name == UpperTeam.Name)
            {
                fromRow = 0;
                toRow = _board.Size / 4;
                fromCol = 0;
                toCol = _board.Size;
            }
            else
            {
                fromRow = _board.Size * 3 / 4;
                toRow = _board.Size;
                fromCol = 0;
                toCol = _board.Size;
            }

            var result = _board.Blocks.Where(b => (b.Column >= fromCol && b.Column < toCol) && 
                                                    (b.Row >= fromRow && b.Row < toRow) && 
                                                    GetUnitAt(b) == null).ToList();
            return result;
        }


        public Team GetTeamByName(string teamName)
        {
            if (UpperTeam.Name == teamName) return UpperTeam;
            else if (LowerTeam.Name == teamName) return LowerTeam;
            return null;
        }
        
        public List<Block> GetEmptyGroundBlocksWithinDistance(Block orgBlock, int distance)
        {   
            var queue = new Queue<Block>();

            var dx = new int[] { 0, -1, 1, 0 };
            var dy = new int[] { -1, 0, 0, 1 };
            var dict = new Dictionary<Block, int>();

            queue.Enqueue(orgBlock);

            while (queue.Count > 0)
            {
                var b = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    var aBlock = _board[b.Row + dx[i], b.Column + dy[i]];
                    if (aBlock != null && GetUnitAt(aBlock) == null && !dict.ContainsKey(aBlock))
                    {
                        var d = 0;
                        if (dict.ContainsKey(b))
                            d = dict[b];
                                        
                        if (d + 1 <= distance)
                        {
                            queue.Enqueue(aBlock);
                            dict.Add(aBlock, d + 1);
                        }   
                    }   
                }
            }

            return dict.Select(db => db.Key).ToList();
        }

        public List<Block> GetEmptyBlocksAround(Block block, int radius)
        {   
            var inRangeBlocks = _board.Blocks.Where(b => (block.Column - radius <= 0) && (block.Row - radius <= 0) && GetUnitAt(b) == null).ToList();
            return inRangeBlocks;
        }

        private Team GetOpponent(Team team)
        {
            if (team.Name == _upperTeam.Name)
                return _lowerTeam;
            return _upperTeam;
        }

        public List<IUnit> GetEnemyAround(IUnit unit, int radius)
        {
            var team = GetOpponent(unit.Team);
            var enemies = TeamHandler.GetUnitsAround(team, unit.Row, unit.Column, radius);
            return enemies;
        }

        public Team GetWinner()
        {
            if (UpperTeam.Units.Count(p => p is Camp) == 0) return LowerTeam;
            if (LowerTeam.Units.Count(p => p is Camp) == 0) return UpperTeam;
            return null;
        }
    }
}
