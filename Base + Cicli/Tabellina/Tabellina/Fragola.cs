using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabellina
{
    internal class Fragola
    {
        static void Main(string[] args)
        {
            float num;
            Console.Write("Inserisci il numero per vedere la tabellina: ");
            num = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("{0,-5}", num * i);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
