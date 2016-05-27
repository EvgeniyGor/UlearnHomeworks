using System.Linq;
using Encapsulation;
using NUnit.Framework;

namespace ChallengesTests.Encapsulation
{
    public class PointTests : TestBase
    {
        [Test]
        public void PointNeigborTest()
        {
            var point = new Point(1, 1);
            var isAllNeigbors = new[]
            {
                new Point(0, 1),
                new Point(1, 0),
                new Point(1, 2),
                new Point(2, 1)
            }
                .Select(i => i.IsNeighbor(point))
                .All(i => i == true);

            Assert.True(isAllNeigbors);
        }

        [Test]
        public void PointNotNeigborTest()
        {
            var point = new Point(1, 1);
            var isNooneNeigbor = new[]
            {
                new Point(0, 0),
                new Point(0, 2),
                new Point(2, 0),
                new Point(2, 2),
            }
                .Select(i => i.IsNeighbor(point))
                .All(i => i == false);

            Assert.True(isNooneNeigbor);
        }
    }
}