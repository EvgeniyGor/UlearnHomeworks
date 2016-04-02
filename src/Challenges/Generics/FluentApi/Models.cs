namespace Generics.FluentApi
{
    public class MyEngine : IEngine
    {
        public override string ToString()
        {
            return "MyEngine";
        }
    }

    public class MyEntity : IEntity
    {
        public override string ToString()
        {
            return "MyEntity";
        }
    }

    public class MyLogger : ILogger
    {
        public override string ToString()
        {
            return "MyLogger";
        }
    }
}