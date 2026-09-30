using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoDoppioniArr
{
    namespace ripassoStruct
    {
        enum Sesso
        {
            Maschio,
            Femmina

        }
        enum StatoCivile
        {
            Celibe, Nubile, Coniugato, Divorziato, Separato
        }
        struct Persona
        {
            public string nome;
            public string cognome;
            public DateTime dataNascita;
            public StatoCivile statoCivile;
            public Sesso sesso;
            public string cittadinanza;
            public string codiceFiscale;
            public override string ToString()
            {
                return string.Format($"{nome,-15}{cognome,-15} {dataNascita.ToShortDateString(),-15}{statoCivile.ToString(),-15}{sesso.ToString(),-10}{cittadinanza,-10}");
            }

        }
        class Program
        {
            static void Main(string[] args)
            {
                Persona cittadino;
                cittadino.nome = "";
                cittadino.cognome = "";
                cittadino.dataNascita = new DateTime();
                //cittadino.dataNascita = DateTime.Parse("31/12/2003");

                //Console.WriteLine("giorno {0}", cittadino.dataNascita.Day);
                //Console.WriteLine("mese {0}", cittadino.dataNascita.Month);
                //Console.WriteLine("anno {0}", cittadino.dataNascita.Year);
                //Console.WriteLine("giorno settimana {0}", cittadino.dataNascita.DayOfWeek);

                cittadino.statoCivile = StatoCivile.Coniugato;
                cittadino.sesso = Sesso.Maschio;
                cittadino.cittadinanza = "italiana";
                cittadino = Inserimento(cittadino);
                Visualizza(cittadino);
                Visualizza2(cittadino);
                Console.ReadLine();

            }
            static void Visualizza2(Persona cittadino)
            {
                Console.WriteLine(cittadino.ToString());
            }
            static void Visualizza(Persona cittadino)
            {
                Console.WriteLine(cittadino.nome);
                Console.WriteLine(cittadino.cognome);

                Console.WriteLine(cittadino.dataNascita.ToString());
                Console.WriteLine(cittadino.statoCivile.ToString());
                Console.WriteLine(cittadino.sesso.ToString());
                Console.WriteLine(cittadino.cittadinanza);
            }
            static Persona Inserimento(Persona cittadino)
            {
                string statoCiv, sesso;
                Console.WriteLine("Inserisci il nome");
                cittadino.nome = Console.ReadLine();
                Console.WriteLine("Inserisci il cognome");
                cittadino.cognome = Console.ReadLine();
                Console.WriteLine("Inserisci la data di nascita");
                cittadino.dataNascita = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Inserisci il sesso (Maschio o Femmina)");
                sesso = Console.ReadLine().ToLower();

                switch (sesso)
                {
                    case "maschio":
                        cittadino.sesso = Sesso.Maschio;
                        break;
                    case "femmina":
                        cittadino.sesso = Sesso.Femmina;
                        break;
                    default:
                        Console.WriteLine("Hai inserito");
                        break;
                }
                Console.WriteLine("Inserisci lo stato civile (Celibe, Nubile, Coniugato, Divorziato, Separato)");
                statoCiv = Console.ReadLine().ToLower();
                switch(statoCiv)
                {
                    case "celibe":
                        cittadino.statoCivile = StatoCivile.Celibe;
                        break;
                    case "nubile":
                        cittadino.statoCivile = StatoCivile.Nubile;
                        break;
                    case "coniugato":
                        cittadino.statoCivile = StatoCivile.Coniugato;
                        break;
                    case "divorziato":
                        cittadino.statoCivile = StatoCivile.Divorziato;
                        break;
                    case "separato":
                        cittadino.statoCivile = StatoCivile.Separato;
                        break;
                }
                Console.WriteLine("Inserisci la cittadinanza");
                cittadino.cittadinanza = Console.ReadLine();
                return cittadino;
            }
        }
    }
}