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

        public BoardController(Board board)
        {
            _board = board;
        }

        private Team GetTeamOfChessPiece(IChessPiece piece)
        {
            if (_board.UpperTeam.Pieces.Any(p => p.Id == piece.Id)) return _board.UpperTeam;
            return _board.LowerTeam;
        }

        public List<Block> GetAvailableMoves(IChessPiece piece)
        {
            var orgBlock = _board[piece.Id];
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
                    if (aBlock != null && aBlock.ChessPiece == null && !dict.ContainsKey(aBlock))
                    {                        
                        if (dict[b] + 1 <= piece.Speed)
                        {
                            queue.Enqueue(aBlock);
                            dict.Add(aBlock, dict[b] + 1);
                        }   
                    }   
                }
            }

            return dict.Select(db => db.Key).ToList();
        }

        public List<Block> GetAvailableTargets(IChessPiece piece)
        {
            var block = _board[piece.Id];
            var inRangeBlocks = _board.Blocks.Where(b => (block.Column - piece.Range <= 0) && (block.Row - piece.Range <= 0)).ToList();
            var team = GetTeamOfChessPiece(piece);
            var targets = inRangeBlocks.Where(b => b.ChessPiece != null && !team.Pieces.Any(p => p.Id == b.ChessPiece.Id)).ToList();
            return targets;
        }

        public void Move(IChessPiece piece, int row, int col)
        {
            var availMoves = GetAvailableMoves(piece);
            var availTargets = GetAvailableTargets(piece);

            if (availMoves.FirstOrDefault(b => b.Row == row && b.Column == col) != null)
            {
                var block = _board[piece.Id];
                var newBlock = _board[row, col];

                // move the chess piece to new block
                newBlock.ChessPiece = block.ChessPiece;
                block.ChessPiece = null;
            }
            else if (availTargets.FirstOrDefault(b => b.Row == row && b.Column == col) != null)
            {
                var target = _board[row, col].ChessPiece;
                target.HP -= 1;

                // if the chess piece is out of hp, remove it
                if (target.HP == 0)
                {
                    var team = GetTeamOfChessPiece(target);
                    team.Pieces.Remove(target);

                    _board[row, col].ChessPiece = null;
                }
            }
            else
            {
                throw new Exception("Invalid move");
            }
        }

        public Team GetWinner()
        {
            if (_board.UpperTeam.Pieces.Where(p => p.PieceType == ChessPieceType.Base) == null) return _board.LowerTeam;
            if (_board.LowerTeam.Pieces.Where(p => p.PieceType == ChessPieceType.Base) == null) return _board.UpperTeam;
            return null;
        }
    }
}
