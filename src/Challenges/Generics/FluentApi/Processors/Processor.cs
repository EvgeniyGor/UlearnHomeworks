namespace Generics.FluentApi.Processors
{
    public class Processor
    {
        public IEngine Engine { get; internal set; }
        public IEntity Entity { get; internal set; }
        public ILogger Logger { get; internal set; }

        public static FluentEngine CreatEngine<TEngine>() where TEngine: IEngine, new()
        {
            var processor = new Processor { Engine = new TEngine() };
            return new FluentEngine(processor);
        }
    }
}