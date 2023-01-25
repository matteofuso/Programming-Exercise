using System;
using System.Threading;

namespace lancioDado
{
    class Program
    {
        static void Main(string[] args)
        {
            const char pallino = 'O';
            int sleep = 1000, centerx = Console.WindowWidth / 2, centery = Console.WindowHeight / 2;
            const string zero = "                   ";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(centerx - 9, centery - 3);
            Console.WriteLine(zero);
            Console.SetCursorPosition(centerx - 9, centery - 1);
            Console.WriteLine(zero);
            Console.SetCursorPosition(centerx - 9, centery + 1);
            Console.WriteLine(zero);
            Console.SetCursorPosition(centerx - 9, centery + 3);
            Console.WriteLine(zero);
            for (int faccia = 1; faccia < 7; faccia++)
            {
                Console.SetCursorPosition(centerx - 9, centery - 2);
                if (faccia == 1)
                {
                    Console.WriteLine(zero);
                    Console.SetCursorPosition(centerx - 9, centery);
                    Console.WriteLine("         {0}         ", pallino);
                    Console.SetCursorPosition(centerx - 9, centery + 2);
                    Console.WriteLine(zero);
                }
                else if (faccia == 2)
                {
                    Console.WriteLine("              {0}    ", pallino);
                    Console.SetCursorPosition(centerx - 9, centery);
                    Console.WriteLine(zero);
                    Console.SetCursorPosition(centerx - 9, centery + 2);
                    Console.WriteLine("    {0}              ", pallino);
                }
                else if (faccia == 3)
                {
                    Console.WriteLine("              {0}    ", pallino);
                    Console.SetCursorPosition(centerx - 9, centery);
                    Console.WriteLine("         {0}         ", pallino);
                    Console.SetCursorPosition(centerx - 9, centery + 2);
                    Console.WriteLine("    {0}              ", pallino);
                }
                else if (faccia == 4)
                {
                    Console.WriteLine("    {0}         {1}    ", pallino, pallino);
                    Console.SetCursorPosition(centerx - 9, centery);
                    Console.WriteLine(zero);
                    Console.SetCursorPosition(centerx - 9, centery + 2);
                    Console.WriteLine("    {0}         {1}    ", pallino, pallino);
                }
                else if (faccia == 5)
                {
                    Console.WriteLine("    {0}         {1}    ", pallino, pallino);
                    Console.SetCursorPosition(centerx - 9, centery);
                    Console.WriteLine("         {0}         ", pallino);
                    Console.SetCursorPosition(centerx - 9, centery + 2);
                    Console.WriteLine("    {0}         {1}    ", pallino, pallino);
                }
                else
                {
                    Console.WriteLine("    {0}         {1}    ", pallino, pallino);
                    Console.SetCursorPosition(centerx - 9, centery);
                    Console.WriteLine("    {0}         {1}    ", pallino, pallino);
                    Console.SetCursorPosition(centerx - 9, centery + 2);
                    Console.WriteLine("    {0}         {1}    ", pallino, pallino);
                }
                Thread.Sleep(sleep);
            }
            Console.ReadLine();
        }
    }
}