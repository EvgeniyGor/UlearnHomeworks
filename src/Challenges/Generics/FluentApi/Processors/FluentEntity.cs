namespace Generics.FluentApi.Processors
{
    public sealed class FluentEntity : IFluentEntity
    {
        private readonly Processor _processor;

        internal FluentEntity(Processor processor)
        {
            _processor = processor;
        }

        public Processor With<TLogger>() where TLogger : ILogger, new()
        {
            _processor.Logger = new TLogger();
            return _processor;
        }

        public IEngine Engine => _processor.Engine;
        public IEntity Entity => _processor.Entity;
    }
}