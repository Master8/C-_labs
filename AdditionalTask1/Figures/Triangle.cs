using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;

        public double Area
        {
            get
            {
                return Math.Sqrt((a + b - c) * (a - b + c) * (b + c - a) * (a + b + c)) / 4;
            }
        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.a = sideA;
            this.b = sideB;
            this.c = sideC;
        }

        public Triangle(double sideA, double sideB, Angle angleBetweenSides)
        {
            this.a = sideA;
            this.b = sideB;
            this.c = Math.Sqrt(Math.Pow((a + b), 2) - 4 * a * b * Math.Pow((Math.Cos(angleBetweenSides.Value / 2)), 2));
        }

        public Triangle(double sideBetweenAngles, Angle angleAlpha, Angle angleBetta)
        {
            this.c = sideBetweenAngles;
            this.a = c * Math.Sin(angleAlpha.Value) / Math.Sin(Math.PI - angleAlpha.Value - angleBetta.Value);
            this.b = a * Math.Sin(angleBetta.Value) / Math.Sin(angleAlpha.Value);
        }
    }
}
