namespace Polymorphism.Interfaces
{
    public interface IEffect
    {
        string Name { get; }
        IStats StatsChanges { get; }
    }
}