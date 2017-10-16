using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess
{
    public class Base : IChessPiece
    {
        public int Id { get; set; }
        public ChessPieceType PieceType { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }

        public Base(int id, int row, int col)
        {
            Id = id;

            // default values
            HP = 5;
            Speed = 0;
            Range = 0;
            PieceType = ChessPieceType.Base;
        }
    }
}
