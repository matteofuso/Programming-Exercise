using System;

namespace giornalista
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] caratteri = new int[65]; // 26 Lettere Lower (0-25) + 26 Lettere Upper (26-52) + 10 Numeri (53-63) + (64) Altro
            char c;
            int i = 0;
            do
            {
                c = Convert.ToChar(Console.Read());
                if (c != '\r')
                {
                    if (Char.IsLetter(c))
                    {
                        if (Char.IsUpper(c))
                        {
                            i = c - 'A';
                        }
                        else
                        {
                            i = c - 'a' + 26;
                        }
                    }
                    else if (char.IsNumber(c))
                    {
                        i = c - '0' + 53;
                    }
                    else
                    {
                        i = 64;
                    }
                    caratteri[i]++;
                }
            } while (c != '\r');
            for (i = 0; i < caratteri.Length - 1; i++)
            {
                // Lettere
                if (caratteri[i] != 0)
                {
                    if (i < 26)
                    {
                        Console.WriteLine("- Il carattere {0} è presente {1} volta/e", Convert.ToChar(i + 'A'), caratteri[i]);
                    }
                    else if (i < 53)
                    {
                        Console.WriteLine("- Il carattere {0} è presente {1} volta/e", Convert.ToChar(i - 26 + 'a'), caratteri[i]);
                    }
                    else
                    {
                        Console.WriteLine("- Il numero {0} è presente {1} volta/e", Convert.ToChar(i - 53 + '0'), caratteri[i]);
                    }
                }
            }
            if (caratteri[64] != 0)
            {
                Console.WriteLine("- Ci sono altri {0} caratteri", caratteri[64]);
            }
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}