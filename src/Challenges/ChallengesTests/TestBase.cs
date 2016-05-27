using NUnit.Framework;

namespace ChallengesTests
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public virtual void SetUp()
        {
        }

        [TearDown]
        public virtual void TearDown()
        {
        }
    }
}