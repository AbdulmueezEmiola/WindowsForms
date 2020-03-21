using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing.Drawing2D;

namespace Assignment4Possible
{
    public partial class Form1 : Form
    {
        Model model;
        Vector3 lamp;
        float axisZ = 0;
        float axisY = 0;
        float scale = 50;
        float axisX = 0;
        Vector3 position = new Vector3(0, 0, 0);
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            lamp = Vector3.Normalize(new Vector3(-1, 1, -1));
            model = new Model();
            model.Vertexes.Add(new Vector3(-2, -1, 1));
            model.Vertexes.Add(new Vector3(-2, 2, 3));
            model.Vertexes.Add(new Vector3(2, 1, -1));
            model.Fig.Add(new Figure(0, 1,2));

        }
        private void AddCylinder(Vector3 end_point, Vector3 axis, double radius, int num_sides) {
            Vector3 v1;
            if ((axis.Z < -0.01) || (axis.Z > 0.01)) {
                v1 = new Vector3(axis.Z, axis.Z, -axis.X - axis.Y);
            }
            else
            {
                v1 = new Vector3(-axis.Y - axis.Z, -axis.X, -axis.X);
            }
            Vector3 v2 = Vector3.Cross(v1, axis);
            var v1Length = radius/v1.Length();
            var v2Length = radius / v2.Length();
            double theta = 0;
            double dtheta = 2 * Math.PI / num_sides;
            v1 = new Vector3((float)v1Length * v1.X, (float)v1Length * v1.Y,(float) v1Length * v1.Z);
            v2 = new Vector3((float)v2Length * v2.X, (float)v2Length * v2.Y, (float)v2Length * v2.Z);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var scaleM = Matrix4x4.CreateScale(scale);
            var rotateM = Matrix4x4.CreateFromYawPitchRoll(axisZ, axisY, axisX);
            var m = scaleM * rotateM;
            Draw(e.Graphics, m, false);
        }
        private void Draw(Graphics gr, Matrix4x4 m, bool calcLevelOfGray) {
            gr.ResetTransform();
            gr.TranslateTransform(Width / 2, Height / 2);
            var vertexes = model.Vertexes.Select(v => Vector3.Transform(v, m)).ToList();            
            var brush = new SolidBrush(Color.Black);
            var path = new GraphicsPath();
            path.AddEllipse(5, 5, 10, 10);
            path.AddEllipse(32, 38, 10, 10);
            path.CloseFigure();
            gr.FillPath(brush, path);
            foreach (var f in model.Fig) {
                var prev = vertexes[f.Vertexes[0]];
                for(int i = 1; i < f.Vertexes.Length; ++i)
                {
                    var v = vertexes[f.Vertexes[i]];
                    path.AddLine(prev.X, prev.Y, v.X, v.Y);
                    prev = v;
                }
                path.CloseFigure();
                brush.Color = Color.FromArgb(150, 150, 150);
                gr.FillPath(brush, path);
                path.Reset();
            }
        }

        private void RowTrackBar_Scroll(object sender, EventArgs e)
        {
            axisX = (float)(rowTrackBar.Value * Math.PI / 180);
            //ReDraw
            Invalidate();
        }

        private void RotationTrackBarY_Scroll(object sender, EventArgs e)
        {
            axisY = (float)(rotationTrackBarY.Value * Math.PI / 180);
            Invalidate();
        }

        private void RotationTrackBarZ_Scroll(object sender, EventArgs e)
        {
            axisZ = (float)(rotationTrackBarZ.Value * Math.PI / 180);
            Invalidate();
        }
    }
}
