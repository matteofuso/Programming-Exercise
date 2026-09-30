using System;

namespace Rettangolo
{
    /*
     Scopo : Calcolo dell'area e del perimetro di un rettangolo
    */
    class Rettangolo
    {
        static void Main(string[] args)
        {
            // Variabili e assegnazione costanti
            double baseRettangolo = 0, altezzaRettangolo, area, perimetro;
            bool flag = false;
            Console.Write("Inserisci l'altezza: ");
            altezzaRettangolo = Convert.ToDouble(Console.ReadLine());
            if (altezzaRettangolo <= 0)
            {
                flag = true; //Metodo delle bandierine
                Console.WriteLine("L'altezza non può essere negativa!");
            }
            if (!flag)
            {
                Console.Write("Inserisci la base: ");
                baseRettangolo = Convert.ToDouble(Console.ReadLine());
                if (baseRettangolo <= 0)
                {
                    flag = true;
                    Console.WriteLine("La base non può essere negativa!");
                }
            }
            if (!flag)
            {
                // Calcolo area e perimetro del rettangolo
                area = baseRettangolo * altezzaRettangolo;
                perimetro = (baseRettangolo + altezzaRettangolo) * 2;
                // Visualizzazione dei risultati
                Console.WriteLine("L'area del rettangolo è di {0:n2} cm^2 e il perimetro di {1:n2} cm", area, perimetro);
            }
            Console.ReadKey();
        }
    }
}