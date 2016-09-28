using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Figures;

namespace Triangles.Tests
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Negative value of side")]
        public void TriangleTryCreateTriangleWithNegativeSide()
        {
            double a = 35;
            double b = -12;
            double c = 24;

            Triangle triangle = new Triangle(a, b, c);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Value of angle out of range, from 0 to pi")]
        public void TriangleTryCreateTriangleWithAngleOutOfRange()
        {
            double a = 27;
            double b = 5;

            Angle alpha = new Angle(6);

            Triangle triangle = new Triangle(a, b, alpha);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "One of the sides of a triangle is greater than or equal to the sum of the other two")]
        public void TriangleTryCreateTriangleWithSideGreaterThanthanOtherTwo()
        {
            double a = 50;
            double b = 12;
            double c = 24;

            Triangle triangle = new Triangle(a, b, c);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The sum of two angles is greater or equal to pi")]
        public void TriangleTryCreateTriangleWithTwoAnglesThatSumItGreaterToPI()
        {
            double a = 16;

            Angle alpha = new Angle(Math.PI / 2);
            Angle betta = new Angle(Math.PI / 1.5);

            Triangle triangle = new Triangle(16, alpha, betta);
        }

        [TestMethod]
        public void TriangleTryCreateTriangleFromThreeSidesTriangleAreaCalculatedCorrectly()
        {
            double a = 35;
            double b = 12;
            double c = 24;

            Triangle triangle = new Triangle(a, b, c);

            Assert.AreEqual(69.25992708630294, triangle.Area, 1e-10);
        }

        [TestMethod]
        public void TriangleTryCreateTriangleFromTwoSidesAndAngleTriangleAreaCalculatedCorrectly()
        {
            double a = 27;
            double b = 5;

            Angle alpha = new Angle(Math.PI / 6);

            Triangle triangle = new Triangle(a, b, alpha);

            Assert.AreEqual(33.74999999999999, triangle.Area, 1e-10);
        }

        [TestMethod]
        public void TriangleTryCreateTriangleFromOneSideAndTwoAnglesTriangleAreaCalculatedCorrectly()
        {
            double a = 16;

            Angle alpha = new Angle(Math.PI / 3);
            Angle betta = new Angle(Math.PI / 6);

            Triangle triangle = new Triangle(16, alpha, betta);

            Assert.AreEqual(55.42562584220406, triangle.Area, 1e-10);
        }
    }
}
