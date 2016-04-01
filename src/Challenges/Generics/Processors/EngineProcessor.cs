using Generics.Interfaces;

namespace Generics.Processors
{
    public class EngineProcessor
    {
        public EngineProcessor(IEngine engine)
        {
            Engine = engine;
        }

        public IEngine Engine { get; }

        public EntityProcessor For<TEntity>() where TEntity : IEntity, new()
        {
            return new EntityProcessor(this, new TEntity());
        }
    }
}