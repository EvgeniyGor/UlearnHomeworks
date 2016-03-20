using System.Collections.Generic;

namespace Polymorphism.Interfaces
{
    public interface ICharacter
    {
        Stats Stats { get; }
        Dictionary<string, ISpell> Spells { get; }
        List<IEffect> Effects { get; }

        void AddEffect(IEffect effect);
        void CastSkill(string spellName, ICharacter target);
    }
}