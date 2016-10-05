using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class ImmutableGame : BaseGame
    {
        public ImmutableGame(params int[] list) : base(list) { }

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
