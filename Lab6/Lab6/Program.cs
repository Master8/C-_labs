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
            using (timer.Start())
            {
                // do things
                Thread.Sleep(100);
            }
            Console.WriteLine(timer.ElapsedMilliseconds);

            using (timer.Continue())
            {
                // do things
                Thread.Sleep(100);
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
        }
    }
}
