using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.DeepSkyBlue);
            e.Graphics.FillRectangle(Brushes.ForestGreen, 0, 340, 855, 115);
            e.Graphics.FillRectangle(Brushes.Aqua, 560, 340, 855, 115);
            DrawBuilding1(e);
            DrawBuilding2(e);
            DrawBuilding3(e);
            DrawBuilding4(e);
            DrawBuilding5(e);
            DrawBridge(e);
        }
        private void DrawCircle(Graphics g, Pen pen, float centerX, float centerY, float radius)
        { 
            g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }
        private void FillCircle( Graphics g, Brush brush, float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }

        private void DrawBuilding1(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Yellow, 42, 227, 65, 160);
            e.Graphics.FillRectangle(Brushes.Yellow, 42, 227, 65, 160);
            e.Graphics.DrawLine(Pens.BurlyWood, 42, 310, 107, 310);
            e.Graphics.DrawLine(Pens.BurlyWood, 42, 380, 107, 380);
            e.Graphics.DrawRectangle(Pens.BurlyWood, 64, 343, 21, 45);
            e.Graphics.FillRectangle(Brushes.DarkGray, 64, 343, 21, 45);
            e.Graphics.DrawArc(Pens.Black, 63, 364, 3, 3, 30, 30);
            for(int i = 0; i < 3; ++i)
            {
                float x = (1.05f + i * 0.5f) * 42;
                e.Graphics.FillRectangle(Brushes.DarkGray, x, 250, 17, 46);
            }
        }
        private void DrawBuilding2(PaintEventArgs e)
        {
            FillCircle(e.Graphics, Brushes.DimGray, 151, 140, 43);
            e.Graphics.DrawLine(Pens.PeachPuff, 151, 97, 115, 135);
            e.Graphics.DrawLine(Pens.PeachPuff, 151, 97, 151, 135);
            e.Graphics.DrawLine(Pens.PeachPuff, 151, 97, 189, 135);
            e.Graphics.DrawLine(Pens.PeachPuff, 151, 97, 131, 135);
            e.Graphics.DrawLine(Pens.PeachPuff, 151, 97, 171, 135);
            e.Graphics.DrawRectangle(Pens.PeachPuff, 108, 135, 85, 252);
            e.Graphics.FillRectangle(Brushes.PeachPuff, 108, 135, 85, 252);
            e.Graphics.FillEllipse(Brushes.DimGray, 132, 335, 37, 15);
            e.Graphics.FillRectangle(Brushes.DimGray, 129, 340, 43, 48);
            e.Graphics.DrawLine(Pens.PeachPuff, 150, 340, 150, 387);
            for(int i = 0; i < 8; ++i)
            {
                if (i % 2 == 0)
                {
                    FillCircle(e.Graphics, Brushes.DimGray, 130, 170+i*21, 10);
                }
                else
                {
                    FillCircle(e.Graphics, Brushes.DimGray, 172, 170 + (i-1) * 21, 10);
                }
            }
            
        }
        private void DrawBuilding3(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.SandyBrown, 193, 172, 84, 216);
            FillCircle(e.Graphics, Brushes.White, 215, 348, 11);
            e.Graphics.FillRectangle(Brushes.White, 204, 343, 22, 45);
            for(int i = 0; i < 6; ++i)
            {
                if (i == 4)
                {
                    continue;
                }
                if (i % 2 == 0)
                {
                    e.Graphics.FillRectangle(Brushes.White, 204, 185 + i * 40, 22, 35);
                    e.Graphics.DrawLine(Pens.Brown, 204, 185 + i * 40 + 17, 226, 185 + i * 40 + 17);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, 246, 185 + (i-1) * 40, 22, 35);
                    e.Graphics.DrawLine(Pens.Brown, 246, 185 + (i-1) * 40 + 17, 268, 185 + (i-1) * 40 + 17);
                }
            }
        }

        private void DrawBuilding4(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Beige, 277, 125, 85, 263);
            e.Graphics.FillRectangle(Brushes.DarkKhaki, 310, 338, 44, 50);
            for(int i = 0; i < 5; ++i)
            {
                if(i %2 == 0)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.DarkKhaki,4), 283, 135 + i * 30, 60, 40);
                    e.Graphics.FillRectangle(Brushes.White, 283, 135 + i * 30, 60, 40);
                    e.Graphics.DrawLine(Pens.DarkKhaki, 313, 135 + i * 30, 313, 135 + i * 30 + 40);
                }
                
            }
        }
        private void DrawBuilding5(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Gray, 362, 385, 100, 3);
            e.Graphics.FillRectangle(Brushes.Gray, 365, 382, 95, 3);
            e.Graphics.FillRectangle(Brushes.Gray, 367, 282, 92, 100);
            e.Graphics.DrawRectangle(new Pen(Color.White, 2), 376, 334, 75, 48);
            e.Graphics.FillRectangle(Brushes.DarkKhaki, 376, 334, 75, 48);
            e.Graphics.DrawLine(new Pen(Color.White, 2), 414, 334, 414, 382);
            for(int i = 0; i < 6; ++i)
            {
                if(i < 3)
                {
                    int x = 378 + i * 23;
                    e.Graphics.DrawRectangle(new Pen(Color.White, 2), x, 285, 25, 18);
                    e.Graphics.FillRectangle(Brushes.DarkKhaki, x, 285, 25, 18);
                }
                else
                {
                    int x = 378 + (i - 3) * 23;
                    e.Graphics.DrawRectangle(new Pen(Color.White, 2), x, 310, 25, 18);
                    e.Graphics.FillRectangle(Brushes.DarkKhaki, x, 310, 25, 18);
                }
            }
            e.Graphics.FillRectangle(Brushes.Gray, 369, 182, 89, 100);            
            for(int i = 0; i < 9; ++i)
            {
                if (i < 3)
                {
                    int x = 380 + i * 23;
                    e.Graphics.DrawRectangle(new Pen(Color.White, 2), x, 200, 20, 20);
                    e.Graphics.FillRectangle(Brushes.DarkKhaki, x, 200, 20, 20);
                }
                else if(i>2 && i<6)
                {
                    int x = 380 + (i%3) * 23;
                    e.Graphics.DrawRectangle(new Pen(Color.White, 2), x, 225, 20, 20);
                    e.Graphics.FillRectangle(Brushes.DarkKhaki, x,225, 20, 20);
                }else if(i>=6 && i < 9)
                {
                    int x = 380 + (i % 3) * 23;
                    e.Graphics.DrawRectangle(new Pen(Color.White, 2), x, 250, 20, 20);
                    e.Graphics.FillRectangle(Brushes.DarkKhaki, x, 250, 20, 20);
                }
            }
            DrawCircle(e.Graphics, new Pen(Color.Gray, 2), 414, 110, 41);
            DrawCircle(e.Graphics, new Pen(Color.Gray, 2), 414, 110, 31);
            DrawCircle(e.Graphics, new Pen(Color.Gray, 2), 414, 110, 21);
            DrawCircle(e.Graphics, new Pen(Color.Gray, 2), 414, 110, 11);
            e.Graphics.FillRectangle(Brushes.Gray, 371, 120, 86, 62);
            for(int i = 0; i < 8; i++)
            {
                int y = 120 + i * 10;
                int x = 380 + i * 10;
                e.Graphics.DrawLine(new Pen(Color.White, 2), x, 120, x, 182);
                if(i < 7)
                    e.Graphics.DrawLine(new Pen(Color.White, 2), 371, y, 457, y);
            }
            
            e.Graphics.FillRectangle(Brushes.Gray, 373, 110, 82, 10);
            e.Graphics.DrawPolygon(Pens.Gray, new Point[]
            {
                new Point(412,69),
                new Point(414,50),
                new Point(416,69)
            });
            
        }

        private void DrawBridge(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkRed, 500, 290, 50, 100);
            e.Graphics.FillRectangle(Brushes.DarkRed, 458, 270, 400, 10);
            e.Graphics.FillRectangle(Brushes.DarkRed, 510, 250, 30, 40);
            e.Graphics.DrawArc(new Pen(Color.DarkRed, 5), 540, 175, 350, 200, 0, -180);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            DrawCircle(g, Pens.Yellow, 755, 50, 40);
            FillCircle(g, Brushes.Yellow, 755, 50, 40);
        }
    }
}
