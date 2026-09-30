using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimaleBinario
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
            int[] array = new int[8];
            Console.Write("Inserire un numero di massimo un byte: ");
            numero = Convert.ToInt32(Console.ReadLine());
            while (numero < 0 || numero > 255)
            {
                Console.Write("Out of range... Reinserisci il numero: ");
                numero = Convert.ToInt32(Console.ReadLine());
            }
            // Convert - Metodo Stringa + Array
            scompongo = numero;
            for (int i = 0; i < 8; i++)
            {
                resto = scompongo % 2;
                scompongo /= 2;
                converted = resto + converted;
                array[7 - i] = resto;
            }
            Console.WriteLine();
            Console.WriteLine("Il numero {0:000} convertito in binario è {1} - Metodo Stringa", numero, converted);
            Console.Write("Il numero {0:000} convertito in binario è ", numero);
            for (int i = 0; i < 8; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine(" - Metodo Array");
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
                finale += (int)Math.Pow(10, peso) * resto;
                peso++;
            }
            Console.WriteLine("Il numero {0:000} convertito in binario è {1:00000000} - Metodo Matematico", numero, finale);
            // Metodo Convert
            finale = Convert.ToInt32(Convert.ToString(numero, 2));
            Console.WriteLine("Il numero {0:000} convertito in binario è {1:00000000} - Metodo ChatGPT", numero, finale);
            Console.WriteLine();
            Console.WriteLine("Conversione riuscita. Preme invio per uscire...");
            Console.ReadLine();
        }
    }
}
