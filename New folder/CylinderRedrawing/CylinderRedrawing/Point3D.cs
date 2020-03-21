using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CylinderRedrawing
{
    class Point3D
    {
        public int _x { set; get; }

        /// координата
        public int _y { set; get; }

        /// координата
        public int _z { set; get; }
        public Point3D multiplyMat(Matrix4x4 mat)
        {
            Vector3 vec = new Vector3(_x, _y,_z);
            Vector3 vec2 = Vector3.Transform(vec, mat);
            return new Point3D((int)vec2.X,(int)vec2.Y,(int)vec2.Z);
        }
        public Point3D()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        public Point3D(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
    }
}
