using System.Linq;
using Polymorphism.Interfaces;
using Polymorphism.Spells;

namespace Polymorphism.Characters
{
    public class Wizzard : Character
    {
        public Wizzard()
        {
            Stats = new Stats
            {
                Health = 100,
                Mana = 100,
                Armor = 100
            };

            Spells = new ISpell[]
            {
                new Fireball(),
                new Blizzard()
            }
            .ToDictionary(key => key.Name, value => value);
        }
    }
}