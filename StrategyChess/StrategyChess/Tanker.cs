using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess
{
    public class Tanker : IChessPiece
    {
        public int Id { get; set; }
        public ChessPieceType PieceType { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public Tanker(int id, int row, int col)
        {
            Id = id;

            // default values
            HP = 5;
            Speed = 1;
            Range = 1;
            PieceType = ChessPieceType.Tanker;
        }
    }
}
