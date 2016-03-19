using System;
using Polymorphism.Interfaces;

namespace Polymorphism.Extentions
{
    public static class CharacterExtentions
    {
        public static void AddEffect(this ICharacter character, IEffect effect)
        {
            character.Effects.Add(effect);
        }

        public static void CastSkill(this ICharacter character, string skillName, ICharacter target)
        {
            if (!character.Skills.ContainsKey(skillName))
            {
                throw new ArgumentException($"Character doesn't have skill {skillName}");
            }

            var skill = character.Skills[skillName];
            character.Mana -= skill.Cost;
            target.AddEffect(skill.Effect);
        }
    }
}