using NUnit.Framework;
using Encapsulation;

namespace EncapsulationTests
{
    public class GameTestsBase : TestBase
    {
        protected IGame Game { get; set; }

        public virtual void SimpleGameTest()
        {
            Assert.AreEqual(Game[0, 0], 1);
            Assert.AreEqual(Game[0, 1], 2);
            Assert.AreEqual(Game[1, 0], 3);
            Assert.AreEqual(Game[1, 1], 0);
        }

        public virtual void GetLocationTest()
        {
            Assert.AreEqual(Game.GetLocation(3).Row, 1);
            Assert.AreEqual(Game.GetLocation(3).Column, 0);
        }

        public virtual void ShiftTest()
        {
            var shifted = Game.Shift(3).Shift(1);
            Assert.AreEqual(shifted[0, 0], 0);
            Assert.AreEqual(shifted[1, 0], 1);
            Assert.AreEqual(shifted[1, 1], 3);
        }
    }
}