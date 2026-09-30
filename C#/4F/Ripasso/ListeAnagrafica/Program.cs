using System;
using System.Collections.Generic;

namespace ListeAnagrafica
{
    internal class Program
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
            List<Anagrafica> comune = new List<Anagrafica>() {
                new Anagrafica { nome = "Agostino", cognome = "Rizzi", luogoNascita = "Castagnaro", cittadinanza = "Italiana", codiceFiscale = "RZZGTN15L28C041W", dataNascita = DateTime.Parse("28/07/1915")},
                new Anagrafica { nome = "Maria", cognome = "Ferrari", luogoNascita = "Brasile", cittadinanza = "Brasiliana", codiceFiscale = "FRRMRA96R42Z602R", dataNascita = DateTime.Parse("02/10/1896"), sesso=Sesso.Femmina, statoCivile=StatoCivile.Coniugato },
                new Anagrafica { nome = "Solidea", cognome = "Monco", luogoNascita = "Villaova del Ghebbo", cittadinanza = "Italiana", codiceFiscale = "MNCCST89E55L985V", dataNascita = DateTime.Parse("15/05/1889"), sesso=Sesso.Femmina, statoCivile=StatoCivile.Coniugato },
                new Anagrafica()
            };

            Console.WriteLine("Len: {0} - Cap: {1}", comune.Count, comune.Capacity);
            Anagrafica impiegato = new Anagrafica { nome = "Luigi", cognome = "Paiato", luogoNascita = "Lendinara", cittadinanza = "Italiana", codiceFiscale = "PTALGU21E14E522O", dataNascita = DateTime.Parse("14/05/1921"), statoCivile = StatoCivile.Coniugato };
            comune.Add(impiegato);
            comune.Add(new Anagrafica { nome = "Atanasio", cognome = "Beghetto", luogoNascita = "Lendinara", cittadinanza = "Italiana", codiceFiscale = "BGHTNS85H10E522R", dataNascita = DateTime.Parse("10/06/1885"), statoCivile = StatoCivile.Divorziato });
            // comune[0].nome = "ciao" --> Not possible
            Console.WriteLine("Len: {0} - Cap: {1}", comune.Count, comune.Capacity);

            Console.WriteLine();
            Console.WriteLine("{0,-14} {1,-14} {2,-32} {3,-9} {4,-13} {5,-14} {6}", "Nome", "Cognome", "Nascita", "Sesso", "Stato Civile", "Cittadinanza", "Codice Fiscale");
            foreach (Anagrafica e in comune)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("{0,-14} {1,-14} {2,-32} {3,-9} {4,-13} {5,-14} {6}", "Nome", "Cognome", "Nascita", "Sesso", "Stato Civile", "Cittadinanza", "Codice Fiscale");
            for (int i = 0; i < comune.Count; i++)
            {
                Console.WriteLine(comune[i]);
            }
            Console.WriteLine();
            Console.Write("Premi un tasto per uscire . . .");
            Console.ReadKey(true);
        }
    }
}
