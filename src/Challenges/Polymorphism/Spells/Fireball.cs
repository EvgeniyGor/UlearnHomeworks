using Polymorphism.Effects;
using Polymorphism.Interfaces;

namespace Polymorphism.Spells
{
    public class Fireball : ISpell
    {
        public Fireball()
        {
            Name = "Fireball";

            ReloadTime = 5;
            Cost = 10;
            Effect = new Burning();
        }

        public string Name { get; }
        public int ReloadTime { get; }

        public int? Cooldown { get; set; } = null;
        public int? InfluenceTime { get; } = null;
        public int? Duration { get; } = null;

        public int Cost { get; }
        public IEffect Effect { get; }
    }
}