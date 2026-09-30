using System;
using System.Collections.Generic;

namespace FlottaDiAuto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] opzioni = { "Inserimento Flotta", "Visualizza Flotta", "Gestione Flotta", "Leggi Log", "Salva", "Carica" };
            string[] opzioniFlotta = { "Aggiungi Veicolo", "Elimina Veicolo", "Visualizza Veicolo", "Ricerca per Numero di Posti", "Ricerca per Marca" };
            List<Flotta> flotte = new List<Flotta>();
            int scelta;
            Console.Title = "Gestione Flotte";
            Gestione.ScriviLog("Avvio Programma");
            do
            {
                Console.Clear();
                scelta = Gestione.Menu(opzioni, OpzioneUscita: true);
                if (scelta != opzioni.Length)
                {
                    Console.Clear();
                    GestioneSceltaIniziale(scelta, flotte, opzioni, opzioniFlotta);
                    Console.WriteLine();
                    Console.WriteLine("Premi un tato per continuare . . .");
                    Console.ReadKey();
                }
            } while (scelta != opzioni.Length);
            Gestione.ScriviLog("Chiusura normale programma");
        }
        static void GestioneSceltaIniziale(int scelta, List<Flotta> flotte, string[] opzioni, string[] opzioniFlotta)
        {
            int flotta = 0;
            string file, nome;
            Console.WriteLine("{0}:", opzioni[scelta]);
            Console.WriteLine();
            if (flotte.Count != 0 || scelta == 0 || scelta == 3 || scelta == 5)
            {
                if (scelta != 0 && scelta < 3)
                {
                    Console.Clear();
                    flotta = Gestione.Menu(GestioneFlotte.DescrizioneFlotte(flotte));
                    Console.Clear();
                    Console.WriteLine("{0}:", opzioni[scelta]);
                    Console.WriteLine();
                }
                switch (scelta)
                {
                    case 0:
                        // Inserimento Flotta
                        nome = Gestione.InserimentoTesto("Inserisci il nome della flotta: ");
                        GestioneFlotte.Add(flotte, nome);
                        Console.WriteLine("Inserimento completato");
                        Gestione.ScriviLog(string.Format("Inserimento flotta {0} ({1})", nome, flotte[flotte.Count-1].AutorizzazioneStatale));
                        break;
                    case 1:
                        // Visualizza Flotta
                        flotte[flotta].Visualizza();
                        Gestione.ScriviLog("Visualizzata flotta " + flotte[flotta].Nome);
                        break;
                    case 2:
                        // Gestione Flotta
                        Console.Clear();
                        GestioneFlotta(Gestione.Menu(opzioniFlotta), flotte, flotta, opzioniFlotta);
                        break;
                    case 3:
                        // Leggi log
                        file = Gestione.ScegliLog();
                        if (file != null)
                        {
                            Console.WriteLine();
                            Gestione.LeggiFile(file);
                            Gestione.ScriviLog("Leggo log " + file);
                        }
                        else
                        {
                            Console.WriteLine("Non ci sono file di log");
                            Gestione.ScriviLog("Tentativo di lettura log, non ci sono file");
                        }
                        break;
                    case 4:
                        // Salva
                        GestioneFlotte.Salva(flotte);
                        Console.WriteLine("Flotte salvate con successo");
                        Gestione.ScriviLog("Esportazione flotte");
                        break;
                    case 5:
                        // Carica
                        GestioneFlotte.Importa(flotte);
                        Console.WriteLine("Flotte importate con successo");
                        Gestione.ScriviLog("Importazione flotte");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Non ci sono flotte");
                Gestione.ScriviLog(string.Format("Tentativo di {0}, non ci sono flotte", opzioni[scelta]));
            }
        }
        static void GestioneFlotta(int scelta, List<Flotta> flotte, int flotta, string[] opzioni)
        {
            string targa = "", marca;
            int codice = -1;
            bool esistente;
            Auto auto = null;
            NumeroPosti posti;
            Console.WriteLine();
            Console.WriteLine("{0}:", opzioni[scelta]);
            Console.WriteLine();
            if (scelta == 1 || scelta == 2)
            {
                targa = Gestione.InserimentoTesto("Inserisci la targa o il codice: ");
                try
                {
                    codice = int.Parse(targa);
                    esistente = !flotte[flotta].Exists(codice);
                }
                catch (Exception)
                {
                    esistente = !flotte[flotta].Exists(targa);
                }
                if (esistente)
                {
                    Console.WriteLine("Il veicolo non esiste");
                    Gestione.ScriviLog(string.Format("Tentativo di {0} nella flotta {1}, non ci sono veicoli corrispondenti", opzioni[scelta], flotte[flotta].Nome));
                    return;
                }
                if (codice == -1)
                {
                    auto = flotte[flotta].Find(targa);
                }
                else
                {
                    auto = flotte[flotta].Find(codice);
                }
            }
            switch (scelta)
            {
                case 0:
                    // Aggiungi Veicolo
                    AggiungiVeicolo(flotte, flotta);
                    auto = flotte[flotta].Last;
                    Console.WriteLine("Inserimento Completato");
                    Gestione.ScriviLog(string.Format("Inserimento veicolo {0} nella flotta {1}", auto, flotte[flotta].Nome));
                    break;
                case 1:
                    // Elimina Veicolo
                    if (codice == -1)
                    {
                        flotte[flotta].Elimina(targa);
                    }
                    else
                    {
                        flotte[flotta].Elimina(codice);
                    }
                    Console.WriteLine("Veicolo eliminato con successo");
                    Gestione.ScriviLog(string.Format("Eliminazione veicolo {0} nella flotta {1}", auto, flotte[flotta].Nome));
                    break;
                case 2:
                    // Visualizza Veicollo
                    Console.WriteLine();
                    if (codice == -1)
                    {
                        flotte[flotta].Visualizza(targa);
                    }
                    else
                    {
                        flotte[flotta].Visualizza(codice);
                    }
                    Gestione.ScriviLog(string.Format("Visualizzazione veicolo {0} nella flotta {1}", auto, flotte[flotta].Nome));
                    break;
                case 3:
                    // Ricerca per Numero di Posti
                    posti = (NumeroPosti)Gestione.Menu(Enum.GetNames(typeof(NumeroPosti)), "Inserisci il numero di posti");
                    Console.WriteLine();
                    flotte[flotta].VisualizzaPerNumeroDiPosti(posti);
                    Gestione.ScriviLog(string.Format("Visualizzazione veicoli con {0} posti nella flotta {1}", posti, flotte[flotta].Nome));
                    break;
                case 4:
                    // Ricerca per Marca
                    marca = Gestione.InserimentoTesto("Inserisci la marca: ");
                    Console.WriteLine();
                    flotte[flotta].VisualizzaPerMarca(marca);
                    Gestione.ScriviLog(string.Format("Visualizzazione veicoli con la marca {0} nella flotta {1}", marca, flotte[flotta].Nome));
                    break;
            }
        }
        static void AggiungiVeicolo(List<Flotta> flotte, int flotta)
        {
            string targa;
            string marca = Gestione.InserimentoTesto("Inserisci la marca del veicolo: ");
            string modello = Gestione.InserimentoTesto("Inserisci il modello del veicolo: ");
            Console.WriteLine();
            NumeroPosti posti = (NumeroPosti)Gestione.Menu(Enum.GetNames(typeof(NumeroPosti)), "Inserisci il numero di posti");
            do
            {
                targa = Ministero.Targa();
            } while (GestioneFlotte.ExistTarga(flotte, targa));
            flotte[flotta].Add(marca, modello, targa, posti);
        }
    }
}
