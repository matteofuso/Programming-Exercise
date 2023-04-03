using System;

namespace Paint
{
    internal class Program
    {
        struct Coordinate
        {
            public int X;
            public int Y;
        }
        struct Pixel
        {
            public char pennello;
            public ConsoleColor background, foreground;
        }
        struct Screenshot
        {
            public Pixel[,] schermo;
            public Coordinate posizione;
            public ConsoleColor backgrond, foreground;
            public char pennello;
        }
        static void Main(string[] args)
        {
            Screenshot screenshot;
            screenshot.schermo = new Pixel[Console.WindowHeight - 1, Console.WindowWidth - 1];
            Pixel[,] schermo = new Pixel[Console.WindowHeight - 1, Console.WindowWidth - 1];
            ConsoleColor background = ConsoleColor.Black, foreground = ConsoleColor.White;
            screenshot.backgrond = background;
            screenshot.foreground = foreground;
            bool ins = false, canc = false;
            screenshot.posizione.X = 0;
            screenshot.posizione.Y = 0;
            screenshot.pennello = '\0';
            Coordinate posizione;
            char pennello = '.';
            bool esci = false;
            ConsoleKey tasto;
            posizione.X = 0;
            posizione.Y = 0;
            int i, j;
            do
            {
                // Cambio il colore di sfondo per scrivere la riga delle informazioni
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                // Sposto il cursore e scrivo la riga
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                for (i = 0; i < Console.WindowWidth - 1; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\r X: {0} Y: {1}", posizione.X, posizione.Y);
                if (ins)
                {
                    Console.Write(" INS");
                }
                if (canc)
                {
                    Console.Write(" CANC");
                }
                // Ripristino il colore di sfondo e testo, riposiziono il cursore
                Console.BackgroundColor = background;
                Console.ForegroundColor = foreground;
                Console.SetCursorPosition(posizione.X, posizione.Y);
                // Mi metto in attesa del tasto premuto
                tasto = Console.ReadKey(true).Key;
                // Controllo quale tasto è stato premuto
                switch (tasto)
                {
                    // Freccia sinistra o A
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        if (Console.CursorLeft < 2)
                        {
                            continue;
                        }
                        Console.CursorLeft -= 2;
                        break;
                    // Freccia a destra o D
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        if (Console.CursorLeft > Console.WindowWidth - 2)
                        {
                            continue;
                        }
                        break;
                    // Freccia in alto o W
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (Console.CursorTop < 1)
                        {
                            continue;
                        }
                        Console.CursorTop--;
                        break;
                    // Freccia in basso o S
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (Console.CursorTop > Console.WindowHeight - 3)
                        {
                            continue;
                        }
                        Console.CursorTop++;
                        break;
                    // Tasto per uscire
                    case ConsoleKey.Escape:
                        esci = true;
                        continue;
                    // Tasto per muovere solo cursore
                    case ConsoleKey.Insert:
                        if (!canc)
                        {
                            ins = !ins;
                        }
                        continue;
                    // Tasto per attivare la gomma
                    case ConsoleKey.Delete:
                        if (!ins)
                        {
                            canc = !canc;
                        }
                        continue;
                    // Tasto per salvare lo schermo
                    case ConsoleKey.F1:
                        // Per salvare lo schermo salvo la matrice dello schermo nella matrice screenshot
                        for (i = 0; i < schermo.GetLength(0); i++)
                        {
                            for (j = 0; j < schermo.GetLength(1); j++)
                            {
                                screenshot.schermo[i, j].pennello = schermo[i, j].pennello;
                                screenshot.schermo[i, j].background = schermo[i, j].background;
                                screenshot.schermo[i, j].foreground = schermo[i, j].foreground;
                            }
                        }
                        // Salvo infine le proprietà
                        screenshot.posizione = posizione;
                        screenshot.foreground = foreground;
                        screenshot.backgrond = background;
                        screenshot.pennello = pennello;
                        continue;
                    // Tasto Undo
                    case ConsoleKey.F2:
                        // Controllo se c'è uno screenshot
                        if (screenshot.pennello != '\0')
                        {
                            // Per tornare indietro modifico i pixel diversi
                            for (i = 0; i < schermo.GetLength(0); i++)
                            {
                                for (j = 0; j < schermo.GetLength(1); j++)
                                {
                                    // Controllo le differenze tra i pixel e modifico solo quelli che sono cambiati
                                    if ((screenshot.schermo[i, j].pennello != schermo[i, j].pennello) ||
                                        (screenshot.schermo[i, j].background != schermo[i, j].background) ||
                                        (screenshot.schermo[i, j].foreground != schermo[i, j].foreground)
                                    )
                                    {
                                        Console.SetCursorPosition(j, i);
                                        if (screenshot.schermo[i, j].pennello == '\0')
                                        {
                                            Console.BackgroundColor = ConsoleColor.Black;
                                            Console.Write("  ");
                                        }
                                        else
                                        {
                                            Console.BackgroundColor = screenshot.schermo[i, j].background;
                                            Console.ForegroundColor = screenshot.schermo[i, j].foreground;
                                            Console.Write(screenshot.schermo[i, j].pennello);
                                        }
                                    }
                                }
                            }
                            // Ripristino le proprietà
                            posizione = screenshot.posizione;
                            foreground = screenshot.foreground;
                            background = screenshot.backgrond;
                            pennello = screenshot.pennello;
                        }
                        else
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight - 1);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("Non hai neancora fatto uno screenshot!");
                            Console.ReadKey();
                        }
                        continue;
                    // Tasto per cambiare matita
                    case ConsoleKey.F3:
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight - 1);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Inserisci il carattere del nuovo pennello:");
                        pennello = Console.ReadKey().KeyChar;
                        continue;
                    // Colore sfondo
                    case ConsoleKey.F10:
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight - 1);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Inserisci il colore dello sfondo:");
                        tasto = Console.ReadKey().Key;
                        switch (tasto)
                        {
                            case ConsoleKey.R:
                                background = ConsoleColor.Red;
                                break;
                            case ConsoleKey.G:
                                background = ConsoleColor.Green;
                                break;
                            case ConsoleKey.B:
                                background = ConsoleColor.Blue;
                                break;
                            default:
                                background = ConsoleColor.Black;
                                break;
                        }
                        continue;
                    // Colore Testo
                    case ConsoleKey.F12:
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight - 1);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Inserisci il colore del pennello:");
                        tasto = Console.ReadKey().Key;
                        switch (tasto)
                        {
                            case ConsoleKey.R:
                                foreground = ConsoleColor.Red;
                                break;
                            case ConsoleKey.G:
                                foreground = ConsoleColor.Green;
                                break;
                            case ConsoleKey.B:
                                foreground = ConsoleColor.Blue;
                                break;
                            default:
                                foreground = ConsoleColor.White;
                                break;
                        }
                        continue;
                    // Nessun tasto valido premuto
                    default:
                        continue;
                }
                // Controllo se mi muovo in verticale e nel caso x-- così da non andare in diagonale
                if (Console.CursorTop != posizione.Y)
                {
                    if (Console.CursorLeft > 0)
                    {
                        Console.CursorLeft--;
                    }
                }
                // Se ins è inserito vado avanti di uno
                if (ins)
                {
                    Console.CursorLeft++;
                }
                // Se canc è inserito scrivo uno spazio di colore nero
                else if (canc)
                {
                    schermo[Console.CursorTop, Console.CursorLeft].pennello = '\0';
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(' ');
                }
                // Se nessuno è inserito scrivo pennello con background e foreground
                else
                {
                    // Salvo i dati del pixel nella matrice
                    schermo[Console.CursorTop, Console.CursorLeft].background = background;
                    schermo[Console.CursorTop, Console.CursorLeft].foreground = foreground;
                    schermo[Console.CursorTop, Console.CursorLeft].pennello = pennello;
                    Console.Write(pennello);
                    posizione.Y = Console.CursorTop;
                    // Se ci si sposta dal primo pixel, coloro anche quello
                    if (posizione.X == 0)
                    {
                        posizione.X = Console.CursorLeft;
                        schermo[0, 0].pennello = pennello;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(pennello);
                        continue;
                    }
                    posizione.X = Console.CursorLeft;
                    continue;
                }
                posizione.Y = Console.CursorTop;
                posizione.X = Console.CursorLeft;
            } while (!esci);
        }
    }
}