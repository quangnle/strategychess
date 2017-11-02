using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessGraphics
{
    public class Global
    {
        public static Color TeamBlueColor = Color.FromArgb(30, 75, 157); //#1E4B9D
        public static Color TeamGreenColor = Color.FromArgb(25, 159, 59); //#199F3B
        public static Color SelectedBlueColor = Color.FromArgb(150, 30, 75, 157); //#1E4B9D
        public static Color SelectedGreenColor = Color.FromArgb(150, 25, 159, 59); //#1E4B9D
        public static Color MovableBlueColor = Color.FromArgb(215, 235, 255); //#EBF1FC
        public static Color MovableGreenColor = Color.FromArgb(200, 225, 251, 228); //#E1FBE4
        public static Color GameSettingBackgroundColor = Color.FromArgb(233, 231, 218); //#E9E7DA
        public static Color AttackableColor = Color.FromArgb(100, 255, 0, 0);
        
        public static int CellWidth = 60;
        public static int CellHeight = 55;

        
    }
}
