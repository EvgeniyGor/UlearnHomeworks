using System;

namespace Polymorphism.Interfaces
{
    public interface IEffect
    {
        string Name { get; }
        Func<Stats, Stats> StatsChanges { get; }
    }
}