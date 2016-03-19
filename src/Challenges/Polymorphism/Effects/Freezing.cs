using Polymorphism.Interfaces;

namespace Polymorphism.Effects
{
    public class Freezing : IEffect
    {
        public Freezing()
        {
            Name = "Freezing";
            StatsChanges = new Stats
            {
                Health = -30,
                Armor = -40,
                Mana = 0,
                Stamina = -20,
                Strength = -15
            };
        }

        public string Name { get; }
        public IStats StatsChanges { get; }
    }
}