namespace Generics.Interfaces
{
    public interface IProcessor
    {
        IEngine Engine { get; }
        IEntity Entity { get; }
        ILogger Logger { get; }
    }
}