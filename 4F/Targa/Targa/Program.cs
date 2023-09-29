using System;

namespace Targa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string targa;
            int n = 0;
            do
            {
                Console.Write("Inserisci la targa: ");
                targa = Console.ReadLine();
            } while (ControlloTarga(targa));
            targa = RiordinaTarga(targa).ToUpper();
            Console.WriteLine("La targa ordinata è {0}", targa);
            for (int i = 0; i < 4; i++)
            {
                n += ((int)targa[i] - 'A') * 1000 * (int)Math.Pow(26, 3 - i);
            }
            for (int i = 4; i < 7; i++)
            {
                n += ((int)targa[i] - '0') * (int)Math.Pow(10, 6 - i);
            }
            Console.WriteLine("La targa è la numero {0}", n);
            Console.Write("Premi un tasto per uscire . . .");
            Console.ReadKey();
        }
        static string RiordinaTarga(string targa)
        {
            return targa.Remove(2, 3) + targa.Substring(2, 3);
        }
        static bool ControlloTarga(string targa)
        {
            if (targa.Length == 7)
            {
                for (int i = 0; i < targa.Length; i++)
                {
                    // AA 000 AA
                    // 01 234 56
                    if (i > 1 && i < 5)
                    {
                        if (!char.IsDigit(targa[i]))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (!char.IsLetter(targa[i]))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            return true;
        }
    }
}
