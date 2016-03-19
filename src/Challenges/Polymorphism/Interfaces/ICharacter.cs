using System.Collections.Generic;

namespace Polymorphism.Interfaces
{
    public interface ICharacter : IStats
    {
        Dictionary<string, ISkill> Skills { get; }
        List<IEffect> Effects { get; }
    }
}