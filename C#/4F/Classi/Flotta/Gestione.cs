using Microsoft.SqlServer.Server;
using System;
using System.IO;

namespace FlottaDiAuto

{
    static internal class Gestione
    {
        public static string path = Path.Combine(Environment.CurrentDirectory, "data");
        public static int Menu(string[] opzioni, string titolo = "Scegli un opzione", bool OpzioneUscita = false)
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
        public static string InserimentoTesto(string messaggio, bool caratteriSpeciali = true)
        {
            string valore;
            do
            {
                Console.Write(messaggio);
                Console.CursorVisible = true;
                valore = Console.ReadLine().Trim();
                Console.CursorVisible = false;
                if (!caratteriSpeciali)
                {
                    foreach (char c in valore)
                    {
                        if (!char.IsLetterOrDigit(c) && c != ' ')
                        {
                            valore = "";
                            break;
                        }
                    }
                }
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
        public static double InserimentoDouble(string messaggio, double valoreMinimo = double.MinValue, double valoreMassimo = double.MaxValue)
        {
            double valore;
            do
            {
                Console.CursorVisible = false;
                Console.Write(messaggio);
                Console.CursorVisible = true;
            } while (!double.TryParse(Console.ReadLine(), out valore) || valore < valoreMinimo || valore > valoreMassimo);
            Console.CursorVisible = false;
            return valore;
        }
        public static string ScegliLog()
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
            return paths[Menu(filenames, "Sciegli il file di log da aprire")];
        }
        public static void PreparaDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        public static void ScriviLog(string messaggio)
        {
            string directory = Path.Combine(path, "log");
            PreparaDirectory(directory);
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
    }
}
