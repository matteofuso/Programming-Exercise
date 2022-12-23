using System;

namespace Casa
{
    class Program
    {
        static void Main(string[] args)
        {
            // <50 5%, <65 6%, <80 7%, >80 10%
            float sconto, spesa;
            string read;
            const float spesaCosto1 = 50, spesaCosto2 = 65, spesaCosto3 = 80;
            Console.Write("Inserisci l'importo della spesa: ");
            read = Console.ReadLine();
            if (read == "")
            {
                Console.WriteLine("Hai premuto invio per errore");
            }
            else
            {
                spesa = Convert.ToSingle(read);
                if (spesa > 0)
                {
                    if (spesa > spesaCosto1)
                    {
                        sconto = 0.1f * spesa;
                    }
                    else
                    {
                        if (spesa < spesaCosto2)
                        {
                            if (spesa < spesaCosto3)
                            {
                                sconto = 0.05f * spesa;
                            }
                            else
                            {
                                sconto = 0.06f * spesa;
                            }
                        }
                        else
                        {
                            sconto = 0.07f * spesa;
                        }
                    }
                    Console.WriteLine("Con lo sconto di {0:n2} Euro, hai pagato {1:n2} Euro", sconto, spesa - sconto);
                }
                else
                {
                    Console.WriteLine("Hai inserito un importo non valido");
                }
            }
            Console.ReadLine();
        }
    }
}
