using System;
using MemoryHandling;
using NUnit.Framework;

namespace ChallengesTests.MemoryHandling
{
    public class TimerTests : TestBase
    {
        [Test]
        public void SimpleTest()
        {
            var timer = new Timer();

            using (timer.Start())
            {
                SomeAction();
            }

            var startElapsed = timer.ElapsedMilliseconds;

            SomeAction();
            SomeAction();
            SomeAction();

            using (timer.Continue())
            {
                SomeAction();
            }

            var continueElapsed = timer.ElapsedMilliseconds;

            Console.WriteLine($"start: { startElapsed}, continue: { continueElapsed}");
            Assert.AreNotEqual(startElapsed, continueElapsed);
        }

        private static void SomeAction()
        {
            var sum = 0;
            for (int i = 0; i < 10000000; ++i)
            {
                sum += i;
            }
        }
    }
}