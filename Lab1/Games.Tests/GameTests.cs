using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Games;

namespace Games.Tests
{
    [TestClass]
    public class GameTests
    {
        public Game CreateGameWithNineValues()
        {
            return new Game(1, 4, 2, 0, 5, 8, 6, 7, 3);
        }

        [TestMethod]
        public void CreateGameWithNineValuesAndAccessToTheCoordinates()
        {
            Game game = CreateGameWithNineValues();

            Assert.AreEqual(8, game[1, 2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Value of argument is out of range!")]
        public void CreateGameWithNineValuesAndAccessToTheWrongCoordinates()
        {
            Game game = CreateGameWithNineValues();

            int value = game[5, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Value of argument is out of range!")]
        public void CreateGameWithNineValuesAndAccessToTheWrongValue()
        {
            Game game = CreateGameWithNineValues();

            Location location = game.GetLocation(-4);
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
            Game game = CreateGameWithNineValues();
            Location location = game.GetLocation(2);

            Assert.AreEqual(0, location.X);
            Assert.AreEqual(2, location.Y);
        }

        [TestMethod]
        public void CreateGameWithNineValuesAndMoveValueNearZero()
        {
            Game game = CreateGameWithNineValues();
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
            Game game = CreateGameWithNineValues();
            game.Shift(8);
        }
    }
}
