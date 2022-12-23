using System;

namespace Eta
{
    class Program
    {
        static void Main(string[] args)
        {
            byte eta;
            Console.Write("Inserisci la tua età: ");
            eta = Convert.ToByte(Console.ReadLine());
            if (eta >= 18)
            {
                Console.Write("Sei maggiorenne!");
            }
            else
            {
                if (eta >= 14)
                {
                    Console.WriteLine("Sei alle superiori");
                }
                else
                {
                    Console.WriteLine("Sei alle medie");
                }
            }
            Console.WriteLine("Programma finito. Premi invio per continuare...");
            Console.ReadLine();
        }
    }
}
