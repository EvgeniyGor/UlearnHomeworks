using System;
using System.Collections.Generic;

namespace DDD.UI
{
    public static class GridDesigner
    {
        private const string MINE   = "*";
        private const string UNREVEALED = ".";
        private const string EMPTY  = "0";

        private static readonly Dictionary<string, ConsoleColor> _colors = new Dictionary<string, ConsoleColor>
        {
            [UNREVEALED] = ConsoleColor.Gray,
            [MINE]   = ConsoleColor.Red,
            [EMPTY]  = ConsoleColor.White,
            ["1"]    = ConsoleColor.Yellow,
            ["2"]    = ConsoleColor.Green,
            ["3"]    = ConsoleColor.Magenta,
            ["4"]    = ConsoleColor.Blue,
            ["5"]    = ConsoleColor.DarkYellow,
            ["6"]    = ConsoleColor.DarkGreen,
            ["7"]    = ConsoleColor.DarkMagenta,
            ["8"]    = ConsoleColor.DarkBlue
        };

        public static void Draw(ConsoleGame game)
        {
            Console.SetCursorPosition(game.ConsolePosLeft, game.ConsolePosTop);

            for (int top = 0; top < game.Height; ++top)
            {
                Console.CursorLeft = game.ConsolePosLeft;

                for (int left = 0; left < game.Width; ++left)
                {
                    if (!game[left, top].Revealed)
                    {
                        ColorWrite(UNREVEALED);
                        continue;
                    }

                    ColorWrite(game[left, top].HasMine ? "*" : game[left, top].Digit.ToString());
                }

                Console.WriteLine();
            }
        }

        private static void ColorWrite(string content)
        {
            Console.ForegroundColor = _colors[content];
            Console.Write(content);
        }
    }
}