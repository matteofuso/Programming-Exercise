using System;

namespace positivi
{
    internal class Positivo
    {
        static void Main(string[] args)
        {
            int numero;
            Console.Write("Inserisci un numero: ");
            numero = Convert.ToInt32(Console.ReadLine());
            if (numero > 0)
            {
                Console.WriteLine("Il numero è positivo");
            } else
            {
                Console.WriteLine("Il numero è negativo");
            }
            Console.ReadLine();
        }
    }
}
