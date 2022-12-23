using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sconti
{
    internal class Prezzo
    {
        static void Main(string[] args)
        {
            float sconto, spesa;
            Console.Write("Inserisci l'importo della spesa: ");
            spesa = Convert.ToSingle(Console.ReadLine());
            if (spesa > 80)
            {
                sconto = 0.1f;
            }
            else
            {
                if (spesa < 65)
                {
                    if (spesa < 50)
                    {
                        sconto = 0.05f;
                    }
                    else
                    {
                        sconto = 0.06f;
                    }
                }
                else
                {
                    sconto = 0.07f;
                }
            }
            Console.WriteLine("Con lo sconto del {0}%, hai pagato {1:n2} Euro", sconto * 100, spesa * (1 - sconto));
            Console.ReadLine();
        }
    }
}
