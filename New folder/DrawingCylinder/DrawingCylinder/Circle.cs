using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DrawingCylinder
{
    class Circle
    {
        private double radius;
        private Vector3 center;
        private Vector3 direction;
        public Circle(double radius, Vector3 center, Vector3 direction)
        {
            this.radius = radius;
            this.center = center;
            this.direction = direction;
        }
        public double getRadius()
        {
            return radius;
        }
        public Vector3 getCenter()
        {
            return center;
        }
        public Vector3 getDirection()
        {
            return direction;
        }
    }
}
