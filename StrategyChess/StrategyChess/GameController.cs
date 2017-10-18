using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChess
{
    public class GameController
    {
        private NetworkProcessor _connector;

        public void Run()
        {
            // _connector.OnClientRegister += Connector_OnClientRegister;
            // _connector.OnClientReady += Connector_OnClientReady;
            // _connector.OnClientMove += Connector_OnClientMove;

            _connector.Start();
        }

        public bool Register(string teamName)
        {
            return true;
        }

        public bool PlaceUnit(string teamName, IChessPiece piece, int row, int col)
        {
            return true;
        }

        public bool RemoveUnitAt(int row, int col)
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
