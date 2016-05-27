namespace Polymorphism.Interfaces
{
    public interface ISpell
    {
        string Name { get; }

        int ReloadTime { get; }
        int? Cooldown { get; set; }

        int? InfluenceTime { get; }
        int? Duration { get; }
        
        int Cost { get; }
        IEffect Effect { get; } 
    }
}