using Derivation;
using NUnit.Framework;

namespace ChallengesTests.Reflection
{
    public class DerivatorTests : TestBase
    {
        [Test]
        public void SimpleTest()
        {
            var result = Derivator.Simplify(x => 2*x + 5);
        }
    }
}