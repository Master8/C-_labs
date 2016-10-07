using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class DecoratorGame : IGame
    {
        private ImmutableGame game;
        private List<int> changes;

        public DecoratorGame(params int[] list)
        {
            game = new ImmutableGame(list);
            changes = new List<int>();
        }

        public int this[int x, int y]
        {
            get
            {
                return BuildCurrentGame()[x, y];
            }
        }

        public Location GetLocation(int value)
        {
            return BuildCurrentGame().GetLocation(value);
        }

        public void Shift(int value)
        {
            Game currentGame = BuildCurrentGame();

            if (currentGame.CheckNearby(currentGame.GetLocation(value), currentGame.GetLocation(0)))
            {
                changes.Add(value);
            }
            else
            {
                throw new ArgumentException("Сan not move the value, not near the place!");
            }
        }

        private Game BuildCurrentGame()
        {
            Game currentGame = new Game(game.BuildArrayOfArguments());

            foreach (int value in changes)
                currentGame.Shift(value);

            return currentGame;
        }
    }
}
