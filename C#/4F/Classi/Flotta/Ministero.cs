using System;

namespace FlottaDiAuto
{
    static internal class Ministero
    {
        static Random _random = new Random();

        public static string AutorizzazioneStatale()
        {
            return Convert.ToString(_random.Next(10000, 100000)) + "AEIOU"[_random.Next(0, 5)];
        }
        public static string Targa()
        {
            string targa = "";
            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                {
                    targa += string.Format("{0:000}", _random.Next(0, 1000));
                }
                else
                {
                    targa += (char)_random.Next('A', 'Z' + 1);
                }
            }
            return targa;
        }
    }
}
