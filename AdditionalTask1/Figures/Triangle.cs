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

        private  void CheckSide(double side)
        {
            if (side <= 0)
                throw new ArgumentException("Negative value of side");
        }

        private void CheckAngle(Angle angle)
        {
            if (angle.Value <= 0 || angle.Value >= Math.PI)
                throw new ArgumentException("Value of angle out of range, from 0 to pi");
        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            CheckSide(sideA);
            CheckSide(sideB);
            CheckSide(sideC);

            if (sideA >= sideB + sideC ||
                sideB >= sideA + sideC ||
                sideC >= sideA + sideB)
                throw new ArgumentException("One of the sides of a triangle is greater than or equal to the sum of the other two");

            this.a = sideA;
            this.b = sideB;
            this.c = sideC;
        }

        public Triangle(double sideA, double sideB, Angle angleBetweenSides)
        {
            CheckSide(sideA);
            CheckSide(sideB);
            CheckAngle(angleBetweenSides);

            this.a = sideA;
            this.b = sideB;
            this.c = Math.Sqrt(Math.Pow((a + b), 2) - 4 * a * b * Math.Pow((Math.Cos(angleBetweenSides.Value / 2)), 2));
        }

        public Triangle(double sideBetweenAngles, Angle angleAlpha, Angle angleBetta)
        {
            CheckSide(sideBetweenAngles);
            CheckAngle(angleAlpha);
            CheckAngle(angleBetta);

            if ((angleAlpha.Value + angleBetta.Value) >= Math.PI)
                throw new ArgumentException("The sum of two angles is greater or equal to pi");

            this.c = sideBetweenAngles;
            this.a = c * Math.Sin(angleAlpha.Value) / Math.Sin(Math.PI - angleAlpha.Value - angleBetta.Value);
            this.b = a * Math.Sin(angleBetta.Value) / Math.Sin(angleAlpha.Value);
        }
    }
}
