namespace DDD.UI
{
    public struct ConsolePoint
    {
        public ConsolePoint(int left, int top)
        {
            Left = left;
            Top = top;
        }

        public int Left { get; }
        public int Top { get; }
    }
}