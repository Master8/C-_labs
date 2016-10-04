using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class ImmutableGame
    {
        private int[,] gameArea;
        private Location[] locations;
        private readonly int sizeArea;

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

        public ImmutableGame(params int[] list)
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

        private bool CheckNearby(Location location, Location zeroLocation)
        {
            return ((location.X == zeroLocation.X) && (Math.Abs(location.Y - zeroLocation.Y) == 1))
                || ((location.Y == zeroLocation.Y) && (Math.Abs(location.X - zeroLocation.X) == 1));
        }

        public ImmutableGame Shift(int value)
        {
            Location location = GetLocation(value);
            Location zeroLocation = GetLocation(0);

            if (CheckNearby(location, zeroLocation))
            {
                int[] arrayOfArguments = new int[locations.Length];

                int k = 0;
                for (int i = 0; i < sizeArea; i++)
                {
                    for (int j = 0; j < sizeArea; j++)
                    {
                        arrayOfArguments[k] = gameArea[i, j];
                        k++;
                    }
                }

                arrayOfArguments[location.X * sizeArea + location.Y] = 0;
                arrayOfArguments[zeroLocation.X * sizeArea + zeroLocation.Y] = value; 
                
                return new ImmutableGame(arrayOfArguments);
            }
            else
            {
                throw new ArgumentException("Сan not move the value, not near the place!");
            }
        }
    }
}
