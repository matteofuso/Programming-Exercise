using System;

namespace Cifre
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] counter = new int[10];
            Random random = new Random();
            int valore;
            // Estraggo e scrivo i numeri
            Console.Write("Sono usciti i numeri: ");
            for (int i = 0; i < counter.Length; i++)
            {
                valore = random.Next(0, 10);
                // Uso un array che contiene quante volte è uscito un numero
                counter[valore]++;
                // Stampo il numero solo se non è mai uscito
                if (counter[valore] == 1)
                {
                    Console.Write("{0} ", valore);
                }
            }
            Console.WriteLine();
            // Stampo i numeri non usciti
            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] == 0)
                {
                    Console.WriteLine("Non è uscito il numero {0}", i);
                }
            }
            Console.ReadLine();
        }
    }
}