using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Figures;

namespace AdditionalTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Triangle triangle = Triangle.CreateTriangleFromTwoSidesAndAngle(10, 7, Math.PI / -6);

                Console.WriteLine(triangle.Area);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Error! " + e.Message);
            }
            
        }
    }
}
