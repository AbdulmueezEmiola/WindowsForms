using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.DeepSkyBlue);
            int formHeight = this.Height;
            int formWidth = this.Width;
            e.Graphics.DrawRectangle(Pens.LawnGreen, 0, formHeight * 3 / 5, formWidth, formHeight);
            e.Graphics.FillRectangle(Brushes.ForestGreen, 0, formHeight * 3 / 5, formWidth, formHeight);
            e.Graphics.DrawLine(Pens.Black, 100, formHeight * 4 / 5, 100, formHeight *1/5 +50);
            e.Graphics.DrawLine(Pens.Black, 100, formHeight * 1 / 5 + 50, 400, formHeight * 1 / 5 + 50);
            e.Graphics.DrawLine(Pens.Black, 400, formHeight * 1 / 5 + 50, 400, formHeight * 4 / 5);
            e.Graphics.DrawLine(Pens.Black, 100, formHeight * 4/5, 400, formHeight * 4/5);
            e.Graphics.DrawLine(Pens.Black, 70, formHeight * 1 / 5 + 30, 100, formHeight * 1 / 5 + 50);
            e.Graphics.DrawLine(Pens.Black, 70, formHeight * 1 / 5 + 30, 450, formHeight * 1 / 5 + 30);
            e.Graphics.DrawLine(Pens.Black, 70, formHeight * 1 / 5 + 30, 70, formHeight * 1 / 5 + 15);
            e.Graphics.DrawLine(Pens.Black, 70, formHeight * 1 / 5 + 15, 450, formHeight * 1 / 5 + 15);
            e.Graphics.DrawLine(Pens.Black, 450, formHeight * 1 / 5 + 30, 450, formHeight * 1 / 5 + 15);
            e.Graphics.DrawLine(Pens.Black, 70, formHeight * 1 / 5 + 15, 310, 40);
            e.Graphics.DrawLine(Pens.Black, 310, 40, 450, formHeight * 1 / 5 + 15);
            e.Graphics.DrawLine(Pens.Black, 450, formHeight * 1 / 5 + 30, 480, formHeight * 1 / 5 + 30);
            e.Graphics.DrawLine(Pens.Black, 450, formHeight * 1 / 5 + 15, 480, formHeight * 1 / 5 + 15);
            e.Graphics.DrawLine(Pens.Black, 480, formHeight * 1 / 5 + 30, 480, formHeight * 1 / 5 + 15);
            e.Graphics.DrawLine(Pens.Black, 310, 40, 450, 40);
            e.Graphics.DrawLine(Pens.Black, 450, 40, 590, formHeight * 1 / 5 + 15);
            e.Graphics.DrawRectangle(Pens.Black, 400, formHeight / 5 + 30, 60, (formHeight * 4/5) - (formHeight * 1/ 5 +30));
            e.Graphics.DrawLine(Pens.Black, 480, formHeight / 5 + 15, 420, formHeight / 5 - 20);
            e.Graphics.DrawLine(Pens.Black, 420, formHeight / 5 - 20, 640, formHeight / 5 - 20);
            e.Graphics.DrawLine(Pens.Black, 640, formHeight / 5 - 20, 640, formHeight * 4 / 5);
            e.Graphics.DrawLine(Pens.Black, 410, formHeight / 5 - 30, 630, formHeight / 5 - 30);
            e.Graphics.DrawLine(Pens.Black, 640, formHeight / 5 - 20, 660, 30);
            e.Graphics.DrawLine(Pens.Black, 660, 30, 680, formHeight / 5 - 20);
            e.Graphics.DrawLine(Pens.Black, 680, formHeight / 5 - 20, 680, formHeight * 4 / 5);
            e.Graphics.DrawLine(Pens.Black, 630, formHeight / 5 - 30, 660, 10);
            e.Graphics.DrawLine(Pens.Black, 660, 10, 690, formHeight / 5 - 20);
            e.Graphics.DrawLine(Pens.Black, 690, formHeight / 5 - 20, 680,formHeight/5-20 );
            e.Graphics.DrawLine(Pens.Black, 660, 10, 450,10);
            e.Graphics.DrawLine(Pens.Black, 660, 10, 450, 10);
            e.Graphics.DrawLine(Pens.Black, 450, 10, 410, formHeight / 5 - 30);
            e.Graphics.DrawLine(Pens.Black, 450, formHeight * 4 / 5, 640, formHeight * 4 / 5);
            e.Graphics.DrawLine(Pens.Black, 640, formHeight * 4 / 5, 680, formHeight*4 / 5);
        }

    }
}
