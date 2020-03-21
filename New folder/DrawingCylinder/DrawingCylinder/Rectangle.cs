using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DrawingCylinder
{
    class Rectangle
    {
        private Vector3[] Vertexes = new Vector3[4];
        public Rectangle(Vector3 vec1, Vector3 vec2, Vector3 vec3, Vector3 vec4)
        {
            Vertexes[0] = vec1;
            Vertexes[1] = vec2;
            Vertexes[2] = vec3;
            Vertexes[3] = vec4;
        }
        public Vector3[] getRectangle()
        {
            return Vertexes;
        }
    }
}
