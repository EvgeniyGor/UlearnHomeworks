using System;
using System.Linq;

namespace Encapsulation
{
    public class Point : IEquatable<Point>
    {
        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }

        public bool IsNeighbor(Point point)
        {
            return BasisPoints
                .Select(i => new Point(Row + i.Row, Column + i.Column))
                .Any(i => i.Equals(point));
        }

        private static readonly Point[] BasisPoints = new[]
                {
                    new Point(0, -1),
                    new Point(-1, 0),
                    new Point(0, 1),
                    new Point(1, 0)
                };

        public bool Equals(Point other)
        {
            return Row == other.Row && Column == other.Column;
        }
    }
}