using Banca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntesaSanPaolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banca banca = new Banca("Intesa SanPaolo");
            string[] opzioni = new string[] { "Aggiungi Conto", "Versamento", "Prelievo", "Stampa banca" };
            Console.Title = "Intesa SanPaolo";
            int scelta;
            do
            {
                Console.Clear();
                scelta = Gestione.Menu(opzioni, "Gestione Banca");
                if (scelta != opzioni.Length)
                {
                    Console.Clear();
                    Console.WriteLine("{0}:", opzioni[scelta]);
                    Console.WriteLine();
                    GestioneScelta(banca, scelta);
                    Console.WriteLine();
                    Console.Write("Premi un tasto per uscire . . .");
                    Console.ReadKey();
                }
            } while (scelta != opzioni.Length);
        }
        static void GestioneScelta(Banca banca, int scelta)
        {
            int id;
            double movimento;
            if (scelta == 0 || banca.NumeroConti != 0)
            {
                switch (scelta)
                {
                    case 0:
                        // Inserimento
                        InserimentoArticolo(banca);
                        break;
                    case 1:
                        // Carico
                        try
                        {
                            id = Gestione.InserimentoIntero("Inserisci il numero di conto: ");
                            movimento = Gestione.InserimentoDouble("Inserisci la quantità da versare: ");
                            banca.Versamento(id, movimento);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        // Scarico
                        try
                        {
                            id = Gestione.InserimentoIntero("Inserisci il numero di conto: ");
                            movimento = Gestione.InserimentoDouble("Inserisci la quantità da versare: ");
                            banca.Prelievo(id, movimento);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        // Stampa
                        banca.Stampa();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Non ci sono conti nella banca");
            }
        }
        static void InserimentoArticolo(Banca banca)
        {
            string nome = Gestione.InserimentoStringa("Inserisci il nome del correntista: ");
            string cognome = Gestione.InserimentoStringa("Inserisci il cognome del correntista: ");
            banca.Add(new ContoCorrente(nome, cognome));
        }

    }
}
