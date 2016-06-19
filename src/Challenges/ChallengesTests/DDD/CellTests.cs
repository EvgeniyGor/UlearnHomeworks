using DDD.Core.Domain.Models;
using NUnit.Framework;

namespace ChallengesTests.DDD
{
    public class CellTests : TestBase
    {
        private Cell _cell;

        public override void SetUp()
        {
            _cell = new Cell
            {
                Digit = 5
            };
        }

        [Test]
        public void CellCreationTest()
        {
            Assert.Equals(5, _cell.Digit);
            Assert.False(_cell.HasMine);
            Assert.False(_cell.Revealed);
            Assert.False(_cell.Empty);
        }

        [Test]
        public void CellActionsTest()
        {
            _cell.Reveal();
            Assert.True(_cell.Revealed);

            _cell.Digit = 0;
            Assert.True(_cell.Empty);

            _cell.SetMine();
            Assert.True(_cell.HasMine);

            _cell.Digit = 0;
            Assert.False(_cell.Empty);
        }
    }
}