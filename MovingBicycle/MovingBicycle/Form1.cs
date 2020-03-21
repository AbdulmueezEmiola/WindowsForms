using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingBicycle
{
    public partial class Form1 : Form
    {
        int frontPosition = 200;
        int backPosition = 0;
        int iRot = 0;
        double angleRot = 0;
        double angleRotPedal = 0;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            drawBackground();
            drawBicycle();
        }
        private void drawBackground()
        {
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            gr.Clear(Color.SkyBlue);
            gr.DrawRectangle(Pens.ForestGreen, 0, pictureBox1.Height - 70, pictureBox1.Width, pictureBox1.Height - 70);
            gr.FillRectangle(Brushes.ForestGreen, 0, pictureBox1.Height - 70, pictureBox1.Width, pictureBox1.Height - 70);
            //First cloud
            for(int x =0, i=10, count = 0;x< pictureBox1.Width; x += 300)
            {
                i = ((count % 2) == 1) ? 10 : -10;
                gr.FillEllipse(new SolidBrush(Color.White), x+11, i+51, x/10+17, x%7+7);
                gr.FillEllipse(new SolidBrush(Color.White), x+16, i+41, x/20+22, x%12+12);
                gr.FillEllipse(new SolidBrush(Color.White), x+21, i+31, x/30+27, x%17+17);                
            }
        }
        static Point RotatePoint(Point pointToRotate, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point
            {
                X =
                    (int)
                    (cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y =
                    (int)
                    (sinTheta * (pointToRotate.X - centerPoint.X) +
                    cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }
        private void drawTyre(int start)
        {
            int height = pictureBox1.Height - 70;
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            gr.DrawEllipse(new Pen(Color.Black,5), start+20, height - 80, 80, 80);
            gr.DrawEllipse(new Pen(Color.White,5), start+25, height - 75, 70, 70);
            gr.FillEllipse(new SolidBrush(Color.Black), start+50, height - 50, 15, 15);
            Point centre = new Point(start+58, height - 40);
            Point outerPoint;
            GraphicsPath path = new GraphicsPath();
            for(int i = 0; i < 12; i++)
            {
                double angle = 2 * (i+iRot) * Math.PI / 12;
                double x = 40 * Math.Cos(angle+angleRot);
                double y = 40 * Math.Sin(angle+angleRot);
                outerPoint = new Point(centre.X+(int)x, centre.Y +(int)y);
                path.AddLine(centre, outerPoint);                
            }
            gr.DrawPath(Pens.Black, path);
        }
        private void drawFirstTyreConnector()
        {
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            int height = pictureBox1.Height - 70;
            Point p1 = new Point(frontPosition+58, height-40);
            Point p2 = new Point(frontPosition+30, height -150);
            Point p3 = new Point(frontPosition + 30, height - 145);
            Point p4 = new Point(frontPosition + 55, height - 155);
            Point p5 = new Point(frontPosition + 55, height - 153);
            Point p6 = new Point(frontPosition + 55, height - 180);
            Point p4O = new Point(frontPosition + 40, height - 160);
            Point p6O = new Point(frontPosition + 40, height - 185);
            Point p5O = new Point(frontPosition + 40, height - 158);
            gr.DrawLine(new Pen(Color.Black,5),p1,p2);
            gr.DrawLine(new Pen(Color.Black, 5), p3, p4);
            gr.DrawLine(new Pen(Color.Black, 5), p3, p4O);
            gr.DrawLine(new Pen(Color.Black, 5), p5, p6);
            gr.DrawLine(new Pen(Color.Black, 5), p5O, p6O);
        }
        private void drawSecondTyreConnector()
        {
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            int height = pictureBox1.Height - 70;
            Point p1 = new Point(backPosition + 58, height - 40);
            Point p2 = new Point(backPosition + 88, height - 125);
            Point p3 = new Point(backPosition + 115, height - 35);
            Point p4 = new Point(backPosition + 80, height - 145);
            Point p5 = new Point(backPosition+235, height - 125);
            Point p6 = new Point(backPosition + 115, height - 65);
            Point p7 = new Point(backPosition + 115, height - 5);
            p6 = RotatePoint(p6, p3, angleRotPedal);
            p7 = RotatePoint(p7, p3, angleRotPedal);
            Point p60 = new Point(p6.X - 10, p6.Y);
            Point p61 = new Point(p6.X + 10, p6.Y);
            Point p70 = new Point(p7.X - 10, p7.Y);
            Point p71 = new Point(p7.X + 10, p7.Y);
            Rectangle rect = new Rectangle(backPosition+40,height-150,100,10);
            gr.DrawEllipse(new Pen(Color.Black, 3), backPosition + 97, height - 55, 35, 35);
            gr.DrawEllipse(new Pen(Color.White, 3), backPosition + 100, height - 52, 29, 29);
            gr.FillEllipse(new SolidBrush(Color.Black), backPosition + 109, height - 41, 10, 10);
            gr.DrawLine(new Pen(Color.Black, 5), p1, p2);
            gr.DrawLine(new Pen(Color.Black, 5), p1, p3);
            gr.DrawLine(new Pen(Color.Black, 5), p3, p4);
            gr.DrawLine(new Pen(Color.Black, 5), p2, p5);                
            gr.DrawLine(new Pen(Color.Black, 5), p3, p5);
            gr.DrawLine(new Pen(Color.Black, 5), p3, p6);
            gr.DrawLine(new Pen(Color.Black, 5), p3, p7);
            gr.DrawLine(new Pen(Color.Black, 5), p60, p61);
            gr.DrawLine(new Pen(Color.Black, 5), p70, p71);
            gr.FillRectangle(Brushes.Black, rect);
        }
        private void drawBicycle()
        {
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            gr.Clear(Color.White);
            drawBackground();
            drawTyre(backPosition);
            drawTyre(frontPosition);
            drawFirstTyreConnector();
            drawSecondTyreConnector();
            pictureBox1.Refresh();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                angleRot -= 0.3;
                frontPosition += 5;
                backPosition += 5;
                angleRotPedal += 2.5;
            }
            if(e.KeyCode == Keys.Left)
            {
                angleRot += 0.3;
                frontPosition -= 5;
                backPosition -= 5;
                angleRotPedal -= 2.5;
            }

            drawBicycle();
        }
    }
}
