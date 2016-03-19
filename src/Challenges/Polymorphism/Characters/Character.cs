using System.Collections.Generic;
using System.Linq;
using Polymorphism.Interfaces;

namespace Polymorphism.Characters
{
    public class Character : ICharacter
    {
        private int _health;
        private int _mana;
        private int _armor;
        private int _strength;
        private int _stamina;

        public Character(IEnumerable<ISkill> skills)
        {
            Skills = skills.ToDictionary(key => key.Name, value => value);
            Effects = new List<IEffect>();
        }

        public int Health
        {
            get { return _health + Effects.Sum(i => i.StatsChanges.Health); }
            set { _health = value; }
        }

        public int Mana
        {
            get { return _mana + Effects.Sum(i => i.StatsChanges.Mana); }
            set { _mana = value; }
        }

        public int Strength
        {
            get { return _strength + Effects.Sum(i => i.StatsChanges.Strength); }
            set { _strength = value; }
        }

        public Dictionary<string, ISkill> Skills { get; }
        public List<IEffect> Effects { get; }
    }
}