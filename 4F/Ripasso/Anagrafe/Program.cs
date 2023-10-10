using System;

namespace Anagrafe
{
    class Program
    {
        enum Sesso
        {
            Maschio,
            Femmina
        }
        enum StatoCivile
        {
            Celibe, // Maschio
            Nubile, // Femmina
            Coniugato,
            Divorziato,
            Separato
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
                return string.Format("{0,-14} {1,-14} {2,-32} {3,-9} {4,-13} {5,-14} {6}", nome, cognome, luogoNascita + ", " + dataNascita.ToShortDateString(), sesso, statoCivile, cittadinanza, codiceFiscale);
            }
        }
        static void Main(string[] args)
        {
            //const int persone = 3;
            //Anagrafica[] rovigo = new Anagrafica[persone];
            string[] opzioni = { "Inserimento", "Visualizzazione", "Modifica", "Elimina", "Età" };
            int scelta, i = 0;
            string input;
            int len = 4;
            Anagrafica[] rovigo = {
                new Anagrafica { nome = "Agostino", cognome = "Rizzi", luogoNascita = "Castagnaro", cittadinanza = "Italiana", codiceFiscale = "RZZGTN15L28C041W", dataNascita = DateTime.Parse("28/07/1915")},
                new Anagrafica { nome = "Solidea", cognome = "Monco", luogoNascita = "Villaova del Ghebbo", cittadinanza = "Italiana", codiceFiscale = "MNCCST89E55L985V", dataNascita = DateTime.Parse("15/05/1889"), sesso=Sesso.Femmina, statoCivile=StatoCivile.Coniugato },
                new Anagrafica { nome = "Atanasio", cognome = "Beghetto", luogoNascita = "Lendinara", cittadinanza = "Italiana", codiceFiscale = "BGHTNS85H10E522R", dataNascita = DateTime.Parse("10/06/1885"), statoCivile = StatoCivile.Divorziato},
                new Anagrafica { nome = "Luigi", cognome = "Paiato", luogoNascita = "Lendinara", cittadinanza = "Italiana", codiceFiscale = "PTALGU21E14E522O", dataNascita = DateTime.Parse("14/05/1921"), statoCivile = StatoCivile.Coniugato}
            };
            do
            {
                scelta = Menu(opzioni, "Comune di Rovigo", 10, 2, ConsoleColor.Gray, ConsoleColor.Black, false);
                if (scelta != opzioni.Length)
                {
                    Console.WriteLine("{0} cittadino:", opzioni[scelta]);
                    Console.WriteLine();
                    if (scelta != 0)
                    {
                        if (len == 0)
                        {
                            Console.WriteLine("Anagrafica vuota");
                            scelta = -1;
                        }
                        else if (scelta != 1)
                        {
                            do
                            {
                                Console.Write("Inserisci il codice fiscale della persona: ");
                                input = Console.ReadLine().ToUpper();
                            } while (input.Length != 16);
                            i = Indice(rovigo, len, input);
                            if (i == -1)
                            {
                                Console.WriteLine("Persona non presente");
                                scelta = -1;
                            }
                        }
                    }
                    switch (scelta)
                    {
                        case 0:
                            // Inserimento
                            if (len < rovigo.Length)
                            {
                                if (!Inserimento(rovigo, ref len))
                                {
                                    Console.WriteLine("Persona già esistente");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Anagrafica Piena");
                            }
                            break;
                        case 1:
                            // Visualizzazione
                            Visualizza(rovigo, len);
                            break;
                        case 2:
                            // Modifica
                            Modifica(rovigo, i);
                            break;
                        case 3:
                            // Rimozione
                            Elimina(rovigo, i, ref len);
                            Console.WriteLine("Perona rimossa dal comune");
                            break;
                        case 4:
                            // Età
                            Console.WriteLine("Il cittadino {0} {1} ha {2} anni", rovigo[i].cognome, rovigo[i].nome, Età(rovigo[i].dataNascita));
                            break;
                    }
                    Console.WriteLine();
                    Console.Write("Premi un tasto per continuare . . .");
                    Console.ReadKey(true);
                }
            } while (scelta != opzioni.Length);
        }
        static void Elimina(Anagrafica[] comune, int indice, ref int len)
        {
            for (int i = indice; i < len - 1; i++)
            {
                comune[i] = comune[i + 1];
            }
            len--;
        }
        static int Età(DateTime nascita)
        {
            TimeSpan differenza = DateTime.Now - nascita;
            return (int)(differenza.Days / 365.25);
        }
        static void Modifica(Anagrafica[] comune, int indice)
        {
            string[] opzioni = { "Stato Civile" };
            int scelta;
            // Chiedo il campo da modificare
            Console.WriteLine();
            scelta = Menu(opzioni, "Seleziona il campo da modificare", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, true);
            Console.WriteLine();
            // Modifico
            switch (scelta)
            {
                case 0:
                    // Modifico lo stato civile
                    comune[indice].statoCivile = (StatoCivile)Menu(Enum.GetNames(typeof(StatoCivile)), "Seleziona lo stato civile", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, true);
                    break;
            }
        }
        static void Visualizza(Anagrafica[] comune, int len)
        {
            Console.WriteLine(" {0,-14} {1,-14} {2,-32} {3,-9} {4,-13} {5,-14} {6}", "Nome", "Cognome", "Nascita", "Sesso", "Stato Civile", "Cittadinanza", "Codice Fiscale");
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine(" {0}", comune[i]);
            }
        }
        static bool Inserimento(Anagrafica[] comune, ref int len)
        {
            string codiceCatastale;
            // Chiedo il nome
            do
            {
                Console.Write("Inserisci il nome: ");
                comune[len].nome = Console.ReadLine();
            } while (!ControlloStringa(comune[len].nome));
            // Chiedo il Cognome
            do
            {
                Console.Write("Inserisci il cognome: ");
                comune[len].cognome = Console.ReadLine();
            } while (!ControlloStringa(comune[len].cognome));
            // Chiedo la cittadinanza
            do
            {
                Console.Write("Inserisci la cittadinanza: ");
                comune[len].cittadinanza = Console.ReadLine();
            } while (!ControlloStringa(comune[len].cittadinanza));
            // Chiedo la data di nascita
            do
            {
                Console.Write("Inserisci la data di nascita (dd/mm/aaaa): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out comune[len].dataNascita));
            // Chiedo il luogo di nasita
            do
            {
                Console.Write("Inserisci il comune o lo stato estero di nascita: ");
                comune[len].luogoNascita = Console.ReadLine();
            } while (!ControlloStringa(comune[len].luogoNascita));
            // Chiedo il codice catastale del luogo di nascita (Per CF)
            do
            {
                Console.Write("Inserisci il Codice Catastale di {0}: ", comune[len].luogoNascita);
                codiceCatastale = Console.ReadLine();
            } while (codiceCatastale.Length != 4);
            // Chiedo il sesso
            Console.WriteLine();
            comune[len].sesso = (Sesso)Menu(Enum.GetNames(typeof(Sesso)), "Seleziona il sesso", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, true);
            // Chiedo lo stato civile
            Console.WriteLine();
            comune[len].statoCivile = (StatoCivile)Menu(Enum.GetNames(typeof(StatoCivile)), "Seleziona lo stato civile", 0, Console.CursorTop, ConsoleColor.Gray, ConsoleColor.Black, true);
            // Calcolo il cofice fiscale
            comune[len].codiceFiscale = CalcolaCF(comune[len], codiceCatastale);
            // Controllo se una persona con lo stesso CF è presente
            if (Indice(comune, len, comune[len].codiceFiscale) == -1)
            {
                len++;
                return true;
            }
            else
            {
                return false;
            }
        }
        static int Menu(string[] opzioni, string intestazione, int x, int y, ConsoleColor coloreTesto, ConsoleColor coloreSfondo, bool inserimento)
        {
            const string SEPARATOR = "========================";
            int scelta, maxValue = opzioni.Length;
            string temp = "";
            // Cambio sfondo e colore
            Console.BackgroundColor = coloreSfondo;
            Console.ForegroundColor = coloreTesto;
            // Cancello tutto se siamo sul menù iniziale
            if (!inserimento)
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
            if (!inserimento)
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
            x = Console.CursorLeft;
            y = Console.CursorTop;
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
                // Se risponde una stringa
                if (!int.TryParse(temp, out scelta))
                {
                    // Controllo se l'opzione è presente nell'array e imposto la scelta
                    for (int i = 0; i < opzioni.Length; i++)
                    {
                        if (temp == opzioni[i])
                        {
                            scelta = i + 1;
                            break;
                        }
                        else if (temp == "Esci" && !inserimento)
                        {
                            scelta = opzioni.Length + 1;
                            break;
                        }
                    }
                }
            } while (scelta < 1 || scelta > maxValue);
            // Resetto il colore di testo e sfondo
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            // Cancello tutto se siamo sul menù iniziale
            if (!inserimento)
            {
                Console.Clear();
            }
            return scelta - 1;
        }
        static string CalcolaCF(Anagrafica persona, string codiceCatastale)
        {
            // https://it.wikipedia.org/wiki/Codice_fiscale#Generazione_del_codice_fiscale
            string CF = "";
            string vocali, consonanti;
            char[] nascita = { 'A', 'B', 'C', 'D', 'E', 'H', 'L', 'M', 'P', 'R', 'S', 'T' };
            // Aggiungo il cognome
            VocaliConsonanti(persona.cognome, out vocali, out consonanti);
            CF += (consonanti + vocali + "XX").Substring(0, 3);
            // Aggiungo il nome
            VocaliConsonanti(persona.nome, out vocali, out consonanti);
            if (consonanti.Length > 3)
            {
                CF += consonanti[0];
                CF += consonanti[2];
                CF += consonanti[3];
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
        static int Indice(Anagrafica[] comune, int len, string codiceFiscale)
        {
            for (int i = 0; i < len; i++)
            {
                if (comune[i].codiceFiscale == codiceFiscale)
                {
                    return i;
                }
            }
            return -1;
        }
        static bool ControlloStringa(string str)
        {
            if (str == "")
            {
                return false;
            }
            foreach (char c in str)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
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
                    checksum += dispari[ChecksumIndex(CF[i], false)];
                }
                else
                {
                    checksum += ChecksumIndex(CF[i], true);
                }
            }
            checksum %= 26;
            return (char)(checksum + 'A');
        }
        static int ChecksumIndex(char c, bool dispari)
        {
            int i;
            if (char.IsLetter(c))
            {
                i = c - 'A' + 10;
                if (dispari)
                {
                    i -= 10;
                }
            }
            else
            {
                i = c - '0';
            }
            return i;
        }
    }
}
