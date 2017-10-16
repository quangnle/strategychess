using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess
{
    public class GameController
    {   
        public void Run()
        {
            // open socket to listen for clients
            while (true) // continuously receiving messages from client
            {
                // msg = received mesage
                // if (msg.MsgType == "Register")
                //  run event Register
                // else if (msg.MsgType == "PlaceAUnit")
                //  run event place a unit
                // ....
            }
        }

        public bool Register(string teamName)
        {
            return true;
        }

        public bool PlaceAUnit(string teamName, IChessPiece piece, int row, int col)
        {
            return true;
        }

        public bool RemoveAUnitAt(int row, int col)
        {
            return true;
        }

        public bool Ready(string teamName)
        {
            return true;
        }

        public bool MakeAMove(IChessPiece piece, int row, int col)
        {
            return true;
        }

    }
}
