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
using System.Numerics;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Model model;    //Coub model
        Vector3 lamp;   //Light source

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            lamp = Vector3.Normalize(new Vector3(-1, 1, -1)); //Light source

            //Create a model (coub)
            model = new Model();

            //Initialize the vertexes
            model.Vertexes.Add(new Vector3(1, 1, 1));       //0
            model.Vertexes.Add(new Vector3(-1, 1, 1));      //1
            model.Vertexes.Add(new Vector3(-1, -1, 1));     //2
            model.Vertexes.Add(new Vector3(1, -1, 1));      //3
            model.Vertexes.Add(new Vector3(1, 1, -1));      //4
            model.Vertexes.Add(new Vector3(-1, 1, -1));     //5
            model.Vertexes.Add(new Vector3(-1, -1, -1));    //6
            model.Vertexes.Add(new Vector3(1, -1, -1));     //7
            
            // Initialize the axis
            model.Fig.Add(new Figure(3, 2, 1, 0));          // Top
            model.Fig.Add(new Figure(4, 5, 6, 7));          // Bottom
            model.Fig.Add(new Figure(4, 7, 3, 0));          // Right
            model.Fig.Add(new Figure(1, 2, 6, 5));          // Left
            model.Fig.Add(new Figure(0, 1, 5, 4));          // Front
            model.Fig.Add(new Figure(2, 3, 7, 6));          // Back
        }

        //Rotation angles
        float AxisZ = 0;
        float AxisY = 0;
        float AxisX = 0;
        float scale = 10;

        Vector3 position = new Vector3(0, 0, 0);

        //When trackBar changes
        void tb_ValueChanged(object sender, EventArgs e)
        {
            scale = tbScale.Value;

            AxisY = (float)(tbRotateY.Value * Math.PI / 180);
            AxisX = (float)(tbRotateX.Value * Math.PI / 180);
            AxisZ = (float)(tbRotateZ.Value * Math.PI / 180);

            //ReDraw
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Matrix of scale
            var scaleM = Matrix4x4.CreateScale(scale);
            
            //Matrix of rotation
            var rotateM = Matrix4x4.CreateFromYawPitchRoll(AxisZ, AxisY, AxisX);
            
            //Matrix of translate
            var translateM = Matrix4x4.CreateTranslation(position);
            
            //Result matrix
            var m = scaleM * rotateM * translateM;

            //Matrix of shadow projection
            var proj = Matrix4x4.CreateShadow(lamp, new Plane(0, 0.7f, -0.2f, -200));

            //Drawing the shadow
            Draw(e.Graphics, m * proj, false);

            //Drawing the model
           // Draw(e.Graphics, m, true);
        }

        private void Draw(Graphics gr, Matrix4x4 m, bool calcLevelOfGray)
        {
            gr.ResetTransform();
            
            //Set the axis begin
            gr.TranslateTransform(Width / 2, Height / 2);

            //Multiply vectors and matrix
            var vertexes = model.Vertexes.Select(v => Vector3.Transform(v, m)).ToList();

            //Sort vertexes by ascending
            Sort(model.Fig, vertexes);

            //Process of Drawing
            using (var brush = new SolidBrush(Color.Black))
            using (var path = new GraphicsPath())
            {
                //Create the vertexes
                foreach (var f in model.Fig)
                {
                    //Polygon
                    var prev = vertexes[f.Vertexes[0]];
                    for (int i = 1; i < f.Vertexes.Length; i++)
                    {
                        var v = vertexes[f.Vertexes[i]];
                        path.AddLine(prev.X, prev.Y, v.X, v.Y);
                        prev = v;
                    }
                    path.CloseFigure();

                    var gray = 150;

                    //Lightening
                    if (calcLevelOfGray)
                    {
                        var p = vertexes[f.Vertexes[0]];
                        var dir1 = vertexes[f.Vertexes[1]] - p; //Direction vector
                        var dir2 = vertexes[f.Vertexes[2]] - p; //Direction vector
                        var n = Vector3.Cross(dir1, dir2); //Normal vector
                        
                        var light = Vector3.Dot(Vector3.Normalize(n), Vector3.Normalize(lamp)); //Scalar multiply normal vector on vector of lightening
                        gray = (int)(255 * (light > 0 ? light : 0));
                    }

                    //Fill the vertexes with gray color
                    brush.Color = Color.FromArgb(gray, gray, gray);
                    gr.FillPath(brush, path);

                    path.Reset();
                }
            }
        }

        //Method of Vertex sorting ascending
        private void Sort(List<Figure> figs, List<Vector3> vertexes)
        {
            foreach (var f in figs)
            {
                f.Distance = vertexes[f.Vertexes[0]].Z;
                for (int i = 1; i < f.Vertexes.Length; i++)
                {
                    var v = vertexes[f.Vertexes[i]];
                    if (f.Distance > v.Z) f.Distance = v.Z;
                }
            }

            figs.Sort((f1, f2) => f1.Distance.CompareTo(f2.Distance));
        }
    }
}
