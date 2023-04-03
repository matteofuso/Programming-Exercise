using System;

namespace LottoRuotaDiVenezia
{
    class Program
    {
        enum Vincite
        {
            estratto,
            ambo,
            terno,
            quaterna,
            cinquina
        }
        static void Main(string[] args)
        {
            /* 
                PT 1.
                    Realizzare un programma che permetta di generare le stazioni del lotto sulla ruota di Venezia.
                    Nel gioco del lotto si estraggono 5 numeri casuali compresi nel range 1-90. 
                    Risolvere l'esercizio utilizzando i vettori considerando che i numeri estratti possono
                    comparire sulla ruota una sola volta
                PT 2.
                    Se indovinate:
                    - un numero (estratto), 11 volte la posta
                    - due numeri (ambo), 250 volte la posta
                    - tre numeri (terno), 4500 volte la posta
                    - quattro numeri (quaterna) 120k volte la posta
                    - cinque numeri (cinquina) 6M di volte la posta
            */

            // Inizializzazione e inizializzazione variabili
            int[] moltiplicatori = { 0, 11, 250, 4500, 120000, 6000000 };
            const int estrazioni = 5, min = 1, max = 91;
            int i, j, temp, trovati = 0, posta;
            int[] estratti = new int[estrazioni];
            int[] giocati = new int[estrazioni];
            Random random = new Random();
            bool esci;
            // Genero i numeri del lotto
            Console.WriteLine("Lotto di Venezia. Numeri estratti:");
            for (i = 0; i < estratti.Length; i++)
            {
                do
                {
                    estratti[i] = random.Next(min, max);
                    // Controllo se è presente, altrimenti lo rigenero
                    esci = false;
                    for (j = 0; j < i && !esci; j++)
                    {
                        esci = estratti[i] == estratti[j];
                    }
                } while (esci);
            }
            // Sort
            esci = false;
            for (i = 1; i < estratti.Length && !esci; i++)
            {
                esci = true;
                for (j = 0; j < estratti.Length - i; j++)
                {
                    if (estratti[j] > estratti[j + 1])
                    {
                        esci = false;
                        temp = estratti[j];
                        estratti[j] = estratti[j + 1];
                        estratti[j + 1] = temp;
                    }
                }
            }
            // Chiedo quanto punta l'utente
            Console.Write("Inserisci la posta: ");
            while (!int.TryParse(Console.ReadLine(), out posta))
            {
                Console.Write("Inserisci un numero intero: ");
            }
            // Chiedo 5 numeri all'utente
            for (i = 0; i < giocati.Length; i++)
            {
                do
                {
                    Console.Write("Inserisci il numero {0} (Tra 1 e 90 compresi): ", i + 1);
                    while (!int.TryParse(Console.ReadLine(), out giocati[i]))
                    {
                        Console.Write("Inserisci un numero intero: ");
                    }
                    esci = giocati[i] < min || giocati[i] >= max;
                    for (j = 0; j < i && !esci; j++)
                    {
                        esci = giocati[i] == giocati[j];
                    }
                } while (esci);
            }
            // Sort
            esci = false;
            for (i = 1; i < giocati.Length && !esci; i++)
            {
                esci = true;
                for (j = 0; j < giocati.Length - i; j++)
                {
                    if (giocati[j] > giocati[j + 1])
                    {
                        esci = false;
                        temp = giocati[j];
                        giocati[j] = giocati[j + 1];
                        giocati[j + 1] = temp;
                    }
                }
            }
            // Stampo i numeri generati
            Console.WriteLine();
            Console.WriteLine("Numeri estratti:");
            foreach (int n in estratti)
            {
                Console.WriteLine(n);
            }
            // Stampo i numeri giocati
            Console.WriteLine();
            Console.WriteLine("Numeri giocati:");
            foreach (int n in giocati)
            {
                Console.WriteLine(n);
            }
            // Controllo la vincita
            for (i = 0; i < estratti.Length; i++)
            {
                esci = false;
                for (j = 0; j < giocati.Length && !esci; j++)
                {
                    if (estratti[i] == giocati[j])
                    {
                        trovati++;
                        esci = true;
                    }
                }
            }
            // Stampo il tipo di vincita e i soldi guadagnati
            Console.WriteLine();
            if (trovati == 0)
            {
                Console.WriteLine("Hai perso {0}E che hai puntato.", posta);
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