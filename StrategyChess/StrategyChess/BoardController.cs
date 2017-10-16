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

        private List<Block> GetAllAroundingBlocks(IChessPiece piece, int radius)
        {
            var block = _board[piece.Id];
            return _board.Blocks.Where(b => (block.Column - radius <= 0) && (block.Row - radius <= 0)).ToList();
        }

        private Team GetTeamOfChessPiece(IChessPiece piece)
        {
            if (_board.UpperTeam.Pieces.Any(p => p.Id == piece.Id)) return _board.UpperTeam;
            return _board.LowerTeam;
        }

        public List<Block> GetAvailableMoves(IChessPiece piece)
        {
            var availableBlocks = GetAllAroundingBlocks(piece, piece.Speed);
            return availableBlocks.Where(b => b.ChessPiece == null).ToList();
        }

        public List<Block> GetAvailableTargets(IChessPiece piece)
        {
            var availableBlocks = GetAllAroundingBlocks(piece, piece.Range);
            var team = GetTeamOfChessPiece(piece);
            var targets = availableBlocks.Where(b => b.ChessPiece != null && !team.Pieces.Any(p => p.Id == b.ChessPiece.Id)).ToList();
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

        public int GetWinner()
        {
            return -1;
        }
    }
}
