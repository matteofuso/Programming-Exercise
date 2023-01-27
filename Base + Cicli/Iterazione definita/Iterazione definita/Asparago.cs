using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterazione_definita
{
    internal class Asparago
    {
        static void Main(string[] args)
        {
            int num, somma = 0;
            Console.Write("Inserisci il numero massimo: ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num < 0)
            {
                num = -num;
            }
            for (int i = num; i != 0; i--)
            {
                somma = somma + i;
            }
            Console.WriteLine("La somma dei numeri precedenti è: {0}", somma);
            Console.ReadLine();
        }
    }
}
