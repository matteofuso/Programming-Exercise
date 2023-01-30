using System;

namespace Ripasso_Verifica
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Scrivere un programma in C# per
                visualizzare in ordine decrescente i numeri divisibili per 5 partendo da un
                numero inserito dall’utente che deve essere maggiore di 5 e minore o uguale a 200;
                se l’utente inserisce un numero al di fuori di questo intervallo, il programma
                deve chiedere nuovamente il numero. Al termine della visualizzazione il programma
                deve chiedere all’utente se vuole inserire un nuovo numero o se il programma
                deve terminare. Con risposta SI il programma chiede un nuovo numero con
                risposta NO il programma termina (SI e NO possono essere scritti in maiuscolo,
                minuscolo, o misto; il programma deve capire comunque)
            */
            // Dichiarazione e inizializzazione variabili
            string input;
            int numero;
            const int divisore = 5;
            // Do per chiedere di rifare il programma
            do
            {
                // Chiedo di inserire il numero e vedo finchè non è accettabile
                Console.Write("Inserisci il numero (maggiore di 5 e minore o uguale a 200): ");
                numero = Convert.ToInt32(Console.ReadLine());
                while (numero <= 5 || numero > 200)
                {
                    Console.Write("Inserisci un numero valido: ");
                    numero = Convert.ToInt32(Console.ReadLine());
                }
                // Tolgo il resto per ottenere il primo divisore
                numero -= (numero % divisore);
                // Stampo la serie, per ottenere il prossimo numero basta rimuovere il divisore
                Console.Write(numero);
                while (numero > divisore)
                {
                    numero -= divisore;
                    Console.Write(" - {0}", numero);
                }
                Console.WriteLine();
                // Chiedo se vuole ripetere il ciclo finchè non risponde un valore accettabile
                Console.Write("Vuoi ripetere il ciclo? ");
                input = Console.ReadLine().ToUpper();
                while (input != "SI" && input != "NO" && input != "")
                {
                    Console.WriteLine("Valore errato, riprova: ");
                    input = Console.ReadLine().ToUpper();
                }
            } while (input == "SI" || input == "");
            Console.ReadLine();
        }
    }
}