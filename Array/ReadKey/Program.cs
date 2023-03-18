using System;

namespace ReadKey
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tasto;
            char matita = '.';
            bool continua = true, write = true;
            int backLeft = 0, backTop = 0;
            do
            {
                if (write)
                {
                    Console.Write(matita);
                }
                backLeft = Console.CursorLeft;
                backTop = Console.CursorTop;
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(new string(' ', Console.WindowWidth) + "\r");
                Console.Write($" x: {backLeft} y: {backTop}");
                Console.SetCursorPosition(backLeft, backTop);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                write = false;
                tasto = Console.ReadKey(true);
                switch (tasto.Key)
                {
                    case (ConsoleKey.LeftArrow):
                        if (Console.CursorLeft > 1)
                        {
                            Console.CursorLeft -= 2;
                            write = true;
                        }
                        break;
                    case (ConsoleKey.RightArrow):
                        if (Console.CursorLeft < Console.WindowWidth - 1)
                        {
                            write = true;
                        }
                        break;
                    case (ConsoleKey.DownArrow):
                        if (Console.CursorTop < Console.WindowHeight - 2)
                        {
                            Console.CursorTop++;
                            Console.CursorLeft--;
                            write = true;
                        }
                        break;
                    case (ConsoleKey.UpArrow):
                        if (Console.CursorTop > 0)
                        {
                            Console.CursorTop--;
                            Console.CursorLeft--;
                            write = true;
                        }
                        break;
                    case (ConsoleKey.Escape):
                        continua = false;
                        break;
                }
            } while (continua);
        }
    }
}