using System;

namespace ConversioneBasi
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, output = "";
            double basePartenza;
            int baseArrivo, intermediario = 0, scomposto, resto;
            char[] caratteri = new char[16] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };//, 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'W', 'X', 'Y', 'Z', '='};
            Console.Write("Inserisci la base di partenza (2-16): ");
            basePartenza = Convert.ToInt32(Console.ReadLine());
            while (basePartenza < 2 || basePartenza > 16)
            {
                Console.Write("Base non valida. Reinseriscila (2-16): ");
                basePartenza = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Inserisci la base di arrivo (2-16): ");
            baseArrivo = Convert.ToInt32(Console.ReadLine());
            while (baseArrivo < 2 || baseArrivo > 16)
            {
                Console.Write("Base non valida. Reinseriscila (2-16): ");
                baseArrivo = Convert.ToInt32(Console.ReadLine());
            }
            do
            {
                Console.Write("Inserisci il numero: ");
                input = Console.ReadLine();
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    intermediario += Convert.ToInt32(Math.Pow(basePartenza, Convert.ToDouble(i)) * Array.IndexOf(caratteri, input[input.Length - i - 1]));
                }
                Console.WriteLine(intermediario);
                scomposto = intermediario;
                while (scomposto > 0)
                {
                    resto = scomposto % baseArrivo;
                    scomposto = scomposto / baseArrivo;
                    output = Convert.ToString(caratteri[resto]) + output;
                }
                Console.WriteLine("Il numero {0} in base {1}, convertito in base {2} è {3}", input, basePartenza, baseArrivo, output);
                Console.WriteLine("Vuoi convertire di nuovo? ");
                input = Console.ReadLine().ToUpper();
                while (input != "SI" && input != "NO" && input != "")
                {
                    Console.WriteLine("Risposta non valida. Reinserisci (Si,No,Invio): ");
                    input = Console.ReadLine().ToUpper();
                }
            } while (input == "SI" || input == "");
            Console.ReadLine();
        }
    }
}