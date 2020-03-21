using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class Form1 : Form
    {
        private Point mouseDownLocation;
        bool sideLeft = false;
        bool sideTop = false;
        float width;
        float height;

        //The problem is from the width and height, i need to look at that
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           //Form1.AllowDrop = true;
        }

        private void ComputeButton_Click(object sender, EventArgs e)
        {
            float radius;
            float.TryParse(radiusTextBox.Text,out radius);
            double angle;
            double.TryParse(angleTextBox.Text,out angle);
            DrawSegment(radius, angle);
        }
        private void DrawSegment(float radius, double angle)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            GraphicsPath myPath = new GraphicsPath();
            RectangleF rectangle;
            angle = Math.PI * angle / 180;
            width = Math.Abs(2 * radius * (float)Math.Sin(angle / 2));
            height = radius * (1 - (float)Math.Cos(angle / 2));
            rectangle = new RectangleF(10, 10, 10 + (float)width, 10 + (float)height);
            float startAngle = (float)(Math.PI - angle) / 2;
            myPath.AddArc(rectangle, (float)(startAngle * 180 / Math.PI), (float)(angle * 180 / Math.PI));
            myPath.CloseFigure();
            g.FillPath(Brushes.Gold, myPath);
            g.DrawRectangle(Pens.Black, new Rectangle(10, 10, 10 + (int)width, 10 + (int)height));
            Console.WriteLine(rectangle.Width + " " + rectangle.Height);
            Size size = new Size((int)width + 30,(int)height+ 30);
            pictureBox1.Size = size;
            pictureBox1.Refresh();
        }
        private void DrawSegment2(float radius, double angle)
        {
            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            GraphicsPath myPath = new GraphicsPath();
            RectangleF rectangle;
            float width = Math.Abs(2 * radius * (float)Math.Sin(angle / 2));
            float height = radius * (1 - (float)Math.Cos(angle / 2));
            rectangle = new RectangleF(10, 10, 10 + (float)width, 10 + (float)height);
            float startAngle = (float)(Math.PI - angle) / 2;
            myPath.AddArc(rectangle, (float)(startAngle * 180 / Math.PI), (float)(angle * 180 / Math.PI));
            myPath.CloseFigure();
            g.FillPath(Brushes.Gold, myPath);
            g.DrawRectangle(Pens.Black, new Rectangle(10, 10, 10 + (int)width, 10 + (int)height));
            Console.WriteLine(rectangle.Width + " " + rectangle.Height);            
            pictureBox1.Refresh();
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            sideLeft = false;
            sideTop = false;
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;

                if (mouseDownLocation.X <= 10 && mouseDownLocation.X>=0)
                {
                    sideLeft = true;
                }
                else if (mouseDownLocation.Y <= 10 && mouseDownLocation.Y >=0)
                {
                    sideTop = true;
                }
            }
            
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int left =0;
                int width=0;
                int height =0;
                int bottom = 0;
                if(sideLeft)
                {
                    width = pictureBox1.Width - (e.X - mouseDownLocation.X);
                    left = e.X + pictureBox1.Left - mouseDownLocation.X;
                    pictureBox1.Left = left;
                    pictureBox1.Width = width;                    
                }else if(sideTop)
                {
                    height = pictureBox1.Height - (e.Y - mouseDownLocation.Y);                    
                    bottom = e.Y + pictureBox1.Top - mouseDownLocation.Y;
                    pictureBox1.Height = height;
                    pictureBox1.Top = bottom;              
                }
                else
                {
                    pictureBox1.Left = e.X + pictureBox1.Left - mouseDownLocation.X;
                    pictureBox1.Top = e.Y + pictureBox1.Top - mouseDownLocation.Y;
                    return;
                }
                float width2 = pictureBox1.Width-30;
                float height2 = pictureBox1.Height-30;
                double angle = 4 * Math.Atan(2*(height2) / (width2));
                float radius = (float)(0.5*width2) / (float)Math.Sin(0.5 * angle);
                radiusTextBox.Text = radius.ToString();
                angleTextBox.Text = (angle * 180 / Math.PI).ToString();
                DrawSegment2(radius, angle);
            }
        }
    }
}

    