using DDD.Core.Domain;
using DDD.Core.Domain.Models;

namespace DDD.UI
{
    public class ConsoleGame : IGame
    {
        private readonly IGame _game;

        public ConsoleGame(IGame game, int posLeft, int posTop)
        {
            _game = game;

            ConsolePosLeft = posLeft;
            ConsolePosTop = posTop;
        }

        public int ConsolePosLeft { get; }
        public int ConsolePosTop { get; }

        public int Width => _game.Width;
        public int Height => _game.Height;

        public GameState State => _game.State;

        public Cell this[int left, int top] => _game[top, left];

        public void RevealCell(Point point)
        {
            _game.RevealCell(point);
        }

        public void RevealCell(int left, int top)
        {
            _game.RevealCell(top, left);
        }
    }
}