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

        public bool IsNeigbor(Point point)
        {
            return new[]
            {
                new Point(0, -1),
                new Point(-1, 0),
                new Point(0, 1),
                new Point(1, 0)
            }
                .Select(i => new Point(Row + i.Row, Column + i.Column))
                .Any(i => i.Equals(point));
        }

        public bool Equals(Point other)
        {
            return Row == other.Row && Column == other.Column;
        }
    }
}