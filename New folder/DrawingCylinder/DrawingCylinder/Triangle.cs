using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DrawingCylinder
{
    class Triangle
    {
        private Vector3[] Vertexes;
        public Triangle(Vector3 vec1, Vector3 vec2, Vector3 vec3) {
            Vertexes = new Vector3[3];
            Vertexes[0] = vec1;
            Vertexes[1] = vec2;
            Vertexes[2] = vec3;
        }
        public Vector3[] getTriangle()
        {
            return Vertexes;
        }
    }
}
