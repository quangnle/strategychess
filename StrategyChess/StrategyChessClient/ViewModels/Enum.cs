using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessClient.ViewModels
{
    public enum GameMode : int
    {
        Single = 0,
        Network
    }

    public enum ChessPieceColor : int
    {
        Blue = 0,
        Green
    }

    public enum UnitType
    {
        Camp = 0,
        Ambusher = 1,
        Ranger = 2,
        Tanker = 3
    }
}
