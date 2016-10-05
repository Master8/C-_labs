using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Games;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ImmutableGame game = new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            
            ImmutableGame game2 = game.Shift(8);

            DecoratorGame game3 = new DecoratorGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            game3.Shift(8);
            game3.Shift(5);
            game3.Shift(2);
            game3.Shift(1);

            Console.WriteLine(game3[2, 1]);
        }
    }
}
