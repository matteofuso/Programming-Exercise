using System;

namespace divisibile
{
    class check
    {
        static void Main(string[] args)
        {
            int numero;
            const byte divisore = 5;
            Console.Write("Inserisci un numero per vedere se è divisibile per {0}: ", divisore);
            numero = Convert.ToInt32(Console.ReadLine());
            if (numero%divisore == 0)
            {
                Console.WriteLine("{0} è divisibile per {1}", numero, divisore);
            }
            Console.Write("Programma finito, premi invio per continuare...");
            Console.ReadLine();
        }
    }
}