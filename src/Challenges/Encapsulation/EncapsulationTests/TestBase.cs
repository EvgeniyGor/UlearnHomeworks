using NUnit.Framework;

namespace EncapsulationTests
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