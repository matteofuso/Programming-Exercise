using System;
using System.Timers;

namespace LifeCATTO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Timer myTimer = new Timer();
            ConsoleKeyInfo key;
            int counter = 0;
            myTimer.Elapsed += new ElapsedEventHandler((source, e) =>
            {
                counter++;
                Azioni(counter);
            });
            myTimer.Interval = 10;
            myTimer.Enabled = true;
            Console.WriteLine("Premi \"Enter\" per uscire . . .");
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Enter);
            myTimer.Enabled = false;
            Console.WriteLine(counter / 10.0);
            Console.Write("Premi invio per uscire . . .");
            Console.ReadKey();
        }
        static void Azioni(int counter)
        {
            if (counter % 100 == 0)
            {
                Console.WriteLine("Il gattino mangia");
            }
            if (counter % 1000 == 0)
            {
                Console.WriteLine("Il gattino dorme");
            }
        }
    }
}
