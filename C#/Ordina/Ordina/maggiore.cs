using System;

namespace Ordina
{
    internal class maggiore
    {
        static void Main(string[] args)
        {
            int num1, num2, tempo;
            Console.Write("Inserisci il primo numero: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inserisci il secondo numero: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 < num2)
            {
                tempo = num1;
                num1 = num2;
                num2 = tempo;
            }
            Console.WriteLine("Il maggiore è {0} ed il minore è {1}", num1, num2);
            Console.ReadLine();
        }
    }
}
