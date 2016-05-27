using System;
using System.Drawing;

namespace MyPhotoshop
{
    public class FreeRotationTransformer : ITransformer<RotationParameters>
    {
        public Size SizeTransform(Size oldSize, RotationParameters parameters)
        {
            var angle = Math.PI * parameters.Angle / 180.0d;
            var cosAngle = Math.Abs(Math.Cos(angle));
            var sinAngle = Math.Abs(Math.Sin(angle));
            return new Size(
                (int)(oldSize.Width * cosAngle + oldSize.Height * sinAngle),
                (int)(oldSize.Height * cosAngle + oldSize.Width * sinAngle)
            );
        }

        public Point? PointTransform(Point point, Size oldSize, RotationParameters parameters)
        {
            var newSize = SizeTransform(oldSize, parameters);
            var angle = Math.PI * parameters.Angle / 180.0d;
            point = new Point(point.X - newSize.Width / 2, point.Y - newSize.Height / 2);

            var cosAngle = Math.Cos(angle);
            var sinAngle = Math.Sin(angle);

            var x = oldSize.Width / 2 + (int)(point.X * cosAngle + point.Y * sinAngle);
            var y = oldSize.Height / 2 + (int)(-point.X * sinAngle + point.Y * cosAngle);

            if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
            {
                return null;
            }

            return new Point(x, y);
        }
    }
}