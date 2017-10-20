using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessCore
{
    public class GameMsg
    {   
        public string Sender { get; set; }
        public string Command { get; set; }
        public string Content { get; set; }
    }
}
