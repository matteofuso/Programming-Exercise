using System;

namespace DecHex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero, baseArrivo;
            string risultato = "";
            // Chiedo di inserire un numero finche è accettabile
            Console.WriteLine("Inserisci il numero da convertire in esadecimale (0-255): ");
            numero = Convert.ToInt32(Console.ReadLine());
            while (numero < 0 || numero > 255)
            {
                Console.WriteLine("Il numero inserito non è valido. Inserisci un numero compreso tra 0 e 255: ");
                numero = Convert.ToInt32(Console.ReadLine());
            }
            // Chiedo di inserire una base finchè è accettabile
            Console.WriteLine("Inserisci la base di arrivo (2-16): ");
            baseArrivo = Convert.ToInt32(Console.ReadLine());
            while (baseArrivo < 2 || baseArrivo > 16)
            {
                Console.WriteLine("La base inserita non è valida. Inserisci una base compresa tra 2 e 16: ");
                baseArrivo = Convert.ToInt32(Console.ReadLine());
            }
            // Inizializzo l'array
            char[] mappa = new char[baseArrivo];
            // Nella mappa ASCII il carattere 0 ha valore 48, fino al 9 che ha valore 57
            // Il carattere A ha valore 65, fino al F che ha valore 70
            for (int i = 0; i < mappa.Length; i++)
            {
                if (i < 10)
                {
                    mappa[i] = Convert.ToChar(i + 48);
                }
                else
                {
                    mappa[i] = Convert.ToChar(i + 55);
                }
            }
            // Uso un for perchè voglio tenere 0 all'inizio e quindi devo fare l'operazione due volte
            Console.Write("Il numero {0} convertito in base {1} è: ", numero, baseArrivo);
            if (numero == 0)
            {
                risultato = "0";
            }
            else
            {
                while (numero > 0)
                {
                    risultato = mappa[numero % baseArrivo] + risultato;
                    numero = numero / baseArrivo;
                }
            }
            Console.WriteLine(risultato);
            Console.ReadLine();
        }
    }
}