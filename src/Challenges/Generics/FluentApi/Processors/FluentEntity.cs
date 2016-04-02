namespace Generics.FluentApi.Processors
{
    public sealed class FluentEntity
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
    }
}