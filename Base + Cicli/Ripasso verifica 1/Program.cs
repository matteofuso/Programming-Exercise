using System;

namespace Ripasso_verifica_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Scrivere un programma per
                disegnare a video un rettangolo con base e altezza scelte dall’utente; il
                programma deve verificare che le dimensioni inserite siano maggiori o uguali a
                3 e minori di 30. Il programma deve chiedere all’utente se desidera disegnare
                un altro rettangolo oppure se vuole terminare (con S il programma chiede di
                inserire i dati per il nuovo rettangolo da disegnare, con N il programma termina
                scrivendo a video “disegno finito”.
            */
            // Dichiarazione variabili e inizializzazione
            int baseRettangolo, altezza;
            string input;
            do
            {
                // Cancello tutto per quando si rientra nel ciclo
                Console.Clear();
                // Inizializzo la base a zero perchè la userò dopo per controllare se è un quadrato
                baseRettangolo = 0;
                do
                {
                    // Controllo se è un quadrato
                    if (baseRettangolo != 0)
                    {
                        Console.WriteLine("Quello che hai inserito è un quadrato. Reinserisci i lati");
                    }
                    // Chiedo il valore della base finchè non è accettabile
                    Console.Write("Inserisci il valore della base (maggiore o uguale a 3 e minori di 30): ");
                    baseRettangolo = Convert.ToInt32(Console.ReadLine());
                    while (baseRettangolo < 3 || baseRettangolo >= 30)
                    {
                        Console.Write("Numero non valido, reinserisci: ");
                        baseRettangolo = Convert.ToInt32(Console.ReadLine());
                    }
                    // Chiedo il valore dell'altezza finchè non è accettabile
                    Console.Write("Inserisci il valore dell'altezza (maggiore o uguale a 3 e minori di 30): ");
                    altezza = Convert.ToInt32(Console.ReadLine());
                    while (altezza < 3 || altezza >= 30)
                    {
                        Console.Write("Numero non valido, reinserisci: ");
                        altezza = Convert.ToInt32(Console.ReadLine());
                    }
                } while (baseRettangolo == altezza);
                // Rimuovo 2 all'altezza perchè compresi tra le due basi
                altezza -= 2;
                // Stampo la base alta
                for (int i = 0; i < baseRettangolo; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                // Stampo i lati
                for (int i = 0; i < altezza; i++)
                {
                    Console.CursorLeft = 0;
                    Console.Write("*");
                    Console.CursorLeft = baseRettangolo - 1;
                    Console.WriteLine("*");
                }
                // Stampo la base bassa
                for (int i = 0; i < baseRettangolo; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                // Chiedo se vuole ripetere il ciclo
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