using System;

namespace Clinica
{
    internal class Inserimento
    {
        public static string Testo(string messaggio, bool numeri = false)
        {
            string valore;
            do
            {
                Console.Write(messaggio);
                Console.CursorVisible = true;
                valore = Console.ReadLine();
                Console.CursorVisible = false;
                foreach (char c in valore)
                {
                    if ((numeri && !char.IsLetterOrDigit(c)) || (!numeri && !char.IsLetter(c)))
                    {
                        valore = "";
                        break;
                    }
                }
            } while (valore == "");
            return char.ToUpper(valore[0]) + valore.Substring(1);
        }
        public static int Intero(string messaggio, int valoreMinimo = 1, int valoreMassimo = int.MaxValue)
        {
            int valore;
            do
            {
                Console.CursorVisible = false;
                Console.Write(messaggio);
                Console.CursorVisible = true;
            } while (!int.TryParse(Console.ReadLine(), out valore) || valore < valoreMinimo || valore > valoreMassimo);
            Console.CursorVisible = false;
            return valore;
        }
        public static double Double(string messaggio, double valoreMinimo = double.MinValue, double valoreMassimo = double.MaxValue)
        {
            double valore;
            do
            {
                Console.CursorVisible = false;
                Console.Write(messaggio);
                Console.CursorVisible = true;
            } while (!double.TryParse(Console.ReadLine(), out valore) || valore < valoreMinimo || valore > valoreMassimo);
            Console.CursorVisible = false;
            return valore;
        }
    }
}
