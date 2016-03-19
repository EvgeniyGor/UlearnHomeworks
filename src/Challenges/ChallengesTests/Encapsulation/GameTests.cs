using Encapsulation;
using NUnit.Framework;

namespace ChallengesTests.Encapsulation
{
    public class GameTests : GameTestsBase
    {
        public override void SetUp()
        {
            Game = new Game(1, 2, 3, 0);
        }

        [Test]
        public override void SimpleGameTest()
        {
            base.SimpleGameTest();
        }

        [Test]
        public override void GetLocationTest()
        {
            base.GetLocationTest();
        }

        [Test]
        public override void ShiftTest()
        {
            base.ShiftTest();
        }

        [Test]
        public void MutableShiftTest()
        {
            var game = Game as Game;

            if (game == null)
            {
                Assert.Fail();
            }

            game.MutableShift(2);
            Assert.AreEqual(Game[1, 1], 2);
            Assert.AreEqual(Game[0, 1], 0);
        }
    }
}