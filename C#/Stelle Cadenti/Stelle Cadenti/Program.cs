using Microsoft.SqlServer.Server;
using System;

namespace Stelle_Cadenti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random casual = new Random();
            int i = 0, resetCount = 4000;
            char[] linee = {' '};
            do
            {
                Console.BackgroundColor = (ConsoleColor)casual.Next(0, 16);
                Console.ForegroundColor = (ConsoleColor)casual.Next(0, 16);
                Console.CursorLeft = (int)casual.Next(0, Console.WindowWidth);
                Console.CursorTop = (int)casual.Next(0, Console.WindowHeight);
                Console.Write("*");
                i++;
                if (i > resetCount)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    for (; i > 0; i--)
                    {
                        Console.CursorLeft = (int)casual.Next(0, Console.WindowWidth);
                        Console.CursorTop = (int)casual.Next(0, Console.WindowHeight);
                        Console.Write(linee[casual.Next(0,linee.Length)]);
                    }
                }
            } while (!Console.KeyAvailable);
        }
    }
}