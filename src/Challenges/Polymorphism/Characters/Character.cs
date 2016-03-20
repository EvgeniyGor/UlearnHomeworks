using System;
using System.Collections.Generic;
using Polymorphism.Interfaces;

namespace Polymorphism.Characters
{
    public class Character : ICharacter
    {
        public List<IEffect> Effects { get; set; } = new List<IEffect>();

        public Stats Stats { get; protected set; }
        public Dictionary<string, ISpell> Spells { get; protected set; }

        protected Stats ChangedStats { get; set; }

        public void AddEffect(IEffect effect)
        {
            Effects.Add(effect);

            ChangedStats = Stats;
            Effects.ForEach(i => i.StatsChanges(ChangedStats));
        }

        public void CastSkill(string spellName, ICharacter target)
        {
            if (!Spells.ContainsKey(spellName))
            {
                throw new ArgumentException($"Character doesn't have spell {spellName}");
            }

            if (Spells[spellName]?.Cooldown != 0)
            {
                return;
            }

            Spells[spellName].Cooldown = Spells[spellName].ReloadTime;

            Stats.Mana -= Spells[spellName].Cost;

            target.AddEffect(Spells[spellName].Effect);
        }
    }
}