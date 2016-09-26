using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle.Tests
{
    [TestClass]
    public class TriangleTest
    {
        void areaTest(Figures.Triangle triangle, double expectedResult)
        {
            double resultArea = triangle.Area;

            Assert.AreEqual(expectedResult, resultArea, 1e-10);
        }

        [TestMethod]
        public void AreaTestForSides()
        {
            double a = 35;
            double b = 12;
            double c = 24;

            areaTest(new Figures.Triangle(a, b, c), 69.25992708630294);
        }

        [TestMethod]
        public void AreaTestWithOneAngle()
        {
            double a = 27;
            double b = 5;

            areaTest(new Figures.Triangle(a, b, new Figures.Angle(Math.PI/6)), 33.74999999999999);
        }

        [TestMethod]
        public void AreaTestWithTwoAngle()
        {
            double a = 16;

            areaTest(new Figures.Triangle(a, new Figures.Angle(Math.PI/3), new Figures.Angle(Math.PI / 6)), 55.42562584220406);
        }
    }
}
