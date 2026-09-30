using System;

namespace Read
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string buffer = "";
            int ASCII;
            char carattere;
            Console.WriteLine("Inserisci una frase:");
            do
            {
                ASCII = Console.Read();
                carattere = Convert.ToChar(ASCII);
                if (ASCII == 32 || ASCII == 13)
                {
                    Console.WriteLine("Hai inserito la parola: {0}", buffer);
                    buffer = "";
                }
                else if (Char.IsLetterOrDigit(carattere))
                {
                    buffer += carattere;
                }
            } while (carattere != 13);
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}