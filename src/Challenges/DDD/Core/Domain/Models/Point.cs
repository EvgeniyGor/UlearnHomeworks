using System;

namespace DDD.Core.Domain.Models
{
    public struct Point
    {
        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }

        public override string ToString()
        {
            return $"({ Row }, { Column })";
        }

        public override bool Equals(Object obj)
        {
            return obj is Point && this == (Point)obj;
        }

        public override int GetHashCode()
        {
            return Column.GetHashCode() ^ Row.GetHashCode();
        }

        public static bool operator == (Point first, Point second)
        {
            return first.Column == second.Column && first.Row == second.Row;
        }

        public static bool operator != (Point first, Point second)
        {
            return !(first == second);
        }
    }
}