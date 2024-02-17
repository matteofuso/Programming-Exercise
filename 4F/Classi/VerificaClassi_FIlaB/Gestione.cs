using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace VerificaClassi_FIlaB
{
    static internal class Gestione
    {
        // Menu
        public static int Menu(string[] opzioni, string titolo)
        {
            Console.WriteLine(titolo);
            Console.WriteLine("=======================");
            for (int i = 0; i < opzioni.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i + 1, opzioni[i]);
            }
            Console.WriteLine("[{0}] Esci", opzioni.Length + 1);
            Console.WriteLine("=======================");
            return InserimentoIntero("Inserisci l'opzione scelta: ", 1, opzioni.Length + 1) - 1;
        }
        // Inserimento
        public static string InserimentoStringa(string messaggio)
        {
            string value;
            do
            {
                Console.Write(messaggio);
                value = Console.ReadLine();
            } while (value == "");
            return char.ToUpper(value[0]) + value.Substring(1).ToLower();
        }
        public static int InserimentoIntero(string messaggio, int min, int max)
        {
            int value;
            do
            {
                Console.Write(messaggio);
            } while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max);
            return value;
        }
        public static double InserimentoDouble(string messaggio, double min, double max)
        {
            double value;
            do
            {
                Console.Write(messaggio);
            } while (!double.TryParse(Console.ReadLine(), out value) || value < min || value > max);
            return value;
        }
        public static int InserimentoIntero(string messaggio) { return InserimentoIntero(messaggio, int.MinValue, int.MaxValue); }
        public static double InserimentoDouble(string messaggio) { return InserimentoDouble(messaggio, 0, int.MaxValue); }
        // Log
        public static void Log(string testo)
        {
            string directory = Path.Combine(Environment.CurrentDirectory, "log");
            StreamWriter stream;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            try
            {
                stream = new StreamWriter(Path.Combine(directory,
                    DateTime.Now.ToShortDateString().Replace('/', '_') + ".log"
                    ), true);
            }
            catch (Exception)
            {
                throw new Exception("Errore nell'apertura del file di log");
            }
            stream.WriteLine("{0} {1}", DateTime.Now, testo);
            stream.Close();
        }
    }
}
