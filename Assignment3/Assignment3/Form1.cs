using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox3.Image = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Graphics gra = CreateGraphics();
            g.Clear(Color.White);
            string[] xText = textBox2.Text.Split();
            int[] x = new int[xText.Length];
            for(int i = 0; i < xText.Length; ++i)
            {
                x[i] = Convert.ToInt32(xText[i]);
            }
            int xMax = x.Max();
            int yConn = pictureBox1.Height;
            float width = 2 * (pictureBox1.Width) / (3 * x.Length - 1);
            float period = width / 2;
            Random rand = new Random();
            for (int i = 0; i < x.Length; ++i)
            {
                int height = yConn * x[i] / xMax;
                float xCoordinate = (width + period) * i;
                float yCoordinate = yConn - height;
                g.FillRectangle(new SolidBrush(Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255))), xCoordinate, yCoordinate, width, height);
                gra.DrawString((Convert.ToInt32(x[i] /(float) xMax * 100)).ToString(), DefaultFont, Brushes.Black, pictureBox1.Location.X- 30,pictureBox1.Location.Y+yCoordinate);
            }
            DrawCIrcle(x);   
            pictureBox1.Refresh();
        }
        public void DrawCIrcle(int[] x)
        {
            Graphics g2 = Graphics.FromImage(pictureBox3.Image);
            Graphics g3 = Graphics.FromImage(pictureBox2.Image);
            g2.Clear(Color.White);
            g3.Clear(Color.White);
            int sum = 0;
            for(int i = 0; i < x.Length; ++i)
            {
                sum += x[i];
            }
            float angle =0;
            Random rand = new Random();
            for(int i = 0; i < x.Length; ++i)
            {
                float sweepAngle = x[i]*360 / (float)sum;
                Color color = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                g2.FillPie(new SolidBrush(color), 0, 0,pictureBox3.Width,pictureBox3.Height,angle,sweepAngle) ;
                //g2.DrawString(x[i].ToString(), DefaultFont, Brushes.White, sweepAngle, angle);
                angle += sweepAngle;
                float keyHeight = pictureBox2.Height < x.Length ? pictureBox2.Height / x.Length : 30;
                g3.FillRectangle(new SolidBrush(color), 10, i * keyHeight, 40, keyHeight);
                g3.DrawString(x[i].ToString(), DefaultFont, Brushes.Black, 60, i * keyHeight +15);

            }
            pictureBox2.Refresh();
            pictureBox3.Refresh();
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
