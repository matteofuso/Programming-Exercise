using System;

namespace ScuolaElementare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            string input;
            string[] nomi = new string[3];
            do
            {
                Console.WriteLine("Benvenuto nel programma di gestione della scuola elementare, seleziona l'opzione:");
                Console.WriteLine("1. Inserisci il nome di un alunno");
                Console.WriteLine("2. Esci");
                input = Console.ReadLine();
                while (input != "1" && input != "2")
                {
                    Console.WriteLine("Opzione non valida, riprova");
                    input = Console.ReadLine();
                }
                if (input == "1")
                {
                    if (size == nomi.Length)
                    {
                        Console.WriteLine("La classe è completa");
                    }
                    else
                    {
                        Console.WriteLine("Inserisci il nome dell'alunno");
                        nomi[size] = Console.ReadLine();
                        size++;
                    }
                }
            } while (input != "2");
            Console.ReadLine();
        }
    }
}