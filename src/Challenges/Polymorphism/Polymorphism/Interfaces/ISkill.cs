namespace Polymorphism.Interfaces
{
    public interface ISkill
    {
        string Name { get; }
        int Cooldown { get; }
        int ActionTime { get; }
        int Cost { get; }
        IEffect Effect { get; }
    }
}