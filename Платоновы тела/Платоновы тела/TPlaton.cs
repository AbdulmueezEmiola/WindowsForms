using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Платоновы_тела
{
    public  class TPlaton
    {
        public  double Xmin;    // прямоугольник
        public  double Xmax;
        public  double Ymin;
        public  double Ymax;
        //public  double FA;
        public  int I2;
        public  int J2;
        public  bool fTypeFace = false; // true - Line, false - Face
        public  double Alf;
        public  double Bet;
        public  double Alf1;
        public  double Bet1;
        public static double Xs = 0; // 1-я точка схода
        public static double Zs = 0; // 2-я точка схода
        public static double[] Sv = {-0.0, -0.0, 1.5, 1}; // источник света
        public static bool visibleOXYZ = false;
        public static bool visiblePoint = false;
        public static bool visibleShadow = false;
        public static bool flRotate = false;
        public static byte flEdge = 0;
        double AnglStereo = 0.015;

        public  Bitmap bitmap;
        public  SolidBrush myBrush;
        public  Font myFont = new Font("Courier", 10);
        public static TBody body;
        public static TBody body0;

        public TPlaton(int VW, int VH)
        {
            Xmin = -2;
            Xmax =  2;
            Ymin = -2;
            Ymax =  2;
            Alf  = 4.31;
            Bet  = 4.92;
            Alf1 = 0;
            Bet1 = 0;
            //FA = -0.2;
            fTypeFace = false;
            I2 = VW;
            J2 = VH;
            bitmap = new Bitmap(VW, VH);
            myBrush = new SolidBrush(Color.White);
            body = new TBody(0);
            body0 = new TBody(1);
        }

        double[] ToVector(double x, double y, double z)
        { 
            double[] result = new double[4];
            result[0] = x;
            result[1] = y;
            result[2] = z;
            result[3] = 1;
            return result;
        }

        double[] VM_Mult(double[] A, double[][] B)
        {
            double[] result = new double[4];
            for (int j = 0; j < 4; j++)
            {
                result[j] = A[0] * B[0][j];
                for (int k=1; k<4; k++)
                    result[j] +=A[k]*B[k][j];
            }
            if (result[3] != 0)
                for (int j = 0; j < 3; j++)
                    result[j] /= result[3];
            result[3] = 1;
            return result;
        }

        public  double[] Rotate(double[] V, int k, double fi, double p, double r)
        {
            double[][] M = new double[4][];
            
            for (int i = 0; i < 4; i++)
                M[i] = new double[4];

            for (int i = 0; i < 4; i++)
            {
                M[3][i] = 0;
                M[i][3] = 0;
            }
            M[3][3] = 1;
            switch (k)
            {
                case 0:
                    M[0][0]=1; M[0][1]=0;             M[0][2]=0;
                    M[1][0]=0; M[1][1]= Math.Cos(fi); M[1][2]=Math.Sin(fi);
                    M[2][0]=0; M[2][1]=-Math.Sin(fi); M[2][2]=Math.Cos(fi);
                    break;
                case 1:
                    M[0][0]=Math.Cos(fi); M[0][1]=0; M[0][2]=-Math.Sin(fi);
                    M[1][0]=0;            M[1][1]=1; M[1][2]=0;
                    M[2][0]=Math.Sin(fi); M[2][1]=0; M[2][2]=Math.Cos(fi);
                    break;
                case 2:
                    M[0][0]= Math.Cos(fi); M[0][1]=Math.Sin(fi); M[0][2]=0;
                    M[1][0]=-Math.Sin(fi); M[1][1]=Math.Cos(fi); M[1][2]=0;
                    M[2][0]= 0;            M[2][1]=0;            M[2][2]=1;
                    break;
                case 3:
                    M[0][0]= 1; M[0][1]=0; M[0][2]=0;
                    M[1][0]= 0; M[1][1]=1; M[1][2]=0;
                    M[2][0]= 0; M[2][1]=0; M[2][2]=1;
                    M[1][3]= p; M[2][3]=r;
                    break;
            }
            return VM_Mult(V, M);
        }
        
        int II(double x)
        {
            return (int)Math.Round((x - Xmin) * I2 / (Xmax - Xmin));
        }

        int JJ(double y)
        {
            return (int)Math.Round((y - Ymax) * J2 / (Ymin - Ymax));
        }

        double XX(int I)
        {
            return Xmin+(Xmax-Xmin)*I/I2;
        }

        double YY(int J)
        {
            return Ymax + (Ymin - Ymax) * J / J2;
        }

        Point IJ(double[] Vt)
        {
            Point result;
            Vt=Rotate(Vt, 0, Alf,0,0);
            Vt=Rotate(Vt, 1, Bet,0,0);
            result = new Point(II(Vt[0]), JJ(Vt[1]));
            return result;
        }

        double[] Norm(double[] V1,double[] V2,double[] V3)
         {
             double[] Result = new double[4];
             double[] A = new double[4];
             double[] B = new double[4];
             A[0]=V2[0]-V1[0]; A[1]=V2[1]-V1[1]; A[2]=V2[2]-V1[2];
             B[0]=V3[0]-V1[0]; B[1]=V3[1]-V1[1]; B[2]=V3[2]-V1[2];
             double u=A[1]*B[2]-A[2]*B[1];
             double v=-A[0]*B[2]+A[2]*B[0];
             double w=A[0]*B[1]-A[1]*B[0];
             
             double d=Math.Sqrt(u*u+v*v+w*w);
             if (d!=0)
             {
                 Result[0]=u/d;
                 Result[1]=v/d;
                 Result[2]=w/d;
             }
             else 
             {
                 Result[0]=0;
                 Result[1]=0;
                 Result[2]=0;
             }
             return Result;
         }

        void OXYZ(Graphics g)
        {
            Point P0, P1;
            P0 = IJ(ToVector(-3, 0, 0));
            P1 = IJ(ToVector( 3, 0, 0));
            g.DrawLine(Pens.Silver,P0.X,P0.Y,P1.X,P1.Y);
            g.DrawString("X",myFont,Brushes.Black,P1);
            P0 = IJ(ToVector(0, -3, 0));
            P1 = IJ(ToVector(0, 3, 0));
            g.DrawLine(Pens.Silver, P0.X, P0.Y, P1.X, P1.Y);
            g.DrawString("Y",myFont,Brushes.Black,P1);
            P0 = IJ(ToVector(0, 0, -3));
            P1 = IJ(ToVector(0, 0, 3));
            g.DrawLine(Pens.Silver, P0.X, P0.Y, P1.X, P1.Y);
            g.DrawString("Z",myFont,Brushes.Black,P1);
        }

        public void DrawBody(Graphics g)
        {
            int L;
            if ((flEdge == 0) | (flEdge == 2))
            {
                L = body.Vertexs.Length;
                for (int i = 0; i < L; i++)
                {
                    body.VertexsT[i] = Rotate(body.Vertexs[i], 0, Alf1, 0, 0);
                    body.VertexsT[i] = Rotate(body.VertexsT[i], 1, Bet1, 0, 0);
                    body.VertexsT[i] = Rotate(body.VertexsT[i], 3, 0, Xs, Zs);
                    body.VertexsT[i] = Rotate(body.VertexsT[i], 0, Alf, 0, 0);
                    body.VertexsT[i] = Rotate(body.VertexsT[i], 1, Bet, 0, 0);
                }
            }
            switch (flEdge)
            {
                case 0:  // Edges
                    L = body.Edges.Length;
                    for (int i = 0; i < L; i++)
                    {
                        int x1 = II(body.VertexsT[body.Edges[i].p1][0]);
                        int y1 = JJ(body.VertexsT[body.Edges[i].p1][1]);
                        int x2 = II(body.VertexsT[body.Edges[i].p2][0]);
                        int y2 = JJ(body.VertexsT[body.Edges[i].p2][1]);
                        g.DrawLine(Pens.Black, x1, y1, x2, y2);
                    }
                    break;
                case 1:  // faces
                    int L1 = body.Faces.Length;
                    int L0 = body.Faces[0].p.Length;
                    Point[] w = new Point[L0];

                    double[][] Vn = new double[3][];
                    double[][] Wn = new double[3][];
                    for (int i = 0; i < L1; i++)
                    {
                        for (int j = 0; j < L0; j++)
                        {
                            double[] Vt = body.Vertexs[body.Faces[i].p[j]];
                            Vt = Rotate(Vt, 0, Alf1, 0, 0);
                            Vt = Rotate(Vt, 1, Bet1, 0, 0);
                            if (j <= 2) Vn[j] = Vt;
                            Vt = Rotate(Vt, 3, 0, Xs, Zs);
                            Vt = Rotate(Vt, 0, Alf, 0, 0);
                            Vt = Rotate(Vt, 1, Bet, 0, 0);
                            w[j].X = II(Vt[0]);
                            w[j].Y = JJ(Vt[1]);
                            if (j <= 2) Wn[j] = Vt;
                        }
                        body.Faces[i].N = Norm(Vn[0], Vn[1], Vn[2]);
                        double[] NN = Norm(Wn[0], Wn[1], Wn[2]);
                        double d = Math.Abs(NN[2]);
                        Color col = Color.FromArgb(0, 0, (byte)(Math.Round(255 * d)));
                        SolidBrush br = new SolidBrush(col);
                        if (NN[2] < 0)
                            g.FillPolygon(br, w);
                    }
                    break;
                case 2: // stereo
                    Color c = Color.FromArgb(0xCF,0,0);
                    Pen myPenR = new Pen(c,2);
                    Pen myPenB = new Pen(Color.Blue, 2);
                    
                    L = body.Edges.Length;
                    for (int i = 0; i < L; i++)
                    {
                        TEdge e = body.Edges[i];
                        double[] V1 = Rotate(body.VertexsT[e.p1], 1, AnglStereo, 0, 0);
                        double[] V2 = Rotate(body.VertexsT[e.p2], 1, AnglStereo, 0, 0);
                        g.DrawLine(myPenR, II(V1[0]), JJ(V1[1]), II(V2[0]), JJ(V2[1]));

                        V1 = Rotate(body.VertexsT[e.p1], 1, -AnglStereo, 0, 0);
                        V2 = Rotate(body.VertexsT[e.p2], 1, -AnglStereo, 0, 0);
                        g.DrawLine(myPenB, II(V1[0]), JJ(V1[1]), II(V2[0]), JJ(V2[1]));
                    }

                    //Bitmap bmp = new Bitmap(I2,J2);
                    //Graphics gBmp = Graphics.FromImage(bmp);
                    //gBmp.PixelOffsetMode .CopyFromScreen(,) .CompositingMode = CompositingMode.

                    //CopyPixelOperation = SourceInvert;
                    //g.DrawImage(,);
                    break;
            }
        }

        private void Shadow(Graphics g)
        {
            Point P=IJ(Sv);
            g.FillRectangle(Brushes.Red, P.X-2,P.Y-2,5,5);
            g.DrawLine(Pens.Red, P.X - 4, P.Y, P.X + 4, P.Y);
            g.DrawLine(Pens.Red, P.X, P.Y - 4, P.X, P.Y + 5);

            Point P1,P2;
            double Zh = -1;
            for (int i = 0; i < 41; i++)
            {
                P1 = IJ(ToVector(-1 + i * 0.2/4, -1, Zh));
                P2 = IJ(ToVector(-1 + i * 0.2/4, 1, Zh));
                g.DrawLine(Pens.Silver, P1.X, P1.Y, P2.X, P2.Y);
            }
            for (int i = 0; i < 41; i++)
            {
                P1 = IJ(ToVector(-1 , -1+ i * 0.2 / 4, Zh));
                P2 = IJ(ToVector( 1 , -1+ i * 0.2 / 4, Zh));
                g.DrawLine(Pens.Silver, P1.X, P1.Y, P2.X, P2.Y);
            }

            int L1 = body.Faces.Length;
            int L0 = body.Faces[0].p.Length;
            Point[] w = new Point[L0];

            for (int i = 0; i < L1; i++)
                {
                    for (int j = 0; j < L0; j++)
                    {
                        double[] Vt = body.Vertexs[body.Faces[i].p[j]];
                        Vt = Rotate(Vt, 0, Alf1, 0, 0);
                        Vt = Rotate(Vt, 1, Bet1, 0, 0);
                        Vt = Rotate(Vt, 3, 0, Xs, Zs);
                        Vt[0] = Sv[0] + (Vt[0] - Sv[0]) * (Zh - Sv[2]) / (Vt[2] - Sv[2]);
                        Vt[1] = Sv[1] + (Vt[1] - Sv[1]) * (Zh - Sv[2]) / (Vt[2] - Sv[2]);
                        Vt[2] = Zh;
                        Vt = Rotate(Vt, 0, Alf, 0, 0);
                        Vt = Rotate(Vt, 1, Bet, 0, 0);
                        w[j].X = II(Vt[0]);
                        w[j].Y = JJ(Vt[1]);
                    }
                    g.FillPolygon(Brushes.Silver, w);
                }
        } // Тень

        private void DrawPoint(Graphics g)
        {
            Pen myPen = new Pen(Color.Gray);
            myPen.DashStyle = DashStyle.Dash;
            int L = body0.Vertexs.Length;
            for (int i=0; i<L;i++)
            {
                body0.VertexsT[i]=Rotate(body0.Vertexs[i],  3, 0,Xs,Zs);
                body0.VertexsT[i]=Rotate(body0.VertexsT[i], 0, Alf,0,0);
                body0.VertexsT[i]=Rotate(body0.VertexsT[i], 1, Bet,0,0);
            }
            int L0=body0.Edges.Length;
            for (int i = 0; i < L0; i++)
            {
                int x1 = II(body0.VertexsT[body0.Edges[i].p1][0]);
                int y1 = JJ(body0.VertexsT[body0.Edges[i].p1][1]);
                int x2 = II(body0.VertexsT[body0.Edges[i].p2][0]);
                int y2 = JJ(body0.VertexsT[body0.Edges[i].p2][1]);
                g.DrawLine(myPen, x1, y1, x2, y2);
            }

            if (Xs!=0)
            {
                double[] V1 = new double[4];
                V1[1]=1/Xs; V1[0]=0; V1[2]=0; V1[3]=1;
                V1 = Rotate(V1, 0, Alf,0,0);
                V1 = Rotate(V1, 1, Bet,0,0);
                int u=II(V1[0]); int v=JJ(V1[1]);
                for (int i=0; i<6; i++)
                if ((i!=2) && (i!=3))
                    g.DrawLine(myPen, u, v, 
                        II(body0.VertexsT[i][0]), 
                        JJ(body0.VertexsT[i][1]));
                g.FillRectangle(Brushes.Black,u-2,v-2,4,4);
            }
            if (Zs != 0)
            {
                double[] V1 = new double[4];
                V1[1] = 0; V1[0] = 0; V1[2] = 1 / Zs; V1[3] = 1;
                V1 = Rotate(V1, 0, Alf, 0, 0);
                V1 = Rotate(V1, 1, Bet, 0, 0);
                int u = II(V1[0]); int v = JJ(V1[1]);
                for (int i = 0; i < 4; i++)
                    g.DrawLine(myPen, u, v, 
                        II(body0.VertexsT[i][0]), 
                        JJ(body0.VertexsT[i][1]));
                g.FillRectangle(Brushes.Black, u - 2, v - 2, 4, 4);
            }
        } // Точки схода

        public void Draw()
        {
            I2 = bitmap.Width;
            J2 = bitmap.Height;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Color cl;
                if (flEdge==2)
                    cl = Color.FromArgb(0, 0, 0);
                else
                    cl = Color.FromArgb(255, 255, 255);
                g.Clear(cl);
                g.SmoothingMode = SmoothingMode.HighQuality;

                if (visibleOXYZ)
                    OXYZ(g);
                if (visibleShadow)
                    Shadow(g);
                if (visiblePoint)
                    DrawPoint(g);
                DrawBody(g);
            }
        }

        public void ChangeWindowXY(int u, int v, int Delta)
        {
            double coeff;
            double x = XX(u);
            double y = YY(v);
            if (Delta < 0)
                coeff = 1.03;
            else
                coeff = 0.97;
            Xmin = x - (x - Xmin) * coeff;
            Xmax = x + (Xmax - x) * coeff;
            Ymin = y - (y - Ymin) * coeff;
            Ymax = y + (Ymax - y) * coeff;
        }

        public void SetAngle(double x, double y)
        {
            if (flRotate)
            {
                Alf = Math.Atan2(y, x);
                Bet = Math.Sqrt((x / 10) * (x / 10) + (y / 10) * (y / 10));
            }
            else
            {
                Alf1 = Math.Atan2(y, x);
                Bet1 = Math.Sqrt((x / 10) * (x / 10) + (y / 10) * (y / 10));
            }
        }

    }
    // ========== Body =================================================
    public struct TFace
    {
        public int[] p;            // номера вершин
        public double A, B, C, D;  // коэффициенты уравнения плоскости
        public double[] N;         // вектор нормали к грани
    }
    public struct TEdge
    {
        public int p1, p2;         // номера вершин
    }

    public class TBody
    {
        #region // const
        int[,] HexaedrIndex = 
        {   {3,2,1,0},
            {4,5,6,7},
            {5,1,2,6},
            {6,2,3,7},
            {3,0,4,7},
            {0,1,5,4} };
        int[,] OctaedrIndex =
        {   {4,1,0},
            {4,2,1},
            {4,3,2},
            {4,0,3},
            {5,0,1},
            {5,1,2},
            {5,2,3},
            {5,3,0} };
        static double IcoX = 0.525731112119133606;
        static double IcoZ = 0.850650808352039932;
        double[,] IcoData =
        {   {-IcoX,     0,  IcoZ},
            { IcoX,     0,  IcoZ},
            {-IcoX,     0, -IcoZ},
            { IcoX,     0, -IcoZ},
            {    0,  IcoZ,  IcoX},
            {    0,  IcoZ, -IcoX},
            {    0, -IcoZ,  IcoX},
            {    0, -IcoZ, -IcoX},
            { IcoZ,  IcoX,     0},
            {-IcoZ,  IcoX,     0},
            { IcoZ, -IcoX,     0},
            {-IcoZ, -IcoX,     0} };

        int[,] IcoIndex =
        {   { 0,  4,  1},
            { 0,  9,  4},
            { 9,  5,  4},
            { 4,  5,  8},
            { 4,  8,  1},
            { 8, 10,  1},
            { 8,  3, 10},
            { 5,  3,  8},
            { 5,  2,  3},
            { 2,  7,  3},
            { 7, 10,  3},
            { 7,  6, 10},
            { 7, 11,  6},
            {11,  0,  6},
            { 0,  1,  6},
            { 6,  1, 10},
            { 9,  0, 11},
            { 9, 11,  2},
            { 9,  2,  5},
            { 7,  2, 11} };
        int[,] DodecIndex =
        {   { 0,  1,  9, 16,  5},
            { 1,  0,  3, 18,  7},
            { 1,  7, 11, 10,  9},
            {11,  7, 18, 19,  6},
            { 8, 17, 16,  9, 10},
            { 2, 14, 15,  6, 19},
            { 2, 13, 12,  4, 14},
            { 2, 19, 18,  3, 13},
            { 3,  0,  5, 12, 13},
            { 6, 15,  8, 10, 11},
            { 4, 17,  8, 15, 14},
            { 4, 12,  5, 16, 17} };
#endregion
        public double SizeBody = 0.8;
        public double[][] Vertexs;   // массив вершин всех тел
        public double[][] VertexsT;  // массив вершин всех тел
        public TEdge[] Edges;        // массив ребер всех тел
        public TFace[] Faces;        // массив граней всех тел
        double[,] dodec = new double[20,3];
        public TBody(byte fl)
        {
            switch (fl)
            {
                case 0:
                    Tetraedr(SizeBody);
                    break;
                case 1:
                    Hexaedr(SizeBody);
                    break;
                case 2:
                    Octaedr(SizeBody);
                    break;
                case 3:
                    Icosahedron(SizeBody);
                    break;
                case 4:
                    Dodecahedron(SizeBody);
                    break;
            } 
        }

        TEdge[] GetEdges(TFace[] Sides)
        {
            TEdge[] Result = new TEdge[0];
            int Ls=Sides.Length; 
            int Le=0;
            for (int i=0; i<Ls; i++)
            {
                int L=Sides[i].p.Length;
                for (int j=0; j<L; j++)
                {
                    bool Ok=false; int k=-1;
                    while ((k<Le-1) && !Ok)
                    {
                        k++;
                        Ok = ((Result[k].p1 == Sides[i].p[j]) & 
                              (Result[k].p2 == Sides[i].p[(j + 1) % L])) |
                             ((Result[k].p2 == Sides[i].p[j]) & 
                              (Result[k].p1 == Sides[i].p[(j + 1) % L]));
                    }
                    if (!Ok)
                    {
                        Array.Resize<TEdge>(ref Result,++Le);
                        Result[Le-1].p1=Sides[i].p[j];
                        Result[Le-1].p2=Sides[i].p[(j+1) % L];
                    }
                }
            }
            return Result;
        }

        private void Octaedr(double Size)
        {
            Vertexs = new double[6][];
            VertexsT = new double[6][];
            for (int i = 0; i < 6; i++)
            {
                Vertexs[i] = new double[4];
                VertexsT[i] = new double[4];
            }
            Vertexs[0][0] = 0; Vertexs[0][1] = Size; Vertexs[0][2] = 0;
            Vertexs[1][0]= Size; Vertexs[1][1]=0;     Vertexs[1][2]=0;
            Vertexs[2][0]=0;     Vertexs[2][1]=-Size; Vertexs[2][2]=0;
            Vertexs[3][0]=-Size; Vertexs[3][1]=0;     Vertexs[3][2]=0;
            Vertexs[4][0]=0;     Vertexs[4][1]=0;     Vertexs[4][2]= Size;
            Vertexs[5][0]=0;     Vertexs[5][1]=0;     Vertexs[5][2]=-Size;
            for (int i=0;i<6;i++)
                Vertexs[i][3]=1;
            Faces = new TFace[8];
            for (int i=0;i<8;i++)
            {
                Faces[i].p = new int[3];
                for (int j=0; j<3; j++)
                    Faces[i].p[j]=OctaedrIndex[i,j];
            }
            Edges=GetEdges(Faces);
        }

        private void Icosahedron(double Size)
        {
            Vertexs = new double[12][];
            VertexsT = new double[12][];
            for (int i = 0; i < 12; i++)
            {
                Vertexs[i] = new double[4];
                VertexsT[i] = new double[4];
            }
            for (int i = 0; i < 12; i++)
            for (int j = 0; j < 3; j++)
                Vertexs[i][j]= Size*IcoData[i,j];

            for (int i=0;i<12;i++)
                Vertexs[i][3]=1;
            
            Faces = new TFace[20];
            for (int i=0;i<20;i++)
            {
                Faces[i].p = new int[3];
                for (int j=0; j<3; j++)
                    Faces[i].p[j]=IcoIndex[i,j];
            }
            Edges=GetEdges(Faces);
        }

        private void initDodecahedron()
        {
            double alpha = Math.Sqrt(2.0 / (3.0 + Math.Sqrt(5.0)));
            double beta = 1.0 + Math.Sqrt(6.0 / (3.0 + Math.Sqrt(5.0)) -
                2.0 + 2.0 * Math.Sqrt(2.0 / (3.0 + Math.Sqrt(5.0))));
            dodec[0, 0] = -alpha;  dodec[0, 1] = 0;       dodec[0, 2] = beta;
            dodec[1, 0] = alpha;   dodec[1, 1] = 0;       dodec[1, 2] = beta;
            dodec[2, 0] = -1;      dodec[2, 1] = -1;      dodec[2, 2] = -1;
            dodec[3, 0] = -1;      dodec[3, 1] = -1;      dodec[3, 2] = 1;
            dodec[4, 0] = -1;      dodec[4, 1] = 1;       dodec[4, 2] = -1;
            dodec[5, 0] = -1;      dodec[5, 1] = 1;       dodec[5, 2] = 1;
            dodec[6, 0] = 1;       dodec[6, 1] = -1;      dodec[6, 2] = -1;
            dodec[7, 0] = 1;       dodec[7, 1] = -1;      dodec[7, 2] = 1;
            dodec[8, 0] = 1;       dodec[8, 1] = 1;       dodec[8, 2] = -1;
            dodec[9, 0] = 1;       dodec[9, 1] = 1;       dodec[9, 2] = 1;
            dodec[10, 0] = beta;   dodec[10, 1] = alpha;  dodec[10, 2] = 0;
            dodec[11, 0] = beta;   dodec[11, 1] = -alpha; dodec[11, 2] = 0;
            dodec[12, 0] = -beta;  dodec[12, 1] = alpha;  dodec[12, 2] = 0;
            dodec[13, 0] = -beta;  dodec[13, 1] = -alpha; dodec[13, 2] = 0;
            dodec[14, 0] = -alpha; dodec[14, 1] = 0;      dodec[14, 2] = -beta;
            dodec[15, 0] = alpha;  dodec[15, 1] = 0;      dodec[15, 2] = -beta;
            dodec[16, 0] = 0;      dodec[16, 1] = beta;   dodec[16, 2] = alpha;
            dodec[17, 0] = 0;      dodec[17, 1] = beta;   dodec[17, 2] = -alpha;
            dodec[18, 0] = 0;      dodec[18, 1] = -beta;  dodec[18, 2] = alpha;
            dodec[19, 0] = 0;      dodec[19, 1] = -beta;  dodec[19, 2] = -alpha;
        } // initDodecaheadron 

        private void Dodecahedron(double Size)
        {
            Vertexs = new double[20][];
            VertexsT = new double[20][];
            for (int i = 0; i < 20; i++)
            {
                Vertexs[i] = new double[4];
                VertexsT[i] = new double[4];
            }
            initDodecahedron();
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 3; j++)
                    Vertexs[i][j] = Size * dodec[i, j];

            for (int i = 0; i < 20; i++)
                Vertexs[i][3] = 1;

            Faces = new TFace[12];
            for (int i = 0; i < 12; i++)
            {
                Faces[i].p = new int[5];
                for (int j = 0; j < 5; j++)
                    Faces[i].p[j] = DodecIndex[i, j];
            }
            Edges = GetEdges(Faces);
        }

        private void Hexaedr(double Size)
        {
            Vertexs = new double[8][];
            VertexsT = new double[8][];
            for (int i = 0; i < 8; i++)
            {
                Vertexs[i] = new double[4];
                VertexsT[i] = new double[4];
            }

            Vertexs[0][0]=-Size; Vertexs[0][1]=-Size; Vertexs[0][2]=-Size;
            Vertexs[1][0]= Size; Vertexs[1][1]=-Size; Vertexs[1][2]=-Size;
            Vertexs[2][0]= Size; Vertexs[2][1]= Size; Vertexs[2][2]=-Size;
            Vertexs[3][0]=-Size; Vertexs[3][1]= Size; Vertexs[3][2]=-Size;
            Vertexs[4][0] = -Size; Vertexs[4][1] = -Size; Vertexs[4][2] = Size;
            Vertexs[5][0] = Size;  Vertexs[5][1] = -Size; Vertexs[5][2] = Size;
            Vertexs[6][0] = Size;  Vertexs[6][1] = Size;  Vertexs[6][2] = Size;
            Vertexs[7][0] = -Size; Vertexs[7][1] = Size;  Vertexs[7][2] = Size;
            
            for (int i=0;i<8;i++)
                Vertexs[i][3]=1;
            Faces = new TFace[6];
            for (int i=0;i<6;i++)
            {
                Faces[i].p = new int[4];
                for (int j=0; j<4; j++)
                    Faces[i].p[j]=HexaedrIndex[i,j];
            }
            Edges=GetEdges(Faces);
        }

        private void Tetraedr(double Size)
        {
            Vertexs = new double[4][];
            VertexsT = new double[4][];
            for (int i=0;i<4;i++)
            {
                Vertexs[i] = new double[4];
                VertexsT[i] = new double[4];
            }
 
            Vertexs[0][0]= Size; Vertexs[0][1]=-Size; Vertexs[0][2]=-Size;
            Vertexs[1][0]= Size; Vertexs[1][1]= Size; Vertexs[1][2]= Size;
            Vertexs[2][0]=-Size; Vertexs[2][1]=-Size; Vertexs[2][2]= Size;
            Vertexs[3][0]=-Size; Vertexs[3][1]= Size; Vertexs[3][2]=-Size;
            for (int i=0;i<4;i++)
                Vertexs[i][3]=1;
            Edges = new TEdge[6];
            Edges[0].p1=0; Edges[0].p2=1;
            Edges[1].p1=0; Edges[1].p2=2;
            Edges[2].p1=1; Edges[2].p2=2;
            Edges[3].p1=3; Edges[3].p2=0;
            Edges[4].p1=3; Edges[4].p2=1;
            Edges[5].p1=3; Edges[5].p2=2;
            Faces = new TFace[4];
            for (int i=0;i<4;i++)
                Faces[i].p = new int[3];
 
            Faces[0].p[0]=0; Faces[0].p[1]=1; Faces[0].p[2]=2;
            Faces[1].p[0]=1; Faces[1].p[1]=3; Faces[1].p[2]=2;
            Faces[2].p[0]=0; Faces[2].p[1]=2; Faces[2].p[2]=3;
            Faces[3].p[0]=0; Faces[3].p[1]=3; Faces[3].p[2]=1;
        }
    }

}
