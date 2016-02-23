using Encapsulation;
using NUnit.Framework;

namespace EncapsulationTests
{
    public class GameTests : TestBase
    {
        private Game _game;

        public override void SetUp()
        {
            _game = new Game(1, 2, 3, 0);
        }

        [Test]
        public void SimpleGameTest()
        {
            Assert.AreEqual(_game[0, 0], 1);
            Assert.AreEqual(_game[0, 1], 2);
            Assert.AreEqual(_game[1, 0], 3);
            Assert.AreEqual(_game[1, 1], 0);
        }

        [Test]
        public void GetLocationTest()
        {
            Assert.AreEqual(_game.GetLocation(3).Row, 1);
            Assert.AreEqual(_game.GetLocation(3).Column, 0);
        }

        [Test]
        public void VerticalShiftTest()
        {
            _game.Shift(2);
            Assert.AreEqual(_game[1, 1], 2);
            Assert.AreEqual(_game[0, 1], 0);
        }

        [Test]
        public void HorizontalShiftTest()
        {
            _game.Shift(3);
            Assert.AreEqual(_game[1, 0], 0);
            Assert.AreEqual(_game[1, 1], 3);
        }

        [Test]
        public void ImmutableShiftTest()
        {
            var shifted = _game.ImmutableShift(3).ImmutableShift(1);
            Assert.AreEqual(shifted[0, 0], 0);
            Assert.AreEqual(shifted[1, 0], 1);
            Assert.AreEqual(shifted[1, 1], 3);
        }
    }
}