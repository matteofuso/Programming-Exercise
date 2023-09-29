using System;

namespace ContaParole
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxParole = 3;
            int dictLen = 0;
            string buffer = "", input;
            string[] dict = new string[maxParole];
            Console.WriteLine("Inserisci una frase: ");
            input = Console.ReadLine() + " ";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    if (buffer != "")
                    {
                        if (dictLen < 3)
                        {
                            dict[dictLen] = buffer;
                            buffer = "";
                            dictLen++;
                        }
                    }
                }
                else if (Char.IsLetterOrDigit(input[i]))
                {
                    buffer += input[i];
                }
            }
            Console.WriteLine("Dict: [ {0} ]", string.Join(", ", dict));
            Console.ReadLine();
        }
    }
}
