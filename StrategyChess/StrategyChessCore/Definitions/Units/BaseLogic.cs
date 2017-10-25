﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions.Units
{
    public abstract class BaseLogic
    {
        protected IUnit Unit { get; set; }
        protected BoardHandler BoardHandler { get; set; }

        public BaseLogic(IUnit unit, BoardHandler boardHandler)
        {
            unit = Unit;
            BoardHandler = boardHandler;
        }

        public virtual List<IUnit> GetAllTargets()
        {
            return BoardHandler.GetEnemyAround(Unit, Unit.Range);
        }

        public virtual List<Block> GetAllMoveableBlocks()
        {
            return BoardHandler.GetEmptyGroundBlocksWithinDistance(BoardHandler.Board[Unit.Row, Unit.Column], Unit.Speed);
        }

        public virtual bool Attack(int row, int col)
        {

            var target = GetAllTargets().FirstOrDefault(u => u.Row == row && u.Column == col);
            if (target != null)
            {
                target.HP--;
                if (target.HP == 0)
                {
                    var team = target.Team;
                    team.Units.Remove(target);
                }
                return true;
            }

            return false;
        }

        public virtual bool Move(int row, int col)
        {
            var moveableBlocks = GetAllMoveableBlocks();
            if (moveableBlocks.Exists(b => b.Row == row && b.Column == col))
            {
                Unit.Row = row;
                Unit.Column = col;
                return true;
            }

            return false;
        }
    }
}
