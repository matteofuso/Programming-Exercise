using System.Timers;
using System;

namespace Tmier
{
    internal class Program
    {
        static int counter = 0;
        static Timer myTimer = new Timer();
        static void Main(string[] args)
        {
            myTimer.Elapsed += new ElapsedEventHandler((source, e) => counter++);
            myTimer.Interval = 100;
            Console.Write("Premi \"Enter\" per avviare il timer . . .");
            WaitForEnter();
            Console.WriteLine();
            myTimer.Enabled = true;
            Console.Write("Premi \"Enter\" per terminare il timer . . .");
            WaitForEnter();
            Console.WriteLine();
            Console.WriteLine("Tempo trascorso {0} secondi", counter/10.0);
            Console.WriteLine();
            Console.Write("Premi invio per uscire . . .");
            Console.ReadKey();
        }
        static void WaitForEnter()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Enter);
        }
    }
}
