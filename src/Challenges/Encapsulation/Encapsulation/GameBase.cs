using System;

namespace Encapsulation
{
    public abstract class GameBase : IGame
    {
        protected int[,] Tiles { get; }
        protected Point[] LocationCache { get; }

        protected GameBase(params int[] tileNumbers)
        {
            FieldSize = Convert.ToInt32(Math.Sqrt(tileNumbers.Length));

            if (FieldSize * FieldSize != tileNumbers.Length)
            {
                throw new ArgumentException();
            }

            Tiles = new int[FieldSize, FieldSize];
            LocationCache = new Point[tileNumbers.Length];

            for (int i = 0; i < FieldSize; ++i)
            {
                for (int j = 0; j < FieldSize; ++j)
                {
                    var currentTileNumber = tileNumbers[i * FieldSize + j];
                    Tiles[i, j] = currentTileNumber;
                    LocationCache[currentTileNumber] = new Point(i, j);
                }
            }
        }

        public int FieldSize { get; }

        public int this[int row, int column]
        {
            get
            {
                if (IsInField(new Point(row, column)))
                {
                    return Tiles[row, column];
                }

                throw new ArgumentException($"Значения индексов {nameof(row)} и {nameof(column)} вне границ поля");
            }
        }

        public Point GetLocation(int value)
        {
            if (value >= 0 && value < FieldSize * FieldSize)
            {
                return LocationCache[value];
            }

            throw new ArgumentException($"Значения {nameof(value)} не существует на поле");
        }

        public abstract IGame Shift(int value);

        private bool IsInField(Point point)
        {
            return point.Row >= 0 && point.Row < FieldSize && point.Column >= 0 && point.Column < FieldSize;
        }
    }
}