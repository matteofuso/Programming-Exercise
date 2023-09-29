using System;

namespace Concessionario
{
    class Program
    {
        struct Vettura
        {
            public string marca;
            public string modello;
            public string targa;
            public double prezzo;
        }
        static void Main(string[] args)
        {
            const int maxAuto = 3;
            int len = 0, times;
            Vettura[] vetture = new Vettura[maxAuto];
            do
            {
                vetture[len] = InsAuto(false);
                len++;
                if (len == vetture.Length)
                {
                    break;
                }
                Console.Write("Continuare l'inserimento (S/N)? ");
            } while (Console.ReadLine().ToLower() == "s");
            Console.WriteLine();
            List(vetture, len);
            Console.WriteLine();
            if (Ricerca(vetture, len))
            {
                Console.WriteLine("La vettura è presente");
            }
            else
            {
                Console.WriteLine("La vettura non è presente");
            }
            Console.ReadLine();
        }
        static private void GeneraTarga(out string targa)
        {
            Random random = new Random();
            targa = "";
            for (int i = 0; i < 7; i++)
            {
                if (i > 1 && i < 5)
                {
                    targa += random.Next(0, 10);
                    continue;
                }
                targa += Convert.ToChar(random.Next(65, 91));
            }
        }
        static private Vettura InsAuto(bool ricerca)
        {
            Vettura vettura = new Vettura();
            do
            {
                Console.Write("Inserisci la marca della vettura: ");
                vettura.marca = Console.ReadLine();
            } while (vettura.marca == "");
            do
            {
                Console.Write("Inserisci il modello della vettura: ");
                vettura.modello = Console.ReadLine();
            } while (vettura.modello == "");
            if (!ricerca)
            {
                GeneraTarga(out vettura.targa);
                Console.Write("Inserisci il prezzo della vettura: ");
                while (!double.TryParse(Console.ReadLine(), out vettura.prezzo))
                {
                    Console.Write("Inserisci un numero: ");
                }
            }
            return vettura;
        }
        static private bool Ricerca(Vettura[] vetture, int len)
        {
            Vettura vettura = InsAuto(true);
            for (int i = 0; i < len; i++)
            {
                if (vetture[i].marca == vettura.marca && vetture[i].modello == vettura.modello)
                {
                    return true;
                }
            }
            return false;
        }
        static private void List(Vettura[] vetture, int len)
        {
            Console.WriteLine(" Marca              Modello              Targa              Prezzo");
            Console.WriteLine();
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine(" {0,-18} {1,-20} {2,-18} {3:N2}E", vetture[i].marca, vetture[i].modello, vetture[i].targa, vetture[i].prezzo);
            }
        }
    }
}