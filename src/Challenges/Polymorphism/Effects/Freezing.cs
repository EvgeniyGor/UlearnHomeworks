using System;
using Polymorphism.Interfaces;

namespace Polymorphism.Effects
{
    public class Freezing : IEffect
    {
        public string Name { get; } = "Freezing";

        public Func<Stats, Stats> StatsChanges { get; } = stats => new Stats
        {
            Health = stats.Health -= 30,
            Mana = stats.Mana /= 2,
            Armor = stats.Armor += 20
        };
    }
}