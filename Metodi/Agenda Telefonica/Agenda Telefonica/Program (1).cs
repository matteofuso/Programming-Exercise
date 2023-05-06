using System;
using System.Threading;

namespace Agenda_Telefonica
{
    internal class Program
    {
        struct Contatto
        {
            public string nome, cognome, numero;
        }
        static void Main(string[] args)
        {
            const int max = 100, scelte = 4;
            byte scelta;
            int len = 0;
            Contatto[] agenda = new Contatto[max];
            do
            {
                Console.Clear();
                Console.WriteLine("Agenda telefonica");
                Console.WriteLine("1. Aggiungi un contatto");
                Console.WriteLine("2. Mostra elenco");
                Console.WriteLine("3. Modifica dettagli");
                Console.WriteLine("{0}. Esci", scelte);
                Console.WriteLine();
                do
                {
                    Console.Write("Inserisci la scelta: ");
                    while (!byte.TryParse(Console.ReadLine(), out scelta))
                    {
                        Console.Write("Inserisci un numero: ");
                    }
                } while (scelta < 1 || scelta > scelte);
                Console.WriteLine();
                switch (scelta)
                {
                    case 1:
                        if (!ArrayFull(agenda.Length, len))
                        {
                            agenda[len] = GetContact();
                            len++;
                        }
                        Console.ReadLine();
                        break;
                    case 2:
                        if (!ArrayEmpty(len))
                        {
                            ShowContacts(agenda);
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        if (!ArrayEmpty(len))
                        {
                            Console.Write("Inserisci il numero del contatto da modificare: ");
                            if (ModificaDettagli(agenda, Console.ReadLine()))
                            {
                                Console.WriteLine("Contatto modificato con successo!");
                            }
                            else
                            {
                                Console.WriteLine("Contatto non trovato");
                            }
                        }
                        Console.ReadLine();
                        break;
                }
            } while (scelta != scelte);
            Console.WriteLine("Arrivederci . . .");
            Thread.Sleep(1000);
        }
        static private Contatto GetContact()
        {
            Contatto contatto;
            Console.Write("Inserisci il nome: ");
            contatto.nome = Console.ReadLine();
            Console.Write("Inserisci il cognome: ");
            contatto.cognome = Console.ReadLine();
            Console.Write("Inserisci il numero: ");
            contatto.numero = Console.ReadLine();
            return contatto;
        }
        static private void ShowContacts(Contatto[] agenda)
        {
            Console.WriteLine(" Nome           Cognome           Numero di Telefono");
            Console.WriteLine();
            foreach (Contatto contatto in agenda)
            {
                Console.WriteLine(" {0,-14} {1,-17} {2}", contatto.nome, contatto.cognome, contatto.numero);
            }
        }
        static private bool ModificaDettagli(Contatto[] agenda, string numero)
        {
            string input;
            int i = ContactIndex(agenda, numero);
            if (i != -1)
            {
                Console.Write("Inserisci il nuovo nome o premi invio continuare: ");
                input = Console.ReadLine();
                if (input != "")
                {
                    agenda[i].nome = input;
                }
                Console.Write("Inserisci il nuovo cognome o premi invio continuare: ");
                input = Console.ReadLine();
                if (input != "")
                {
                    agenda[i].cognome = input;
                }
                Console.Write("Inserisci il nuovo numero o premi invio continuare: ");
                input = Console.ReadLine();
                if (input != "")
                {
                    agenda[i].numero = input;
                }
                return true;
            }
            return false;
        }
        static private int ContactIndex(Contatto[] agenda, string numero)
        {
            for (int i = 0; i < agenda.Length; i++)
            {
                if (agenda[i].numero == numero)
                {
                    return i;
                }
            }
            return -1;
        }
        static private bool ArrayFull(int max, int len)
        {
            if (len >= max)
            {
                Console.WriteLine("Agenda già piena!");
                return true;
            }
            return false;
        }
        static private bool ArrayEmpty(int len)
        {
            if (len == 0)
            {
                Console.WriteLine("Agenda ancora vuota!");
                return true;
            }
            return false;
        }
    }
}