using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            using (timer.StartPeriod())
            {
                // do things
                Thread.Sleep(100);
            }
            Console.WriteLine(timer.ElapsedMilliseconds);

            using (timer.ContinuePeriod())
            {
                // do things
                Thread.Sleep(100);
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
        }
    }
}
