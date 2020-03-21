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
namespace Assignment2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(x1TextBox.Text);
            int x2 = Convert.ToInt32(x2TextBox.Text);
            int y1 = Convert.ToInt32(y1TextBox.Text);
            int y2 = Convert.ToInt32(y2TextBox.Text);
            if(x2TextBox.TextLength == 0 && x1TextBox.TextLength ==0 && y1TextBox.TextLength ==0 && y2TextBox.TextLength == 0)
            {
                MessageBox.Show("Input the coordinates of the axis");
            }
            else
            {
                x1TextBox.Hide();
                x2TextBox.Hide();
                y1TextBox.Hide();
                y2TextBox.Hide();
                button1.Hide();
                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                if(y1 == y2)
                {
                    Graphics draw = CreateGraphics();
                    for(int x = x1; x < x2; ++x)
                    {
                        draw.FillRectangle(Brushes.Red, x, y1, 1, 1);
                        Thread.Sleep(100);
                    }
                    draw.Dispose();
                    return;
                }
                else if(x1 == x2)
                {
                    Graphics draw = CreateGraphics();
                    for (int y = y1; y < y2; ++y)
                    {
                        draw.FillRectangle(Brushes.Red, x1, y, 1, 1);
                        Thread.Sleep(100);
                    }
                    draw.Dispose();
                    return;
                }
                double m = (Convert.ToDouble(y2) - Convert.ToDouble(y1)) / (Convert.ToDouble(x2) - Convert.ToDouble(x1));
                MessageBox.Show("I'm here " + m);
                if (m>0 && m <= 1)
                {
                    if (x1 < x2)
                    {
                        int y = y1;
                        double error = 0;
                        Graphics draw = CreateGraphics();
                        for (int x = x1; x <= x2; ++x)
                        {
                            if (error + m < 0.5)
                            {
                                error = error + m;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                            else
                            {
                                error = error + m - 1;
                                ++y;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                        }
                        draw.Dispose();
                    }
                    else
                    {
                        int y = y2;
                        double error = 0;
                        Graphics draw = CreateGraphics();
                        for (int x = x2; x <= x1; ++x)
                        {
                            if (error + m < 0.5)
                            {
                                error = error + m;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                            else
                            {
                                error = error + m - 1;
                                ++y;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                        }
                        draw.Dispose();
                    }                 
                }
                if(m<0 && m>= -1)
                {
                    if(x1 < x2)
                    {
                        int y = y1;
                        double error = 0;
                        Graphics draw = CreateGraphics();
                        for(int x = x1; x <= x2; ++x)
                        {
                            if(error +m > -0.5)
                            {
                                error = error + m;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                            else
                            {
                                error = error + m + 1;
                                --y;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                        }
                    }
                    else
                    {
                        int y = y1;
                        double error = 0;
                        Graphics draw = CreateGraphics();
                        for(int x = x2; x <= x1; ++x)
                        {
                            if (error + m > -0.5)
                            {
                                error = error + m;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                            else
                            {
                                error = error + m + 1;
                                --y;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                        }
                    }
                }
                if(m > 1)
                {
                    if(y1 < y2)
                    {
                        int x = x1;
                        double error = 0;
                        Graphics draw = CreateGraphics();
                        for(int y = y1; y <= y2; ++y)
                        {
                            if(error +m < 0.5)
                            {
                                error = error + m;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                            else
                            {
                                error = error + m - 1;
                                ++x;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                        }
                    }
                    else
                    {
                        int x = x1;
                        double error = 0;
                        Graphics draw = CreateGraphics();
                        for(int y = y2;y<= y1; ++y)
                        {
                            if(error + m < 0.5)
                            {
                                error = error + m;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                            else
                            {
                                error = error + m - 1;
                                ++x;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                        }
                    }
                }
                if(m < -1)
                {
                    if (y1 < y2)
                    {
                        int x = x1;
                        double error = 0;
                        Graphics draw = CreateGraphics();
                        for (int y = y1; y <= y2; ++y)
                        {
                            if (error + m > -0.5)
                            {
                                error = error + m;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                            else
                            {
                                error = error + m + 1;
                                --x;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                        }
                    }
                    else
                    {
                        int x = x1;
                        double error = 0;
                        Graphics draw = CreateGraphics();
                        for (int y = y2; y <= y1; ++y)
                        {
                            if (error + m > -0.5)
                            {
                                error = error + m;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                            else
                            {
                                error = error + m + 1;
                                --x;
                                draw.FillRectangle(Brushes.Red, x, y, 1, 1);
                                Thread.Sleep(100);
                            }
                        }
                    }

                } 
            }
        }
    }
}
