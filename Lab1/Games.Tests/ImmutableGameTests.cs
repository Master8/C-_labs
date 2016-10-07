using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games.Tests
{
    [TestClass]
    public class ImmutableGameTests : GameTests
    {
        [TestMethod]
        public override IGame CreateGameWithNineValues()
        {
            return new ImmutableGame(1, 4, 2, 0, 5, 8, 6, 7, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "It is impossible to construct a square!")]
        public override void CreateGameWithIncorrectCountOfValuesThrownArgumentException()
        {
            IGame game = new ImmutableGame(1, 4, 2, 0, 5, 8, 6, 7, 3, 9);
        }

        [TestMethod]
        public override void CreateGameWithNineValuesAndMoveValueNearZero()
        {
            ImmutableGame game = (ImmutableGame)CreateGameWithNineValues();
            ImmutableGame resultGame = game.Shift(6);

            Assert.AreEqual(6, resultGame[1, 0]);
            Assert.AreEqual(0, resultGame[2, 0]);

            Location newValueLocation = resultGame.GetLocation(6);

            Assert.AreEqual(1, newValueLocation.X);
            Assert.AreEqual(0, newValueLocation.Y);

            Location newZeroLocation = resultGame.GetLocation(0);

            Assert.AreEqual(2, newZeroLocation.X);
            Assert.AreEqual(0, newZeroLocation.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Сan not move the value, not near the place!")]
        public override void CreateGameWithNineValuesAndMoveValueNotNearZeroThrownArgumentException()
        {
            ImmutableGame game = (ImmutableGame)CreateGameWithNineValues();
            game.Shift(8);
        }

        [TestMethod]
        public void CreateGameWithNineValuesAndCheckOnTheImmutability()
        {
            ImmutableGame game = (ImmutableGame)CreateGameWithNineValues();
            game.Shift(6);

            Assert.AreEqual(0, game[1, 0]);
            Assert.AreEqual(6, game[2, 0]);

            Location newValueLocation = game.GetLocation(6);

            Assert.AreEqual(2, newValueLocation.X);
            Assert.AreEqual(0, newValueLocation.Y);

            Location newZeroLocation = game.GetLocation(0);

            Assert.AreEqual(1, newZeroLocation.X);
            Assert.AreEqual(0, newZeroLocation.Y);
        }
    }
}
