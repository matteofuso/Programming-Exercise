using System;

namespace LaScuolaElementare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxOpzione = 4, massimoClasse = 5;
            int scelta, alunni = 0, posizione;
            string[] classe = new string[massimoClasse];
            string nome;
            do
            {
                // Chiedo l'opzione che si intende scegliere
                Console.WriteLine("---- Registro di Classe ----");
                Console.WriteLine("1. Inserisci un nuovo alunno");
                Console.WriteLine("2. Stampa registro");
                Console.WriteLine("3. Ricerca di un alunno");
                Console.WriteLine($"{maxOpzione}. Esci");
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
                    case (1):
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
                    case (2):
                        // Stampa elenco
                        Console.WriteLine("Ecco l'elenco della classe:");
                        for (int i = 0; i < classe.Length; i++)
                        {
                            Console.WriteLine("{0}. {1}", i + 1, classe[i]);
                        }
                        break;
                    case (3):
                        // Ricerca di un alunno
                        Console.WriteLine("Inserisci il nome dell'alunno: ");
                        Console.Write("> ");
                        nome = Console.ReadLine();
                        posizione = -1;
                        for (int i = 0; i < classe.Length; i++)
                        {
                            if (nome == classe[i])
                            {
                                posizione = i + 1;
                                break;
                            }
                        }
                        // Controllo se il contatore della posizione è stato modificato
                        if (posizione != -1)
                        {
                            Console.WriteLine("L'alunno è stato trovato in posizione {0}", posizione);
                        }
                        else
                        {
                            Console.WriteLine("L'alunno non è presente nell'elenco.");
                        }
                        break;
                }
            } while (scelta != maxOpzione);
            Console.ReadLine();
        }
    }
}