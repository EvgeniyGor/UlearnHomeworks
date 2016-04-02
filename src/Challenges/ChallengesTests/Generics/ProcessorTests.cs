using Generics.FluentApi;
using Generics.FluentApi.Processors;
using NUnit.Framework;

namespace ChallengesTests.Generics
{
    public class ProcessorTests : TestBase
    {
        [Test]
        public void InitializeTest()
        {
            var processor = Processor.CreatEngine<MyEngine>().For<MyEntity>().With<MyLogger>();
            Assert.AreEqual("MyEntity", processor.Entity.ToString());
            Assert.AreEqual("MyEngine", processor.Engine.ToString());
            Assert.AreEqual("MyLogger", processor.Logger.ToString());
        } 
    }
}