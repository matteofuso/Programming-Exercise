using System;

namespace Tabellone_Ruote
{
    internal class Program
    {
        enum Ruote
        {
            Bari,
            Cagliari,
            Firenze,
            Genova,
            Milano,
            Napoli,
            Palermo,
            Roma,
            Torino,
            Venezia,
            Nazionale
        }
        static void Main(string[] args)
        {
            int[,] ruote = new int[11, 5];
            const int min = 1, max = 91;
            int i, j, k, l, temp;
            Random random = new Random();
            bool esci;
            for (i = 0; i < ruote.GetLength(0); i++)
            {
                // Genero numeri della ruota
                for (j = 0; j < ruote.GetLength(1); j++)
                {
                    do
                    {
                        ruote[i, j] = random.Next(min, max);
                        esci = false;
                        for (k = 0; k < j && !esci; k++)
                        {
                            esci = ruote[i, j] == ruote[i, k];
                        }
                    } while (esci);
                }
                // Sort
                esci = false;
                for (l = 1; l < ruote.GetLength(1) && !esci; l++)
                {
                    esci = true;
                    for (j = 0; j < ruote.GetLength(1) - l; j++)
                    {
                        if (ruote[i, j] < ruote[i, j + 1])
                        {
                            esci = false;
                            temp = ruote[i, j];
                            ruote[i, j] = ruote[i, j + 1];
                            ruote[i, j + 1] = temp;
                        }
                    }
                }
                // Stampa Ruota
                Console.WriteLine("Ruota di {0}: ", (Ruote)i);
                for (j = 0; j < ruote.GetLength(1); j++)
                {
                    Console.Write("{0} ", ruote[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}