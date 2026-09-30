using System;


namespace VerificaClassi_FIlaB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Magazzino magazzino = new Magazzino("Amazon");
            string[] opzioni = new string[] { "Aggiungi", "Carico", "Scarico", "Stampa magazzino" };
            int scelta;
            do
            {
                Console.Clear();
                scelta = Gestione.Menu(opzioni, "Gestione Magazzino");
                if (scelta != opzioni.Length)
                {
                    Console.Clear();
                    Console.WriteLine("{0}:", opzioni[scelta]);
                    Console.WriteLine();
                    GestioneScelta(magazzino, scelta);
                    Console.WriteLine();
                    Console.Write("Premi un tasto per uscire . . .");
                    Console.ReadKey();
                }
            } while (scelta != opzioni.Length);
        }
        static void GestioneScelta(Magazzino magazzino, int scelta)
        {
            if (scelta == 0 || magazzino.NumeroArticoli != 0)
            {
                switch (scelta)
                {
                    case 0:
                        // Inserimento
                        InserimentoArticolo(magazzino);
                        break;
                    case 1:
                        // Carico
                        try
                        {
                            Gestione.Log(Movimento(magazzino, true));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        // Scarico
                        try
                        {
                            Gestione.Log(Movimento(magazzino, false));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        // Stampa
                        magazzino.Stampa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Il magazzino è vuoto");
            }
        }
        static string Movimento(Magazzino magazzino, bool carico)
        {
            int codice = Gestione.InserimentoIntero("Inserisci il codice dell'articolo: ");
            if (carico)
            {
                return magazzino.Movimento(codice, Gestione.InserimentoDouble("Inserisce la quantità di elementi da caricare: "));
            }
            return magazzino.Movimento(codice, -Gestione.InserimentoDouble("Inserisce la quantità di elementi da scaricare: "));
        }
        static void InserimentoArticolo(Magazzino magazzino)
        {
            string descrizione = Gestione.InserimentoStringa("Inserisci la descrizione dell'articolo: ");
            double prezzo = Gestione.InserimentoDouble("Inserisci il prezzo dell'articolo: ");
            magazzino.Add(descrizione, prezzo);
        }
    }
}
