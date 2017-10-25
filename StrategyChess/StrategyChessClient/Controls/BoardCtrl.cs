using StrategyChessCore;
using StrategyChessCore.Definitions;
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
        public Team UpperTeam { get; set; }
        public Team LowerTeam { get; set; }
        private List<ChessPiece> _chessPieces = new List<ChessPiece>();
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
        public GameController GameController { get; set; }
        #endregion

        #region UI Command
        //public void InitChessPiece(IUnit unit, Image chessPieceImage, Color selectedColor, Color movableColor)
        //{
        //    if (unit == null) return;
        //    if (unit is Ranger)
        //        ChessPiece = new RangerGr(unit, new Rectangle(_rect.Location, _rect.Size));
        //    else if (unit is Tanker)
        //        ChessPiece = new TankerGr(unit, new Rectangle(_rect.Location, _rect.Size));
        //    else if (unit is Ambusher)
        //        ChessPiece = new AmbusherGr(unit, new Rectangle(_rect.Location, _rect.Size));
        //    else
        //        ChessPiece = new CampGr(unit, new Rectangle(_rect.Location, _rect.Size));

        //    ChessPiece.ChessPieceImage = chessPieceImage;
        //    ChessPiece.SelectedColor = selectedColor;
        //    ChessPiece.MovableColor = movableColor;
        //}
        #endregion

        #region Window Event Handlers
        private void BoardCtrl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _boardGr.Draw(e.Graphics);

            //Draw chess piece
            foreach (var chessPiece in _chessPieces)
            {
                chessPiece.Draw(e.Graphics);
            }

            //Draw HP & Cooldown
            foreach (var chessPiece in _chessPieces)
            {
                chessPiece.DrawExt(e.Graphics);
            }
        }

        private void BoardCtrl_DoubleClick(object sender, EventArgs e)
        {
            //if (GameController.GetGameState() == GameState.Init)
            //{
            //    /// do removing chesspiece
            //}
        }

        private void BoardCtrl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if (GameController.GetGameState() == GameState.Init)
            //{
            //    // place chesspiece
            //}
            //else if (GameController.GameState == GameState.Ready)
            //{
            //    // do moving
            //}
        }

        #endregion
    }
}
