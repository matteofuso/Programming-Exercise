using System;
using System.IO;

namespace FlottaAuto
{
    internal class Gestione
    {
        static string path = Path.Combine(Environment.CurrentDirectory, "data");
        public static string BasePath
        {
            get { return path; }
        }
        // Inserimento
        public static int Menu(string[] opzioni, string titolo, bool OpzioneUscita)
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
            scelta = InserimentoIntero("Seleziona un opzione valida: ", 1, sceltaMassima);
            return scelta - 1;
        }
        public static int Menu(string[] opzioni, string titolo)
        {
            return Menu(opzioni, titolo, false);
        }
        public static string InserimentoTesto(string messaggio)
        {
            string valore;
            do
            {
                Console.Write(messaggio);
                Console.CursorVisible = true;
                valore = Console.ReadLine().Trim();
                Console.CursorVisible = false;
            } while (valore == "");
            return char.ToUpper(valore[0]) + valore.Substring(1);
        }
        public static int InserimentoIntero(string messaggio, int valoreMinimo = 0, int valoreMassimo = int.MaxValue)
        {
            int valore;
            do
            {
                Console.CursorVisible = false;
                Console.Write(messaggio);
                Console.CursorVisible = true;
            } while (!int.TryParse(Console.ReadLine(), out valore) || valore < valoreMinimo || valore > valoreMassimo);
            Console.CursorVisible = false;
            return valore;
        }
        public static bool IsTarga(string targa)
        {
            if (targa.Length != 7)
            {
                return false;
            }
            for (int i = 0; i < targa.Length; i++)
            {
                if (i > 1 && i < 5) // 01 234 56
                {
                    if (!char.IsDigit(targa[i]))
                    {
                        return false;
                    }
                }
                else if (!char.IsLetter(targa[i]))
                {
                    return false;
                }
            }
            return true;
        }
        // Log
        public static string SceltaLog()
        {
            string directory = Path.Combine(path, "log");
            string[] paths;
            if (!Directory.Exists(directory))
            {
                return null;
            }
            paths = Directory.GetFiles(directory, "*.log");
            if (paths.Length == 0)
            {
                return null;
            }
            string[] filenames = new string[paths.Length];
            for (int i = 0; i < paths.Length; i++)
            {
                filenames[i] = Path.GetFileName(paths[i]);
            }
            return paths[Menu(filenames, "Sciegli il file di log da aprire", false)];
        }
        public static void ControlloDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        public static void ScriviLog(string messaggio)
        {
            string directory = Path.Combine(path, "log");
            ControlloDirectory(directory);
            StreamWriter stream = new StreamWriter(Path.Combine(directory, DateTime.Now.ToShortDateString().Replace('/', '_') + ".log"), true);
            stream.WriteLine("{0} {1}", DateTime.Now, messaggio);
            stream.Close();
        }
        public static void LeggiFile(string path)
        {
            StreamReader stream = new StreamReader(path);
            while (!stream.EndOfStream)
            {
                Console.WriteLine(stream.ReadLine());
            }
            stream.Close();
        }
        // CSV
        public static void Esporta(Flotta flotta)
        {
            ControlloDirectory(path);
            flotta.Esporta(Path.Combine(path, string.Format("export.csv", flotta.AutorizzazioneStatale, flotta.Nome)));
        }
        public static void Importa(Flotta flotta)
        {
            ControlloDirectory(path);
            flotta.Importa(Path.Combine(path, string.Format("export.csv", flotta.AutorizzazioneStatale, flotta.Nome)));
        }
    }
}
