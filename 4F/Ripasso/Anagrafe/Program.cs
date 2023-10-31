using System.Collections.Generic;
using System.IO;
using System;

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
        static void Main(string[] args)
        {
            List<Anagrafica> comune = new List<Anagrafica>();
            string root = Environment.CurrentDirectory + "\\data\\", messaggio;
            ImportaCSV(comune, root);
            //List<Anagrafica> comune = new List<Anagrafica>() {
            //    new Anagrafica { nome = "Agostino", cognome = "Rizzi", dataNascita = new DateTime(1915,7,28), luogoNascita = "Castagnaro", cittadinanza = "Italiana", codiceFiscale = "RZZGTN15L28C041W"},
            //    new Anagrafica { nome = "Maria", cognome = "Ferrari",dataNascita = new DateTime(1896,10,2) ,luogoNascita = "Brasile",sesso=Sesso.Femmina,statoCivile=StatoCivile.Coniugato, cittadinanza = "Brasiliana", codiceFiscale = "FRRMRA96R42Z602R"},
            //    new Anagrafica { nome = "Solidea", cognome = "Monco", dataNascita = new DateTime(1889,5,15),luogoNascita = "Villanova del Ghebbo", sesso=Sesso.Femmina,statoCivile=StatoCivile.Nubile, cittadinanza = "Italiana", codiceFiscale = "MNCSLD89E55L985N"},
            //    new Anagrafica { nome = "Atanasio", cognome = "Beghetto", dataNascita = new DateTime(1885,6,10), luogoNascita = "Lendinara", statoCivile = StatoCivile.Divorziato, cittadinanza = "Italiana", codiceFiscale = "BGHTNS85H10E522R"},
            //    new Anagrafica { nome = "Luigi", cognome = "Paiato", dataNascita = new DateTime(1921,5,14), luogoNascita = "Lendinara",statoCivile=StatoCivile.Coniugato, cittadinanza = "Italiana", codiceFiscale = "PTALGU21E14E522O"}
            //};
            string[] opzioni = { "Inserimento", "Visualizzazione", "Modifica", "Eliminazione", "Calcolo Età", "Stampa Log", "Elimina Log", "Esporta in CSV", "Importa da CSV" };
            int scelta;
            do
            {
                Console.Clear();
                scelta = Menu(opzioni, "Comune di Rovigo", 10, 3, true);
                Console.Clear();
                if (scelta != opzioni.Length)
                {
                    Console.WriteLine($"{opzioni[scelta]}:\r\n");
                    ScelteMenu(opzioni[scelta], comune, scelta, root, out messaggio);
                    ScriviLog(root + "log\\", messaggio);
                    Console.WriteLine();
                    Console.Write("Premi un tasto per continuare . . .");
                    Console.ReadKey();
                }
            } while (scelta != opzioni.Length);
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
        static void Modifica(List<Anagrafica> comune, int indice, int scelta, string valore)
        {
            Anagrafica cittadino = comune[indice];
            switch (scelta)
            {
                case 0:
                    // Stato civile
                    cittadino.statoCivile = (StatoCivile)Convert.ToInt32(valore);
                    break;
            }
            comune[indice] = cittadino;
        }
        static void Visualizza(List<Anagrafica> comune)
        {
            Console.WriteLine(" {0,-13} {1,-13} {2,-34} {3,-9} {4,-13} {5,-14} {6}", "Nome", "Cognome", "Nascita", "Sesso", "Stato Civile", "Cittadinanza", "Codice Fiscale");
            comune.ForEach(p => Console.WriteLine(" {0}", p));
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
            cittadino.sesso = (Sesso)Menu(Enum.GetNames(typeof(Sesso)), "Seleziona il sesso", 0, Console.CursorTop, false);
            // Chiedo lo stato civile
            Console.WriteLine();
            cittadino.statoCivile = (StatoCivile)Menu(Enum.GetNames(typeof(StatoCivile)), "Seleziona lo stato civile", 0, Console.CursorTop, false);
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
        static void ScelteMenu(string operazione, List<Anagrafica> comune, int scelta, string root, out string messaggio)
        {
            //{ "Inserimento", "Visualizzazione", "Modifica", "Eliminazione", "Calcolo Età", "Stapa Log", "Elimina Log", "Esporta in CSV", "Importa da CSV" }
            //        0                1               2             3              4             5             6                 7                 8
            int sceltaModifica, indiceInserimento, indice = 0;
            string percorso;
            Controllo(comune, scelta, root, operazione, out messaggio, out percorso);
            if (messaggio == "")
            {
                switch (scelta)
                {
                    case 0:
                        indiceInserimento = Inserimento(comune);
                        if (indiceInserimento != -1)
                        {
                            Console.WriteLine("La persona inserità è già presente");
                            messaggio = $"Tentativo di inserimento, persona già esistente (CF: {comune[indiceInserimento].codiceFiscale}";
                        }
                        else
                        {
                            messaggio = $"Persona inserita: {comune[comune.Count - 1]}";
                        }
                        break;
                    case 1:
                        Visualizza(comune);
                        messaggio = "Visualizzazione registro";
                        break;
                    case 2:
                        Console.WriteLine();
                        sceltaModifica = Menu(new string[] { "Stato Civile" }, "Seleziona il campo da modificare", 0, Console.CursorTop, true);
                        Console.WriteLine();
                        if (sceltaModifica == 2)
                        {
                            messaggio = $"Interrompo l'operazione di {operazione}";
                        }
                        else
                        {
                            switch (sceltaModifica)
                            {
                                case 0:
                                    Console.WriteLine();
                                    messaggio = string.Format("Modifica Stato Civile di {0} {1} ({2}): {3} -> ", comune[indice].nome, comune[indice].cognome, comune[indice].codiceFiscale, comune[indice].statoCivile);
                                    Modifica(comune, indice, sceltaModifica, Convert.ToString(Menu(Enum.GetNames(typeof(StatoCivile)), "Seleziona lo stato civile", 0, Console.CursorTop, false)));
                                    messaggio += comune[indice].statoCivile;
                                    Console.WriteLine("Stato Civile modificato con successo");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        messaggio = $"Eliminazione cittadio (CF: {comune[indice].codiceFiscale})";
                        Console.WriteLine("Cancellazione avvanuta con successo");
                        comune.RemoveAt(indice);
                        break;
                    case 4:
                        Console.WriteLine("Il cittadino {0} {1} ha {2} anni", comune[indice].nome, comune[indice].cognome, CalcoloEtà(comune[indice].dataNascita, DateTime.Now));
                        messaggio = $"Calcolo età cittadino (CF: {comune[indice].codiceFiscale})";
                        break;
                    case 5:
                        LeggiLog(percorso);
                        messaggio = "Stampo log " + percorso;
                        break;
                    case 6:
                        File.Delete(percorso);
                        messaggio = "Cancello log " + percorso;
                        break;
                    case 7:
                        EsportaCSV(comune, root);
                        Console.WriteLine("Esportazione eseguita");
                        messaggio = "Esportazione comune";
                        break;
                    case 8:
                        ImportaCSV(comune, root);
                        Console.WriteLine("Importato con successo");
                        messaggio = "Importo da CSV";
                        break;
                }
            }
        }
        static void Controllo(List<Anagrafica> comune, int scelta, string root, string operazione, out string messaggio, out string percorso)
        {
            string CF;
            messaggio = percorso = "";
            string[] files;
            int indice;
            if (scelta != 0 && scelta < 7)
            {
                if (scelta > 0 && scelta < 5 && comune.Count == 0)
                {
                    messaggio = $"Errore nella {operazione}, il registro è vuoto.";
                }
                else if (scelta > 1 && scelta < 5)
                {
                    do
                    {
                        Console.Write("Inserisci il codice fiscale o scrivi \"Esci\": ");
                        CF = Console.ReadLine().ToUpper();
                    } while (CF.Length != 16 && CF != "ESCI");
                    if (CF == "ESCI")
                    {
                        messaggio = $"Interrompo l'operazione di {operazione}";
                    }
                    else
                    {
                        indice = comune.FindIndex(c => c.codiceFiscale == CF);
                        if (indice == -1)
                        {
                            messaggio = $"Errore nella {operazione}, non è stata trovata persona con il Codice Fiscale specificato";
                        }
                    }
                }
                else if (scelta > 4 && scelta < 7)
                {
                    root += "log\\";
                    if (!Directory.Exists(root))
                    {
                        messaggio = "Nessun log esistente";
                    }
                    else
                    {
                        files = Directory.GetFiles(root, "*.log");
                        if (files.Length == 0)
                        {
                            messaggio = "Nessun log esistente";
                        }
                        else
                        {
                            indice = Menu(GetNames(files), "Seleziona il file di log", Console.CursorLeft, Console.CursorTop, true);
                            if (indice == files.Length)
                            {
                                messaggio = $"Interrompo l'operazione di {operazione}";
                            }
                            else
                            {
                                percorso = files[indice];
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
        static int Menu(string[] opzioni, string intestazione, int x, int y, bool voceUscita)
        {
            const string SEPARATOR = "========================";
            int scelta, maxValue = opzioni.Length;
            string temp = "";
            // Mi posiziono dove richiesto e inizio a scrivere l'intestazione
            Console.SetCursorPosition(x, y);
            Console.WriteLine(intestazione);
            Console.CursorLeft = x;
            Console.WriteLine(SEPARATOR);
            // Scrivo le varie opzioni
            for (int i = 1; i <= opzioni.Length; i++)
            {
                Console.CursorLeft = x;
                Console.WriteLine("{0}. {1}", i, opzioni[i - 1]);
            }
            // Stampo l'opzione di uscita (Se nel menù iniziale)
            if (voceUscita)
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
        static string[] GetNames(string[] filesPath)
        {
            string[] names = new string[filesPath.Length];
            for (int i = 0; i < filesPath.Length; i++)
            {
                names[i] = Path.GetFileName(filesPath[i]);
            }
            return names;
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
        static void ScriviLog(string path, string testo)
        {
            StreamWriter sw;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
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
            while (!sr.EndOfStream)
            {
                Console.WriteLine(linea);
                linea = sr.ReadLine();
            }
            sr.Close();
        }
        static void EsportaCSV(List<Anagrafica> comune, string directory)
        {
            StreamWriter sw = new StreamWriter(directory + "data.csv");
            sw.WriteLine("Nome,Cognome,Data di Nascita,Luogo di Nascita,Sesso,Stato Civile,Cittadinanza,Codice Fiscale");
            foreach (Anagrafica p in comune)
            {
                sw.WriteLine($"{p.nome},{p.cognome},{p.dataNascita.ToShortDateString()},{p.luogoNascita},{p.sesso},{p.statoCivile},{p.cittadinanza},{p.codiceFiscale}");
            }
            sw.Close();
        }
        static void ImportaCSV(List<Anagrafica> comune, string directory)
        {
            StreamReader sr = File.OpenText(directory + "data.csv");
            string linea;
            string[] campi;
            sr.ReadLine();
            linea = sr.ReadLine();
            while (linea != null)
            {
                campi = linea.Split(',');
                if (!comune.Exists(p => p.codiceFiscale == campi[7]))
                {
                    comune.Add(new Anagrafica()
                    {
                        nome = campi[0],
                        cognome = campi[1],
                        dataNascita = DateTime.Parse(campi[2]),
                        luogoNascita = campi[3],
                        sesso = (Sesso)Enum.Parse(typeof(Sesso), campi[4]),
                        statoCivile = (StatoCivile)Enum.Parse(typeof(StatoCivile), campi[5]),
                        cittadinanza = campi[6],
                        codiceFiscale = campi[7]
                    });
                }
                linea = sr.ReadLine();
            }
            sr.Close();
        }
    }
}
