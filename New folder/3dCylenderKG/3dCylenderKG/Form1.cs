using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3dCylenderKG
{
    public partial class Form1 : Form
    {

        #region переменные

        // угол
        double angel_OXY;

        // угол
        double angel_res_OXY;

        // точка 0
        Point Point_0 = new Point(0, 0);

        // фигура
        List<Point3D> figure_3D = new List<Point3D>();

        // pen для проекции figure_3D
        Pen pen_figure_3D = new Pen(Color.Black);

        // для временного хранения при поворотах
        int tmp_XX;
        int tmp_YY;

        # endregion
        public Form1()
        {
            InitializeComponent();

            Point_0.X = pictureBox_main.Width / 2;
            Point_0.Y = pictureBox_main.Height / 2;     //точка отсчета

            // установим углы
            angel_OXY = 3.14;
            angel_res_OXY = 1.0;

            

        }

        private Point convert_3D_in_2D_Point(Point3D val)
        {
            // проицируем
            double res_x = -val._z * System.Math.Sin(angel_OXY) + val._x * System.Math.Cos(angel_OXY) + Point_0.X;
            double res_y = -(val._z * System.Math.Cos(angel_OXY) + val._x * System.Math.Sin(angel_OXY)) * System.Math.Sin(angel_res_OXY) + val._y * System.Math.Cos(angel_res_OXY) + Point_0.Y;

            return new Point((int)(res_x), (int)(res_y));
        }

        void draw(List<Point3D> val)
        {
            // проверка наличия фигуры 3d
            if (figure_3D.Count <= 0)
                return;

            // создадим bitmap и Graphics
            Bitmap bmp = new Bitmap(pictureBox_main.Width, pictureBox_main.Height);
            Graphics grf = Graphics.FromImage(bmp);

            for (int i = 0; i < val.Count - 1; i++)
            {
                grf.DrawLine(pen_figure_3D, convert_3D_in_2D_Point(val[i]), convert_3D_in_2D_Point(val[i + 1]));
            }

            // выводим 
            pictureBox_main.Image = bmp;
            pictureBox_main.Refresh();
            //GC.Collect();
        }

            private void Cylinder_btn_Click(object sender, EventArgs e)
        {
            // очистим если есть
            if (figure_3D != null)
                figure_3D.Clear();

            for(int i =0; i < 200; i+=2)
            {
                for(double j = 0; j < 6.28; j += 0.1)
                {
                    figure_3D.Add(new Point3D((int)(200 * Math.Cos(j)), (int)(200 * Math.Sin(j)), i));
                }
            }
            
            draw(figure_3D);
        }

        private void PictureBox_main_MouseDown(object sender, MouseEventArgs e)
        {
            // зададим точку отсчета
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point_0.X = e.X;
                Point_0.Y = e.Y;
            }
        }

        private void PictureBox_main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point_0.X = e.X;
                Point_0.Y = e.Y;
                draw(figure_3D);
            }
        }

        private void TrackBar_OX_Scroll(object sender, EventArgs e)
        {
            for (int i = 0; i < figure_3D.Count; ++i)
            {
                var axisX = trackBar_OX.Value / 360 * Math.PI;
                Vector3 vector = new Vector3(figure_3D[i]._x, figure_3D[i]._y, figure_3D[i]._z);
                var mat = Matrix4x4.CreateFromYawPitchRoll((float)axisX, 0, 0);
                vector = Vector3.Transform(vector, mat);
                figure_3D[i] = new Point3D((int)vector.X, (int)vector.Y, (int)vector.Z);
            }
            draw(figure_3D);
        }

        private void TrackBar_res_OXY_Scroll(object sender, EventArgs e)
        {
            angel_res_OXY = (double)(trackBar_res_OXY.Value) / 100;
            draw(figure_3D);
        }
    }
}
