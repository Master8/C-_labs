using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public interface IGame
    {
        int this[int x, int y] { get; }
        Location GetLocation(int value);
    }
}
