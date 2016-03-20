using Polymorphism.Effects;
using Polymorphism.Interfaces;

namespace Polymorphism.Spells
{
    public class Blizzard : ISpell
    {
        public Blizzard()
        {
            Name = "Blizzard";

            ReloadTime = 3;
            Cooldown = 3;

            InfluenceTime = 1;
            Duration = 1;

            Cost = 30;
            Effect = new Freezing();
        }

        public string Name { get; }

        public int ReloadTime { get; }
        public int? Cooldown { get; set; }

        public int? InfluenceTime { get; }
        public int? Duration { get; set; }

        public int Cost { get; }
        public IEffect Effect { get; }
    }
}