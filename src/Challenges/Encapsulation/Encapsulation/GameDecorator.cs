using System;

namespace Encapsulation
{
    public class GameDecorator : IGame
    {
        private readonly IGame _game;
        private readonly LastChange _lastChange;

        public GameDecorator(IGame game, LastChange lastChange)
        {
            _game = game;
            _lastChange = lastChange;
        }

        public int FieldSize => _game.FieldSize;

        public int this[int row, int column]
        {
            get
            {
                if (_lastChange.NewValueLocation.Row == row && _lastChange.NewValueLocation.Column == column)
                {
                    return _lastChange.Value;
                }

                if (_lastChange.NewZeroLocation.Row == row && _lastChange.NewZeroLocation.Column == column)
                {
                    return 0;
                }

                return _game[row, column];
            }
        }

        public Point GetLocation(int value)
        {
            if (_lastChange.Value == value)
            {
                return _lastChange.NewValueLocation;
            }

            return value == 0 ? _lastChange.NewZeroLocation : _game.GetLocation(value);
        }

        public IGame Shift(int value)
        {
            var valueLocation = _game.GetLocation(value);
            var zeroLocation = _lastChange.NewZeroLocation;

            if (valueLocation.IsNeigbor(zeroLocation))
            {
                return new GameDecorator(this, new LastChange(value, zeroLocation, valueLocation));
            }

            throw new ArgumentException($"Невозможно выполнить сдвиг для {nameof(value)}");
        } 
    }
}