using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Clinica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] specializzazioni = Enum.GetNames(typeof(Specializzazione)).Select(e => e.Replace('_', ' ')).ToArray();
            string[] opzioni = { "Inserimento Reparti", "Inserimento Pazienti", "Visualizzazione Reparto", "Visualizza Clinica", "Aggiorna Temperatura Paziente", "Leggi log", "Salva", "Importa" };
            string path = Path.Combine(Environment.CurrentDirectory, "data");
            List<Reparto> clinica = new List<Reparto>();
            int scelta;
            Console.Title = "Clinica Dr.Melon";
            Console.CursorVisible = false;
            ScriviLog(path, "Avvio Programma");
            do
            {
                Console.Clear();
                Console.WriteLine();
                scelta = Menu(opzioni, "Clinica Dr.Melon", true);
                if (scelta != opzioni.Length)
                {
                    Console.Clear();
                    Console.WriteLine("{0}:\r\n", opzioni[scelta]);
                    Scelte(scelta, opzioni[scelta], clinica, specializzazioni, path);
                    Console.WriteLine();
                    Console.Write("Premi un tasto per continuare . . .");
                    Console.ReadKey(true);
                }
            } while (scelta != opzioni.Length);
            ScriviLog(path, "Chiusura non forzata programma");
        }
        static void Scelte(int scelta, string voceScelta, List<Reparto> clinica, string[] specializzazioni, string path)
        {
            string file, log = "", paziente;
            double temperatura;
            if (scelta != 0 && scelta != 5 && scelta != 7 && clinica.Count == 0)
            {
                Console.WriteLine("Non ci sono reparti nella clinica");
                log = $"Tentativo di {voceScelta}, non ci sono reparti";
            }
            else
            {
                try
                {
                    switch (scelta)
                    {
                        case 0:
                            // Inserimento Reparti
                            InserimentoReparto(clinica, specializzazioni);
                            Console.WriteLine("Inserimento effettuato con successo");
                            log = $"Inserimento reparto {clinica[clinica.Count - 1]}";
                            break;
                        case 1:
                            // Inserimento Pazienti
                            scelta = IndiceReparto(clinica);
                            Console.WriteLine();
                            InserimentoPaziente(clinica[scelta], out paziente);
                            log = $"Inserimento paziente {paziente} nel reparto {clinica[scelta]}";
                            Console.WriteLine("Inserimento effettuato con successo");
                            break;
                        case 2:
                            // Visualizza Reparto
                            scelta = IndiceReparto(clinica);
                            Console.WriteLine();
                            VisualizzaReparto(clinica[scelta]);
                            log = $"Visualizzazione reparto {clinica[scelta]}";
                            break;
                        case 3:
                            // Visualizza Clinica
                            clinica.ForEach(r =>
                            {
                                r.Visualizza();
                                Console.WriteLine();
                            });
                            log = "Visualizzazione Clinica";
                            break;
                        case 4:
                            // Aggiorna Temperatura Paziente
                            MisuraTemperatura(SelezionaPaziente(clinica, out scelta, out paziente), clinica[scelta], out temperatura);
                            Console.WriteLine("Temperatura aggiornata");
                            log = $"Aggiornamento temperatura {paziente} a {temperatura}°C nel reparto {clinica[scelta]}";
                            break;
                        case 5:
                            // Leggi log
                            file = ScegliLog(Path.Combine(path, "log"));
                            Console.WriteLine();
                            if (file == null)
                            {
                                Console.WriteLine("Non ci sono log");
                                log = "Tentativo di stampare log, non ci sono file";
                            }
                            else
                            {
                                Console.WriteLine("Leggo il file {0}:\r\n", file);
                                log = $"Leggo il log {file}";
                                LeggiLog(file);
                            }
                            break;
                        case 6:
                            // Salva
                            SalvaCSV(clinica, path);
                            Console.WriteLine("Esportazione eseguita");
                            log = "Esportazione clinica";
                            break;
                        case 7:
                            // Esporta
                            ImportaCSV(clinica, path);
                            Console.WriteLine("Importazione eseguita");
                            log = "Importazione clinica";
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    log = $"Errore in {voceScelta}, {e.Message}";
                }
            }
            ScriviLog(path, log);
        }
        // Gestione
        static void VisualizzaReparto(Reparto reparto)
        {
            ConsoleKey key;
            Paziente paziente;
            bool correctKey = true;
            Console.WriteLine("[ <- Previews ] [ Space Reset ] [ Esc Exit ] [ -> Next ]");
            Console.WriteLine();
            Console.WriteLine(" {0,-30} {1,-30} {2}", "Nome", "Cognome", "Temperatura (°C)");
            do
            {
                if (correctKey)
                {
                    Console.CursorLeft = 0;
                    for (int i = 0; i < Console.WindowWidth - 1; i++)
                    {
                        Console.Write(' ');
                    }
                    Console.CursorLeft = 0;
                    paziente = reparto.GetPaziente();
                    Console.Write(" {0,-30} {1,-30} {2}", paziente.GetNome(), paziente.GetCognome(), paziente.GetTemperatura());
                }
                correctKey = true;
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (reparto.Previews())
                        {
                            correctKey = false;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (reparto.Next())
                        {
                            correctKey = false;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        reparto.Reset();
                        break;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        correctKey = false;
                        break;
                }
            } while (key != ConsoleKey.Escape);
            Console.WriteLine();
        }
        static void MisuraTemperatura(int paziente, Reparto reparto, out double temperatura)
        {
            Console.WriteLine();
            temperatura = Inserimento.Double("Inserisci la temperatura misurata: ");
            reparto.LeggiTermometro(temperatura);
            reparto.AggiornaTemperatura(paziente);
        }
        static int SelezionaPaziente(List<Reparto> clinica, out int reparto, out string anagraficaPaziente)
        {
            int identificativo;
            reparto = IndiceReparto(clinica);
            Console.WriteLine();
            List<Paziente> pazienti = clinica[reparto].GetPazienti();
            identificativo = Menu(pazienti.Select(p => p.ToString()).ToArray(), "Seleziona il paziente");
            anagraficaPaziente = pazienti[identificativo].ToString();
            return identificativo;
        }
        static int IndiceReparto(List<Reparto> clinica)
        {
            return Menu(clinica.Select(r => r.ToString()).ToArray(), "Seleziona il reparto");
        }
        // Inserimento
        static void InserimentoPaziente(Reparto reparto, out string anagraficaPaziente)
        {
            string nome = Inserimento.Testo("Inserisci il nome del paziente: ");
            string cognome = Inserimento.Testo("Inserisci il cognome del paziente: ");
            if (reparto.GetPazienti().Exists(p => p.GetNome() == nome && p.GetCognome() == cognome))
            {
                throw new Exception("Paziente già esistente");
            }
            double temperatura = Inserimento.Double("Inserisci la temperatura: ", 35, 42);
            Paziente paziente = new Paziente(nome, cognome, temperatura);
            reparto.Aggiungi(paziente);
            anagraficaPaziente = paziente.ToString();
        }
        static void InserimentoReparto(List<Reparto> clinica, string[] specializzazioni)
        {
            string identificativo = Inserimento.Testo("Inserisci l'identificativo del reparto: ", true);
            if (clinica.Exists(r => r.GetIdentificativo() == identificativo))
            {
                throw new Exception("Reparto già esistente");
            }
            Console.WriteLine();
            Specializzazione nome = (Specializzazione)Menu(specializzazioni, "Seleziona il reparto");
            Console.WriteLine();
            clinica.Add(new Reparto(nome, identificativo, Inserimento.Intero("Inserisci il numero di letti disponibili: ")));
        }
        // Menu
        static int Menu(string[] opzioni, string titolo, bool OpzioneUscita = false)
        {
            int scelta;
            int sceltaMassima = opzioni.Length;
            Console.WriteLine(titolo);
            Console.WriteLine("=========================");
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, opzioni[i]);
            }
            if (OpzioneUscita)
            {
                Console.WriteLine("{0}. Esci", ++sceltaMassima);
            }
            Console.WriteLine("=========================");
            do
            {
                Console.Write("Seleziona un opzione valida: ");
                Console.CursorVisible = true;
                int.TryParse(Console.ReadLine(), out scelta);
                Console.CursorVisible = false;
            } while (scelta < 1 || scelta > sceltaMassima);
            return scelta - 1;
        }
        // Log
        static string ScegliLog(string path)
        {
            string[] files;
            if (!Directory.Exists(path))
            {
                return null;
            }
            files = Directory.GetFiles(path, "*.log");
            if (files.Length == 0)
            {
                return null;
            }
            return files[Menu(files.Select(file => Path.GetFileName(file)).ToArray(), "Sciegli il file di log da aprire")];
        }
        static void ScriviLog(string path, string text)
        {
            StreamWriter sw;
            PreparePath(Path.Combine(path, "log"));
            path = Path.Combine(path, "log", DateTime.Now.ToShortDateString().Replace('/', '_') + ".log");
            if (!File.Exists(path))
            {
                sw = new StreamWriter(path);
                sw.WriteLine("{0} {1}", DateTime.Now, "Creazione file di log");
            }
            else
            {
                sw = new StreamWriter(path, true);
            }
            sw.WriteLine("{0} {1}", DateTime.Now, text);
            sw.Close();
        }
        static void LeggiLog(string file)
        {
            StreamReader sw = new StreamReader(file);
            do
            {
                Console.WriteLine(sw.ReadLine());
            } while (!sw.EndOfStream);
            sw.Close();
        }
        // CSV
        static void SalvaCSV(List<Reparto> clinica, string path)
        {
            PreparePath(path);
            StreamWriter sw = new StreamWriter(Path.Combine(path, "export.csv"));
            List<Paziente> pazienti;
            foreach (Reparto r in clinica)
            {
                sw.WriteLine("Identificativo,Specializzazione,Numero Letti Disponibili,Numeri Letti Occupati");
                sw.WriteLine("{0},{1},{2},{3}", CSV.SanitizeValue(r.GetIdentificativo()), r.GetSpecializzazione(), r.GetLettiDisponibili(), r.GetLettiOccupati());
                sw.WriteLine("Nome,Cognome,Temperatura");
                pazienti = r.GetPazienti();
                foreach (Paziente p in pazienti)
                {
                    sw.WriteLine("{0},{1},{2}", CSV.SanitizeValue(p.GetNome()), CSV.SanitizeValue(p.GetCognome()), CSV.SanitizeValue(p.GetTemperatura().ToString()));
                }
                sw.WriteLine();
            }
            sw.Close();
        }
        static void ImportaCSV(List<Reparto> clinica, string path)
        {
            List<Reparto> newClinica = new List<Reparto>();
            if (!File.Exists(Path.Combine(path, "export.csv")))
            {
                throw new Exception("Non è possibile aprire il file");
            }
            StreamReader sr = new StreamReader(Path.Combine(path, "export.csv"));
            string[] values;
            int limit;
            try
            {
                do
                {
                    sr.ReadLine();
                    values = CSV.Load(sr.ReadLine());
                    sr.ReadLine();
                    newClinica.Add(new Reparto((Specializzazione)Enum.Parse(typeof(Specializzazione), values[1]), values[0], int.Parse(values[2]))); //
                    limit = int.Parse(values[3]);
                    for (int i = 0; i < limit; i++)
                    {
                        values = CSV.Load(sr.ReadLine());
                        newClinica[newClinica.Count - 1].Aggiungi(new Paziente(values[0], values[1], double.Parse(values[2]))); //
                    }
                    sr.ReadLine();
                } while (!sr.EndOfStream);
            }
            catch (Exception)
            {
                sr.Close();
                throw new Exception("Formato del file non valido");
            }
            clinica.Clear();
            newClinica.ForEach(r => clinica.Add(r));
            sr.Close();
        }
        // Utils
        public static void PreparePath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
