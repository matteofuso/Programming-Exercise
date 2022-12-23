using System;

namespace Chiamate
{
    class Bolletta
    {
        static void Main(string[] args)
        {
            int scatti, scattiBollettaPrecedente;
            float bollettaPrecedente, bolletta, costoScatti, canone, aumento;
            Console.Write("Inserisci il costo di ogni scatto: ");
            costoScatti = Convert.ToSingle(Console.ReadLine());
            Console.Write("Inserisci il costo del canone: ");
            canone = Convert.ToSingle(Console.ReadLine());
            Console.Write("Leggi il numero di scatti della bolletta precedente: ");
            scattiBollettaPrecedente = Convert.ToInt32(Console.ReadLine());
            Console.Write("Leggi il numero di scatti del primo giorno del trimestre: ");
            scatti = Convert.ToInt32(Console.ReadLine());
            Console.Write("Leggi il numero di scatti dell'ultimo giorno del trimestre: ");
            scatti = Convert.ToInt32(Console.ReadLine()) - scatti;
            bollettaPrecedente = scattiBollettaPrecedente * costoScatti + canone;
            bolletta = scatti * costoScatti + canone;
            Console.WriteLine("\nIl canone fisso è di {0} Euro ed il costo di ogni scatto è di {1:n2} Euro", canone, costoScatti);
            Console.WriteLine("Lo scorso trimestre con {0} scatti, hai pagato {1:0000.#0} Euro", scattiBollettaPrecedente, bollettaPrecedente);
            Console.WriteLine($"Questo trimestre con {scatti,10} scatti, hai pagato {(bolletta.ToString("n2")),-10} Euro");
            aumento = bolletta - bollettaPrecedente;
            if (aumento >= 0)
            {
                Console.WriteLine("Hai pagato {0:n2} Euro in più della scorsa bolletta", aumento);
            } else
            {
                Console.WriteLine("Hai pagato {0:n2} Euro in meno della scorsa bolletta", -aumento);
            }
            Console.Write("\nPremi un tasto per continuare");
            Console.ReadKey();
        }
    }
}