using System;
using DDD.Core.App;

namespace DDD.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetConsoleSettings();

//            var game = GameBuilder.CreateGrid(16, 30)
//                .SetMine(3, 3)
//                .SetMine(5, 5)
//                .SetMine(15, 15)
//                .SetMine(10, 2)
//                .SetMine(12, 7)
//                .SetMine(9, 8)
//                .SetMine(11, 11)
//                .SetMine(12, 10)
//                .SetMine(14, 29)
//                .SetMine(14, 15)
//                .SetMine(13, 28)
//                .SetMine(12, 16)
//                .Build();

            var game = GameBuilder.CreateGrid(5, 5)
                .SetMine(0, 0)
                .SetMine(1, 1)
                .SetMine(2, 2)
                .SetMine(3, 3)
                .SetMine(4, 4)
                .Build();

            var consoleLeft = Console.BufferWidth/2 - game.Width/2;
            var consoleTop  = Console.BufferHeight/2 - game.Height/2 - 5;

            var consoleGame = new ConsoleGame(game, consoleLeft, consoleTop);

            GridDesigner.Draw(consoleGame);

            new GameController(consoleGame).Start();
        }

        public static void SetConsoleSettings()
        {
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
        }
    }
}