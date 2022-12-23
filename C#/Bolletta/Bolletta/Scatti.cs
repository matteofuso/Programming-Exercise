using System;

namespace Bolletta
{
    internal class Scatti
    {
        static void Main(string[] args)
        {
            double scattiBollettaPrecedente, scatti, bollettaPrecedente, bolletta;
            const double canone = 20, costoScatti = 0.10;
            Console.Write("Leggi il numero di scatti della bolletta precedente: ");
            scattiBollettaPrecedente = Convert.ToDouble(Console.ReadLine());
            Console.Write("Leggi il numero di scatti del primo giorno del trimestre: ");
            scatti = Convert.ToDouble(Console.ReadLine());
            Console.Write("Leggi il numero di scatti dell'ultimo giorno del trimestre: ");
            scatti = Convert.ToDouble(Console.ReadLine()) - scatti;
            bollettaPrecedente = scattiBollettaPrecedente * costoScatti + canone;
            bolletta = scatti * costoScatti + canone;
            Console.WriteLine("\nLo scorso trimestre con {0} scatti, hai pagato {1:n2} Euro", scattiBollettaPrecedente, bollettaPrecedente);
            Console.WriteLine("Questo trimestre con {0} scatti, hai pagato {1:n2} Euro", scatti, bolletta);
            Console.WriteLine("Hai pagato {0:n2} Euro in più della scorsa bolletta", bollettaPrecedente - bolletta);
            Console.ReadLine();
        }
    }
}