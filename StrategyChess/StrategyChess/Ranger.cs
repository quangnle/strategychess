using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess
{
    public class Ranger : IChessPiece
    {
        public int Id { get; set; }
        public ChessPieceType PieceType { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }

        public Ranger(int id, int row, int col)
        {
            Id = id;

            // default values
            HP = 2;
            Speed = 3;
            Range = 5;
            PieceType = ChessPieceType.Ranger;
        }
    }
}
