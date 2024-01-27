using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Security.Authentication;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MenuAnagrafe
{
    internal class Smenu
    {
        internal class Program
        {
            enum Sesso
            {
                Maschio, Femmina,
            }
            enum Stato
            {
                Libero, Occupato, Cancellato
            }

            enum StatoCivile
            {
                Celibe, Nubile, Coniugato, Divorziato, Separato
            }

            struct Anagrafica
            {
                public string nome;
                public string cognome;
                public DateTime dataNascita;
                public Sesso sesso;
                public StatoCivile statocivile;
                public string cittadinanza;
                public string codiceFiscale;//QIUXNG05T26Z210S
                public Stato stato;
                public static void Ciccio()
                {
                    Console.WriteLine(null ?? "ciao");
                }
            }

            static void Main(string[] args)
            {
                HttpClient x = new HttpClient();
                Task<HttpResponseMessage> a = x.GetAsync("https://google.com");
                Console.WriteLine(a.Result);
                Console.ReadLine();
                const int max = 4;
                Console.WriteLine("");
                List<Anagrafica> persone = new List<Anagrafica>();
                int i = 0, pos = 0;

                CWriteLine("Ciao");
                Console.ReadLine();

                string titolo = "=====ANAGRAFICA=====";
                string[] opzioni = new string[] { "Inserimento", "Visualizza", "Modifica S.Civile", "Calcola età", "Cancella", "Esci" };
                Menu(opzioni, titolo, 10, 0, ConsoleColor.White, ConsoleColor.Green, ConsoleColor.Blue, persone, i, pos, max);
            }
            static void CWriteLine(string text)
            {
                if (!false)
                {
                    try
                    {
                        throw new BadImageFormatException(null ?? text);
                    }
                    catch (BadImageFormatException e)
                    {
                        Console.WriteLine(null ?? e.Message);
                    }
                }
            }
            static void Menu(string[] opzioni, string titolo, int x, int y, ConsoleColor coloreTitolo, ConsoleColor coloreTesto, ConsoleColor coloreSfondo, List<Anagrafica> persone, int i, int pos, int max)
            {
                int temp = y;
                int scelta;
                int prova;
                y = temp;
                Console.ForegroundColor = coloreTitolo;
                Console.BackgroundColor = coloreSfondo;
                Console.Clear();
                do
                {

                    GiustificaOpzione(opzioni, ref y, titolo);
                    do
                    {
                        prova = Convert.ToInt32(Console.ReadLine());
                    } while (prova < 1 || prova > opzioni.Length);
                    if (prova != opzioni.Length)
                    {
                        scelta = prova;
                        Opzione(scelta, persone, ref i, pos);
                    }
                } while (prova != opzioni.Length);
            }
            static void Opzione(int scelta, List<Anagrafica> persone, ref int i, int pos)
            {
                Anagrafica p1 = new Anagrafica();
                string cf;
                StatoCivile stato = StatoCivile.Coniugato;
                switch (scelta)
                {
                    case 1:
                        Inserimento(persone, ref i);
                        break;
                    case 2:
                        Visualizza(persone);
                        break;
                    case 3:
                        Console.WriteLine("l'inserisci il tuo codice fiscale");
                        cf = Console.ReadLine();
                        if (IdVerififca(ref cf, persone, out pos))
                        {
                            Console.WriteLine("Sei Nubile(1) Coniugato/a(2) Divorziata/o(3) Separato/a(4) Celibe(5) ");
                            p1.statocivile = CambioStatoCivile(stato);
                        }
                        else
                        {
                            Console.WriteLine("Id invalido");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:

                        Console.WriteLine("inserisci il tuo id");
                        cf = Console.ReadLine();
                        if (IdVerififca(ref cf, persone, out pos))
                        {
                            Console.WriteLine($"L'età della persona corrispondente al codice fiscale inserito è {ContaEtà(pos, persone)}");
                        }
                        else
                        {
                            Console.WriteLine("codice fiscale invalido");
                        }
                        break;
                    case 5:

                        Console.WriteLine("inserisci il tuo codice fiscale");
                        cf = Console.ReadLine();
                        if (IdVerififca(ref cf, persone, out pos))
                        {
                            persone = Cancella(pos, persone);
                        }
                        else
                        {
                            Console.WriteLine("codice fiscale invalido");
                        }
                        break;
                }
            }
            static void GiustificaOpzione(string[] frase, ref int y, string TITOLO)
            {
                Console.SetCursorPosition(10, 0);
                Console.WriteLine(TITOLO);
                y++;
                for (int i = 0; i < frase.Length; i++)
                {
                    Console.SetCursorPosition(10, i + 1);
                    Console.WriteLine($"[{i + 1}] {frase[i]} ");
                    y++;
                }
            }
            static bool ControlloIns(string cognome, string nome, out string stringa, int n, List<Anagrafica> persone)
            {
                if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(nome))
                {
                    stringa = null;
                    return false;
                }
                for (int i = 0; i < persone.Count; i++)
                {
                    if (persone[i].nome == nome && persone[i].cognome == cognome)
                    {
                        stringa = null;
                        return false;
                    }
                }

                stringa = cognome;
                return true;
            }
            static List<Anagrafica> Inserimento(List<Anagrafica> persone, ref int i)
            {
                Anagrafica p1 = new Anagrafica();
                bool ok;
                string data, cf, nome = "", cognome = "";
                int anno, mese, giorno, pos;
                Sesso tipo;
                if (i < 3)
                {
                    Console.Clear();
                    StatoCivile stato = StatoCivile.Separato;
                    do
                    {
                        Console.WriteLine("Inserisci il tuo nome");
                        nome = Console.ReadLine();
                        Console.WriteLine("Inserisci il tuo cognome");
                        cognome = Console.ReadLine();
                    } while (!ControlloIns(cognome, nome, out p1.cognome, 2, persone));
                    do
                    {
                        Console.WriteLine("Inserisci la tua data di nascità");
                        data = Console.ReadLine();
                        EstraiData(data, out anno, out mese, out giorno);
                        ok = VerfificaData(anno, mese, giorno);
                    } while (ok);
                    p1.dataNascita = Convert.ToDateTime(data);
                    Console.WriteLine("Inserisci la tua cittadinanza");
                    p1.cittadinanza = Console.ReadLine();
                    Console.WriteLine("Sei Nubile(1) Coniugato/a(2) Divorziata/o(3) Separato/a(4) Celibe(5) ");
                    p1.statocivile = CambioStatoCivile(stato);
                    Console.WriteLine("che sesso sei? Maschio [1] o femmina [2]");
                    int scelta = Convert.ToInt32(Console.ReadLine());
                    p1.sesso = gender(scelta, out tipo);
                    do
                    {
                        Console.WriteLine("inserisci il tuo Id fiscale");
                        cf = Console.ReadLine();
                    } while (IdVerififca(ref cf, persone, out pos));
                    p1.codiceFiscale = cf;
                    i++;
                    persone.Add(p1);
                }
                else
                {
                    Console.WriteLine("Non ce più spazio per l'inserimento");
                }
                Console.ReadLine();
                Console.Clear();

                return persone;
            }
            static bool IdVerififca(ref string cf, List<Anagrafica> persone, out int pos)
            {
                pos = 0;
                for (int i = 0; i < persone.Count; i++)
                {
                    if (Convert.ToString(cf) == persone[i].codiceFiscale)
                    {
                        pos = i;
                        return true;
                    }
                }
                return false;
            }
            static void EstraiData(string data2, out int anno2, out int mese2, out int giorno2)
            {
                string[] array = data2.Split('/');
                giorno2 = Convert.ToInt32(array[0]);
                mese2 = Convert.ToInt32(array[1]);
                anno2 = Convert.ToInt32(array[2]);
            }
            static void Visualizza(List<Anagrafica> persone)
            {
                Console.WriteLine("=============================================================================");
                for (int i = 0; i < persone.Count; i++)
                {
                    if (String.IsNullOrWhiteSpace(persone[i].nome) && String.IsNullOrEmpty(persone[i].cognome))
                    {
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("nome:{0}", persone[i].nome);
                        Console.WriteLine("cognome:{0}", persone[i].cognome);
                        Console.WriteLine("nascità:{0}", persone[i].dataNascita.ToShortDateString().ToString());
                        Console.WriteLine("stato civile:{0}", persone[i].statocivile.ToString());
                        Console.WriteLine("sesso:{0}", persone[i].sesso.ToString());
                        Console.WriteLine("cittadinanza:{0}", persone[i].cittadinanza);
                        Console.WriteLine("codice fiscale:{0}", persone[i].codiceFiscale);
                        Console.WriteLine("=============================================================================");
                    }
                }
                Console.ReadLine();
                Console.Clear();
            }
            static List<Anagrafica> Cancella(int pos, List<Anagrafica> persone)
            {
                persone[pos] = new Anagrafica();
                Console.Clear();
                return persone;
            }
            static int ContaEtà(int pos, List<Anagrafica> persone)
            {
                int eta = DateTime.Now.Year - persone[pos].dataNascita.Year - 1; // calcolo età
                if (DateTime.Now.Month >= persone[pos].dataNascita.Month && DateTime.Now.Day > persone[pos].dataNascita.Day) // verifica del mese e del giorno
                {
                    eta++;
                }
                return eta;
            }
            static StatoCivile CambioStatoCivile(StatoCivile stato)
            {
                bool controllo;
                int opzione = 0;
                do
                {
                    try
                    {
                        controllo = false;
                        opzione = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        controllo = true;
                    }
                } while (controllo == true);
                switch (opzione)
                {
                    case 1:
                        stato = StatoCivile.Nubile;
                        break;
                    case 2:
                        stato = StatoCivile.Coniugato;
                        break;
                    case 3:
                        stato = StatoCivile.Divorziato;
                        break;
                    case 4:
                        stato = StatoCivile.Separato;
                        break;
                    case 5:
                        stato = StatoCivile.Celibe;
                        break;
                }
                return stato;
            }
            static Sesso gender(int scelta, out Sesso tipo)
            {
                tipo = Sesso.Maschio;
                switch (scelta)
                {
                    case 2:
                        tipo = Sesso.Femmina;
                        break;
                }
                return tipo;
            }
            static bool VerfificaData(int anno, int mese, int giorno)
            {
                bool controllo = false;
                if (anno < 0)
                {
                    controllo = true;
                }
                else if (mese < 0 || mese > 12)
                {
                    controllo = true;
                }
                if (mese == 1 || mese == 3 || mese == 5 || mese == 7 || mese == 8 || mese == 10 || mese == 12)
                {
                    if (Convert.ToInt32(giorno) > 31)
                    {
                        controllo = true;
                    }
                }
                else if (mese == 4 || mese == 6 || mese == 7 || mese == 11)
                {
                    if (Convert.ToInt32(giorno) > 30)
                    {
                        controllo = true;
                    }
                }
                else if (mese == 2)
                {
                    if (Convert.ToInt32(giorno) > 29)
                    {
                        controllo = true;
                    }
                }
                return controllo;
            }
        }
    }
}
//si vuole scegliere uno dei file di log presenti all'interno della directory di lavoro dall'elenco dei file all'interno della stessa
//i file dovranno essere visualizzati utilizzando il metodo menù dal quale l'utente può scegliere uno dei file di log.