using Generics.Interfaces;

namespace Generics.Processors
{
    public class LoggerProcessor : IProcessor
    {
        private readonly EntityProcessor _processor;

        public LoggerProcessor(EntityProcessor processor, ILogger logger)
        {
            _processor = processor;
            Logger = logger;
        }

        public IEngine Engine => _processor.Engine;
        public IEntity Entity => _processor.Entity;
        public ILogger Logger { get; }
    }
}