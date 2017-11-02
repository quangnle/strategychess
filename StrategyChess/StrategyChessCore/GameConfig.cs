using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore
{
    public class GameConfig
    {
        public static int BoardWidth = 10;
        public static int BoardHeight = 12;
        public static int InitHeight = 3;

        public static int MaxUnits = 6;
        public static int MaxCamps = 1;

        public static int CampHp = 5;
        public static int CampSpeed = 0;
        public static int CampRange = 0;
        public static int CampCoolDown = 0;

        public static int RangerHp = 2;
        public static int RangerSpeed = 3;
        public static int RangerRange = 5;
        public static int RangerCoolDown = 4;

        public static int TankerHp = 5;
        public static int TankerSpeed = 2;
        public static int TankerRange = 1;
        public static int TankerCoolDown = 2;

        public static int AmbusherHp = 3;
        public static int AmbusherSpeed = 4;
        public static int AmbusherRange = 1;
        public static int AmbusherCoolDown = 2;
    }
}
