using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public abstract class BaseGame : IGame
    {
        protected int[,] gameArea;
        protected Location[] locations;
        protected readonly int sizeArea;

        public int this[int x, int y]
        {
            get
            {
                if (x >= 0 && x < sizeArea && y >= 0 && y < sizeArea)
                    return gameArea[x, y];
                else
                    throw new ArgumentException("Value of argument is out of range!");
            }
        }

        public BaseGame(params int[] list)
        {
            int length = list.Length;
            sizeArea = (int)Math.Sqrt(length);

            if (length != sizeArea * sizeArea)
                throw new ArgumentException("It is impossible to construct a square!");

            gameArea = new int[sizeArea, sizeArea];
            locations = new Location[length];

            int k = 0;

            for (int i = 0; i < sizeArea; i++)
            {
                for (int j = 0; j < sizeArea; j++)
                {
                    gameArea[i, j] = list[k];
                    locations[list[k]] = new Location(i, j);
                    k++;
                }
            }
        }

        public Location GetLocation(int value)
        {
            if (value >= 0 && value < locations.Length)
                return locations[value];
            else
                throw new ArgumentException("Value of argument is out of range!");
        }

        protected internal bool CheckNearby(Location location, Location zeroLocation)
        {
            return ((location.X == zeroLocation.X) && (Math.Abs(location.Y - zeroLocation.Y) == 1))
                || ((location.Y == zeroLocation.Y) && (Math.Abs(location.X - zeroLocation.X) == 1));
        }
    }
}
