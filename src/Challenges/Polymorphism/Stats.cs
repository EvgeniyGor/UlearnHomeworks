using Polymorphism.Interfaces;

namespace Polymorphism
{
    public struct Stats : IStats
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Armor { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
    }
}