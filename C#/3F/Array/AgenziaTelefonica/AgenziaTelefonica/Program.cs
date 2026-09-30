using System;
using System.Threading;

namespace AgenziaTelefonica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dichiarazione e Inizializzazione variabili e costanti
            const int MAXCONTATTI = 3, MAXOPZIONE = 4;
            int contattiInseriti = 0, intInput, posizione;
            string strInput;
            string[] nome = new string[MAXCONTATTI];// { "Ringo Star", "John Lennon", "Ivan Lokusko" };
            long[] numero = new long[MAXCONTATTI]; // { 3216549874, 3256987452, 3256985632 };
            do
            {
                Console.Clear();
                Console.WriteLine("Benvenuto nel menù di gestione della agenda telefonica.");
                Console.WriteLine("1. Inserimento");
                Console.WriteLine("2. Visualizza Contatti");
                Console.WriteLine("3. Aggiorna numero");
                Console.WriteLine("{0}. Esci", MAXOPZIONE);
                Console.Write("Inserisci l'opzione: ");
                intInput = Convert.ToInt32(Console.ReadLine());
                if (intInput > 0 && intInput <= MAXOPZIONE)
                {
                    if (intInput != MAXOPZIONE)
                    {
                        Console.WriteLine();
                        switch (intInput)
                        {
                            case 1:
                                if (contattiInseriti < MAXCONTATTI)
                                {
                                    Console.Write("Inserisci il nome ed il cognome del contatto da inserire: ");
                                    nome[contattiInseriti] = Console.ReadLine();
                                    while (nome[contattiInseriti].Length > 22)
                                    {
                                        Console.Write("La lunghezza massima di un nome è di 22 caratteri. Reinserisci il nome: ");
                                        nome[contattiInseriti] = Console.ReadLine();
                                    }
                                    Console.Write("Inserisci il numero del contatto da inserire: +39 ");
                                    strInput = Console.ReadLine();
                                    while (strInput.Length != 10)
                                    {
                                        Console.Write("La lunghezza di un numero di telefono è di 10 numeri. Reinserisci il numero: +39 ");
                                        strInput = Console.ReadLine();
                                    }
                                    numero[contattiInseriti] = Convert.ToInt64(strInput);
                                    contattiInseriti++;
                                    Console.WriteLine("Contatto inserito con successo nella posizione {0}", contattiInseriti);
                                }
                                else
                                {
                                    Console.WriteLine("L'elenco è già pieno.");
                                }
                                break;
                            case 2:
                                if (contattiInseriti != 0)
                                {
                                    Console.WriteLine("Ecco l'elenco:");
                                    Console.WriteLine("Numero    Nome e Cognome         Numero di Telefono");
                                    for (int i = 0; i < contattiInseriti; i++)
                                    {
                                        Console.WriteLine("{0,-9} {1,-22} +39 {2:000 000 0000}", i + 1, nome[i], numero[i]);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("L'agenda è ancora vuota.");
                                }
                                break;
                            case 3:
                                if (contattiInseriti != 0)
                                {
                                    Console.Write("Inserisci il nome ed il congome del contatto: ");
                                    strInput = Console.ReadLine();
                                    posizione = -1;
                                    for (int i = 0; i < contattiInseriti; i++)
                                    {
                                        if (strInput == nome[i])
                                        {
                                            posizione = i;
                                            break;
                                        }
                                    }
                                    if (posizione != -1)
                                    {
                                        Console.Write("Il numero precedente era +39 {0:000 000 0000}, inserisci il nuovo numero: +39 ", numero[posizione]);
                                        strInput = Console.ReadLine();
                                        while (strInput.Length != 10)
                                        {
                                            Console.Write("La lunghezza di un numero di telefono è di 10 numeri. Reinserisci il numero: +39 ");
                                            strInput = Console.ReadLine();
                                        }
                                        numero[posizione] = Convert.ToInt64(strInput);
                                        Console.WriteLine("Numero aggiornato con successo");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Contatto non trovato.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("L'agenda è ancora vuota.");
                                }
                                break;
                        }
                        Console.Write("\n\rPremi invio per continuare . . .");
                        Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
            } while (intInput != MAXOPZIONE);
            Console.WriteLine("Buona giornata.");
            Thread.Sleep(1000);
        }
    }
}