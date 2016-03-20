using NUnit.Framework;
using Polymorphism.Characters;
using Polymorphism.Extentions;
using Polymorphism.Interfaces;
using Polymorphism.Spells;

namespace ChallengesTests.Polymorphism
{
    public class CharacterTests : TestBase
    {
        private ICharacter _firstCharacter;
        private ICharacter _secondCharacter;

        public override void SetUp()
        {
            _firstCharacter = new Wizzard(new[] { new Blizzard() })
            {
                Health = 100,
                Mana = 100,
                Strength = 100,
            };

            _secondCharacter = new Wizzard(new[] { new Blizzard() })
            {
                Health = 100,
                Mana = 100,
                Strength = 100,
            };
        }

        [Test]
        public void CharacterCreationTest()
        {
            Assert.AreEqual(100, _firstCharacter.Health);
            Assert.AreEqual(100, _firstCharacter.Mana);
            Assert.AreEqual(100, _firstCharacter.Strength);
        }

        [Test]
        public void CastSkillTest()
        {
            var skill = _firstCharacter.Spells["Blizzard"];

            _firstCharacter.CastSkill(skill, _secondCharacter);

            Assert.AreEqual(1, _secondCharacter.Effects.Count);

            Assert.AreEqual(_firstCharacter.Mana - skill.Cost, _firstCharacter.Mana);

            Assert.AreEqual(_secondCharacter.Health + skill.Effect.StatsChanges.Health, _secondCharacter.Health);
            Assert.AreEqual(_secondCharacter.Mana + skill.Effect.StatsChanges.Mana, _secondCharacter.Mana);
            Assert.AreEqual(_secondCharacter.Strength + skill.Effect.StatsChanges.Strength, _secondCharacter.Strength);
        }
    }
}