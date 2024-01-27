using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Diagnostics.Eventing.Reader;

namespace LoZooDiCasaMia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] opzioni = { "Inserisci", "Visualizza", "Dai da magiare", "Aggiungi cibo", "Togli cibo", "Leggi Log" };
            string path = Path.Combine(Environment.CurrentDirectory, "data");
            List<AnimaleDomestico> animaliDomestici = new List<AnimaleDomestico>()
            {
                new AnimaleDomestico("Gatto", "Europeo", "Miagolio", "GiàMangiato", "Crocchette", 1000, 100),
                new AnimaleDomestico("Criceto", "Cinese", "Squitto", "DeveMangiare", "Semi", 10, 100),
            };
            int scelta;
            do
            {
                Console.Clear();
                scelta = Menu(opzioni, true);
                if (scelta != opzioni.Length)
                {
                    Console.Clear();
                    Console.WriteLine("{0}:\r\n", opzioni[scelta]);
                    Scelte(animaliDomestici, scelta, opzioni[scelta], path);
                    Console.WriteLine();
                    Console.Write("Premi un tasto per continuare . . .");
                    Console.ReadKey();
                }
            } while (scelta != opzioni.Length);
        }
        static void Scelte(List<AnimaleDomestico> animaliDomestici, int scelta, string opzione, string path)
        {
            int indice = 0, quantità;
            string log = "", file;
            if (scelta != 0 && scelta < 5 && animaliDomestici.Count == 0)
            {
                Console.WriteLine("Non hai ancora inserito animali");
                ScriviLog(Path.Combine(path, "log"), $"Tentativo di {opzione}, non ci sono animali");
                return;
            }
            if (scelta > 1 && scelta < 5)
            {
                indice = InserimentoIntero("Inserisci l'ID dell'animale: ", 0, animaliDomestici.Count - 1);
            }
            switch (scelta)
            {
                case 0:
                    try
                    {
                        Inserimento(animaliDomestici);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        log = string.Format("Errore nell'inserimeto, {0}", e.Message);
                        break;
                    }
                    log = string.Format("Inserisco animale: {0,-5} {1}", animaliDomestici.Count - 1, animaliDomestici[animaliDomestici.Count - 1]);
                    break;
                case 1:
                    Stampa(animaliDomestici);
                    log = "Stampo lista animali";
                    break;
                case 2:
                    try
                    {
                        animaliDomestici[indice].Mangia();
                        Console.WriteLine("Ho nutrito l'animale");
                        log = $"Animale con id {indice} è stato nutrito";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        log = $"Errore nel nutrire l'animale con id {indice}. {e.Message}";
                    }
                    break;
                case 3:
                    quantità = InserimentoIntero("Inserisci la quatità in grammi di cibo da aggiungere: ", 0, int.MaxValue);
                    animaliDomestici[indice].AggiugniCibo(quantità);
                    Console.WriteLine("Ho aggiunto {0}gr di cibo", quantità);
                    log = $"Ho aggiunto {quantità}gr di cibo all'animale con id {indice}";
                    break;
                case 4:
                    quantità = InserimentoIntero("Inserisci la quatità in grammi di cibo da togliere: ", 0, int.MaxValue);
                    animaliDomestici[indice].AggiugniCibo(-quantità);
                    Console.WriteLine("Ho tolto {0}gr di cibo", quantità);
                    log = $"Ho tolto {quantità}gr di cibo all'animale con id {indice}";
                    break;
                case 5:
                    Console.CursorTop--;
                    file = ScegliLog(Path.Combine(path, "log"));
                    Console.WriteLine();
                    if (file == null)
                    {
                        Console.WriteLine("Non ci sono log");
                        log = "Tentativo di lettura log. Nessun log esistente";
                    }
                    else
                    {
                        Console.WriteLine("Leggo il file {0}:\r\n", file);
                        LeggiLog(file);
                        log = $"Lettura log {file}";
                    }
                    break;
            }
            ScriviLog(Path.Combine(path, "log"), log);
        }
        static void Stampa(List<AnimaleDomestico> animaliDomestici)
        {
            Console.WriteLine("{0,-5} {1,-14} {2,-14} {3,-14} {4,-14} {5,-14} {6,-14} {7}", "ID", "Specie", "Razza", "Verso", "Cibo", "Ha mangiato?", "Cibo Posseduto", "Cibo mangiato per volta");
            for (int i = 0; i < animaliDomestici.Count; i++)
            {
                Console.WriteLine("{0,-5} {1}", i, animaliDomestici[i]);
            }
        }
        static void Inserimento(List<AnimaleDomestico> animaliDomestici)
        {
            AnimaleDomestico animale = new AnimaleDomestico();
            animale.SetSpecie(InserimentoTesto("Inserisci la specie dell'animale: "));
            animale.SetRazza(InserimentoTesto("Inserisci la razza dell'animale: "));
            animale.SetVerso(InserimentoTesto("Inserisci il verso dell'animale: "));
            animale.SetCibo(InserimentoTesto("Inserisci il cibo mangiato dall'animale: "));
            animale.SetMangiato(InserimentoTesto(String.Format("Inserisci lo stato di nutrizione dell'animale ({0}): ", String.Join(", ", Enum.GetNames(typeof(Mangiato))))));
            animale.SetQuantitàCiboPosseduto(InserimentoIntero("Inserisci il la quantità in grammi di cibo posseduto: ", 1, int.MaxValue));
            animale.SetQuantitàCiboMangiatoPerVolta(InserimentoIntero("Inserisci il la quantità in grammi di cibo mangiato ogni volta: ", 1, int.MaxValue));
            animaliDomestici.Add(animale);
        }
        static string InserimentoTesto(string messaggio)
        {
            string valore;
            do
            {
                Console.Write(messaggio);
                valore = Console.ReadLine();
                foreach (char c in valore)
                {
                    if (!char.IsLetter(c))
                    {
                        valore = "";
                        break;
                    }
                }
            } while (valore == "");
            return char.ToUpper(valore[0]) + valore.Substring(1);
        }
        static int InserimentoIntero(string messaggio, int valoreMinimo, int valoreMassimo)
        {
            int valore;
            do
            {
                Console.Write(messaggio);
            } while (!int.TryParse(Console.ReadLine(), out valore) || valore < valoreMinimo || valore > valoreMassimo);
            return valore;
        }
        static int Menu(string[] opzioni, bool OpzioneUscita)
        {
            int scelta;
            int sceltaMassima = opzioni.Length;
            Console.WriteLine();
            Console.WriteLine("Lo Zoo di casa mia:");
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
                int.TryParse(Console.ReadLine(), out scelta);
            } while (scelta < 1 || scelta > sceltaMassima);
            return scelta - 1;
        }
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
            return files[Menu(files.Select(file => Path.GetFileName(file)).ToArray(), false)];
        }
        static void ScriviLog(string path, string text)
        {
            StreamWriter sw;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, DateTime.Now.ToShortDateString().Replace('/', '_') + ".log");
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
    }
}
