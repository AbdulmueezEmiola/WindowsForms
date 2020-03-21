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

namespace DrawingCylinder
{
    public partial class Form1 : Form
    {
        float AxisZ = 0;
        float AxisY = 0;
        float AxisX = 0;
        float scaleRadius = 1;
        float scaleHeight = 1;
        Vector3 lamp;
        bool drawEnds = false;
        private const int num_sides = 10000;
        Cylinder cylinder = new Cylinder(15, new Vector3(1, 3, 1), new Vector3(-1, 0, 1), 100);
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            lamp = Vector3.Normalize(new Vector3(-1, 1, 1));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void drawTriangle(Graphics gr, Triangle triangle, Color color) {            
            var brush = new SolidBrush(color);
            var path = new GraphicsPath();
            Vector3[] vectTriangle = triangle.getTriangle();
            Vector3 point1 = vectTriangle[0];
            Vector3 point2 = vectTriangle[1];
            Vector3 point3 = vectTriangle[2];
            path.AddLine(point1.X, point1.Y, point2.X, point2.Y);
            //Console.WriteLine(point1.X + " " + point1.Y + " " + point2.X + " " + point2.Y);
            path.AddLine(point2.X, point2.Y, point3.X, point3.Y);
            //Console.WriteLine(point2.X + " " + point2.Y + " " + point3.X + " " + point3.Y);
            path.CloseFigure();
            gr.FillPath(brush,path);
        
        }
        private void drawCircle(Graphics gr, Circle circle)
        {
            Vector3 center = circle.getCenter();
            Vector3 v1 = circle.getDirection();
            double radius = circle.getRadius();
            Vector3 v2 = new Vector3(v1.Z, v1.Z, -v1.X - v1.Y);
            Vector3 v3 = Vector3.Cross(v1, v2);
            var v2Length = radius / v2.Length();
            var v3Length = radius / v3.Length();
            v2 = new Vector3((float)v2Length * v2.X, (float)v2Length * v2.Y, (float)v2Length * v2.Z);
            v3 = new Vector3((float)v3Length * v3.X, (float)v3Length * v3.Y, (float)v3Length * v3.Z);
            double theta = 0;
            double dtheta = 2 * Math.PI / num_sides;
            for(int i =0; i < num_sides; ++i)
            {
                Vector3 point1 = new Vector3(center.X + v2.X * (float)Math.Cos(theta) + v3.X * (float)Math.Sin(theta),
                    center.Y + v2.Y * (float)Math.Cos(theta) + v3.Y * (float)Math.Sin(theta),
                    center.Z + v2.Z * (float)Math.Cos(theta) + v3.Z * (float)Math.Sin(theta));
                theta += dtheta;
                Vector3 point2 = new Vector3(center.X + v2.X * (float)Math.Cos(theta) + v3.X * (float)Math.Sin(theta),
                    center.Y + v2.Y * (float)Math.Cos(theta) + v3.Y * (float)Math.Sin(theta),
                    center.Z + v2.Z * (float)Math.Cos(theta) + v3.Z * (float)Math.Sin(theta));
                Triangle triangle = new Triangle(center, point1, point2);
                drawTriangle(gr, triangle,Color.Brown);
            }
       
        }
        private void drawRectangle(Graphics gr, Rectangle rectangle, Color color)
        {
            Vector3 []vertexes = rectangle.getRectangle();
            Vector3 vertex1 = vertexes[0];
            Vector3 vertex2 = vertexes[1];
            Vector3 vertex3 = vertexes[2];
            Vector3 vertex4 = vertexes[3];
            Triangle triangle1 = new Triangle(vertex1, vertex2, vertex4);
            Triangle triangle2 = new Triangle(vertex2, vertex3, vertex4);
            drawTriangle(gr, triangle1, color);
            drawTriangle(gr, triangle2, color);
        }
        private void splitIntoRectangle(Graphics gr, Cylinder cylinder)
        {
            Vector3 center = cylinder.getCenter();
            Vector3 v1 = cylinder.getDirection();
            double radius = cylinder.getRadius();
            Vector3 v2 = new Vector3(v1.Z, v1.Z, -v1.X - v1.Y);
            Vector3 v3 = Vector3.Cross(v1, v2);
            Vector3 axis = cylinder.getDirection();
            var v2Length = radius / v2.Length();
            var v3Length = radius / v3.Length();
            v2 = new Vector3((float)v2Length * v2.X, (float)v2Length * v2.Y, (float)v2Length * v2.Z);
            v3 = new Vector3((float)v3Length * v3.X, (float)v3Length * v3.Y, (float)v3Length * v3.Z);
            double theta = 0;
            double dtheta = 2 * Math.PI / num_sides;
            float height = (float)cylinder.getHeight();
            for (int i = 0; i < num_sides; ++i)
            {
                Vector3 point1 = new Vector3(center.X + v2.X * (float)Math.Cos(theta) + v3.X * (float)Math.Sin(theta),
                    center.Y + v2.Y * (float)Math.Cos(theta) + v3.Y * (float)Math.Sin(theta),
                    center.Z + v2.Z * (float)Math.Cos(theta) + v3.Z * (float)Math.Sin(theta));
                theta += dtheta;
                Vector3 point2 = new Vector3(center.X + v2.X * (float)Math.Cos(theta) + v3.X * (float)Math.Sin(theta),
                    center.Y + v2.Y * (float)Math.Cos(theta) + v3.Y * (float)Math.Sin(theta),
                    center.Z + v2.Z * (float)Math.Cos(theta) + v3.Z * (float)Math.Sin(theta));
                Vector3 point3 = new Vector3(point1.X + height * axis.X, point1.Y + height * axis.Y, point1.Z + height * axis.Z);
                Vector3 point4 = new Vector3(point2.X + height * axis.X, point2.Y + height * axis.Y, point2.Z + height * axis.Z);
                drawRectangle(gr, new Rectangle(point1, point2, point3, point4), Color.Brown);
            }
        }
        private void drawCylinder(Graphics gr, Matrix4x4 mat, double matScale)
        {
            Vector3 axisTemp = Vector3.Transform(cylinder.getDirection(), mat);
            Vector3 centerTemp = Vector3.Transform(cylinder.getCenter(), mat);
            double radiusTemp = cylinder.getRadius() * matScale;
            double heightTemp = cylinder.getRadius() * matScale;
            Cylinder cylinderTemp = new Cylinder(radiusTemp, centerTemp, axisTemp, heightTemp);
            double radius = cylinderTemp.getRadius();
            Vector3 center = cylinderTemp.getCenter();
            Vector3 axis = cylinderTemp.getDirection();
            float height = (float)cylinderTemp.getHeight();
            Circle circle1 = new Circle(radius, center, axis);
            Vector3 center2 = new Vector3(center.X + height*axis.X, center.Y + height*axis.Y, center.Z + height*axis.Z);
            Circle circle2 = new Circle(radius, center2, axis);
            if (drawEnds) {
                drawCircle(gr, circle1);
                drawCircle(gr, circle2);
            }
            splitIntoRectangle(gr, cylinderTemp);
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var rotateM = Matrix4x4.CreateFromYawPitchRoll(AxisZ, AxisY, AxisX);
            var scale = scaleRadius;
            var proj = Matrix4x4.CreateShadow(lamp, new Plane(0, 0.7f, -0.2f, -100));
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(Width / 2, Height / 2);
            drawCylinder(e.Graphics, rotateM*proj, scale);
            drawCylinder(e.Graphics, rotateM, scale);
        }

        private void RotXTrackBar_Scroll(object sender, EventArgs e)
        {
            AxisX = (float)(rotXTrackBar.Value * Math.PI / 180);
            Invalidate();
        }

        private void RotYTrackBar_Scroll(object sender, EventArgs e)
        {
            AxisY = (float)(rotYTrackBar.Value * Math.PI / 180);
            Invalidate();
        }

        private void RotZtrackBar_Scroll(object sender, EventArgs e)
        {
            AxisZ = (float)(rotZTrackBar.Value * Math.PI / 180);
            Invalidate();
        }

        private void ScaleRadiusTrackBar1_Scroll(object sender, EventArgs e)
        {
            scaleRadius = scaleRadiusTrackBar1.Value;
            scaleHeight = scaleRadiusTrackBar1.Value;
            Invalidate();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                drawEnds = true;
            }
            else
            {
                drawEnds = false;
            }
            Invalidate();
        }

    }
}
