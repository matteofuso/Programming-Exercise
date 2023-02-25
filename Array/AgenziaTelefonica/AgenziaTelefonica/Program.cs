using System;

namespace AgenziaTelefonica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dichiarazione e Inizializzazione variabili e costanti
            const int MAXCONTATTI = 3, MAXOPZIONE = 3;
            int contattiInseriti = 0, intInput;
            string strInput;
            string[] nome = new string[MAXCONTATTI];// { "Rigno Star", "Jogn Lennon", "Ivan Lokusko" };
            long[] numero = new long[MAXCONTATTI]; // { 3216549874, 3256987452, 3256985632 };
            do
            {
                Console.Clear();
                Console.WriteLine("Benvenuto nel menù di gestione della agenda telefonica.");
                Console.WriteLine("1. Inserimento");
                Console.WriteLine("2. Visualizza Contatti");
                Console.WriteLine("3. Esci");
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
                                    Console.Write("Inserisci il numero del contatto da inserire: ");
                                    strInput = Console.ReadLine();
                                    while (strInput.Length != 10)
                                    {
                                        Console.Write("La lunghezza di un numero di telefono è di 10 numeri (Tralascia il prefisso). Reinserisci il numero: ");
                                        strInput = Console.ReadLine();
                                    }
                                    numero[contattiInseriti] = Convert.ToInt64(strInput);
                                    Console.WriteLine("Contatto inserito con successo nella posizione {0}", contattiInseriti);
                                    contattiInseriti++;
                                }
                                else
                                {
                                    Console.WriteLine("L'elenco è già pieno.");
                                }
                                break;
                            case 2:
                                Console.WriteLine("Ecco l'elenco:");
                                Console.WriteLine("Numero    Nome e Cognome         Numero di Telefono");
                                for (int i = 0; i < contattiInseriti; i++)
                                {
                                    Console.WriteLine("{0,-9} {1,-22} +39 {2:### ### ####}", i + 1, nome[i], numero[i]);
                                }
                                break;
                        }
                        Console.Write("\n\rPremi invio per continuare . . .");
                        Console.ReadLine();
                    }
                }
            } while (intInput != MAXOPZIONE);
        }
    }
}