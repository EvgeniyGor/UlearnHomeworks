using System;
using System.Diagnostics;
using MyPhotoshop;

namespace Profiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var handler = new ExpressionParametersHandler<LighteningParameters>();
            Test(values => handler.CreateParameters(values), 100000);
            Test(values =>  new LighteningParameters { Coefficient = values[0] }, 100000);
        }

        public static void Test(Func<double[], LighteningParameters> method, int N)
        {
            var values = new double[] {0};

            method(values);

            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < N; ++i)
            {
                method(values);
            }

            watch.Stop();

            Console.WriteLine(1000 * (double)watch.ElapsedMilliseconds / N);
        }
    }
}
