using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3dCylenderKG
{
    class Point3D
    {

        //координата
        public int _x { set; get; }

        /// координата
        public int _y { set; get; }

        /// координата
        public int _z { set; get; }

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
