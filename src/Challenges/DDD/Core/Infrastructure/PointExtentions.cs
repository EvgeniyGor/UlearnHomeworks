using System.Collections.Generic;
using System.Linq;
using DDD.Core.Domain.Models;

namespace DDD.Core.Infrastructure
{
    public static class PointExtentions
    {
        private static readonly Point[] _shiftPoints;

        static PointExtentions()
        {
            var shifts = new [] {-1, 0, 1};
            var zeroPoint = new Point(0, 0);

            _shiftPoints = shifts
                .SelectMany(row => shifts.Select(column => new Point(row, column)))
                .Where(point => point != zeroPoint)
                .ToArray();
        }
        
        public static IEnumerable<Point> GetNeighbours(this Point point) => 
            _shiftPoints.Select(shift => new Point(shift.Row + point.Row, shift.Column + point.Column));

        public static bool InArray(this Point point, int height, int width)
        {
            return point.Row >= 0 && point.Row < height &&
                   point.Column >= 0 && point.Column < width;
        }
    }
}