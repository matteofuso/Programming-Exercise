using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Calcolo delle costanti:

                Per calcolare la farina si divide la quantità per il numero di pizze (1200/12)
                Per il prosciutto si fa allo stesso modo (400/8)
                Per calcolare quanto pomodoro, siccome sarà diverso per le due perchè devono avere lo stesso peso, bisogna calcolare un sistema
                m = pomodoro margherita
                p = pomodoro prosicutto
                {
                    8p + 4m = 1400 --> la somma del pomodoro delle pizze è di 1400g
                    50+100+p = 100+m --> uguaglio il peso delle pizze
                {
                da cui esce m=150 e p=100
            */
            const byte farina = 100, prosciutto = 50, pomodoroProsciutto = 100, pomodoroMargherita = 150;
            uint pizzeMargherite, pizzeProsciutto;
            Console.Write("Inserisci il numero di pizze margherita: ");
            pizzeMargherite = Convert.ToUInt32(Console.ReadLine());
            Console.Write("Inserisci il numero di pizze al prosciutto: ");
            pizzeProsciutto = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("\nIngredienti per {0} pizze margherite:", pizzeMargherite);
            Console.WriteLine("{0}g di farina, {1}g di pomodoro", farina * pizzeMargherite, pomodoroMargherita * pizzeMargherite);
            Console.WriteLine("\nIngredienti per {0} pizze al prosciutto:", pizzeProsciutto);
            Console.WriteLine("{0}g di farina, {1}g di prosciutto, {2}g di pomodoro", farina * pizzeProsciutto, prosciutto * pizzeProsciutto, pomodoroProsciutto * pizzeProsciutto);
            Console.ReadLine();
        }
    }
}