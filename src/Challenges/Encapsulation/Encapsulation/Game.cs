using System;
using System.Collections.Generic;
using System.Linq;

namespace Encapsulation
{
    public class Game
    {
        private readonly int[,] _tiles;
        private readonly Point[] _locationCache;
        private readonly int _fieldSize;

        public Game(params int[] tileNumbers)
        {
            _fieldSize = Convert.ToInt32(Math.Sqrt(tileNumbers.Length));

            if (_fieldSize * _fieldSize != tileNumbers.Length)
            {
                throw new ArgumentException();
            }

            _tiles = new int[_fieldSize, _fieldSize];
            _locationCache = new Point[tileNumbers.Length];

            CreateField(tileNumbers);
        }

        public int this[int row, int column]
        {
            get
            {
                if (row >= 0 && row < _fieldSize && column >= 0 && column < _fieldSize)
                {
                    return _tiles[row, column];
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public Point GetLocation(int value)
        {
            if (value >= 0 && value < _fieldSize*_fieldSize)
            {
                return _locationCache[value];
            }

            throw new ArgumentOutOfRangeException();
        }

        public void Shift(int value)
        {
            var valueTile = _locationCache[value];

            var zeroTile = new[]
            {
                new Point(0, -1),
                new Point(-1, 0),
                new Point(0, 1),
                new Point(1, 0)
            }
            .Select(i => new Point(valueTile.Row + i.Row, valueTile.Column + i.Column))
            .Where(IsInField)
            .SingleOrDefault(i => _tiles[i.Row, i.Column] == 0);

            if (zeroTile == null)
            {
                throw new ArgumentException();
            }

            _tiles[zeroTile.Row, zeroTile.Column] = value;
            _tiles[valueTile.Row, valueTile.Column] = 0;

            _locationCache[value] = zeroTile;
            _locationCache[0] = valueTile;
        }

        public Game ImmutableShift(int value)
        {
            var valueTile = _locationCache[value];

            var zeroTile = new[]
            {
                new Point(0, -1),
                new Point(-1, 0),
                new Point(0, 1),
                new Point(1, 0)
            }
            .Select(i => new Point(valueTile.Row + i.Row, valueTile.Column + i.Column))
            .Where(IsInField)
            .SingleOrDefault(i => _tiles[i.Row, i.Column] == 0);

            if (zeroTile == null)
            {
                throw new ArgumentException();
            }

            var arguments = new List<int>();
            for (int i = 0; i < _fieldSize; ++i)
            {
                for (int j = 0; j < _fieldSize; ++j)
                {
                    if (_tiles[i, j] == 0)
                    {
                        arguments.Add(value);
                        continue;
                    }

                    if (_tiles[i, j] == value)
                    {
                        arguments.Add(0);
                        continue;
                    }

                    arguments.Add(_tiles[i, j]);
                }
            }

            return new Game(arguments.ToArray());
        }

        private void CreateField(params int[] tileNumbers)
        {
            for (int i = 0; i < _fieldSize; ++i)
            {
                for (int j = 0; j < _fieldSize; ++j)
                {
                    var currentTileNumber = tileNumbers[i * _fieldSize + j];
                    _tiles[i, j] = currentTileNumber;
                    _locationCache[currentTileNumber] = new Point(i, j);
                }
            }
        }

        private bool IsInField(Point point)
        {
            return point.Row >= 0 && point.Row < _fieldSize && point.Column >= 0 && point.Column < _fieldSize;
        }
    }
}