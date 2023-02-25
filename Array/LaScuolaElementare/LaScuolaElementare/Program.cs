using System;

namespace LaScuolaElementare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxOpzione = 7, massimoClasse = 3;
            int scelta;
            // Indici per gli array
            int posizione = 0, alunni = 0, alunniGita = 0;
            string[] classe = new string[massimoClasse];
            string[] gita = new string[classe.Length];
            string input;
            do
            {
                // Chiedo l'opzione che si intende scegliere
                Console.WriteLine("---- Registro di Classe ----");
                Console.WriteLine("1. Inserisci un nuovo alunno");
                Console.WriteLine("2. Stampa registro");
                Console.WriteLine("3. Ricerca di un alunno");
                Console.WriteLine("4. Visualizza alunno");
                Console.WriteLine("5. Chi viene in gita");
                Console.WriteLine("6. Elenco gita");
                Console.WriteLine("{0}. Esci", maxOpzione);
                Console.WriteLine("Inserisci la scleta:");
                Console.Write("> ");
                scelta = Convert.ToInt32(Console.ReadLine());
                // Controllo che sia nel range
                while (scelta < 1 || scelta > maxOpzione)
                {
                    Console.WriteLine("Scelta non valida. Scegli un opzione dall'elenco: ");
                    Console.Write("> ");
                    scelta = Convert.ToInt32(Console.ReadLine());
                }
                switch (scelta)
                {
                    case maxOpzione:
                        // Esci dal programma
                        break;
                    case 1:
                        // Inserisci un nuovo alunno
                        // Controllo se la classe è al pieno
                        if (alunni < classe.Length)
                        {
                            Console.WriteLine("Inserisci il nome dell'alunno: ");
                            Console.Write("> ");
                            classe[alunni] = Console.ReadLine();
                            alunni++;
                        }
                        else
                        {
                            Console.WriteLine("La classe è al completo.");
                        }
                        break;
                    case 2:
                        // Stampa elenco
                        if (alunni != 0)
                        {
                            Console.WriteLine("Ecco l'elenco della classe:");
                            for (int i = 0; i < alunni; i++)
                            {
                                Console.WriteLine("{0}. {1}", i + 1, classe[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("La classe è vuota.");
                        }
                        break;
                    case 3:
                        // Ricerca di un alunno
                        if (alunni != 0)
                        {
                            Console.WriteLine("Inserisci il nome dell'alunno: ");
                            Console.Write("> ");
                            input = Console.ReadLine();
                            posizione = 0;
                            for (int i = 0; i < alunni; i++)
                            {
                                if (input == classe[i])
                                {
                                    posizione = i + 1;
                                }
                            }
                            // Controllo se il contatore della posizione è stato modificato
                            if (posizione != 0)
                            {
                                Console.WriteLine("L'alunno è stato trovato in posizione {0}", posizione);
                            }
                            else
                            {
                                Console.WriteLine("L'alunno non è presente nell'elenco.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("La classe è vuota.");
                        }
                        break;
                    case 4:
                        // Stampa il nome dell'ultimo alunno cercato
                        if (posizione != 0)
                        {
                            Console.WriteLine("{0}. {1}", posizione, classe[posizione - 1]);
                        }
                        else
                        {
                            Console.WriteLine("Non hai fatto ricerca alunno.");
                        }
                        break;
                    case 5:
                        // Chi viene in gita
                        // Svuoto l'array cancellando il contatore
                        if (alunni != 0)
                        {
                            alunniGita = 0;
                            for (int i = 0; i < alunni; i++)
                            {
                                Console.WriteLine("L'alunno {0} viene in gita? (Si/No)", classe[i]);
                                Console.Write("> ");
                                input = Console.ReadLine().ToLower();
                                while (input != "si" && input != "no")
                                {
                                    if (classe[i] == "")
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Non ho capito, reinserisci");
                                    Console.Write("> ");
                                    input = Console.ReadLine().ToLower();
                                }
                                if (input == "si")
                                {
                                    gita[alunniGita] = classe[i];
                                    alunniGita++;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("La classe è vuota.");
                        }
                        break;
                    case 6:
                        // Elenco gita
                        if (alunniGita != 0)
                        {
                            Console.WriteLine("Ecco l'elenco degli alunni che vengono in gita:");
                            for (int i = 0; i < alunniGita; i++)
                            {
                                Console.WriteLine("{0}. {1}", i + 1, gita[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nessuno viene in gita.");
                        }
                        break;
                }
                Console.WriteLine();
            } while (scelta != maxOpzione);
        }
    }
}