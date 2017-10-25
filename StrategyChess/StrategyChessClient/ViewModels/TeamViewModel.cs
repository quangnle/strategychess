using StrategyChessCore.Definitions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessClient.ViewModels
{
    public class TeamViewModel
    {
        public Team Team { get; set; }

        public ChessPieceColor Color { get; set; }

        public Color SelectedColor { get; set; }
        
        public Color MovableColor { get; set; }

        public Color AttackableColor { get; set; }

        public UnitType SelectedUnitType { get; set; }

        public TeamViewModel()
        {

        }
    }
}
