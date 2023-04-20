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
            Nazionale,
            Giocato
        }
        enum Vincite
        {
            ambata,
            ambo,
            terno,
            quaterna,
            cinquina
        }
        static void Main(string[] args)
        {
            int[] moltiplicatori = { 0, 2, 5, 10, 20, 50 };
            const int min = 1, max = 91, numeri = 5;
            int[,] ruote = new int[(int)Ruote.Giocato + 1, numeri];
            int i, j, k, l, r = 0, trovati = 0, temp;
            Random random = new Random();
            float posta = 0;
            bool esci;
            for (i = 0; i < ruote.GetLength(0); i++)
            {
                if (i != ruote.GetLength(0) - 1)
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
                }
                else
                {
                    // Chiedo la ruota su cui si vuole giocare
                    Console.WriteLine("Lista delle ruote disponibili:");
                    for (j = 0; j <= (int)Ruote.Nazionale; j++)
                    {
                        Console.WriteLine("{0} - {1}", j, (Ruote)j);
                    }
                    do
                    {
                        Console.Write("Inserisci la ruota su cui vuoi giocare: ");
                        while (!int.TryParse(Console.ReadLine(), out r))
                        {
                            Console.Write("Inserisci un numero intero: ");
                        }
                    } while (r < 0 || r > (int)Ruote.Nazionale);
                    // Chiedo quanto punta
                    Console.Write("Inserisci quanto punti: ");
                    while (!float.TryParse(Console.ReadLine(), out posta))
                    {
                        Console.Write("Inserisci un numero: ");
                    }
                    // Chiedo i numeri giocati
                    Console.WriteLine();
                    for (j = 0; j < ruote.GetLength(1); j++)
                    {
                        do
                        {
                            Console.Write("Inserisci il numero {0} (Tra 1 e 90 compresi): ", j + 1);
                            while (!int.TryParse(Console.ReadLine(), out ruote[i, j]))
                            {
                                Console.Write("Inserisci un numero intero: ");
                            }
                            esci = ruote[i, j] < min || ruote[i, j] >= max;
                            for (k = 0; k < j && !esci; k++)
                            {
                                esci = ruote[i, j] == ruote[i, k];
                            }
                        } while (esci);
                    }
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
                            temp = ruote[i, j];
                            ruote[i, j] = ruote[i, j + 1];
                            ruote[i, j + 1] = temp;
                            esci = false;
                        }
                    }
                }
            }
            // Stampa Ruote
            Console.WriteLine();
            Console.WriteLine("Ruote estratte e giocata:");
            for (i = 0; i < ruote.GetLength(0); i++)
            {
                Console.Write("{0,-9} : ", (Ruote)i);
                for (j = 0; j < ruote.GetLength(1); j++)
                {
                    Console.Write(" {0,2}", ruote[i, j]);
                }
                Console.WriteLine();
            }
            // Controllo vincita
            for (i = 0; i < ruote.GetLength(1); i++)
            {
                // Devo controllare r e (int)Ruote.Giocata
                for (j = 0; j < ruote.GetLength(1); j++)
                {
                    if (ruote[r, i] == ruote[ruote.GetLength(0) - 1, j])
                    {
                        trovati++;
                    }
                }
            }
            // Stampo il tipo di vincita e i soldi guadagnati
            Console.WriteLine();
            if (trovati == 0)
            {
                Console.WriteLine("Hai perso");
            }
            else
            {
                Console.WriteLine("Hai fatto {0} quindi hai vinto {1:N}E.", (Vincite)(trovati - 1), posta * moltiplicatori[trovati]);
            }
            Console.WriteLine();
            Console.Write("Premi un tasto per uscire . . .");
            Console.ReadKey();
        }
    }
}