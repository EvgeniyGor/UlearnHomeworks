using System;

namespace Encapsulation
{
    public class RefactoredGame : GameBase
    {
        public RefactoredGame(params int[] tileNumbers) : base(tileNumbers)
        {
        }

        public override IGame Shift(int value)
        {
            var valueLocation = LocationCache[value];
            var zeroLocation = LocationCache[0];

            if (valueLocation.IsNeigbor(zeroLocation))
            {
                return new GameDecorator(this, new LastChange(value, zeroLocation, valueLocation));
            }

            throw new ArgumentException($"Невозможно выполнить сдвиг для {nameof(value)}");
        }
    }
}