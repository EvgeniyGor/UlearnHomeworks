using System.Linq;
using DDD.Core.Domain.Models;
using DDD.Core.Infrastructure;
using NUnit.Framework;

namespace ChallengesTests.DDD
{
    public class PointTests : TestBase
    {
        [Test]
        public void PointEqualityTest()
        {
            var first = new Point(2, 3);
            var second = new Point(2, 3);

            Assert.True(first == second);
            Assert.True(first.Equals(second));
        }

        [Test]
        public void NeigborsTest()
        {
            var point = new Point(3, 5);

            var expected = new[]
            {
                new Point(2, 4),
                new Point(2, 5),
                new Point(2, 6),
                new Point(3, 4),
                new Point(3, 6),
                new Point(4, 4),
                new Point(4, 5),
                new Point(4, 6)
            };

            var actual = point
                .GetNeighbours()
                .ToArray();

            var actualMessage = string.Join("; ", actual.OrderBy(i => i.Column).ThenBy(i => i.Row));
            var expectedMessage = string.Join("; ", expected.OrderBy(i => i.Column).ThenBy(i => i.Row));

            Assert.Equals(expected, actual);
            Assert.Equals(expectedMessage, actualMessage);
        }

        [Test]
        public void InArrayTest()
        {
            var point = new Point(2, 3);

            Assert.True(point.InArray(5, 5), "Height = 5, Width = 5");

            Assert.False(point.InArray(2, 3), "Height = 2, Width = 3");
            Assert.False(point.InArray(1, 5), "Height = 1, Width = 5");
            Assert.False(point.InArray(4, 2), "Height = 4, Width = 2");
        }
    }
}