using System.Collections.Generic;
using System.IO;
using System;

namespace VerificaConListe
{
    internal class Program
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
        static void Main(string[] args)
        {
            string[] opzioni = { "Inserimento", "Visualizza", "Visualizza Maggiorenni" };
            List<Studente> classe = new List<Studente>();
            string path = Path.Combine(Environment.CurrentDirectory, "Data");
            ImportCSV(classe, path, "studenti");
            const int MassimoAlunni = 3;
            int scelta;
            do
            {
                Console.Clear();
                scelta = Menu(opzioni, true);
                Console.Clear();
                if (scelta != opzioni.Length)
                {
                    Console.WriteLine("{0}:", opzioni[scelta]);
                    Console.WriteLine();
                    Scelte(classe, scelta, MassimoAlunni, path, "studenti");
                    Console.WriteLine();
                    Console.Write("Premi un tasto per continuare . . .");
                    Console.ReadKey();
                }
            } while (scelta != opzioni.Length);
        }
        static void Scelte(List<Studente> classe, int scelta, int MassimoAlunni, string path, string filename)
        {
            if (scelta == 0 && classe.Count == MassimoAlunni)
            {
                Console.WriteLine("Agenga piena");
            }
            else if (scelta > 0 && classe.Count == 0)
            {
                Console.WriteLine("Agenda vuota");
            }
            else
            {
                switch (scelta)
                {
                    case 0:
                        if (Inserimento(classe))
                        {
                            Console.WriteLine("Inserimento completato");
                            UpdateCSV(classe, path, filename);
                        }
                        else
                        {
                            Console.WriteLine("Persona già presente");
                        }
                        break;
                    case 1:
                        Visualizza(classe);
                        break;
                    case 2:
                        if (!Visualizza(classe.FindAll(s => Maggiorenne(s.dataNascita))))
                        {
                            Console.WriteLine("Non ci sono maggiorenni");
                        }
                        break;
                }
            }
        }
        static bool Visualizza(List<Studente> classe)
        {
            if (classe.Count != 0)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Cognome", "Nome", "Voto", "Data di Nascita");
                foreach (Studente studente in classe)
                {
                    Console.WriteLine(studente);
                }
                return true;
            }
            return false;
        }
        static bool Inserimento(List<Studente> classe)
        {
            Studente studente = new Studente();
            studente.nome = InserimentoTesto("Inserisci il nome dello studente: ");
            studente.cognome = InserimentoTesto("Inserisci il cognome dello studente: ");
            if (!classe.Exists(s => s.nome == studente.nome && s.cognome == studente.cognome))
            {
                do
                {
                    Console.Write("Inserisci la media dello studente: ");
                    try
                    {
                        studente.voto = InserimentoVoto();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        studente.voto = -1;
                    }
                } while (studente.voto == -1);
                do
                {
                    Console.Write("Inserire la data di nascita: ");
                } while (!DateTime.TryParse(Console.ReadLine(), out studente.dataNascita));
                classe.Add(studente);
                return true;
            }
            return false;
        }
        static int Menu(string[] opzioni, bool OpzioneUscita)
        {
            int scelta;
            int sceltaMassima = opzioni.Length;
            Console.WriteLine();
            Console.WriteLine("Scuola:");
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
                int.TryParse(Console.ReadLine(), out scelta);
            } while (scelta < 1 || scelta > sceltaMassima);
            return scelta - 1;
        }
        static double InserimentoVoto()
        {
            double voto;
            try
            {
                voto = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                throw new Exception("Inserire un numero.");
            }
            if (voto < 0 || voto > 10)
            {
                throw new Exception("Inserisci un numero compreso tra 0 e 10.");
            }
            return voto;
        }
        static string InserimentoTesto(string messaggio)
        {
            string valore;
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
            return char.ToUpper(valore[0]) + valore.Substring(1);
        }
        static bool Maggiorenne(DateTime datanascita)
        {
            DateTime adesso = DateTime.Now;
            int età = adesso.Year - datanascita.Year;
            if (datanascita.Month >= adesso.Month)
            {
                if (adesso.Month > datanascita.Month || adesso.Day < datanascita.Day)
                {
                    età--;
                }
            }
            return età >= 18;
        }
        static void UpdateCSV(List<Studente> classe, string path, string filename)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            StreamWriter stream = new StreamWriter(Path.Combine(path, filename + ".csv"));
            stream.WriteLine("Nome,Cognome,Voto,Data di nascita");
            foreach (Studente studente in classe)
            {
                stream.WriteLine("{0},{1},{2},{3}", studente.nome, studente.cognome, studente.voto.ToString().Replace(',', '_'), studente.dataNascita.ToShortDateString());
            }
            stream.Close();
        }
        static void ImportCSV(List<Studente> classe, string path, string filename)
        {
            string line;
            string[] campi;
            if (File.Exists(Path.Combine(path, filename + ".csv")))
            {
                StreamReader stream = new StreamReader(Path.Combine(path, filename + ".csv"));
                stream.ReadLine();
                do
                {
                    line = stream.ReadLine();
                    campi = line.Split(',');
                    classe.Add(new Studente
                    {
                        nome = campi[0],
                        cognome = campi[1],
                        voto = double.Parse(campi[2].Replace('_', ',')),
                        dataNascita = DateTime.Parse(campi[3])
                    });
                } while (!stream.EndOfStream);
                stream.Close();
            }
        }
    }
}
