using Generics.Interfaces;

namespace Generics
{
    public class MyLogger : ILogger
    {
        public override string ToString()
        {
            return "MyLogger";
        }
    }
}