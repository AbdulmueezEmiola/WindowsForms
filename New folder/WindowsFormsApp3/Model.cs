using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace WindowsFormsApp3
{
    public class Model
    {
        public List<Vector3> Vertexes = new List<Vector3>();
        public List<Figure> Fig = new List<Figure>();
    }

    public class Figure
    {
        public int[] Vertexes { get; set; }
        public float Distance { get; set; }

        public Figure(params int[] vertexes)
        {
            Vertexes = vertexes;
        }
    }
}
