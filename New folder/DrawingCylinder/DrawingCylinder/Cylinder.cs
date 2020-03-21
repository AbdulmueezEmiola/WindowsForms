using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DrawingCylinder
{
    class Cylinder : Circle
    {
        private double height;
        public Cylinder(double radius, Vector3 center, Vector3 direction, double height) : base(radius, center, direction)
        {
            this.height = height;
        }
        public double getHeight (){
            return height;
        }
    }
}
