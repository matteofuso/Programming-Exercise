using System;

namespace Conversione
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Autore: Matteo Fuso
            Descrizione: Convertitore Euro-Dollaro/Lire
            Release: 1.0.0
            */

            // Tassi di Cambio
            const double EUROLIRE = 1936.27, EURODOLLARI = 1.0282687;
            // Dichiarazione Variabili
            double euro;
            // Input dei dati
            Console.Write("Inserisci il saldo in euro: ");
            euro = Convert.ToDouble(Console.ReadLine());
            // Conversione Euro/Lire
            //lire = euro * EUROLIRE;
            // Conversione Euro/Dollari
            //dollari = euro * EURODOLLARI;
            Console.WriteLine($"\nIl tuo saldo:\n-{(euro).ToString("n2")} euro\n-{(euro * EURODOLLARI):####.##} dollari\n-{(euro * EUROLIRE):000000.00} lire");
            Console.WriteLine("\nIl tuo saldo:\n-{0} euro\n-{1:n2} dollari\n-{2:####.##} lire", euro, euro * EURODOLLARI, euro * EUROLIRE);
            
            Console.WriteLine("Premi invio per continuare");
            Console.ReadLine();
        }
    }
}