using System;

namespace Volume_del_Cilindro
{
    internal class Volume
    {
        static void Main(string[] args)
        {
            // Uso delle variabili double così posso ammettere anche numeri con la virgola
            double raggio, altezza, volume;
            // Chiedo l'inserimeto del dato finchè non è accettabile (>0)
            do
            {
                // Uso un Console.Write() così da mettere l'input nella stessa riga
                Console.Write("Inserisci il raggio del cinlindro: ");
                raggio = Convert.ToDouble(Console.ReadLine()); // Uso Convert.ToDouble() per convertire l'input (String) a double (Numero con la virgola)
            } while (raggio <= 0);
            do
            {
                Console.Write("Inserisci l'altezza del cinlindro: ");
                altezza = Convert.ToDouble(Console.ReadLine());
            } while (altezza <= 0);
            // Uso la classe Math per importare il valore PI
            volume = Math.PI * raggio * raggio * altezza;
            Console.WriteLine("\nIl volume del cilindro è di {0} cm^3\n", volume); // Uso \n per andare a capo senza usare un Console.WriteLine() vuoto
            Console.Write("Premi un tasto per uscire.");
            Console.ReadKey(); // Uso Console.ReadKey() così esce al premere di qualsiasi tasto 
        }
    }
}