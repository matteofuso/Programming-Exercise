using System;

namespace Frequenza
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dichiarazione e inizializzazione variabili
            int numero, numeroDaScomporre, i = 0, resto;
            const int numeroFine = 0;
            int contaZero = 0, contaUno = 0, contaDue = 0, contaTre = 0, contaQuattro = 0, contaCinque = 0, contaSei = 0, contaSette = 0, contaOtto = 0, contaNove = 0;
            int contaZeroFinale = 0, contaUnoFinale = 0, contaDueFinale = 0, contaTreFinale = 0, contaQuattroFinale = 0, contaCinqueFinale = 0, contaSeiFinale = 0, contaSetteFinale = 0, contaOttoFinale = 0, contaNoveFinale = 0;
            do
            {
                // Chiedo il numero x
                i++;
                Console.Write("Inserisci il {0}° numero intero della serie (Inserisci {1} per uscire): ", i, numeroFine);
                numero = Convert.ToInt32(Console.ReadLine());
                // Scompongo il numero e conto quante volte appaiono i le cifre singole
                numeroDaScomporre = Math.Abs(numero);
                while (numeroDaScomporre != 0)
                {
                    if (numeroDaScomporre == numero)
                    {
                        // Inizializzo le variabili a 0
                        contaZero = 0;
                        contaUno = 0;
                        contaDue = 0;
                        contaTre = 0;
                        contaQuattro = 0;
                        contaCinque = 0;
                        contaSei = 0;
                        contaSette = 0;
                        contaOtto = 0;
                        contaNove = 0;
                        Console.Write("Scompongo il numero:");
                    }
                    resto = numeroDaScomporre % 10;
                    Console.Write(" {0} ", resto);
                    numeroDaScomporre = numeroDaScomporre / 10;
                    // Aggiungo il numero scomposto alle variabili contatore
                    switch (resto)
                    {
                        case (0):
                            contaZero++;
                            contaZeroFinale++;
                            break;
                        case (1):
                            contaUno++;
                            contaUnoFinale++;
                            break;
                        case (2):
                            contaDue++;
                            contaDueFinale++;
                            break;
                        case (3):
                            contaTre++;
                            contaTreFinale++;
                            break;
                        case (4):
                            contaQuattro++;
                            contaQuattroFinale++;
                            break;
                        case (5):
                            contaCinque++;
                            contaCinqueFinale++;
                            break;
                        case (6):
                            contaSei++;
                            contaSeiFinale++;
                            break;
                        case (7):
                            contaSette++;
                            contaSetteFinale++;
                            break;
                        case (8):
                            contaOtto++;
                            contaOttoFinale++;
                            break;
                        case (9):
                            contaNove++;
                            contaNoveFinale++;
                            break;
                    }
                    if (numeroDaScomporre == 0)
                    {
                        Console.WriteLine();
                    }
                }
                if (numero != 0)
                {
                    // Stampa quanti numeri sono stati inseriti nel numero corrente
                    Console.WriteLine("Di questo numero:");
                    if (contaZero != 0)
                    {
                        Console.WriteLine("- 0 compare {0} volte", contaZero);
                    }
                    if (contaUno != 0)
                    {
                        Console.WriteLine("- 1 compare {0} volte", contaUno);
                    }
                    if (contaDue != 0)
                    {
                        Console.WriteLine("- 2 compare {0} volte", contaDue);
                    }
                    if (contaTre != 0)
                    {
                        Console.WriteLine("- 3 compare {0} volte", contaTre);
                    }
                    if (contaQuattro != 0)
                    {
                        Console.WriteLine("- 4 compare {0} volte", contaQuattro);
                    }
                    if (contaCinque != 0)
                    {
                        Console.WriteLine("- 5 compare {0} volte", contaCinque);
                    }
                    if (contaSei != 0)
                    {
                        Console.WriteLine("- 6 compare {0} volte", contaSei);
                    }
                    if (contaSette != 0)
                    {
                        Console.WriteLine("- 7 compare {0} volte", contaSette);
                    }
                    if (contaOtto != 0)
                    {
                        Console.WriteLine("- 8 compare {0} volte", contaOtto);
                    }
                    if (contaNove != 0)
                    {
                        Console.WriteLine("- 9 compare {0} volte", contaNove);
                    }
                }
                Console.WriteLine();
            } while (numero != numeroFine);
            // Controllo se ha inserito subito lo 0
            if (i == 1)
            {
                Console.WriteLine("Non hai inserito una serie!");
            }
            else
            {
                // Stampa quanti numeri sono stati inseriti nella serie di numeri
                // Aggiungo lo zero finale
                contaZeroFinale++;
                Console.WriteLine("Della serie di numeri:");
                if (contaZeroFinale != 0)
                {
                    Console.WriteLine("- 0 compare {0} volte", contaZeroFinale);
                }
                if (contaUnoFinale != 0)
                {
                    Console.WriteLine("- 1 compare {0} volte", contaUnoFinale);
                }
                if (contaDueFinale != 0)
                {
                    Console.WriteLine("- 2 compare {0} volte", contaDueFinale);
                }
                if (contaTreFinale != 0)
                {
                    Console.WriteLine("- 3 compare {0} volte", contaTreFinale);
                }
                if (contaQuattroFinale != 0)
                {
                    Console.WriteLine("- 4 compare {0} volte", contaQuattroFinale);
                }
                if (contaCinqueFinale != 0)
                {
                    Console.WriteLine("- 5 compare {0} volte", contaCinqueFinale);
                }
                if (contaSeiFinale != 0)
                {
                    Console.WriteLine("- 6 compare {0} volte", contaSeiFinale);
                }
                if (contaSetteFinale != 0)
                {
                    Console.WriteLine("- 7 compare {0} volte", contaSetteFinale);
                }
                if (contaOttoFinale != 0)
                {
                    Console.WriteLine("- 8 compare {0} volte", contaOttoFinale);
                }
                if (contaNoveFinale != 0)
                {
                    Console.WriteLine("- 9 compare {0} volte", contaNoveFinale);
                }
            }
            Console.ReadLine();
        }
    }
}