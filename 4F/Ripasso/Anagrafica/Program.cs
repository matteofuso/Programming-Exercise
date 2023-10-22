using System.Collections.Generic;
using System.IO;
using System;
using Microsoft.SqlServer.Server;

namespace Anagrafe
{
    internal class Program
    {
        enum StatoCivile
        {
            Celibe, Nubile, Coniugato, Divorziato, Separato
        }
        enum Sesso
        {
            Maschio, Femmina
        }
        struct Anagrafica
        {
            public string nome;
            public string cognome;
            public DateTime dataNascita;
            public string luogoNascita;
            public Sesso sesso;
            public StatoCivile statoCivile;
            public string cittadinanza;
            public string codiceFiscale;
            public override string ToString()
            {
                return string.Format("{0,-13} {1,-13} {2,-34} {3,-9} {4,-13} {5,-14} {6}", nome, cognome, luogoNascita + ", " + dataNascita.ToShortDateString(), sesso, statoCivile, cittadinanza, codiceFiscale);
            }
        }
        static string support = "";
        static void Main(string[] args)
        {
            string[] opzioni = { "Inserimento", "Visualizzazione", "Modifica", "Eliminazione", "Calcolo età", "Stampa Log", "Cancella Log" };
            string directory = Environment.CurrentDirectory + "\\log\\";
            int scelta, indice = 0;
            List<Anagrafica> comune = new List<Anagrafica>() {
                new Anagrafica { nome = "Agostino", cognome = "Rizzi", dataNascita = new DateTime(1915,7,28), luogoNascita = "Castagnaro", cittadinanza = "Italiana", codiceFiscale = "RZZGTN15L28C041W"},
                new Anagrafica { nome = "Maria", cognome = "Ferrari",dataNascita = new DateTime(1896,10,2) ,luogoNascita = "Brasile",sesso=Sesso.Femmina,statoCivile=StatoCivile.Coniugato, cittadinanza = "Brasiliana", codiceFiscale = "FRRMRA96R42Z602R"},
                new Anagrafica { nome = "Solidea", cognome = "Monco", dataNascita = new DateTime(1889,5,15),luogoNascita = "Villanova del Ghebbo", sesso=Sesso.Femmina,statoCivile=StatoCivile.Nubile, cittadinanza = "Italiana", codiceFiscale = "MNCSLD89E55L985N"},
                new Anagrafica { nome = "Atanasio", cognome = "Beghetto", dataNascita = new DateTime(1885,6,10), luogoNascita = "Lendinara", statoCivile = StatoCivile.Divorziato, cittadinanza = "Italiana", codiceFiscale = "BGHTNS85H10E522R"},
                new Anagrafica { nome = "Luigi", cognome = "Paiato", dataNascita = new DateTime(1921,5,14), luogoNascita = "Lendinara",statoCivile=StatoCivile.Coniugato, cittadinanza = "Italiana", codiceFiscale = "PTALGU21E14E522O"}
            };
            do
            {
                scelta = Menu(opzioni, "Comune di Rovigo", 10, 3, ConsoleColor.Gray, ConsoleColor.Black, true, false);
                if (scelta != opzioni.Length)
                {
                    Console.WriteLine("{0} cittadini:", opzioni[scelta]);
                    Console.WriteLine();
                    if (scelta > 0 && scelta < 5)
                    {
                        if (comune.Count == 0)
                        {
                            Console.WriteLine("Agenda vuota");
                            support = $"Tentativo di {opzioni[scelta].ToLower()}, agenda vuota";
                            scelta = -1;
                        }
                        else if (scelta > 1)
                        {
                            do
                            {
                                Console.Write("Inserisci il codice fiscale: ");
                                support = Console.ReadLine().ToUpper();
                            } while (support.Length != 16);
                            indice = comune.FindIndex(CercaPerCF);
                            if (indice == -1)
                            {
                                Console.WriteLine("Persona non trovata");
                                support = $"Tentativo di {opzioni[scelta].ToLower()}, persona non trovata (CF: {support})";
                                scelta = -1;
                            }
                        }
                    }
                    if (scelta != -1)
                    {
                        ScelteMenu(comune, scelta, indice, directory);
                    }
                    else if (support != "")
                    {
                        ScriviLog(directory, support);
                    }
                    Console.WriteLine();
                    Console.Write("Premi un tasto per continuare . . .");
                    Console.ReadKey(true);
                }
            } while (scelta != opzioni.Length);
        }
        static bool CercaPerCF(Anagrafica c)
        {
            return c.codiceFiscale == support;
        }
        static void ScelteMenu(List<Anagrafica> comune, int scelta, int indice, string directory)
        {
            string log = "", path = "";
            if (scelta > 4)
            {
                if (Directory.Exists(directory))
                {
                    if (Directory.GetFiles(directory, "*.log").Length != 0)
                    {
                        path = ScegliLog(directory);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Cartella log vuota");
                        scelta = -1;
                    }
                }
                else
                {
                    Console.WriteLine("Cartella log non esistente");
                    scelta = -1;
                }
            }
            switch (scelta)
            {
                case 0:
                    indice = Inserimento(comune);
                    if (indice != -1)
                    {
                        Console.WriteLine("Persona già presente");
                        log = $"Tentativo di inserimento, persona già presente (CF: {comune[indice].codiceFiscale})";
                    }
                    else
                    {
                        Console.WriteLine("Persona inserita");
                        log = string.Format("{0,-20} {1}", "Inserimento persona:", comune[comune.Count - 1]);
                    }
                    break;
                case 1:
                    Visualizza(comune);
                    log = "Visualizzazione dei cittadini";
                    break;
                case 2:
                    Console.WriteLine();
                    scelta = Menu(new string[] { "Stato Civile" }, "Seleziona il campo da modificare", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, false, false);
                    Console.WriteLine();
                    switch (scelta)
                    {
                        case 0:
                            log = string.Format("Modifica Stato Civile di {0} {1} ({2}): {3} -> ", comune[indice].nome, comune[indice].cognome, comune[indice].codiceFiscale, comune[indice].statoCivile);
                            Modifica(comune, indice, scelta, Menu(Enum.GetNames(typeof(StatoCivile)), "Seleziona lo stato civile", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, false, false));
                            log += comune[indice].statoCivile;
                            break;
                    }
                    break;
                case 3:
                    log = $"Eliminazione cittadio (CF: {comune[indice].codiceFiscale})";
                    comune.RemoveAt(indice);
                    break;
                case 4:
                    Console.WriteLine("Il cittadino {0} {1} ha {2} anni", comune[indice].nome, comune[indice].cognome, CalcoloEtà(comune[indice].dataNascita, DateTime.Now));
                    log = $"Calcolo età cittadino (CF: {comune[indice].codiceFiscale})";
                    break;
                case 5:
                    LeggiLog(path);
                    log = "Stampo log " + path;
                    break;
                case 6:
                    File.Delete(path);
                    break;
            }
            if (log != "")
            {
                ScriviLog(directory, log);
            }
        }
        static int CalcoloEtà(DateTime nascita, DateTime data)
        {
            int età;
            età = data.Year - nascita.Year;
            if (nascita.Month >= data.Month && (nascita.Month > data.Month || nascita.Day > data.Day))
            {
                età--;
            }
            return età;
        }
        static void Modifica(List<Anagrafica> comune, int indice, int scelta, int valore)
        {
            Anagrafica cittadino = comune[indice];
            switch (scelta)
            {
                case 0:
                    // Stato civile
                    cittadino.statoCivile = (StatoCivile)valore;
                    break;
            }
            comune[indice] = cittadino;
        }
        static void Visualizza(List<Anagrafica> comune)
        {
            Console.WriteLine(" {0,-13} {1,-13} {2,-34} {3,-9} {4,-13} {5,-14} {6}", "Nome", "Cognome", "Nascita", "Sesso", "Stato Civile", "Cittadinanza", "Codice Fiscale");
            foreach (Anagrafica persona in comune)
            {
                Console.WriteLine(" {0}", persona);
            }
        }
        static int Inserimento(List<Anagrafica> comune)
        {
            Anagrafica cittadino = new Anagrafica();
            string codiceCatastale;
            int i;
            // Chiedo nome, cognome, cittadinanza, luogo di nascita e codice catastale
            cittadino.nome = LeggiStringa("Inserisci il nome: ", false);
            cittadino.cognome = LeggiStringa("Inserisci il cognome: ", false);
            cittadino.cittadinanza = LeggiStringa("Inserisci la cittadinanza: ", false);
            cittadino.luogoNascita = LeggiStringa("Inserisci il luogo di nascita: ", false);
            do
            {
                Console.Write("Inserisci il Codice Catastale di {0}: ", cittadino.luogoNascita);
                codiceCatastale = Console.ReadLine();
            } while (codiceCatastale.Length != 4);
            // Chiedo il giorno di nascita
            do
            {
                Console.Write("Inserisci la data di nascita (dd/mm/aaaa): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out cittadino.dataNascita));
            // Chiedo il sesso
            Console.WriteLine();
            cittadino.sesso = (Sesso)Menu(Enum.GetNames(typeof(Sesso)), "Seleziona il sesso", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, false, false);
            // Chiedo lo stato civile
            Console.WriteLine();
            cittadino.statoCivile = (StatoCivile)Menu(Enum.GetNames(typeof(StatoCivile)), "Seleziona lo stato civile", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, false, false);
            // Calcolo il cofice fiscale
            cittadino.codiceFiscale = CalcolaCF(cittadino, codiceCatastale);
            // Controllo se una persona con lo stesso CF è presente
            i = comune.FindIndex(c => c.codiceFiscale == cittadino.codiceFiscale);
            if (i == -1)
            {
                comune.Add(cittadino);
            }
            return i;
        }
        static int Menu(string[] opzioni, string intestazione, int x, int y, ConsoleColor coloreTesto, ConsoleColor coloreSfondo, bool opzioneUscita, bool path)
        {
            int scelta, maxValue = opzioni.Length;
            const string SEPARATOR = "========================";
            string temp = "";
            // Cambio sfondo e colore
            (Console.BackgroundColor, Console.ForegroundColor) = (coloreSfondo, coloreTesto);
            // Cancello tutto se siamo sul menù iniziale
            if (opzioneUscita)
            {
                Console.Clear();
            }
            // Mi posiziono dove richiesto e inizio a scrivere l'intestazione
            Console.SetCursorPosition(x, y);
            Console.WriteLine(intestazione);
            Console.CursorLeft = x;
            Console.WriteLine(SEPARATOR);
            // Scrivo le varie opzioni
            for (int i = 1; i <= opzioni.Length; i++)
            {
                Console.CursorLeft = x;
                if (path)
                {
                    Console.WriteLine("{0}. {1}", i, Path.GetFileName(opzioni[i - 1]));
                }
                else
                {
                    Console.WriteLine("{0}. {1}", i, opzioni[i - 1]);
                }
            }
            // Stampo l'opzione di uscita (Se nel menù iniziale)
            if (opzioneUscita)
            {
                Console.CursorLeft = x;
                Console.WriteLine("{0}. Esci", opzioni.Length + 1);
                maxValue++;
            }
            // Mi preparo per l'input, salvo x e y per quando cancello la risposta dell'utente
            Console.CursorLeft = x;
            Console.WriteLine(SEPARATOR);
            Console.CursorLeft = x;
            Console.Write("Inserisci la scelta: ");
            (x, y) = (Console.CursorLeft, Console.CursorTop);
            do
            {
                // Cancello la scelta precedente e riposiziono il cursore
                Console.SetCursorPosition(x, y);
                for (int i = 0; i < temp.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x, y);
                // Chiedo di inserire la scelta
                temp = Console.ReadLine();
                // Se risponde una stringa reinizio
                int.TryParse(temp, out scelta);
            } while (scelta < 1 || scelta > maxValue);
            // Resetto il colore di testo e sfondo
            (Console.BackgroundColor, Console.ForegroundColor) = (ConsoleColor.Black, ConsoleColor.Gray);
            // Cancello tutto se siamo sul menù iniziale
            if (opzioneUscita)
            {
                Console.Clear();
            }
            return scelta - 1;
        }
        static string CalcolaCF(Anagrafica persona, string codiceCatastale)
        {
            // https://it.wikipedia.org/wiki/Codice_fiscale#Generazione_del_codice_fiscale
            char[] nascita = { 'A', 'B', 'C', 'D', 'E', 'H', 'L', 'M', 'P', 'R', 'S', 'T' };
            string vocali, consonanti;
            string CF;
            // Aggiungo il cognome
            VocaliConsonanti(persona.cognome, out vocali, out consonanti);
            CF = (consonanti + vocali + "XX").Substring(0, 3);
            // Aggiungo il nome
            VocaliConsonanti(persona.nome, out vocali, out consonanti);
            if (consonanti.Length > 3)
            {
                CF += consonanti[0].ToString() + consonanti[2].ToString() + consonanti[3].ToString();
            }
            else
            {
                CF += (consonanti + vocali + "XX").Substring(0, 3);
            }
            // Aggiungo l'anno di nascita
            CF += persona.dataNascita.Year.ToString().Substring(2);
            // Aggiungo il mese di nascita
            CF += nascita[persona.dataNascita.Month - 1];
            // Aggiungo il giorno ed il sesso
            if (persona.sesso == Sesso.Femmina)
            {
                CF += (persona.dataNascita.Day + 40);
            }
            else
            {
                CF += persona.dataNascita.Day;
            }
            // Aggiungo il luogo di nascita
            CF += codiceCatastale;
            // Calcolo il carattere di controllo
            CF = CF.ToUpper();
            CF += Checksum(CF);
            return CF;
        }
        static void VocaliConsonanti(string str, out string vocali, out string consonanti)
        {
            vocali = "";
            consonanti = "";
            foreach (char c in str.ToLower())
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    vocali += c;
                }
                else if (c != ' ')
                {
                    consonanti += c;
                }
            }
        }
        static char Checksum(string CF)
        {
            short[] dispari = { 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };
            int checksum = 0;
            for (int i = 0; i < CF.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (char.IsLetter(CF[i]))
                    {
                        checksum += dispari[CF[i] - 'A' + 10];
                    }
                    else
                    {
                        checksum += dispari[CF[i] - '0'];
                    }
                }
                else
                {
                    if (char.IsLetter(CF[i]))
                    {
                        checksum += CF[i] - 'A';
                    }
                    else
                    {
                        checksum += CF[i] - '0';
                    }
                }
            }
            checksum %= 26;
            return (char)(checksum + 'A');
        }
        static string LeggiStringa(string messaggio, bool numeri)
        {
            string testo;
            do
            {
                Console.Write(messaggio);
                testo = Console.ReadLine();
                if (!numeri)
                {
                    foreach (char c in testo)
                    {
                        if (!char.IsLetter(c))
                        {
                            testo = "";
                            break;
                        }
                    }
                }
            } while (testo.Length == 0);
            // Prima lettera maiuscola
            return char.ToUpper(testo[0]) + testo.Substring(1).ToLower();
        }
        static void ScriviLog(string path, string testo)
        {
            StreamWriter sw;
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            path += DateTime.Now.ToShortDateString().Replace('/', '_') + ".log";
            if (!File.Exists(path))
            {
                sw = new StreamWriter(path);
                sw.WriteLine("{0} {1}", DateTime.Now, "Creazione Log");
            }
            else
            {
                sw = new StreamWriter(path, true);
            }
            sw.WriteLine("{0} {1}", DateTime.Now, testo);
            sw.Close();
        }
        static void LeggiLog(string path)
        {
            StreamReader sr = File.OpenText(path);
            string linea;
            linea = sr.ReadLine();
            while (linea != null)
            {
                Console.WriteLine(linea);
                linea = sr.ReadLine();
            }
            sr.Close();
        }
        static string ScegliLog(string directory)
        {
            string[] files = Directory.GetFiles(directory, "*.log");
            return files[Menu(files, "Scegli il log", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, false, true)];
        }
    }
}