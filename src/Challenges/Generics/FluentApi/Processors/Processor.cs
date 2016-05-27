namespace Generics.FluentApi.Processors
{
    //TODO: добавить возможность создавать процессор без логгера или без сущности
    public class Processor
    {
        public Processor(IEngine engine)
        {
            Engine = engine;
        }

        public IEngine Engine { get; internal set; }
        public IEntity Entity { get; internal set; } = null;
        public ILogger Logger { get; internal set; } = null;

        public static FluentEngine CreatEngine<TEngine>() where TEngine: IEngine, new()
        {
            var processor = new Processor(new TEngine());
            return new FluentEngine(processor);
        }
    }
}