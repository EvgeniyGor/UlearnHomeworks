using Generics.IdStorage;
using NUnit.Framework;

namespace ChallengesTests.Generics
{
    public class StorageTests : TestBase
    {
        private Storage _storage;

        public override void SetUp()
        {
            _storage = new Storage();
        }

        [Test]
        public void CreateObjectTest()
        {
            var result = _storage.CreateObject<SampleObject>();
            Assert.AreEqual(typeof(SampleObject), result.GetType());
        }

        [Test]
        public void GetObjectsTest()
        {
            
        }
    }

    internal class SampleObject
    {
    }
}