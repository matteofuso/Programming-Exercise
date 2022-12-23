using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversione
{
    internal class Conto
    {
        static void Main(string[] args)
        {
            const double EURODOLLARO = 1.0282687, EUROLIRE = 1936.27;
            double euro, dollari, lire;
            Console.Write("Inserisci il saldo del conto corrente in euro: ");
            euro = Convert.ToDouble(Console.ReadLine());
            dollari = euro * EURODOLLARO;
            lire = euro * EUROLIRE;
            Console.WriteLine($"Il tuo conto di {euro} euro corrisponde a {dollari} dollari e {lire} lire");
            Console.ReadLine();
        }
    }
}
