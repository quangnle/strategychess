using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StrategyChessGraphics;

namespace StrategyChessClient
{
    public partial class MainForm : Form
    {
        #region Members
        private Board _board;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            _board = new Board(20, 6, 2);
        }
        #endregion

        #region UI Command

        #endregion

        #region Window Event Handles
        private void pBoard_Paint(object sender, PaintEventArgs e)
        {
            _board.Draw(e.Graphics);
        }

        private void pBoard_MouseUp(object sender, MouseEventArgs e)
        {


            var cell = _board.GetCell(e.X, e.Y);
        }
        #endregion
    }
}
