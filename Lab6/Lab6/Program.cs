using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Drawing;

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

            //Task2

            Bitmap bitmap = (Bitmap)Bitmap.FromFile(@"C:\Users\maste\Pictures\web\image.jpg");
            
            using (var bitmapEditor = new BitmapEditor(bitmap))
            {
                bitmapEditor.SetPixel(0, 1, 255, 255, 0);
                Console.WriteLine(bitmapEditor.GetPixel(0, 1).ToString());
            }
        }
    }
}
