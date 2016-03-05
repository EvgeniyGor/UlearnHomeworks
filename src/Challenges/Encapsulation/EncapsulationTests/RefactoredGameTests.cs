using Encapsulation;
using NUnit.Framework;

namespace EncapsulationTests
{
    [TestFixture]
    public class RefactoredGameTests : GameTestsBase
    {
        public override void SetUp()
        {
            Game = new RefactoredGame(1, 2, 3, 0);
            base.SetUp();
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
    }
}