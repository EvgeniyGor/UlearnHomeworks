using DDD.Core.Domain;
using DDD.Core.Domain.Models;
using NUnit.Framework;

namespace ChallengesTests.DDD
{
    public class GridTests : TestBase
    {
        private Grid _grid;

        public override void SetUp()
        {
            _grid = new Grid(3, 4);
        }

        [Test]
        public void GridCreation()
        {
            Assert.Equals(3, _grid.Height);
            Assert.Equals(4, _grid.Width);
        }

        [Test]
        public void GetCellTest()
        {
            _grid[0, 0].Digit = 3;
            Assert.Equals(3, _grid[new Point(0, 0)].Digit);
        }

        [Test]
        public void SetMineTest()
        {
            _grid.SetMine(0, 2);
            _grid.SetMine(1, 1);

            Assert.True(_grid[0, 2].HasMine);
            Assert.True(_grid[1, 1].HasMine);

            Assert.Equals(1, _grid[0, 0].Digit);
            Assert.Equals(2, _grid[0, 1].Digit);
            Assert.Equals(1, _grid[0, 3].Digit);

            Assert.Equals(1, _grid[1, 0].Digit);
            Assert.Equals(2, _grid[1, 2].Digit);
            Assert.Equals(1, _grid[1, 3].Digit);

            Assert.Equals(1, _grid[2, 0].Digit);
            Assert.Equals(1, _grid[2, 1].Digit);
            Assert.Equals(1, _grid[2, 2].Digit);
          
            Assert.True(_grid[2, 3].Empty);
        }
    }
}