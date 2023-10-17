using System;
using System.IO;

namespace Anagrafe
{
    internal class Program
    {
        enum StatoCivile
        {
            Celibe,
            Nubile,
            Coniugato,
            Divorziato,
            Separato
        }
        enum Stato
        {
            Libero,
            Occupato,
            Cancellato
        }
        enum Sesso
        {
            Maschio,
            Femmina
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
            public Stato stato;
            public override string ToString()
            {
                return string.Format("{0,-14} {1,-14} {2,-32} {3,-9} {4,-13} {5,-14} {6}", nome, cognome, luogoNascita + ", " + dataNascita.ToShortDateString(), sesso, statoCivile, cittadinanza, codiceFiscale);
            }
        }
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory + "\\leaf.log";
            string[] opzioni = { "Inserimento", "Visualizzazione", "Modifica", "Eliminazione", "Calcolo età", "Stampa Log" };
            Anagrafica[] comune = {
                new Anagrafica { nome = "Agostino", cognome = "Rizzi", dataNascita = new DateTime(1915,7,28), luogoNascita = "Castagnaro", cittadinanza = "Italiana", codiceFiscale = "RZZGTN15L28C041W", stato = Stato.Cancellato},
                new Anagrafica { nome = "Maria", cognome = "Ferrari",dataNascita = new DateTime(1896,10,2) ,luogoNascita = "Brasile",sesso=Sesso.Femmina,statoCivile=StatoCivile.Coniugato, cittadinanza = "Brasiliana", codiceFiscale = "FRRMRA96R42Z602R", stato = Stato.Occupato},
                new Anagrafica { nome = "Solidea", cognome = "Monco", dataNascita = new DateTime(1889,5,15),luogoNascita = "Villaova del Ghebbo", sesso=Sesso.Femmina,statoCivile=StatoCivile.Nubile, cittadinanza = "Italiana", codiceFiscale = "MNCSLD89E55L985N", stato = Stato.Cancellato},
                new Anagrafica { nome = "Atanasio", cognome = "Beghetto", dataNascita = new DateTime(1885,6,10), luogoNascita = "Lendinara", statoCivile = StatoCivile.Divorziato, cittadinanza = "Italiana", codiceFiscale = "BGHTNS85H10E522R", stato = Stato.Occupato},
                new Anagrafica { nome = "Luigi", cognome = "Paiato", dataNascita = new DateTime(1921,5,14), luogoNascita = "Lendinara",statoCivile=StatoCivile.Coniugato, cittadinanza = "Italiana", codiceFiscale = "PTALGU21E14E522O", stato = Stato.Occupato}
            };
            int scelta, indice;
            string input;
            do
            {
                scelta = Menu(opzioni, "Comune di Rovigo", 10, 3, ConsoleColor.Gray, ConsoleColor.Black, true);
                if (scelta != opzioni.Length)
                {
                    Console.WriteLine("{0} cittadini:", opzioni[scelta]);
                    Console.WriteLine();
                    indice = PrimoIndicePerStato(comune, true, false, true);
                    if (scelta == 0)
                    {
                        if (indice == -1)
                        {
                            ScriviLog(path, "Tentativo di inserimento, agenda piena");
                            Console.WriteLine("Agenda piena");
                            scelta = -1;
                        }
                    }
                    else if (scelta != 5)
                    {
                        indice = PrimoIndicePerStato(comune, false, true, false);
                        if (indice == -1)
                        {
                            ScriviLog(path, $"Tentativo di {opzioni[scelta].ToLower()}, agenda vuota");
                            Console.WriteLine("Agenda vuota");
                            scelta = -1;
                        }
                        else if (scelta > 1)
                        {
                            do
                            {
                                Console.Write("Inserisci il codice fiscale: ");
                                input = Console.ReadLine().ToUpper();
                            } while (input.Length != 16);
                            indice = CercaCF(comune, input);
                            if (indice == -1)
                            {
                                ScriviLog(path, $"Tentativo di {opzioni[scelta].ToLower()}, persona non trovata (CF: {input})");
                                Console.WriteLine("Persona non trovata");
                                scelta = -1;
                            }
                        }
                    }
                    if (scelta != -1)
                    {
                        ScelteMenu(comune, scelta, indice, path);
                    }
                    Console.WriteLine();
                    Console.Write("Premi un tasto per continuare . . .");
                    Console.ReadKey(true);
                }
            } while (scelta != opzioni.Length);
        }
        static void ScelteMenu(Anagrafica[] comune, int scelta, int indice, string path)
        {
            switch (scelta)
            {
                case 0:
                    indice = Inserimento(comune);
                    if (indice < 1)
                    {
                        Console.WriteLine("Persona già presente");
                        ScriviLog(path, $"Tentativo di inserimento, persona già presente (CF: {comune[-indice].codiceFiscale})");
                    }
                    else
                    {
                        Console.WriteLine("Persona inserita");
                        ScriviLog(path, string.Format("{0,-20} {1}", "Inserimento persona:", comune[indice]));
                    }
                    break;
                case 1:
                    scelta = Menu(new string[] { "Persone Presenti", "Tutti gli elementi" }, "Seleziona la categoria da visualizzare: ", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, false);
                    Console.WriteLine();
                    if (scelta == 0)
                    {
                        Visualizza(comune, false, true, false);
                        ScriviLog(path, "Visualizzazione di tutte le persone presenti");
                    }
                    else
                    {
                        Visualizza(comune, true, true, true);
                        ScriviLog(path, "Visualizzazione di tutti gli elementi");
                    }
                    break;
                case 2:
                    Console.WriteLine();
                    scelta = Menu(new string[] { "Stato Civile" }, "Seleziona il campo da modificare", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, false);
                    Console.WriteLine();
                    ScriviLog(path, string.Format("{0,20} {1}", "Modifica cittadino:", comune[indice]));
                    switch (scelta)
                    {
                        case 0:
                            Modifica(comune, indice, scelta, Menu(Enum.GetNames(typeof(StatoCivile)), "Seleziona lo stato civile", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, false));
                            break;
                    }
                    ScriviLog(path, string.Format("{0,20} {1}", "->", comune[indice]));
                    break;
                case 3:
                    Elimina(comune, indice);
                    ScriviLog(path, $"Eliminazione cittadio (CF: {comune[indice].codiceFiscale})");
                    break;
                case 4:
                    Console.WriteLine("Il cittadino {0} {1} ha {2} anni", comune[indice].nome, comune[indice].cognome, CalcoloEtà(comune[indice].dataNascita, DateTime.Now));
                    ScriviLog(path, $"Calcolo età cittadino (CF: {comune[indice].codiceFiscale})");
                    break;
                case 5:
                    LeggiLog(path);
                    ScriviLog(path, "Stampo log");
                    break;
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
        static void Elimina(Anagrafica[] comune, int indice)
        {
            comune[indice].stato = Stato.Cancellato;
        }
        static void Modifica(Anagrafica[] comune, int indice, int scelta, int valore)
        {
            // Modifico
            switch (scelta)
            {
                case 0:
                    // Modifico lo stato civile
                    comune[indice].statoCivile = (StatoCivile)valore;
                    break;
            }
        }
        static void Visualizza(Anagrafica[] comune, bool libero, bool occupato, bool cancellato)
        {
            Console.WriteLine(" {0,-14} {1,-14} {2,-32} {3,-9} {4,-13} {5,-14} {6}", "Nome", "Cognome", "Nascita", "Sesso", "Stato Civile", "Cittadinanza", "Codice Fiscale");
            foreach (Anagrafica persona in comune)
            {
                if ((libero && persona.stato == Stato.Libero) || (occupato && persona.stato == Stato.Occupato) || (cancellato && persona.stato == Stato.Cancellato))
                {
                    Console.WriteLine(" {0}", persona);
                }
            }
        }
        static int Inserimento(Anagrafica[] comune)
        {
            string codiceCatastale;
            int i = PrimoIndicePerStato(comune, true, false, true), j;
            // Chiedo il nome
            do
            {
                Console.Write("Inserisci il nome: ");
                comune[i].nome = Console.ReadLine();
            } while (comune[i].nome == "");
            // Chiedo il Cognome
            do
            {
                Console.Write("Inserisci il cognome: ");
                comune[i].cognome = Console.ReadLine();
            } while (comune[i].cognome == "");
            // Chiedo la cittadinanza
            do
            {
                Console.Write("Inserisci la cittadinanza: ");
                comune[i].cittadinanza = Console.ReadLine();
            } while (comune[i].cittadinanza == "");
            // Chiedo la data di nascita
            do
            {
                Console.Write("Inserisci la data di nascita (dd/mm/aaaa): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out comune[i].dataNascita));
            // Chiedo il luogo di nasita
            do
            {
                Console.Write("Inserisci il comune o lo stato estero di nascita: ");
                comune[i].luogoNascita = Console.ReadLine();
            } while (comune[i].nome == "");
            // Chiedo il codice catastale del luogo di nascita (Per CF)
            do
            {
                Console.Write("Inserisci il Codice Catastale di {0}: ", comune[i].luogoNascita);
                codiceCatastale = Console.ReadLine();
            } while (codiceCatastale.Length != 4);
            // Chiedo il sesso
            Console.WriteLine();
            comune[i].sesso = (Sesso)Menu(Enum.GetNames(typeof(Sesso)), "Seleziona il sesso", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, false);
            // Chiedo lo stato civile
            Console.WriteLine();
            comune[i].statoCivile = (StatoCivile)Menu(Enum.GetNames(typeof(StatoCivile)), "Seleziona lo stato civile", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, false);
            // Calcolo il cofice fiscale
            comune[i].codiceFiscale = CalcolaCF(comune[i], codiceCatastale);
            // Controllo se una persona con lo stesso CF è presente
            j = CercaCF(comune, comune[i].codiceFiscale);
            if (j == -1)
            {
                comune[i].stato = Stato.Occupato;
                return i;
            }
            return -j;
        }
        static int Menu(string[] opzioni, string intestazione, int x, int y, ConsoleColor coloreTesto, ConsoleColor coloreSfondo, bool opzioneUscita)
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
                Console.WriteLine("{0}. {1}", i, opzioni[i - 1]);
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
        static int CercaCF(Anagrafica[] comune, string codiceFiscale)
        {
            for (int i = 0; i < comune.Length; i++)
            {
                if (comune[i].stato == Stato.Occupato && comune[i].codiceFiscale == codiceFiscale)
                {
                    return i;
                }
            }
            return -1;
        }
        static int PrimoIndicePerStato(Anagrafica[] comune, bool libero, bool occupato, bool cancellato)
        {
            for (int i = 0; i < comune.Length; i++)
            {
                if ((libero && comune[i].stato == Stato.Libero) || (occupato && comune[i].stato == Stato.Occupato) || (cancellato && comune[i].stato == Stato.Cancellato))
                {
                    return i;
                }
            }
            return -1;
        }
        static void ScriviLog(string path, string testo)
        {
            StreamWriter sw = File.AppendText(path);
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
    }
}