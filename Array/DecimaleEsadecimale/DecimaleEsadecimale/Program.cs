using System;

namespace DecimaleEsadecimale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] conversione = new string[16];
            string input, convertito;
            int baseNumero, numero, scomposto, resto;
            // Inizializzazione Array
            for (int i = 0; i < 10; i++)
            {
                conversione[i] = Convert.ToString(i);
            }
            conversione[10] = "A";
            conversione[11] = "B";
            conversione[12] = "C";
            conversione[13] = "D";
            conversione[14] = "E";
            conversione[15] = "F";
            do
            {
                convertito = "";
                // Chiedo in numero
                Console.Write("Inserisci la base: ");
                baseNumero = Convert.ToInt32(Console.ReadLine());
                while (baseNumero < 2 || baseNumero > 16)
                {
                    Console.Write("La base deve essere compresa tra 2 e 16. Inserisci una base: ");
                    baseNumero = Convert.ToInt32(Console.ReadLine());
                }
                // Chiedo di inserire la base
                Console.Write("Inserisci il numero: ");
                numero = Convert.ToInt32(Console.ReadLine());
                while (numero < 0 || numero > 255)
                {
                    Console.Write("Il numero deve essere massimo di un byte (0-255). Inserisci un numero: ");
                    numero = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
                // Controllo se il numero è 0 per saltare la conversione
                if (numero == 0)
                {
                    convertito = "0";
                } else
                {
                    // Converto il numero e lo concateno ad un stringa
                    scomposto = numero;
                    while (scomposto > 0)
                    {
                        resto = scomposto % baseNumero;
                        scomposto = scomposto / baseNumero;
                        convertito = conversione[resto] + convertito;
                    }
                }
                // Stampo il risultato
                Console.WriteLine("Il numero {0} convertito in base {1} è {2}", numero, baseNumero, convertito);
                Console.WriteLine();
                // Chiedo se si vuole fare un altra conversione
                Console.Write("Vuoi convertire nuovamete? ");
                input = Console.ReadLine().ToUpper();
                while (input != "NO" && input != "SI" && input != "")
                {
                    Console.Write("Inserisci un valore valido (Si/No/Invio): ");
                    input = Console.ReadLine().ToUpper();
                }
            } while (input == "SI" || input == "");
            Console.ReadLine();
        }
    }
}