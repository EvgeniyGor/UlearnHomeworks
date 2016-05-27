using Generics.FluentApi.Processors;

namespace Generics.FluentApi
{
    public interface IProcessor
    {
        IEngine Engine { get; }
        IEntity Entity { get; }
        ILogger Logger { get; }
    }

    public interface IFluentEngine
    {
        FluentEntity For<TEntity>() where TEntity : IEntity, new();
    }

    public interface IFluentEntity
    {
        Processor With<TLogger>() where TLogger : ILogger, new();
    }

    public interface IEngine
    {
    }

    public interface IEntity
    {
    }

    public interface ILogger
    {
    }
}