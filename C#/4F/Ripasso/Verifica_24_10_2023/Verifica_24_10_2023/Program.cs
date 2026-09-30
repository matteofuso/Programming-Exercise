using System;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Verifica_24_10_2023
{
    struct Studente
    {
        public string cognome;
        public string nome;
        public double voto;
        public DateTime dataNascita;
        public override string ToString()
        {
            return string.Format("{0,-20} {1,-20} {2,-20} {3,-20}", cognome, nome, voto, dataNascita.ToShortDateString());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Fuso Matteo - 4F - 24/10/2023 - Fila A
            // Dichiarazione e inizializzazione variabili
            const int max = 5;
            int elementi = 0, scelta;
            string[] opzioni = { "Inserimento", "Visualizza", "Visualizza Maggiorenni", "Esci" };
            Studente[] classe = new Studente[max];
            // Menu
            do
            {
                // Chiedo la scelta con un metodo
                scelta = Menu(opzioni);
                // Controllo che non sia l'uscita
                if (scelta != opzioni.Length - 1)
                {
                    Console.WriteLine();
                    // Processo la scelta
                    switch (scelta)
                    {
                        case 0:
                            // Inserimento
                            // Guardo se la classe non è già piena
                            if (elementi != classe.Length)
                            {
                                Inserimento(classe, ref elementi);
                            }
                            else
                            {
                                Console.WriteLine("Classe già piena");
                            }
                            break;
                        case 1:
                            // Visualizzazione
                            // Contollo che la classe non sia vuota
                            if (elementi != 0)
                            {
                                Visualizza(classe, elementi, false);
                            }
                            else
                            {
                                Console.WriteLine("Classe vuota");
                            }
                            break;
                        case 2:
                            // Visualizzazione maggiorenni
                            // Controllo che la classe non sia vuota
                            if (elementi != 0)
                            {
                                Visualizza(classe, elementi, true);
                            }
                            else
                            {
                                Console.WriteLine("Classe vuota");
                            }
                            break;
                    }
                    // Chiedo l'invio per continuare
                    Console.WriteLine();
                    Console.Write("Premi invio per continuare . . .");
                    Console.ReadLine();
                }
                // Esco se l'opzione è l'ultima
            } while (scelta != opzioni.Length - 1);
        }
        static bool Presente(string nome, string cognome, Studente[] classe, int elementi)
        {
            // Ciclo l'array fino dove è pieno
            for (int i = 0; i < elementi; i++)
            {
                // Controllo nome e cognome
                if (nome == classe[i].nome && cognome == classe[i].cognome)
                {
                    return true;
                }
            }
            return false;
        }
        static void Visualizza(Studente[] classe, int elementi, bool maggiorenni)
        {
            // Stampo l'instestazione
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Cognome", "Nome", "Voto", "Data di Nascita");
            for (int i = 0; i < elementi; i++)
            {
                // Se voglio visualizzare solo i maggiorenni
                if (maggiorenni)
                {
                    if (Maggiorenne(classe[i].dataNascita))
                    {
                        Console.WriteLine(classe[i]);
                    }
                }
                // Se voglio visualizzare tutti gli elementi
                else
                {
                    Console.WriteLine(classe[i]);
                }
            }
        }
        static bool Maggiorenne(DateTime datanascita)
        {
            DateTime adesso = DateTime.Now;
            int età = adesso.Year - datanascita.Year;
            // Se il mese di nascicta è maggiore o uguale, l'utente deve ancora compiere gli anni
            if (datanascita.Month >= adesso.Month)
            {
                // Se il mese di nascicta è maggiore o uguale or il giorno è minore, allore l'utente deve ancora compiere gli anni
                if (adesso.Month > datanascita.Month || adesso.Day <= datanascita.Day)
                {
                    età--;
                }
            }
            return età >= 18;
        }
        static void Inserimento(Studente[] classe, ref int elementi)
        {
            bool conversione;
            // Chiedo nome e cognome
            classe[elementi].nome = InserimentoTesto("Inserisci il nome: ");
            classe[elementi].cognome = InserimentoTesto("Inserisci il cognome: ");
            // Controllo se è presente e continuo in caso affermativo
            if (!Presente(classe[elementi].nome, classe[elementi].cognome, classe, elementi))
            {
                // Controllo il voto tramite un try catch, il metodo inserimento voto solleva un eccezzione
                do
                {
                    try
                    {
                        classe[elementi].voto = InserimentoVoto();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        // Metto il voto a -1 così il ciclo continua
                        classe[elementi].voto = -1;
                    }
                } while (classe[elementi].voto == -1);
                // Chiedo e Controllo la data di nascita
                do
                {
                    Console.Write("Inserisci la data di nascita: ");
                    conversione = DateTime.TryParse(Console.ReadLine(), out classe[elementi].dataNascita);
                } while (!conversione || classe[elementi].dataNascita == DateTime.Now);
                // Incremento di uno il numero di elementi
                elementi++;
                Console.WriteLine();
                Console.WriteLine("Inserimento effettuato con successo!");
            }
            else
            {
                Console.WriteLine("Elemento già presente");
            }
        }
        static double InserimentoVoto()
        {
            double voto = 0;
            // Chiedo di inserire il voto
            Console.Write("Inserisci il voto: ");
            // Se il parse solleva un eccezione, la conversione non è possibile
            try
            {
                voto = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                throw new Exception("Formato voto non valido");
            }
            // Se il voto non è accettabile, sollevo un eccezione
            if (voto < 0 || voto > 10)
            {
                throw new Exception("Voto non valido");
            }
            return voto;
        }
        static string InserimentoTesto(string messaggio)
        {
            string valore;
            // Controllo che la stringa non sia vuota e che contenga solo lettere
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
            return valore;
        }
        static int Menu(string[] opzioni)
        {
            int scelta;
            Console.Clear();
            Console.WriteLine("Seleziona l'operazione:");
            // Stampo le scelta
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, opzioni[i]);
            }
            // Controllo che mi sia stato dato un valore accettabile
            do
            {
                Console.Write("Seleziona un opzione valida: ");
                int.TryParse(Console.ReadLine(), out scelta);
            } while (scelta < 1 || scelta > opzioni.Length);
            return scelta - 1;
        }
    }
}
