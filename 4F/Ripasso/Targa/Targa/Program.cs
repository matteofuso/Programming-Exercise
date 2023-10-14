using System;

namespace Targa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string targa;
            int n;
            // Chiedo la targa
            do
            {
                Console.Write("Inserisci la targa: ");
                targa = Console.ReadLine();
            } while (!TargaValida(targa));
            // Converto
            n = PlateToInt(targa);
            // Stampo
            Console.WriteLine("La targa {0} è la numero {1}", targa, n);
            // Converto
            targa = IntToPlate(n);
            // Stampo
            Console.WriteLine("La targa numero {0} è la targa {1}", n, targa);
            // Esco
            Console.Write("Premi un tasto per uscire . . .");
            Console.ReadKey();
        }
        static int PlateToInt(string targa)
        {
            int n = 0;
            targa = RiordinaTarga(targa).ToUpper();
            for (int i = 0; i < 4; i++)
            {
                // Lettere
                Console.WriteLine("{0} - {1} - {2} -> {3}", targa[i], (int)targa[i] - 'A', 3 - i, ((int)targa[i] - 'A') * (int)Math.Pow(26, 3 - i) * 1000);
                n += ((int)targa[i] - 'A') * (int)Math.Pow(26, 3 - i) * 1000;
            }
            // Numeri
            n += Convert.ToInt32(targa.Substring(4));
            return n;
        }
        static string IntToPlate(int n)
        {
            string targa = "";
            int numeriCentrali = n % 1000;
            n /= 1000;
            for (int i = 0; i < 4; i++)
            {
                targa = (char)(n % 26 + 'A') + targa;
                n /= 26;
            }
            targa = targa.Insert(2, Convert.ToString(numeriCentrali));
            return targa;
        }
        static string RiordinaTarga(string targa)
        {
            return targa.Remove(2, 3) + targa.Substring(2, 3);
        }
        static bool TargaValida(string targa)
        {
            if (targa.Length == 7)
            {
                for (int i = 0; i < targa.Length; i++)
                {
                    //01 234 56
                    if (i > 1 && i < 5)
                    {
                        if (!char.IsDigit(targa[i]))
                        {
                            return false;
                        }
                    }
                    else if (!char.IsLetter(targa[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
