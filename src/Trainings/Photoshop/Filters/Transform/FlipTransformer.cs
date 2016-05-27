using System.Drawing;

namespace MyPhotoshop
{
    public class FlipTransformer : ITransformer<EmptyParameters>
    {
        public Size SizeTransform(Size oldSize, EmptyParameters parameters)
        {
            return oldSize;
        }

        public Point? PointTransform(Point point, Size oldSize, EmptyParameters parameters)
        {
            return new Point(oldSize.Width - point.X - 1, point.Y);
        }
    }
}