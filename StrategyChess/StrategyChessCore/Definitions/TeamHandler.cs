using StrategyChessCore.Definitions.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore.Definitions
{
    public class TeamHandler
    {
        public static IUnit GetUnitAt(Team team, int row, int col)
        {
            return team.Units.FirstOrDefault(u => u.Row == row && u.Column == col);
        }

        public static IUnit GetUnitAt(Team team, Block block)
        {
            return team.Units.FirstOrDefault(u => u.Row == block.Row && u.Column == block.Column);
        }

        public static List<IUnit> GetUnitsAround(Team team, int row, int col, int radius)
        {
            return team.Units.Where(u => (Math.Abs(u.Row - row) <= radius) && (Math.Abs(u.Column - col) <= radius)).ToList();
        }

        public static List<IUnit> GetCamps(Team team)
        {
            return team.Units.Where(u => u is Camp).ToList();
        }

        public static List<IUnit> GetUnits(Team team)
        {
            return team.Units.Where(u => !(u is Camp)).ToList();
        }
    }
}
