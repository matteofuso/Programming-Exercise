using System;

namespace maggiore
{
    internal class minore
    {
        static void Main(string[] args)
        {
            int num1, num2, maggiore, minore;
            Console.Write("Inserisci il primo numero: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inserisci il secondo numero: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 > num2)
            {
                maggiore = num1;
                minore = num2;
            }
            else
            {
                maggiore = num2;
                minore = num1;
            }
            Console.WriteLine("Il numero maggiore è {0} e quello minore è {1}", maggiore, minore);
            Console.ReadLine();
        }
    }
}