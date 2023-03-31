using System;

namespace FioreriaRossi
{
    class Program
    {
        enum Tipo
        {
            Rosa,
            Margherita,
            Ciclamino,
            Gerbero
        }
        struct Fiore
        {
            public double prezzo;
            public Tipo tipo;
        }
        static void Main(string[] args)
        {
            int scelta;
            Fiore[] fiori;
            Console.Write("Inserisci quanti fiori vuoi mettere: ");
            fiori = new Fiore[Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < fiori.Length; i++)
            {
                Console.Clear();
                Console.WriteLine("Sclete:");
                Console.WriteLine("0. Rose");
                Console.WriteLine("1. Margherite");
                Console.WriteLine("2. Ciclamini");
                Console.WriteLine("3. Gerbere");
                Console.WriteLine();
                do
                {
                    Console.Write("Inserisci il tipo del {0}° fiore: ", i + 1);
                    scelta = Convert.ToInt32(Console.ReadLine());
                } while (scelta < 0 || scelta > 3);
                fiori[i].tipo = (Tipo)scelta;
                do
                {
                    Console.Write("Inserisci il prezzo di {0}: ", (Tipo)scelta);
                    fiori[i].prezzo = Convert.ToDouble(Console.ReadLine());
                } while (fiori[i].prezzo < 0);
            }
            foreach(Fiore fiore in fiori)
            {
                Console.WriteLine("Hai inserito un {0} al prezzo di {1}E. Questo elemento è alla posizione {2}", fiore.tipo, fiore.prezzo, Convert.ToInt32(fiore.tipo));
            }
            Console.ReadLine();
        }
    }
}