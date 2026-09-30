using System;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Range Byte ( 8 bit, cioè 0-255, stampare out of range)
            */
            int numero, resto, scompongo, posizione, finale = 0;
            string converted = "";
            double peso;
            Console.Write("Inserire un numero di massimo un byte: ");
            numero = Convert.ToInt32(Console.ReadLine());
            while (numero < 0 || numero > 255)
            {
                Console.Write("Out of range... Reinserisci il numero: ");
                numero = Convert.ToInt32(Console.ReadLine());
            }
            // Convert - Metodo Stringa
            scompongo = numero;
            while (scompongo != 0)
            {
                resto = scompongo % 2;
                scompongo /= 2;
                converted = resto + converted;
            }
            Console.WriteLine();
            scompongo = Convert.ToInt32(converted);
            Console.WriteLine("Il numero {0:000} convertito in binario è {1:00000000} - Metodo Stringa", numero, scompongo);
            // Metodo Grafico
            scompongo = numero;
            Console.Write("Il numero {0:000} convertito in binario è 00000000 - Metodo Grafico", numero);
            posizione = 45;
            while (scompongo != 0)
            {
                resto = scompongo % 2;
                scompongo /= 2;
                Console.CursorLeft = posizione;
                Console.Write(resto);
                posizione--;
            }
            Console.WriteLine();
            // Metodo Matematico
            scompongo = numero;
            peso = 0;
            while (scompongo != 0)
            {
                resto = scompongo % 2;
                scompongo /= 2;
                finale += Convert.ToInt32(Math.Pow(10, peso)) * resto;
                peso++;
            }
            Console.WriteLine("Il numero {0:000} convertito in binario è {1:00000000} - Metodo Matematico", numero, finale);
            // Metodo Convert
            // Console.WriteLine("Il numero {0:000} convertito in binario è {1:00000000} - Metodo ChatGPT", numero, Convert.ToInt32(Convert.ToString(numero, 2)));
            Console.WriteLine("Conversione riuscita. Preme invio per uscire...");
            Console.ReadLine();
        }
    }
}