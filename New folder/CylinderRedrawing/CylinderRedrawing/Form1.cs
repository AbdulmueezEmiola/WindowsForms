using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CylinderRedrawing
{
    public partial class Form1 : Form
    {
        private List<Vector3> figure = new List<Vector3>();
        Point centre = new Point(0, 0);
        double angle_oxy;
        double angle_oxy_res;
        double radius;
        double height;
        Vector3 lamp;
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            lamp = Vector3.Normalize(new Vector3(1, 1, 1));
            centre.X = pictureBox1.Width / 2+50;
            centre.Y = pictureBox1.Height / 2-50;
            angle_oxy = 0;
            angle_oxy_res =1.0;
            radius = 100;
            height = 100;
        }
        //gotten from the formula from axonometric projection
        private Point Convert_3D_To_2D_Point(Vector3 point)
        {
            double xPoint = -point.Z * Math.Sin(angle_oxy) + point.X * Math.Cos(angle_oxy) + centre.X;
            double yPoint = (point.Z * System.Math.Cos(angle_oxy) + point.X * System.Math.Sin(angle_oxy)) * System.Math.Sin(angle_oxy_res) 
                + point.Y* System.Math.Cos(angle_oxy_res) + centre.Y;
            return new Point((int)(xPoint), (int)(yPoint));
        }
        void draw(List<Vector3> points)
        {
            if (points.Count <= 0)
            {
                return;
            }
            var proj = Matrix4x4.CreateShadow(lamp, new Plane(-1,-1,-1,-300));
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var path = new GraphicsPath();
            var path2 = new GraphicsPath();
            Graphics grf = Graphics.FromImage(bmp);
            for(int i = 0; i < points.Count-1; ++i)
            {
                path.AddLine(Convert_3D_To_2D_Point(points[i]), Convert_3D_To_2D_Point(points[i + 1]));
                path2.AddLine(Convert_3D_To_2D_Point(Vector3.Transform(points[i],proj)), Convert_3D_To_2D_Point(Vector3.Transform(points[i + 1],proj)));
            }
            grf.DrawPath(Pens.Black, path);
            grf.DrawPath(Pens.Black, path2);
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ComputeButton_Click(object sender, EventArgs e)
        {
            fillFigure();
            draw(figure);
        }
        private void fillFigure()
        {
            if (figure != null)
            {
                figure.Clear();
            }
            for (int i = 0; i < height; i += 1)
            {
                for (double j = 0; j < 6.28; j += 0.1)
                {
                    figure.Add(new Vector3((int)(radius * Math.Cos(j)), (int)(radius * Math.Sin(j)), i));
                }
            }
        }
        private void TrackBarRotX_Scroll(object sender, EventArgs e)
        {
            var mat = Matrix4x4.CreateRotationX(trackBarRotX.Value * (float) Math.PI / (float)180);
            for(int i = 0; i < figure.Count; ++i)
            {
                figure[i] = Vector3.Transform(figure[i], mat);
            }
            draw(figure);
        }

        private void TrackBarRotY_Scroll(object sender, EventArgs e)
        {
            var mat = Matrix4x4.CreateRotationY(trackBarRotY.Value * (float)Math.PI / (float)180);
            for (int i = 0; i < figure.Count; ++i)
            {
                figure[i] = Vector3.Transform(figure[i], mat);
            }
            draw(figure); 
        }

        private void TrackBarScaleRadius_Scroll(object sender, EventArgs e)
        {
            radius = trackBarScaleRadius.Value * 100;
            fillFigure();
            draw(figure);
        }

        private void TrackBarScaleHeight_Scroll(object sender, EventArgs e)
        {
            height = trackBarScaleHeight.Value * 100;
            fillFigure();
            draw(figure);
        }
    }
}
