using Delegates.Classes;
using NUnit.Framework;

namespace ChallengesTests.Delegates
{
    public class DelegatesTest : TestBase
    {
        private Processor _processor;

        public override void SetUp()
        {
            _processor = new Processor();
        }

        [Test]
        public void CreateTransactionTest()
        {
            var transaction = _processor.Process(new TransactionRequest(), i => true, i => new Transaction(), i => { });
            Assert.AreEqual("This is Transaction", transaction.ToString());
        }

        [Test]
        public void CreateOrderTest()
        {
            var order = _processor.Process(new OrderRequest(), i => true, i => new Order(), i => { });
            Assert.AreEqual("This is Order", order.ToString());
        }
    }
}