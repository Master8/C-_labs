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
                Triangle triangle = new Triangle(10, 7, new Angle(Math.PI / -6));

                Console.WriteLine(triangle.Area);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Error! " + e.Message);
            }
            
        }
    }
}
