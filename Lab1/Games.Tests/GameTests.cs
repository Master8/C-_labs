using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Games;

namespace Games.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CreateGameWithNineValuesAndAccessToTheCoordinates()
        {
            Game game = new Game(1, 4, 2, 0, 5, 8, 6, 7, 3);

            Assert.AreEqual(8, game[1, 2]);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "It is impossible to construct a square!")]
        public void CreateGameWithIncorrectCountOfValuesThrownArgumentException()
        {
            Game game = new Game(1, 4, 2, 0, 5, 8, 6, 7, 3, 9);
        }

        [TestMethod]
        public void CreateGameWithNineValuesAndAccessToTheValue()
        {
            Game game = new Game(1, 4, 2, 0, 5, 8, 6, 7, 3);
            Location location = game.GetLocation(2);

            Assert.AreEqual(0, location.X);
            Assert.AreEqual(2, location.Y);
        }

        [TestMethod]
        public void CreateGameWithNineValuesAndMoveValueNearZero()
        {
            Game game = new Game(1, 4, 2, 0, 5, 8, 6, 7, 3);
            game.Shift(6);

            Assert.AreEqual(6, game[1, 0]);
            Assert.AreEqual(0, game[2, 0]);

            Location newValueLocation = game.GetLocation(6);

            Assert.AreEqual(1, newValueLocation.X);
            Assert.AreEqual(0, newValueLocation.Y);

            Location newZeroLocation = game.GetLocation(0);

            Assert.AreEqual(2, newZeroLocation.X);
            Assert.AreEqual(0, newZeroLocation.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Сan not move the value, not near the place!")]
        public void CreateGameWithNineValuesAndMoveValueNotNearZeroThrownArgumentException()
        {
            Game game = new Game(1, 4, 2, 0, 5, 8, 6, 7, 3);
            game.Shift(8);
        }
    }
}
