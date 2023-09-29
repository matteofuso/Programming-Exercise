using System;

namespace PI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int precisione = 10000000, esci = 4;
            Random rnd = new Random();
            decimal pi;
            double px, py, test;
            ulong d;
            int dentro, fuori, input;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Scegli con che metodo vuoi calcolare il valore di PI:");
                Console.WriteLine("1. Punti casuali (Metodo Montecarlo)");
                Console.WriteLine("2. Formula di Leibniz");
                Console.WriteLine("3. Formula di Nilakantha");
                Console.WriteLine("{0}. Esci", esci);
                Console.Write("Inserisci il metodo: ");
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (input < 1 || input > esci)
                {
                    continue;
                }
                if (input == esci)
                {
                    break;
                }
                switch (input)
                {
                    case 1:
                        dentro = 0;
                        fuori = 0;
                        for (int i = 0; i < precisione; i++)
                        {
                            // Equazione cironferenza: x^2+y^2-2x-2y+1=0
                            // c = (1;1)
                            // r = 1
                            // d = sqrt((px-cx)^2+(py-cy)^2)
                            px = 2*rnd.NextDouble();
                            py = 2*rnd.NextDouble();
                            test = Math.Sqrt(Math.Pow(1 - px, 2) + Math.Pow(1 - py, 2));
                            if (test <= 1)
                            {
                                dentro++;
                            }
                            else
                            {
                                fuori++;
                            }
                        }
                        pi = 4*(decimal)dentro / precisione;
                        Console.WriteLine("PI = {0:N28}", pi);
                        break;
                    case 2:
                        pi = 4;
                        d = 1;
                        for (int i = 1; i < precisione; i++)
                        {
                            if (i % 2 == 1)
                            {
                                d += 2;
                                pi -= 4 / (decimal)d;
                            }
                            else
                            {
                                d += 2;
                                pi += 4 / (decimal)d;
                            }
                        }
                        Console.WriteLine("PI = {0:N28}", pi);
                        break;
                    case 3:
                        pi = (decimal)19 / 6;
                        for (int i = 2; i < precisione; i++)
                        {
                            d = (ulong)i * ((ulong)i + 1) * (2 * (ulong)i + 1);
                            if (d < 0)
                            {
                                break;
                            }
                            if (i % 2 == 0)
                            {
                                pi -= 1 / (decimal)d;
                            }
                            else
                            {
                                pi += 1 / (decimal)d;
                            }
                        }
                        Console.WriteLine("PI = {0:N28}", pi);
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}