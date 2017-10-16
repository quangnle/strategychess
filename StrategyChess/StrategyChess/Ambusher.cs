using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess
{
    public class Ambusher : IChessPiece
    {
        public int Id { get; set; }
        public ChessPieceType PieceType { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }

        public Ambusher(int id, int row, int col)
        {
            Id = id;

            // default values
            HP = 3;
            Speed = 4;
            Range = 1;
            PieceType = ChessPieceType.Ambusher;
        }
    }
}
