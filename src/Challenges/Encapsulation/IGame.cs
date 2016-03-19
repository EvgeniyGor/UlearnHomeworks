namespace Encapsulation
{
    public interface IGame
    {
        Point GetLocation(int value);
        IGame Shift(int value);

        int FieldSize { get; }
        int this[int row, int column] { get; }
    }
}