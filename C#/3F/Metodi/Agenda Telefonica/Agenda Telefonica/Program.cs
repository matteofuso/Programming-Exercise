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
            const sbyte max = 1, scelte = 7;
            int scelta;
            int len = 0;
            Contatto[] agenda = new Contatto[max];
            do
            {
                Console.Clear();
                Console.WriteLine("Agenda telefonica");
                Console.WriteLine("1. Aggiungi un contatto");
                Console.WriteLine("2. Mostra elenco");
                Console.WriteLine("3. Modifica dettagli");
                Console.WriteLine("4. Elimina Contatto");
                Console.WriteLine("5. Cerca Contatto");
                Console.WriteLine("6. Espandi Agenda");
                Console.WriteLine("{0}. Esci", scelte);
                Console.WriteLine();
                do
                {
                    Console.Write("Inserisci la scelta: ");
                    while (!int.TryParse(Console.ReadLine(), out scelta))
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
                            GetContact(agenda, ref len, out agenda[len]);
                        }
                        Console.ReadLine();
                        break;
                    case 2:
                        if (!ArrayEmpty(len))
                        {
                            ShowContacts(agenda, len);
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        if (!ArrayEmpty(len))
                        {
                            Console.Write("Inserisci il numero del contatto da modificare: ");
                            if (ModificaDettagli(agenda, Console.ReadLine(), len))
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
                    case 4:
                        if (!ArrayEmpty(len))
                        {
                            Console.Write("Inserisci il numero del contatto da modificare: ");
                            if (EliminaContatto(agenda, Console.ReadLine(), ref len))
                            {
                                Console.WriteLine("Contatto eliminato con successo!");
                            }
                            else
                            {
                                Console.WriteLine("Contatto non trovato");
                            }
                        }
                        Console.ReadLine();
                        break;
                    case 5:
                        if (!ArrayEmpty(len))
                        {
                            Console.Write("Inserisci il numero del contatto da cercare: ");
                            scelta = ContactIndex(agenda, Console.ReadLine(), len);
                            if (scelta != -1)
                            {
                                Console.WriteLine("Il contatto si trova alla posizioe {0}", scelta + 1);
                            }
                            else
                            {
                                Console.WriteLine("Contatto non trovato.");
                            }
                        }
                        break;
                    case 6:
                        Console.Write("Di quanto vuoi aumentare l'agenda? ");
                        while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1)
                        {
                            Console.Write("Inserisci un numero intero positivo: ");
                        }
                        SgrandaVettore(ref agenda, scelta);
                        break;
                }
            } while (scelta != scelte);
            Console.WriteLine("Arrivederci . . .");
            Thread.Sleep(1000);
        }
        static void SgrandaVettore(ref Contatto[] origine, int quantità)
        {
            Contatto[] destinazione = new Contatto[origine.Length + quantità];
            for (int i = 0; i < origine.Length; i++)
            {
                destinazione[i] = origine[i];
            }
            origine = destinazione;
        }
        static private void GetContact(Contatto[] agenda, ref int len, out Contatto contatto)
        {
            contatto = new Contatto();
            string numero;
            do
            {
                Console.Write("Inserisci il nome: ");
                contatto.nome = Console.ReadLine();
            } while (contatto.nome == "");
            do
            {
                Console.Write("Inserisci il cognome: ");
                contatto.cognome = Console.ReadLine();
            } while (contatto.cognome == "");
            do
            {
                Console.Write("Inserisci il numero: ");
                numero = Console.ReadLine();
            } while (numero.Length != 10 || ContactIndex(agenda, numero, len) != -1);
            contatto.numero = numero;
            len++;
        }
        static private void ShowContacts(Contatto[] agenda, int len)
        {
            Console.WriteLine(" Nome           Cognome           Numero di Telefono");
            Console.WriteLine();
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine(" {0,-14} {1,-17} {2}", agenda[i].nome, agenda[i].cognome, agenda[i].numero);
            }
        }
        static private bool ModificaDettagli(Contatto[] agenda, string numero, int len)
        {
            string input;
            int i = ContactIndex(agenda, numero, len);
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
                do
                {
                    Console.Write("Inserisci il nuovo numero o premi invio continuare: ");
                    input = Console.ReadLine();
                    if (input != "")
                    {
                        agenda[i].numero = input;
                        break;
                    }
                } while (input.Length != 10 || ContactIndex(agenda, input, len) != -1);
                return true;
            }
            return false;
        }
        static private bool EliminaContatto(Contatto[] agenda, string numero, ref int len)
        {
            int i = ContactIndex(agenda, numero, len);
            if (i != -1)
            {
                for (int j = i; i < len; i++)
                {
                    agenda[i] = agenda[i + 1];
                }
                len--;
                return true;
            }
            return false;
        }
        static private int ContactIndex(Contatto[] agenda, string numero, int len)
        {
            for (int i = 0; i < len; i++)
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