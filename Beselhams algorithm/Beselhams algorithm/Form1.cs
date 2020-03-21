using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Beselhams_algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int x1, x2, y1, y2, dx, dy;
            x1 = Convert.ToInt32(textBox1.Text);
            y1 = Convert.ToInt32(textBox2.Text);
            x2 = Convert.ToInt32(textBox3.Text);
            y2 = Convert.ToInt32(textBox4.Text);
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            button1.Hide();
            dx = x2 - x1;
            dy = y2 - y1;
            Graphics g = CreateGraphics();
            //Finding the driving axis
            if(Math.Abs(dx)>= Math.Abs(dy))     
            {
                //setting the error value
                int error = Math.Abs(dy)- Math.Abs(dx);
                //checking to see if the x axis coordinate is increasing or decreasing
                if (dx >= 0)
                {
                    int j = y1;
                    for (int i = x1; i < x2; ++i)
                    {
                        g.FillRectangle(Brushes.Red, i, j, 1, 1);                        
                        if(error >= 0)
                        {
                            error -= Math.Abs(dx);
                            //checking to see if the y axis coordinate is increasing or decreasing
                            if(dy >= 0)
                            {
                                j++;
                            }
                            else
                            {
                                j--;
                            }
                        }
                        error += Math.Abs(dy);
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    int j = y1;
                    for (int i = x1; i > x2; --i)
                    {
                        g.FillRectangle(Brushes.Red, i, j, 1, 1);                        
                        if(error >= 0)
                        {
                            error -= Math.Abs(dx);
                            //checking to see if the y axis coordinate is increasing or decreasing
                            if(dy >= 0)
                            {
                                j++;
                            }
                            else
                            {
                                j--;
                            }
                        }
                        error += Math.Abs(dy);
                        Thread.Sleep(100);
                    }
                }
            }
            else
            {
                //setting the error value
                int error = Math.Abs(dy) - Math.Abs(dx);
                //checking to see if the x axis coordinate is increasing or decreasing
                if (dy >= 0)
                {
                    int i = x1;
                    for (int j = y1; j < y2; ++j)
                    {
                        g.FillRectangle(Brushes.Red, i, j, 1, 1);
                        if (error >= 0)
                        {
                            error -= Math.Abs(dx);
                            //checking to see if the y axis coordinate is increasing or decreasing
                            if (dx >= 0)
                            {
                                i++;
                            }
                            else
                            {
                                i--;
                            }
                        }
                        error += Math.Abs(dy);
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    int i = x1;
                    for (int j = x1; j > x2; --j)
                    {
                        g.FillRectangle(Brushes.Red, i, j, 1, 1);
                        if (error >= 0)
                        {
                            error -= Math.Abs(dx);
                            //checking to see if the y axis coordinate is increasing or decreasing
                            if (dx >= 0)
                            {
                                j++;
                            }
                            else
                            {
                                j--;
                            }
                        }
                        error += Math.Abs(dy);
                        Thread.Sleep(100);
                    }
                }
            }
        }
    }
}
