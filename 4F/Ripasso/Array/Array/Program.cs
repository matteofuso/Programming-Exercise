using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] vect;
            Console.WriteLine("Creo un array con numeri random");
            CreaVettore(out vect, 10, random);
            MostraVettore(vect);
            Console.WriteLine("Allungo il vettore e aggiungo altri numeri random");
            SgrandaVettore(ref vect, 5, random);
            MostraVettore(vect);
            Console.WriteLine("Rimuovo i numeri duplicati");
            RimuoviDuplicati(ref vect);
            MostraVettore(vect);
            Console.Write("\r\nPremi un tasto per uscire . . .");
            Console.ReadKey();
        }
        static public void RimuoviDuplicati(ref int[] vector)
        {
            int times;
            // Confronto tutti numeri (i) con i suoi successivi (j)
            // Non confronto i successivi perchè se il numero in posizione i
            // non esisterebbe se uno in posizione precedente è uguale
            for (int i = 0; i < vector.Length; i++)
            {
                // Conto le volte che si ripete il numero
                times = -1;
                for (int j = i; j < vector.Length; j++)
                {
                    if (vector[j] == vector[i])
                    {
                        times++;
                    }
                }
                // Se si ripete
                if (times != -1)
                {
                    // Creo un altro array e copio tutti i numeri diversi dal numero in posizione i o in posizione i
                    int[] temp = new int[vector.Length - times];
                    int k = 0;
                    for (int j = 0; j < vector.Length; j++)
                    {
                        if (vector[j] != vector[i] || j == i)
                        {
                            temp[k] = vector[j];
                            k++;
                        }
                    }
                    // Sostituisco l'indirizzo dell'array vector con quello dell'array temp
                    // Il vecchio array verrà cancellato dal Garbage Collector
                    vector = temp;
                }
            }
        }
        static public void SgrandaVettore(ref int[] vector, int add, Random random)
        {
            int[] temp = new int[vector.Length + add];
            for (int i = 0; i < temp.Length; i++)
            {
                if (i < vector.Length)
                {
                    temp[i] = vector[i];
                }
                else
                {
                    temp[i] = random.Next(0, 20);
                }
            }
            vector = temp;
        }
        static public void MostraVettore(int[] vector)
        {
            Console.Write("[ ");
            for (int i = 0; i < vector.Length - 1; i++)
            {
                Console.Write("{0}, ", vector[i]);
            }
            Console.WriteLine("{0} ]", vector[vector.Length - 1]);
        }
        static public void CreaVettore(out int[] vector, int len, Random random)
        {
            vector = new int[len];
            // Generating
            for (int i = 0; i < len; i++)
            {
                vector[i] = random.Next(0, 20);
            }
        }
    }
}
