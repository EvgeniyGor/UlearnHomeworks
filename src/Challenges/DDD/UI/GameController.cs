using System;
using System.Collections.Generic;
using DDD.Core.Domain;

namespace DDD.UI
{
    public class GameController
    {
        private readonly ConsoleGame _game;
        private readonly Dictionary<ConsoleKey, Action> _keyHandlers;

        public GameController(ConsoleGame game)
        {
            _game = game;

            _keyHandlers = new Dictionary<ConsoleKey, Action>
            {
                [ConsoleKey.LeftArrow]  = () => Console.CursorLeft = Console.CursorLeft - 1 < _game.ConsolePosLeft
                                                                   ? _game.ConsolePosLeft + _game.Width - 1
                                                                   : Console.CursorLeft - 1,

                [ConsoleKey.RightArrow] = () => Console.CursorLeft = Console.CursorLeft + 1 == _game.ConsolePosLeft + _game.Width
                                                                   ? _game.ConsolePosLeft
                                                                   : Console.CursorLeft + 1,

                [ConsoleKey.UpArrow]    = () => Console.CursorTop  = Console.CursorTop - 1 < _game.ConsolePosTop
                                                                   ? _game.ConsolePosTop + _game.Height - 1
                                                                   : Console.CursorTop - 1,
                
                [ConsoleKey.DownArrow]  = () => Console.CursorTop  = Console.CursorTop + 1 >= _game.ConsolePosTop + _game.Height
                                                                   ? _game.ConsolePosTop
                                                                   : Console.CursorTop + 1,

                [ConsoleKey.Spacebar]   = () => _game.RevealCell(Console.CursorLeft - _game.ConsolePosLeft, Console.CursorTop - _game.ConsolePosTop)
            };
        }

        public void Start()
        {
            var cursorState = new ConsolePoint(_game.ConsolePosLeft, _game.ConsolePosTop);
            
            while (_game.State == GameState.Continued)
            {
                Console.SetCursorPosition(cursorState.Left, cursorState.Top);

                var key = Console.ReadKey(true).Key;

                if (!_keyHandlers.ContainsKey(key))
                {
                    continue;
                }

                _keyHandlers[key]();

                cursorState = new ConsolePoint(Console.CursorLeft, Console.CursorTop);
                GridDesigner.Draw(_game);
            }

            Console.SetCursorPosition(0, Console.BufferHeight - 3);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(_game.State == GameState.PlayerWon ? "You won!" : "You lose!");
        }
    }
}