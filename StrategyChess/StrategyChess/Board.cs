﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess
{
    public class Board
    {
        public Block this[int row, int column]
        {
            get { return Blocks.FirstOrDefault(b => b.Row == row && b.Column == column); }
        }

        public Block this[int idPiece]
        {
            get
            {
                var block = Blocks.FirstOrDefault(b => b.ChessPiece != null && b.ChessPiece.Id == idPiece);
                return block;
            }
        }

        public Team UpperTeam { get; set; }
        public Team LowerTeam { get; set; }
        public List<Block> Blocks { get; set; }

        public Board(int size)
        {
            Blocks = new List<Block>();
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    var b = new Block { Row = r, Column = c};
                    Blocks.Add(b);
                }
            }
        }
    }
}
