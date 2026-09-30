using System;

namespace BreakFrase
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxRiga = 80;
            string frase;
            do
            {
                Console.WriteLine("Inserisci la frase: ");
                frase = Console.ReadLine();
            } while (frase == "");
            Console.WriteLine();
            WriteWrap(frase, maxRiga);
            Console.ReadLine();
        }
        // Definizione: stampa la frase e la divide in righe di massimo max parole
        // Parametri:
        // Input: stringa contenente la frase, lunghezza massima delle right
        // Output: void
        static private void WriteWrap(string frase, int max)
        {
            string line = "";
            foreach (string parola in RemoveSpace(frase).Split(' '))
            {
                if (line.Length + parola.Length > max)
                {
                    Giustifica80(line.Remove(line.Length - 1), max);
                    line = "";
                }
                line += parola;
                line += " ";
            }
            Giustifica80(line.Remove(line.Length - 1), max);
        }
        // Definizione: Giustifica la riga data e la stampa
        // Parametri:
        // Input: stringa contenente la riga, lunghezza della stringa
        // Output: void
        static private void Giustifica80(string line, int max)
        {
            int i = line.IndexOf(' '), times = 2;
            if (i != -1)
            {
                while (line.Length != max)
                {
                    if (i == -1)
                    {
                        times++;
                        i = line.IndexOf(' ');
                    }
                    line = line.Insert(i, " ");
                    i = line.IndexOf(' ', i + times);
                }
            }
            Console.WriteLine(line);
        }
        // Definizione: rimuove gli spazi superflui
        // Parametri:
        // Input: stringa contenente la frase
        // Output: stringa contenente la frase senza spazi
        static private string RemoveSpace(string frase)
        {
            frase = frase.Trim();
            int i = frase.IndexOf("  ");
            while (i != -1)
            {
                frase = frase.Remove(i, 1);
                i = frase.IndexOf("  ");
            }
            return frase;
        }
    }
}