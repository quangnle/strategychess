using StrategyChessGraphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrategyChessClient.Controls
{
    public delegate void SelectChangedHandler(PictureBox sender, bool selected);
    public class CustomPictureBox : PictureBox
    {
        public event SelectChangedHandler OnSelectChanged;
        private bool _isSelected = false;
        public bool AllowSelect { get; set; }

        public Color SelectedColor { get; set; }

        public CustomPictureBox()
        {
            this.Paint += CustomPictureBox_Paint;
            this.MouseUp += CustomPictureBox_MouseUp;
            this.AllowSelect = true;
            this.SelectedColor = Global.TeamBlueColor;
        }

        private void CustomPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!AllowSelect) return;
            this.IsSelected = true;//!this.IsSelected;

            if (OnSelectChanged != null)
                OnSelectChanged(this, this.IsSelected);
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                this.Invalidate();
            }
        }

        private void CustomPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (IsSelected)
            {
                var pen = new Pen(this.SelectedColor, 3);
                var rect = new Rectangle(0, 0, this.Width - 3 , this.Height - 3);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
