using System;

namespace Paint
{
    internal class Program
    {
        struct Posizione
        {
            public int x;
            public int y;
        }
        static void Main(string[] args)
        {
            bool esci = false, ins = false, canc = false;
            char matita = '.';
            int i;
            ConsoleColor testo = ConsoleColor.White;
            Posizione last = new Posizione();
            ConsoleKey key;
            do
            {
                last.x = Console.CursorLeft;
                last.y = Console.CursorTop;
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                for (i = 0; i < Console.WindowWidth - 1; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\r X: {0} Y: {1}", last.x, last.y);
                if (ins)
                {
                    Console.Write(" INS");
                }
                if (canc)
                {
                    Console.Write(" CANC");
                }
                Console.SetCursorPosition(last.x, last.y);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = testo;
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    // Direzione
                    case (ConsoleKey.LeftArrow):
                        // Freccia sinistra
                        if (Console.CursorLeft > 1)
                        {
                            Console.CursorLeft--;
                        }
                        break;
                    case (ConsoleKey.RightArrow):
                        // Freccia destra
                        if (Console.CursorLeft < Console.WindowWidth - 1)
                        {
                            Console.CursorLeft++;
                        }
                        break;
                    case (ConsoleKey.UpArrow):
                        // Freccia alta
                        if (Console.CursorTop > 0)
                        {
                            Console.CursorTop--;
                        }
                        break;
                    case (ConsoleKey.DownArrow):
                        // Freccia bassa
                        if (Console.CursorTop < Console.WindowHeight - 2)
                        {
                            Console.CursorTop++;
                        }
                        break;
                    // Colore
                    case (ConsoleKey.W):
                        // Bianco
                        testo = ConsoleColor.White;
                        continue;
                    case (ConsoleKey.R):
                        // Bianco
                        testo = ConsoleColor.Red;
                        continue;
                    case (ConsoleKey.G):
                        // Bianco
                        testo = ConsoleColor.Green;
                        continue;
                    case (ConsoleKey.B):
                        // Bianco
                        testo = ConsoleColor.Blue;
                        continue;
                    // Funzione
                    case (ConsoleKey.Escape):
                        // Esci
                        esci = true;
                        continue;
                    case (ConsoleKey.Insert):
                        // Inserisci
                        if (!canc)
                        {
                            ins = !ins;
                        }
                        continue;
                    case (ConsoleKey.Delete):
                        // Cancella con freccette
                        if (!ins)
                        {
                            canc = !canc;
                        }
                        continue;
                    case (ConsoleKey.Backspace):
                        // Cancella tutto
                        Console.Clear();
                        continue;
                    default:
                        // Tasto non implementato
                        continue;
                }
                if (!ins)
                {
                    if (Console.CursorLeft > 0)
                    {
                        Console.CursorLeft--;
                    }
                    if (canc)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(matita);
                    }
                }
            }
            while (!esci);
        }
    }
}
