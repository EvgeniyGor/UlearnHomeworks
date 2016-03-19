using Polymorphism.Effects;
using Polymorphism.Interfaces;

namespace Polymorphism.Skills
{
    public class Blizzard : ISkill
    {
        public Blizzard()
        {
            Name = "Blizzard";
            Cooldown = 3;
            ActionTime = 1;
            Cost = 30;
            Effect = new Freezing();
        }

        public string Name { get; }
        public int Cooldown { get; }
        public int ActionTime { get; }
        public int Cost { get; }
        public IEffect Effect { get; }
    }
}