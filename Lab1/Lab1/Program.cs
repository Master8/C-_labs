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
        }
    }
}
