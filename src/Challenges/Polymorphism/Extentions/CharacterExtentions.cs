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

        public static void CastSkill(this ICharacter character, ISkill skill, ICharacter target)
        {
            if (!character.Skills.ContainsValue(skill))
            {
                throw new ArgumentException($"Character doesn't have skill {skill}");
            }

            character.Mana -= skill.Cost;
            target.AddEffect(skill.Effect);
        }
    }
}