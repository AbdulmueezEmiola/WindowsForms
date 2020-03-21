using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainTask5Anim
{
    
    public partial class Form1 : Form
    {
        double x01, y01, x02, y02, r, ang;
        double  x1, y1, x2, y2;
        int trubaniz = 290;
        int trubaverh = 280;
        int roof = 370;
        int polygon1 = 260;
        int polygon2 = 215;
        int suspension = 260;
        int nose = 240;
        int body = 265;
        int kabina1 = 380;
        int kabina2 = 390;
        int wheel1 = 270;
        int wheel2 = 290;
        int move = 0;


        private void PictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            Text = string.Format("({0}; {1})", e.X, e.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            r = 15; x01 = 295; y01 = 320;
            x02 = 425; y02 = 320; ang = 0;
            x1 = r * Math.Cos(ang) + x01;
            y1 = r * Math.Sin(ang) + y01;
            x2 = r * Math.Cos(ang) + x02;
            y2 = r * Math.Sin(ang) + y02;

             draw(move,ang);
        }

        public Form1()
        {
            InitializeComponent();
            
        }


        public void draw(int move, double angle)
        {
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics gr = Graphics.FromImage(pictureBox2.Image);
            gr.Clear(Color.Blue);
            int delta;
            gr.FillRectangle(Brushes.White, trubaniz+move, 180, 30, 115);  //труба низ
            gr.FillRectangle(Brushes.Orange, trubaverh+move, 170, 50, 10);   //труба верх
            gr.FillEllipse(Brushes.Purple, roof+move, 125, 105, 20);  //крыша

            Point[] polygon =
             {
               new Point(polygon1+move, 295), new Point(polygon1+move, 335), new Point(polygon2+move, 335)
             };
            gr.FillPolygon(Brushes.BlueViolet, polygon); //уборщик мусора

            gr.FillRectangle(Brushes.LightGray, suspension+move, 295, 200, 25);   //подвеска
            gr.FillEllipse(Brushes.Green, nose+move, 230, 50, 65);  //нос
            gr.FillRectangle(Brushes.Red, body+move, 230, 200, 65); //кузов
            gr.FillRectangle(Brushes.Yellow, kabina1+move, 140, 85, 90); //кабина
            gr.FillRectangle(Brushes.White, kabina2+move, 150, 65, 70); //кабина 2

            Pen wheel = new Pen(Color.DimGray, 3);
            Pen wheelcht = new Pen(Color.Brown, 5);
            for (int i = 0; i < 3; i++)
            {
                delta = i * 50 + 15 * i;
                gr.FillEllipse(Brushes.Gray, wheel1 + delta+move, 295, 50, 50);
                gr.FillEllipse(Brushes.Beige, wheel2 + delta+move, 315, 10, 10);
            }
            
            //ang += 0.1;
            x1 = r * Math.Cos(ang) + x01+move;
            y1 = r * Math.Sin(ang) + y01;
            x2 = r * Math.Cos(ang) + x02+move;
            y2 = r * Math.Sin(ang) + y02;
            gr.DrawLine(wheelcht, (float)x1, (float)y1, (float)x2, (float)y2);
            //MessageBox.Show(x1 + " " + y1 + " " + x2 + " " + y2);
            pictureBox2.Refresh();
        }
      
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics gr = Graphics.FromImage(pictureBox2.Image);
            





            if (e.KeyCode == Keys.Left)
            {
                
                //x = r * Math.Cos(ang) + x01;
                //y = r * Math.Sin(ang) + y01;
                //ang += 0.1;
                move -= 5;
                ang -= 0.1;
                
                draw(move, ang);
                //gr.FillRectangle(Brushes.Yellow,(float)x, (float)y, 50, 50);
                
                
            }
            if (e.KeyCode == Keys.Right)
            {
                move += 5;
                ang += 0.1;
                draw(move, ang);
            }
        }
    }
}
