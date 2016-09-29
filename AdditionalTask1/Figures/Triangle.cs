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

        private Triangle(double sideA, double sideB, double sideC)
        {
            this.a = sideA;
            this.b = sideB;
            this.c = sideC;
        }

        public double Area
        {
            get
            {
                return Math.Sqrt((a + b - c) * (a - b + c) * (b + c - a) * (a + b + c)) / 4;
            }
        }

        private static void CheckSide(double side)
        {
            if (side <= 0)
                throw new ArgumentException("Negative value of side");
        }

        private static void CheckAngle(double angle)
        {
            if (angle <= 0 || angle >= Math.PI)
                throw new ArgumentException("Value of angle out of range, from 0 to pi");
        }

        public static Triangle CreateTriangleFromThreeSides(double sideA, double sideB, double sideC)
        {
            CheckSide(sideA);
            CheckSide(sideB);
            CheckSide(sideC);

            if (sideA >= sideB + sideC ||
                sideB >= sideA + sideC ||
                sideC >= sideA + sideB)
                throw new ArgumentException("One of the sides of a triangle is greater than or equal to the sum of the other two");

            return new Triangle(sideA, sideB, sideC);
        }

        public static Triangle CreateTriangleFromTwoSidesAndAngle(double sideA, double sideB, double angleBetweenSides)
        {
            CheckSide(sideA);
            CheckSide(sideB);
            CheckAngle(angleBetweenSides);

            double sideC = Math.Sqrt(Math.Pow((sideA + sideB), 2) - 4 * sideA * sideB * Math.Pow((Math.Cos(angleBetweenSides / 2)), 2));

            return new Triangle(sideA, sideB, sideC);
        }

        public static Triangle CreateTriangleFromSideAndTwoAngles(double sideBetweenAngles, double angleAlpha, double angleBetta)
        {
            CheckSide(sideBetweenAngles);
            CheckAngle(angleAlpha);
            CheckAngle(angleBetta);

            if ((angleAlpha + angleBetta) >= Math.PI)
                throw new ArgumentException("The sum of two angles is greater or equal to pi");

            double sideA = sideBetweenAngles * Math.Sin(angleAlpha) / Math.Sin(Math.PI - angleAlpha - angleBetta);
            double sideB = sideA * Math.Sin(angleBetta) / Math.Sin(angleAlpha);

            return new Triangle(sideA, sideB, sideBetweenAngles);
        }
    }
}
