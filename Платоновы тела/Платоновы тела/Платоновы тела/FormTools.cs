using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Платоновы_тела
{
    public partial class FormTools : Form
    {
        public FormTools()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            byte flBody = Convert.ToByte((sender as RadioButton).Tag);
            TPlaton.body = new TBody(flBody);
            FormMain.MyDraw();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TPlaton.visibleOXYZ = checkBox1.Checked;
            FormMain.MyDraw();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            TPlaton.visibleShadow = checkBox3.Checked;
            FormMain.MyDraw();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            TPlaton.flRotate = true;
            FormMain.MyDraw();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            TPlaton.flRotate = false;
            FormMain.MyDraw();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            TPlaton.Sv[0] = hScrollBar1.Value / 30d;
            FormMain.MyDraw();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            TPlaton.Sv[1] = hScrollBar2.Value / 30d;
            FormMain.MyDraw();
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            TPlaton.Sv[2] = 1.5 + hScrollBar3.Value / 100d;
            FormMain.MyDraw();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            TPlaton.flEdge = 0;
            FormMain.MyDraw();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            TPlaton.flEdge = 1;
            FormMain.MyDraw();
        }

        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            TPlaton.Xs = -hScrollBar4.Value / 100d;
            FormMain.MyDraw();
        }

        private void hScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            TPlaton.Zs = -hScrollBar5.Value / 100d;
            FormMain.MyDraw();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            TPlaton.visiblePoint = checkBox4.Checked;
            FormMain.MyDraw();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            TPlaton.flEdge = 2;
            FormMain.MyDraw();
        }
    }
}
