using System;
using System.Diagnostics;

namespace Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Random random = new Random();
            int[] toSort = new int[15];
            int min, index, i1, i2;
            bool isSorted;
            int options = 5, input, temp;
            do
            {
                Console.Clear();
                for (int i = 0; i < toSort.Length; i++)
                {
                    toSort[i] = random.Next(-100, 101);
                }
                Console.WriteLine("Array da ordinare: [ {0} ]", string.Join(", ", toSort));
                Console.WriteLine("Cosa vuoi fare? ");
                Console.WriteLine("1. Rigenera Array");
                Console.WriteLine("2. Bubble Sort");
                Console.WriteLine("3. Cerca Minore");
                Console.WriteLine("4. Stupid Sort");
                Console.WriteLine("{0}. Esci", options);
                Console.Write("Inserisci la tua scelta: ");
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                while (input < 0 || input > options)
                {
                    Console.WriteLine("Scelta non valida. Reinserisci.");
                    input = Convert.ToInt32(Console.ReadLine());
                }
                if (input != 1 && input != options)
                {
                    switch (input)
                    {
                        case 2:
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
                            break;
                        case 3:
                            stopwatch.Reset();
                            stopwatch.Start();
                            for (int i = 0; i < toSort.Length; i++)
                            {
                                min = toSort[i];
                                index = i;
                                for (int j = i; j < toSort.Length; j++)
                                {
                                    if (toSort[j] < min)
                                    {
                                        min = toSort[j];
                                        index = j;
                                    }
                                }
                                temp = toSort[i];
                                toSort[i] = toSort[index];
                                toSort[index] = temp;
                            }
                            stopwatch.Stop();
                            break;
                        case 4:
                            stopwatch.Reset();
                            stopwatch.Start();
                            do
                            {
                                i1 = random.Next(0, toSort.Length);
                                i2 = random.Next(0, toSort.Length);
                                temp = toSort[i1];
                                toSort[i1] = toSort[i2];
                                toSort[i2] = temp;
                                isSorted = true;
                                for (int i = 0; i < toSort.Length-1; i++)
                                {
                                    if (toSort[i] > toSort[i+1])
                                    {
                                        isSorted = false;
                                        break;
                                    }
                                }
                            } while (!isSorted);
                            stopwatch.Stop();
                            break;
                    }
                    Console.WriteLine("L'array ordinato è: [ {0} ]", string.Join(", ", toSort));
                    Console.WriteLine("\n\rL'esecuzione ha impiegato {0} ticks. Il tuo computer ne esegue {1} ogni ms.\n\rIl tempo di esecuzione è quindi di {2} µs.", stopwatch.ElapsedTicks, TimeSpan.TicksPerMillisecond, (double)stopwatch.ElapsedTicks * 1000 / TimeSpan.TicksPerMillisecond);
                    Console.ReadLine();
                }
            } while (input != 2);
        }
    }
}