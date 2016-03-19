using System;
using System.Collections.Generic;

namespace Encapsulation
{
    public class Game : GameBase
    {
        public Game(params int[] tileNumbers) : base(tileNumbers)
        {
        }

        public void MutableShift(int value)
        {
            var valueLocation = LocationCache[value];
            var zeroLocation = LocationCache[0];

            if (!valueLocation.IsNeighbor(zeroLocation))
            {
                throw new ArgumentException($"Невозможно выполнить сдвиг для {nameof(value)}");
            }

            Tiles[zeroLocation.Row, zeroLocation.Column] = value;
            Tiles[valueLocation.Row, valueLocation.Column] = 0;

            LocationCache[value] = zeroLocation;
            LocationCache[0] = valueLocation;
        }

        public override IGame Shift(int value)
        {
            var valueLocation = LocationCache[value];
            var zeroLocation = LocationCache[0];

            if (!valueLocation.IsNeighbor(zeroLocation))
            {
                throw new ArgumentException($"Невозможно выполнить сдвиг для {nameof(value)}");
            }

            var arguments = new List<int>();
            for (int i = 0; i < FieldSize; ++i)
            {
                for (int j = 0; j < FieldSize; ++j)
                {
                    if (Tiles[i, j] == 0)
                    {
                        arguments.Add(value);
                        continue;
                    }

                    if (Tiles[i, j] == value)
                    {
                        arguments.Add(0);
                        continue;
                    }

                    arguments.Add(Tiles[i, j]);
                }
            }

            return new Game(arguments.ToArray());
        }
    }
}