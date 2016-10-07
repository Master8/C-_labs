using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Games;

namespace Games.Tests
{
    [TestClass]
    public class GameTests
    {
        public virtual IGame CreateGameWithNineValues()
        {
            return new Game(1, 4, 2, 0, 5, 8, 6, 7, 3);
        }

        [TestMethod]
        public virtual void CreateGameWithNineValuesAndAccessToTheCoordinates()
        {
            IGame game = CreateGameWithNineValues();

            Assert.AreEqual(8, game[1, 2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Value of argument is out of range!")]
        public virtual void CreateGameWithNineValuesAndAccessToTheWrongCoordinates()
        {
            IGame game = CreateGameWithNineValues();

            int value = game[5, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Value of argument is out of range!")]
        public virtual void CreateGameWithNineValuesAndAccessToTheWrongValue()
        {
            IGame game = CreateGameWithNineValues();

            Location location = game.GetLocation(-4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "It is impossible to construct a square!")]
        public virtual void CreateGameWithIncorrectCountOfValuesThrownArgumentException()
        {
            IGame game = new Game(1, 4, 2, 0, 5, 8, 6, 7, 3, 9);
        }

        [TestMethod]
        public virtual void CreateGameWithNineValuesAndAccessToTheValue()
        {
            IGame game = CreateGameWithNineValues();
            Location location = game.GetLocation(2);

            Assert.AreEqual(0, location.X);
            Assert.AreEqual(2, location.Y);
        }

        [TestMethod]
        public virtual void CreateGameWithNineValuesAndMoveValueNearZero()
        {
            Game game = (Game)CreateGameWithNineValues();
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
        public virtual void CreateGameWithNineValuesAndMoveValueNotNearZeroThrownArgumentException()
        {
            Game game = (Game)CreateGameWithNineValues();
            game.Shift(8);
        }
    }
}
