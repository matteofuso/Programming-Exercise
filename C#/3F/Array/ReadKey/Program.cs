using System;

namespace ReadKey
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tasto;
            ConsoleColor color = ConsoleColor.Gray;
            char matita = '.';
            bool continua = true, write = false, ins = false;
            int backLeft = 0, backTop = 0, i;
            do
            {
                if (write && !ins)
                {
                    Console.Write(matita);
                }
                if (write && ins)
                {
                    Console.CursorLeft++;
                }
                backLeft = Console.CursorLeft;
                backTop = Console.CursorTop;
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                for (i=0; i < Console.WindowWidth - 1; i++)
                {
                    Console.Write(" ");
                }
                Console.Write($"\r x: {backLeft} y: {backTop}");
                if (ins)
                {
                    Console.Write(" INS");
                }
                Console.SetCursorPosition(backLeft, backTop);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = color;
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
                        if (Console.CursorLeft < Console.WindowWidth)
                        {
                            write = true;
                        }
                        break;
                    case (ConsoleKey.DownArrow):
                        if (Console.CursorTop < Console.WindowHeight - 2)
                        {
                            Console.CursorTop++;
                            if (Console.CursorLeft > 0)
                            {
                                Console.CursorLeft--;
                            }
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
                    case (ConsoleKey.C):
                        Console.Clear();
                        break;
                    case (ConsoleKey.R):
                        color = ConsoleColor.Red;
                        break;
                    case (ConsoleKey.G):
                        color = ConsoleColor.Green;
                        break;
                    case (ConsoleKey.B):
                        color = ConsoleColor.Blue;
                        break;
                    case (ConsoleKey.Y):
                        color = ConsoleColor.Yellow;
                        break;
                    case (ConsoleKey.W):
                        color = ConsoleColor.White;
                        break;
                    case (ConsoleKey.E):
                        color = ConsoleColor.Black;
                        break;
                    case (ConsoleKey.Insert):
                        ins = !ins;
                        break;
                    case (ConsoleKey.Escape):
                        continua = false;
                        break;
                }
            } while (continua);
        }
    }
}