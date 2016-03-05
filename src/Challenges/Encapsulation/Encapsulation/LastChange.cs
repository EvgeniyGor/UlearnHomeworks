namespace Encapsulation
{
    internal class LastChange
    {
        public LastChange(int value, Point valueLocation, Point zeroLocation)
        {
            Value = value;
            NewValueLocation = valueLocation;
            NewZeroLocation = zeroLocation;
        }

        public int Value { get; }
        public Point NewValueLocation { get; }
        public Point NewZeroLocation { get; }
    }
}