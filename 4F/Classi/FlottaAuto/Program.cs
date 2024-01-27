using System;

namespace FlottaAuto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] opzioni = {
                "Aggiungi Veicolo",
                "Elimina Veicolo",
                "Visualizza Veicolo",
                "Visualizzazione Flotta",
                "Ricerca per Numero di Posti",
                "Ricerca per Marca",
                "Leggi Log",
                "Salva Flotta",
                "Importa Flotta",
            };
            int scelta;
            Flotta flotta = new Flotta("Comprovendo Paolo Inc.", Ministero.GeneraAutorizzazioneStatale());
            Console.Title = "Gestione Flotta";
            Console.CursorVisible = false;
            Gestione.ScriviLog("Avvio Programma");
            do
            {
                Console.Clear();
                scelta = Gestione.Menu(opzioni, string.Format("{0} ({1})", flotta.Nome, flotta.AutorizzazioneStatale), true);
                if (scelta != opzioni.Length)
                {
                    Console.Clear();
                    GestioneSceltaIniziale(scelta, opzioni, flotta);
                    Console.WriteLine();
                    Console.WriteLine("Premi un tato per continuare . . .");
                    Console.ReadKey();
                }
            } while (scelta != opzioni.Length);
            Gestione.ScriviLog("Chiusura normale programma");
        }
        static void GestioneSceltaIniziale(int scelta, string[] opzioni, Flotta flotta)
        {
            int codice = 0;
            string targa = "", marca, file;
            NumeroPosti posti;
            Console.WriteLine("{0}:", opzioni[scelta]);
            Console.WriteLine();
            if (scelta == 0 || scelta > 5 || flotta.Veicoli != 0)
            {
                if (scelta == 1 || scelta == 2)
                {
                    IdentificaVeicolo(out codice, out targa);
                }
                switch (scelta)
                {
                    case 0:
                        // Aggiungi Veicolo
                        AggiungiVeicolo(flotta);
                        Console.WriteLine("Auto aggiunta con successo");
                        Gestione.ScriviLog(string.Format("Aggiunta auto {0}", flotta.UltimaAuto));
                        break;
                    case 1:
                        // Elimina Veicolo
                        try
                        {
                            if (codice == -1)
                            {
                                flotta.Elimina(targa);
                                Gestione.ScriviLog(string.Format("Eliminazione veicolo con targa {0}", targa));
                            }
                            else
                            {
                                flotta.Elimina(codice);
                                Gestione.ScriviLog(string.Format("Eliminazione veicolo con codice {0}", codice));
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Gestione.ScriviLog(string.Format("Errore nell'eliminazione", e.Message));
                        }
                        break;
                    case 2:
                        // Visualizza Veicolo
                        Console.WriteLine();
                        try
                        {
                            if (codice == -1)
                            {
                                flotta.Visualizza(targa);
                                Gestione.ScriviLog(string.Format("Visualizzazione veicolo con targa {0}", targa));
                            }
                            else
                            {
                                flotta.Visualizza(codice);
                                Gestione.ScriviLog(string.Format("Visualizzazione veicolo con codice {0}", codice));
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Gestione.ScriviLog(string.Format("Errore nella visualizzaione", e.Message));
                        }
                        break;
                    case 3:
                        // Visualizzazione Flotta
                        flotta.VisualizzaParco();
                        Gestione.ScriviLog("Visualizzazione parco macchine");
                        break;
                    case 4:
                        // Ricerca per Numero di Posti
                        posti = (NumeroPosti)Gestione.Menu(Enum.GetNames(typeof(NumeroPosti)), "Seleziona il numero di posti");
                        Console.WriteLine();
                        try
                        {
                            flotta.VisualizzaPer(posti);
                            Gestione.ScriviLog(string.Format("Visualizzazione veicoli con {0} posti", posti));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Gestione.ScriviLog(string.Format("Errore nella visualizzazione di veicoli per numero di posti ({0}), non ci sono veicoli", posti));
                        }
                        break;
                    case 5:
                        // Ricerca per Marca
                        marca = Gestione.InserimentoTesto("Inserisci la marca: ");
                        Console.WriteLine();
                        try
                        {
                            flotta.VisualizzaPer(marca);
                            Gestione.ScriviLog(string.Format("Visualizzazione veicoli con la marca {0}", marca));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Gestione.ScriviLog(string.Format("Errore nella visualizzazione di veicoli per marca ({0}), non ci sono veicoli", marca));
                        }
                        break;
                    case 6:
                        // Leggi Log
                        file = Gestione.SceltaLog();
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
                    case 7:
                        // Salva Flotta
                        try
                        {
                            Gestione.Esporta(flotta);
                            Console.WriteLine("Esportazione eseguita con successo");
                            Gestione.ScriviLog("Esportazione flotta su file eserno");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Gestione.ScriviLog(string.Format("Impossibile salvare flotta, {0}", e.Message));
                        }
                        break;
                    case 8:
                        // Importa Flotta
                        try
                        {
                            Gestione.Importa(flotta);
                            Console.WriteLine("Importazione eseguita con successo");
                            Gestione.ScriviLog("Importazione flotta su file eserno");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Gestione.ScriviLog(string.Format("Impossibile importare flotta, {0}", e.Message));
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("La flotta è vuota");
                Gestione.ScriviLog(string.Format("Tentativo di {0}, la flotta è vuota", opzioni[scelta]));
            }
        }
        static void IdentificaVeicolo(out int codice, out string targa)
        {
            string value = Gestione.InserimentoTesto("Inserisci il codice o la targa del veicolo: ");
            codice = -1;
            targa = "";
            try
            {
                codice = int.Parse(value);
            }
            catch (Exception)
            {
                while (!Gestione.IsTarga(value))
                {
                    value = Gestione.InserimentoTesto("Inserisci una targa corretta: ");
                }
                targa = value;
            }
        }
        static void AggiungiVeicolo(Flotta flotta)
        {
            string targa;
            string marca = Gestione.InserimentoTesto("Inserisci la marca del veicolo: ");
            string modello = Gestione.InserimentoTesto("Inserisci il modello del veicolo: ");
            Console.WriteLine();
            NumeroPosti posti = (NumeroPosti)Gestione.Menu(Enum.GetNames(typeof(NumeroPosti)), "Seleziona il numero di posti");
            do
            {
                targa = Ministero.GeneraTarga();
            } while (flotta.Exist(targa));
            flotta.Add(marca, modello, targa, posti);
        }
    }
}
