using System;
using System.Collections.Generic;
using Polymorphism.Interfaces;

namespace Polymorphism.Extentions
{
    public static class CharacterExtentions
    {
        public static void AddEffects(this ICharacter character, IEnumerable<IEffect> effects)
        {
            character.Effects.AddRange(effects);
        }

        public static void CastSkill(this ICharacter character, string skillName, ICharacter target)
        {
            if (!character.Skills.ContainsKey(skillName))
            {
                throw new ArgumentException($"Character doesn't have skill {skillName}");
            }

            var skill = character.Skills[skillName];
            character.Mana -= skill.Cost;
            target.AddEffects(skill.Effects);
        }
    }
}