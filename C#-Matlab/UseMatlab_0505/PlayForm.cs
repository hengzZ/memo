using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseMatlab_0505
{
    public partial class PlayForm : Form
    {
        public PlayForm()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
            // Picture 窗口刷新
            pictureBox1.Paint += new PaintEventHandler(PicturePaint);
        }
        private void PicturePaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Draw(g);
        }
        private void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Rectangle rectangle = new Rectangle();
            rectangle.X = 50;
            rectangle.Y = 50;
            rectangle.Width = 100;
            rectangle.Height = 100;
            g.DrawRectangle(pen,rectangle);
        }
    }
}
