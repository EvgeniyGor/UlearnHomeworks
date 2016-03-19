namespace Polymorphism.Interfaces
{
    public interface IStats
    {
        int Health { get; set; }
        int Mana { get; set; }
        int Armor { get; set; }
        int Strength { get; set; }
        int Stamina { get; set; }
    }
}