using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class Location
    {
        public readonly int X;
        public readonly int Y;

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Game : BaseGame
    {
        public Game(params int[] list) : base(list) { }

        public void Shift(int value)
        {
            Location location = GetLocation(value);
            Location zeroLocation = GetLocation(0);

            if (CheckNearby(location, zeroLocation))
            {
                gameArea[location.X, location.Y] = 0;
                gameArea[zeroLocation.X, zeroLocation.Y] = value;

                locations[value] = zeroLocation;
                locations[0] = location;
            }
            else
            {
                throw new ArgumentException("Сan not move the value, not near the place!");
            }
        }
    }
}
