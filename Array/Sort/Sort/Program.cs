using System;
using System.Diagnostics;

namespace Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int[] template = new int[10] { 1, 96, 365, 45, 3, -96, -78, 35, 45, 0 };
            int[] toSort = new int[template.Length];
            int options = 2, input, temp;
            string arr = "[ " + template[0] + ", ";
            for (int i = 1; i < template.Length - 1; i++)
            {
                arr += template[i] + ", ";
            }
            arr += template[template.Length - 1] + " ]";
            do
            {
                Console.Clear();
                template.CopyTo(toSort, 0);
                Console.WriteLine("Array da ordinare: {0}", arr);
                Console.WriteLine("Ecco i metodi di sort a disposizione: ");
                Console.WriteLine("1. Bubble Sort");
                Console.WriteLine("2. Esci");
                Console.Write("Inserisci la tua scelta: ");
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                while (input < 0 || input > options)
                {
                    Console.WriteLine("Scelta non valida. Reinserisci.");
                    input = Convert.ToInt32(Console.ReadLine());
                }
                if (input != options)
                {
                    switch (input)
                    {
                        case 1:
                            stopwatch.Reset();
                            stopwatch.Start();
                            for (int condizioni = toSort.Length - 1; condizioni > 0; condizioni--)
                            {
                                for (int i = 0; i < condizioni; i++)
                                {
                                    if (toSort[i] > toSort[i + 1])
                                    {
                                        temp = toSort[i];
                                        toSort[i] = toSort[i + 1];
                                        toSort[i + 1] = temp;
                                    }
                                }
                            }
                            stopwatch.Stop();
                            Console.WriteLine("L'array ordinato è:");
                            for (int i = 0; i < toSort.Length; i++)
                            {
                                Console.WriteLine(toSort[i]);
                            }
                            Console.WriteLine("\n\rL'esecuzione ha impiegato {0} ticks. La tua macchina ne esegue {1} ogni ms.", stopwatch.ElapsedTicks, TimeSpan.TicksPerMillisecond);
                            break;
                    }
                    Console.ReadLine();
                }
            } while (input != 2);
        }
    }
}