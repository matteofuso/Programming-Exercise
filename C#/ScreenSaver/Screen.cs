using System;
using System.Threading;

namespace ScreenSaver
{
    class Screen
    {
        static void Main(string[] args)
        {
            Random casual = new Random();
            int max = 16, min = 0;
            do
            {
                Console.BackgroundColor = (ConsoleColor)casual.Next(min, max);
                Console.ForegroundColor = (ConsoleColor)casual.Next(min, max);
                Console.CursorLeft = casual.Next(0, Console.WindowWidth - 1);
                Console.CursorTop = casual.Next(0, Console.WindowHeight);
                Console.Write("*");
            }
            while (!Console.KeyAvailable);
        }
    }
}