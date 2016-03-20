using System;
using Polymorphism.Interfaces;

namespace Polymorphism.Effects
{
    public class Burning : IEffect
    {
        public string Name { get; } = "Burning";

        public Func<Stats, Stats> StatsChanges { get; } = stats => new Stats
        {
            Health = stats.Health -= 50,
            Mana = stats.Mana /= 2,
            Armor = stats.Armor -= 100
        };
    }
}