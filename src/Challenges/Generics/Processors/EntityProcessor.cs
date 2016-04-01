using Generics.Interfaces;

namespace Generics.Processors
{
    public class EntityProcessor
    {
        private readonly EngineProcessor _processor;

        public EntityProcessor(EngineProcessor processor, IEntity entity)
        {
            _processor = processor;
            Entity = entity;
        }

        public IEngine Engine => _processor.Engine;
        public IEntity Entity { get; }

        public LoggerProcessor With<TLogger>() where TLogger : ILogger, new()
        {
            return new LoggerProcessor(this, new TLogger());
        }
    }
}