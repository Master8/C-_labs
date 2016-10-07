using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games.Tests
{
    [TestClass]
    public class DecoratorGameTests : GameTests
    {
        public override IGame CreateGameWithNineValues()
        {
            return new DecoratorGame(1, 4, 2, 0, 5, 8, 6, 7, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "It is impossible to construct a square!")]
        public override void CreateGameWithIncorrectCountOfValuesThrownArgumentException()
        {
            IGame game = new DecoratorGame(1, 4, 2, 0, 5, 8, 6, 7, 3, 9);
        }

        [TestMethod]
        public override void CreateGameWithNineValuesAndMoveValueNearZero()
        {
            DecoratorGame game = (DecoratorGame)CreateGameWithNineValues();
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
        public override void CreateGameWithNineValuesAndMoveValueNotNearZeroThrownArgumentException()
        {
            DecoratorGame game = (DecoratorGame)CreateGameWithNineValues();
            game.Shift(8);
        }
    }
}
