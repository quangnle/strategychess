using StrategyChessGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyChessClient.Controls
{
    public class BoardCtrl : CustomPanel
    {
        #region Members
        private BoardGr _boardGr;
        #endregion

        #region Constructor
        public BoardCtrl()
        {
            _boardGr = new BoardGr(20);
            this.BackColor = System.Drawing.Color.White;
            this.Paint += BoardCtrl_Paint;
            this.DoubleClick += BoardCtrl_DoubleClick;
            this.MouseDown += BoardCtrl_MouseDown;
        }
        #endregion

        #region Properties

        #endregion

        #region UI Command

        #endregion

        #region Window Event Handlers
        private void BoardCtrl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _boardGr.Draw(e.Graphics);            
        }

        private void BoardCtrl_DoubleClick(object sender, EventArgs e)
        {

        }

        private void BoardCtrl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }
        #endregion
    }
}
