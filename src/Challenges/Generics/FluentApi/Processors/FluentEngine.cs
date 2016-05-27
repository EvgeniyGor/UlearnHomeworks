namespace Generics.FluentApi.Processors
{
    public sealed class FluentEngine : IFluentEngine
    {
        private readonly Processor _processor;

        internal FluentEngine(Processor processor)
        {
            _processor = processor;
        }

        public FluentEntity For<TEntity>() where TEntity : IEntity, new()
        {
            _processor.Entity = new TEntity();
            return new FluentEntity(_processor);
        }

        public IEngine Engine => _processor.Engine;
    }
}