using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3d
{
    /// <summary>
    /// класс основной формы
    /// </summary>
    public partial class Form_main : Form
    {

        # region переменные
        
        // угол
        double angel_OXY;

        // угол
        double angel_res_OXY;

        // точка 0
        Point Point_0 = new Point(0, 0);

        // фигура
        List<Point3D> figure_3D = new List<Point3D>();

        // pen для проекции figure_3D
        Pen pen_figure_3D = new Pen(Color.Red);

        // для временного хранения при поворотах
        int tmp_XX;
        int tmp_YY;

        # endregion

        /// <summary>
        /// конструктор формы
        /// </summary>        
        public Form_main()
        {
            InitializeComponent();

            // Двойная буф-я
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty).SetValue(pictureBox_main, true, null);

            // зададим точку отсчета по середине
            Point_0.X = pictureBox_main.Width / 2;
            Point_0.Y = pictureBox_main.Height / 2;

            // установим углы
            angel_OXY = 1.0;
            angel_res_OXY = 1.0;

            //
            trackBar_OX.Value = 100;
            trackBar_res_OXY.Value = 100;
        }        

        # region расчеты и отрисовка

        // проекция 2D на 2D
        private Point convert_3D_in_2D_Point(Point3D val)
        {
            // проицируем
            double res_x = -val._z * System.Math.Sin(angel_OXY) + val._x * System.Math.Cos(angel_OXY) + Point_0.X;
            double res_y = -(val._z * System.Math.Cos(angel_OXY) + val._x * System.Math.Sin(angel_OXY)) * System.Math.Sin(angel_res_OXY) + val._y * System.Math.Cos(angel_res_OXY) + Point_0.Y ;
             
            return new Point((int)(res_x), (int)(res_y));
        }

        # endregion

        # region фигуры

        // рисуем
        void draw(List<Point3D> val)
        {
            // проверка наличия фигуры 3d
            if (figure_3D.Count <= 0)
                return;

            // создадим bitmap и Graphics
            Bitmap bmp = new Bitmap(pictureBox_main.Width, pictureBox_main.Height);
            Graphics grf = Graphics.FromImage(bmp);                                               


            // пербираем
            for (int i = 0; i < val.Count - 1; i++)
            {
                grf.DrawLine(pen_figure_3D, convert_3D_in_2D_Point(val[i]), convert_3D_in_2D_Point(val[i + 1]));
            }

            // выводим 
            pictureBox_main.Image = bmp;
            pictureBox_main.Refresh();
            GC.Collect();
            //grf.Dispose();
            //;bmp.Dispose();

        }              

        // куб
        private void cube()
        {
            // очистим если есть
            if (figure_3D != null)
                figure_3D.Clear();

            // заполним
            figure_3D.Add(new Point3D(0, 0, 0));
            figure_3D.Add(new Point3D(300, 0, 0));
            figure_3D.Add(new Point3D(300, 0, 300));
            figure_3D.Add(new Point3D(0, 0, 300));
            figure_3D.Add(new Point3D(0, 300, 300));
            figure_3D.Add(new Point3D(0, 300, 0));
            figure_3D.Add(new Point3D(0, 0, 300));
            figure_3D.Add(new Point3D(0, 0, 0));
            figure_3D.Add(new Point3D(0, 300, 0));
            figure_3D.Add(new Point3D(300, 300, 0));
            figure_3D.Add(new Point3D(300, 300, 300));
            figure_3D.Add(new Point3D(300, 0, 300));
            figure_3D.Add(new Point3D(300, 0, 0));
            figure_3D.Add(new Point3D(300, 300, 0));
            figure_3D.Add(new Point3D(0, 300, 0));
            figure_3D.Add(new Point3D(0, 300, 300));
            figure_3D.Add(new Point3D(300, 300, 300));
            figure_3D.Add(new Point3D(300, 300, 300)); 
        }

        // призма
        private void prism()
        {
            // очистим если есть
            if (figure_3D != null)
                figure_3D.Clear();

            // заполним
            figure_3D.Add(new Point3D(0, 0, 0));
            figure_3D.Add(new Point3D(300, 0, 0));
            figure_3D.Add(new Point3D(0, 300, 0));
            figure_3D.Add(new Point3D(0, 0, 300));
            figure_3D.Add(new Point3D(300, 0, 0));
            figure_3D.Add(new Point3D(0, 0, 0));
            figure_3D.Add(new Point3D(0, 0, 300));
            figure_3D.Add(new Point3D(0, 300, 0));
            figure_3D.Add(new Point3D(0, 0, 0));         

        }

        // сфера
        private void circle()
        {
            // очистим если есть
            if (figure_3D != null)
                figure_3D.Clear();

                // для сферы
                for (double i = 0.00; i <= 3.14; i += 0.07)
                {
                    for (double j = 0.00; j <= 6.28; j += 0.07)
                        figure_3D.Add(new Point3D((int)(200 * Math.Sin(i) * Math.Sin(j)), (int)(200 * Math.Sin(i) * Math.Cos(j)), (int)(200 * Math.Cos(i))));                
                }
        }

        # endregion

        # region обработчики

        // куб
        private void button_cub_Click(object sender, EventArgs e)
        {
            cube();
            draw(figure_3D);
        }

        // для DOWNmous
        private void pictureBox_main_MouseDown(object sender, MouseEventArgs e)
        {
            // зададим точку отсчета
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            { 
                Point_0.X = e.X;
                Point_0.Y = e.Y;
            }
        }

        // клик сфера
        private void button_circle_Click(object sender, EventArgs e)
        {
            circle();
            draw(figure_3D);
        }

        // клик по кнопки куб
        private void button_prism_Click(object sender, EventArgs e)
        {
            prism();
            draw(figure_3D);
        }

        // перемещение мыши
        private void pictureBox_main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                # region горизонтальный поворт
                // вправо
                if (e.X > tmp_XX)
                {
                    if (trackBar_OX.Value <= trackBar_OX.Maximum && trackBar_OX.Value > 0)
                    {                      
                        trackBar_OX.Value -= 1;
                        trackBar1_Scroll(this, EventArgs.Empty);                                                                       
                    }
                    else
                    {                        
                        if (trackBar_OX.Value == 0)
                            trackBar_OX.Value = trackBar_OX.Maximum;
                    }
                }

                // влево
                if (e.X < tmp_XX)
                {
                    if (trackBar_OX.Value < trackBar_OX.Maximum && trackBar_OX.Value >= 0)
                    { 
                        trackBar_OX.Value += 1;
                        trackBar1_Scroll(this, EventArgs.Empty);

                        // переход через MAX
                        if (trackBar_OX.Value >= trackBar_OX.Maximum)
                            trackBar_OX.Value = 0;     
                    }
                }

                # endregion

                # region вертикальный поворт

                // вниз
                if (e.Y > tmp_YY)
                {
                    if (trackBar_res_OXY.Value < trackBar_res_OXY.Maximum && trackBar_res_OXY.Value >= 0)
                    {
                        trackBar_res_OXY.Value += 1;
                        trackBar_res_OXY_Scroll(this, EventArgs.Empty);
                    }
                    else
                    {
                        // переход через MAX
                         if (trackBar_res_OXY.Value >= trackBar_OX.Maximum)
                             trackBar_res_OXY.Value = 0;
                    }
                }

                // вверх
                if (e.Y < tmp_YY)
                {
                    if (trackBar_res_OXY.Value <= trackBar_res_OXY.Maximum && trackBar_res_OXY.Value > 0)
                    { 
                        trackBar_res_OXY.Value -= 1;
                        trackBar_res_OXY_Scroll(this, EventArgs.Empty);
                    }
                    else
                    {
                        // переход через 0
                        if (trackBar_res_OXY.Value <= 0)
                            trackBar_res_OXY.Value = trackBar_res_OXY.Maximum;  
                    }
                }

                # endregion

                // временно для хранения
                tmp_XX = e.X;
                tmp_YY = e.Y;

                return; 
            }

            // пермещаем точку отсчета 0
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point_0.X = e.X;
                Point_0.Y = e.Y;
                draw(figure_3D);
            }
        }

        // поворот
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            angel_OXY = (double)(trackBar_OX.Value) / 100;
            draw(figure_3D);
        }

        // поворот
        private void trackBar_res_OXY_Scroll(object sender, EventArgs e)
        {
            angel_res_OXY = (double)(trackBar_res_OXY.Value) / 100;
            draw(figure_3D);
        }

        // изменение размеров формы
        private void Form_main_Resize(object sender, EventArgs e)
        {
            draw(figure_3D);
        }

        # endregion
    }
}
