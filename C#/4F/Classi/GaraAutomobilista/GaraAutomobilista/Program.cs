using System;
using System.Net.NetworkInformation;

namespace GaraAutomobilista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gara gara = new Gara("Germania", 3);
            string[] opzioni = { "Inserimento", "Visualizza Gara", "Avvia Gara" };
            int scelta;
            Console.Title = "Scuderia Scotti";

            gara.Add(new Auto(new Pilota("Albert", "Monet"), "Alfa Romeo"));
            gara.Add(new Auto(new Pilota("Boicot", "Amah"), "Ferrari"));
            gara.Add(new Auto(new Pilota("Micole", "Joshua"), "Tesla"));
            do
            {
                Console.Clear();
                Console.WriteLine();
                scelta = Menu(opzioni, "Scuderia Scotti", true);
                if (scelta != opzioni.Length)
                {
                    Console.Clear();
                    Console.WriteLine("{0}:\r\n", opzioni[scelta]);
                    Scelte(scelta, gara);
                    Console.WriteLine();
                    Console.Write("Premi un tasto per continuare . . .");
                    Console.ReadKey(true);
                }
            } while (scelta != opzioni.Length);
        }
        static void Scelte(int scelta, Gara gara)
        {
            if (scelta != 0 && gara.Vuota)
            {
                Console.WriteLine("Non ci sono partecipanti alla gara");
            }
            else
            {
                switch (scelta)
                {
                    case 0:
                        if (gara.Piena)
                        {
                            Console.WriteLine("Non ci sono più posti disponibili nella gara");
                        }
                        else
                        {
                            try
                            {
                                if (Inserimento(gara))
                                {
                                    Console.WriteLine("Il pilota è già presente");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;
                    case 1:
                        gara.Visualizza();
                        break;
                    case 2:
                        gara.Avvia();
                        Console.WriteLine("Gara simulata, controlla i risultati");
                        break;
                }
            }
        }
        static bool Inserimento(Gara gara)
        {
            Auto auto;
            string nome, cognome, scuderia;
            nome = InserimentoTesto("Inserisci il nome del partecipante: ");
            cognome = InserimentoTesto("Inserisci il cognome del partecipante: ");
            scuderia = InserimentoTesto("Inserisci la scuderia del partecipante: ");
            auto = new Auto(new Pilota(nome, cognome), scuderia);
            if (gara.Exists(auto))
            {
                return true;
            }
            gara.Add(auto);
            return false;
        }
        public static string InserimentoTesto(string messaggio, bool numeri = false)
        {
            string valore;
            do
            {
                Console.Write(messaggio);
                Console.CursorVisible = true;
                valore = Console.ReadLine();
                Console.CursorVisible = false;
                foreach (char c in valore)
                {
                    if ((numeri && !char.IsLetterOrDigit(c)) || (!numeri && !char.IsLetter(c)))
                    {
                        valore = "";
                        break;
                    }
                }
            } while (valore == "");
            return char.ToUpper(valore[0]) + valore.Substring(1);
        }
        static int Menu(string[] opzioni, string titolo, bool OpzioneUscita = false)
        {
            int scelta;
            int sceltaMassima = opzioni.Length;
            Console.WriteLine(titolo);
            Console.WriteLine("=========================");
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, opzioni[i]);
            }
            if (OpzioneUscita)
            {
                Console.WriteLine("{0}. Esci", ++sceltaMassima);
            }
            Console.WriteLine("=========================");
            do
            {
                Console.Write("Seleziona un opzione valida: ");
                Console.CursorVisible = true;
                int.TryParse(Console.ReadLine(), out scelta);
                Console.CursorVisible = false;
            } while (scelta < 1 || scelta > sceltaMassima);
            return scelta - 1;
        }
    }
}
