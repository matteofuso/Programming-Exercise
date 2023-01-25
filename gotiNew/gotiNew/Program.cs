using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gotiNew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tana dei Goti Update
            /*
                Per effettuare un lancio pubblicitario, un
                commerciante di vino avvia una campagna
                pubblicitaria di vendita di Barbera in
                bottiglioni in cui propone uno sconto per
                acquisti superiori ai 45 litri.
                Progettare e codificare un programma che
                consenta di stabilire il totale che ogni
                cliente deve pagare.

                Più tipi di vino:
                - Barbera (1.5L, 2 E/L)
                - Lugana (1.5L, 10 E/L)
                - Merlotte (1.5L 4 E/L)
                - Soave (1.5L, 6 E/L)
            */
            const int costoConsegna = 3, costoBarbera = 2, costoLugana = 10, costoMerlotte = 4, costoSoave = 6;
            const double capacità = 1.5, sconto = 0.10, sogliaSconto = 45 / capacità;
            int bottiglieBarbera = 0, bottiglieLugana = 0, bottiglieMerlotte = 0, bottiglieSoave = 0;
            string input, vino;
            int bottiglie, bottiglieTot = 0, costoL = 0;
            double prezzoSingolo, scontoTotale = 0, prezzoTotale = 0, litri;
            do
            {
                // Messaggio di Benvenuto e lista dei vini
                Console.WriteLine("Benvenuto alla Tana dei Goti.");
                Console.WriteLine("Ecco Il nostro menù: ");
                Console.WriteLine("- Barbera ({0}L, {1} E/L)", capacità, costoBarbera);
                Console.WriteLine("- Lugana ({0}L, {1} E/L)", capacità, costoLugana);
                Console.WriteLine("- Merlotte ({0}L, {1} E/L)", capacità, costoMerlotte);
                Console.WriteLine("- Soave ({0}L, {1} E/L)", capacità, costoSoave);
                // Scelta del vino
                do
                {
                    Console.Write("Inserisci il nome del vino da acquistare: ");
                    vino = Console.ReadLine().ToUpper();
                } while (vino != "BARBERA" && vino != "LUGANA" && vino != "MERLOTTE" && vino != "SOAVE");
                // Scelta della quantità
                do
                {
                    Console.Write("Inserici il numero di bottiglioni di {0} da acquistare: ", vino);
                    bottiglie = Convert.ToInt32(Console.ReadLine());
                } while (bottiglie <= 0);
                // Assegno delle proprietà e oggiorno il numero di bottiglie totali
                bottiglieTot += bottiglie;
                switch (vino)
                {
                    case ("BARBERA"):
                        bottiglieBarbera += bottiglie;
                        costoL = costoBarbera;
                        break;
                    case ("LUGANA"):
                        bottiglieLugana += bottiglie;
                        costoL = costoLugana;
                        break;
                    case ("MERLOTTE"):
                        bottiglieMerlotte += bottiglie;
                        costoL = costoMerlotte;
                        break;
                    case ("SOAVE"):
                        bottiglieSoave += bottiglie;
                        costoL = costoSoave;
                        break;
                }
                // Calcolo dati per lo scontrino parizle e lo emetto
                litri = bottiglie * capacità;
                prezzoSingolo = litri * costoL;
                Console.WriteLine();
                Console.WriteLine("                     Tana dei Goti                    ");
                Console.WriteLine(" Dettaglio     Bottiglie         Litri        Importo ");
                Console.WriteLine(" {0, 8} {1,14} {2,13:n2} {3,13:n2}E ", vino, bottiglie, litri, prezzoSingolo);
                Console.WriteLine("                          --                          ");
                prezzoTotale += prezzoSingolo;
                Console.WriteLine(" Importo Parziale: {0,33:n2}E ", prezzoTotale);
                Console.WriteLine();
                // Chiedo se vuole altro vino
                do
                {
                    Console.Write("Vuoi un altro vino? (Si/No): ");
                    input = Console.ReadLine().ToUpper();
                } while (input != "SI" && input != "NO");
                Console.WriteLine();
            } while (input == "SI");
            // Chiedo se vuole la consegna
            do
            {
                Console.Write("Vuoi la consegna? (Si/No): ");
                input = Console.ReadLine().ToUpper();
            } while (input != "SI" && input != "NO");
            // Stampo lo scontrino finale
            Console.WriteLine("                     Tana dei Goti                    ");
            Console.WriteLine(" Dettaglio     Bottiglie         Litri        Importo ");
            if (bottiglieBarbera != 0)
            {
                litri = bottiglieBarbera * capacità;
                Console.WriteLine(" Barbera {0,15} {1,13:n2} {2,13:n2}E ", bottiglieBarbera, litri, litri * costoBarbera);
            }
            if (bottiglieLugana != 0)
            {
                litri = bottiglieLugana * capacità;
                Console.WriteLine(" Lugana {0,16} {1,13:n2} {2,13:n2}E ", bottiglieLugana, litri, litri * costoLugana);
            }
            if (bottiglieMerlotte != 0)
            {
                litri = bottiglieMerlotte * capacità;
                Console.WriteLine(" Merlotte {0,14} {1,13:n2} {2,13:n2}E ", bottiglieMerlotte, litri, litri * costoMerlotte);
            }
            if (bottiglieSoave != 0)
            {
                litri = bottiglieSoave * capacità;
                Console.WriteLine(" Soave {0,17} {1,13:n2} {2,13:n2}E ", bottiglieSoave, litri, litri * costoSoave);
            }
            if (bottiglieTot > sogliaSconto)
            {
                scontoTotale = prezzoTotale * sconto;
                prezzoTotale = prezzoTotale - scontoTotale;
                Console.WriteLine(" Sconto 10% {0,40:n2}E ", scontoTotale);
            }
            Console.WriteLine("                          --                          ");
            if (input == "SI")
            {
                Console.WriteLine(" Totale parziale: {0,34:n2}E ", prezzoTotale);
                prezzoTotale += costoConsegna;
                Console.WriteLine(" Spese di trasporto: {0,31:n2}E ", costoConsegna);
                Console.WriteLine("                          --                          ");
            }
            Console.WriteLine(" Importo Totale: {0,35:n2}E ", prezzoTotale);
            Console.WriteLine("                      Arrivederci                     ");
            Console.ReadLine();
        }
    }
}