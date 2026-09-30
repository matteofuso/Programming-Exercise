using System;
using System.Threading;

namespace lancioDado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inizializzazione variabili
            int num, faccia = 1, sleep, centerX = Console.WindowWidth / 2 - 9, centerY = Console.WindowHeight / 2;
            char pallino;
            string zero, unoPrima, unoCentro, unoDopo, due;
            // Chide il numero finche è accettabile
            Console.Write("Inserisci il numero che vuoi visualizzare: ");
            num = Convert.ToInt32(Console.ReadLine());
            while (num < 1 || num > 6)
            {
                Console.Write("Inserisci un numero valido (1-6): ");
                num = Convert.ToInt32(Console.ReadLine());
            }
            // Scrivo solo il numero richiesto per evitare che scritte si sovrascivano
            Console.Clear();
            Console.Write("Stai per visualizzare il numero: {0}", num);
            // Personalizzazione proprietà del dado
            Console.BackgroundColor = ConsoleColor.White; // Colore dado
            Console.ForegroundColor = ConsoleColor.Black; // Colore pallino
            sleep = 1000; // Tempo tra cambio facce (ms)
            pallino = 'O'; // Carattere del pallino
            zero = "                   "; // Parte della faccia senza pallini
            unoPrima = "    " + pallino + "              "; // Parte della faccia con un pallino all'inizio
            unoCentro = "         " + pallino + "         "; // Parte della faccia con un pallino al centro
            unoDopo = "              " + pallino + "    "; // Parte della faccia con un pallino alla fine
            due = "    " + pallino + "         " + pallino + "    "; // Parte della faccia con due pallini
            // Scrivo le parti del dado che non devono essere cambiate
            Console.SetCursorPosition(centerX, centerY - 3);
            Console.WriteLine(zero);
            Console.SetCursorPosition(centerX, centerY - 1);
            Console.WriteLine(zero);
            Console.SetCursorPosition(centerX, centerY + 1);
            Console.WriteLine(zero);
            Console.SetCursorPosition(centerX, centerY + 3);
            Console.WriteLine(zero);
            // Scrivo le parti del dado variabili ( i = index del ciclo; faccia = faccia mostrata )
            for (int i = 1; i < 8; i++)
            {
                // Allineamento iniziale
                Console.SetCursorPosition(centerX, centerY - 2);
                // Costruttore facce
                if (faccia == 1)
                {
                    Console.WriteLine(zero);
                    Console.SetCursorPosition(centerX, centerY);
                    Console.WriteLine(unoCentro);
                    Console.SetCursorPosition(centerX, centerY + 2);
                    Console.WriteLine(zero);
                }
                else if (faccia == 2)
                {
                    Console.WriteLine(unoDopo);
                    Console.SetCursorPosition(centerX, centerY);
                    Console.WriteLine(zero);
                    Console.SetCursorPosition(centerX, centerY + 2);
                    Console.WriteLine(unoPrima);
                }
                else if (faccia == 3)
                {
                    Console.WriteLine(unoDopo);
                    Console.SetCursorPosition(centerX, centerY);
                    Console.WriteLine(unoCentro);
                    Console.SetCursorPosition(centerX, centerY + 2);
                    Console.WriteLine(unoPrima);
                }
                else if (faccia == 4)
                {
                    Console.WriteLine(due);
                    Console.SetCursorPosition(centerX, centerY);
                    Console.WriteLine(zero);
                    Console.SetCursorPosition(centerX, centerY + 2);
                    Console.WriteLine(due);
                }
                else if (faccia == 5)
                {
                    Console.WriteLine(due);
                    Console.SetCursorPosition(centerX, centerY);
                    Console.WriteLine(unoCentro);
                    Console.SetCursorPosition(centerX, centerY + 2);
                    Console.WriteLine(due);
                }
                else
                {
                    Console.WriteLine(due);
                    Console.SetCursorPosition(centerX, centerY);
                    Console.WriteLine(due);
                    Console.SetCursorPosition(centerX, centerY + 2);
                    Console.WriteLine(due);
                    faccia = num - 1;
                }
                faccia++;
                Thread.Sleep(sleep);
            }
            Console.ReadLine();
        }
    }
}