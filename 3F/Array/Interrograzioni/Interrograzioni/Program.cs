using System;

namespace Interrograzioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] elenco = {
                "A",
				"B",
				"C",
				"D"
            };
            int estratto;
            Console.WriteLine("Ecco la lista:\r\n");
            for (int i = 0; i < elenco.Length; i++)
            {
                do
                {
                    estratto = random.Next(0, elenco.Length);
                } while (elenco[estratto] == "");
                Console.WriteLine(" {0,2}. {1}", estratto + 1, elenco[estratto]);
                elenco[estratto] = "";
            }
            Console.Write("\r\nPremi un tasto per uscire . . .");
            Console.ReadKey();
        }
    }
}