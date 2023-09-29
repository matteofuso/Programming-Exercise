using System;

namespace Anagrafe
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] opzioni = { "Inserimento", "Visualizza", "Modifica", "Esci" };
            int scelta;
            do
            {
                scelta = Menu(opzioni, "Anagrafica", 10, 2, (ConsoleColor)random.Next(0, 16), (ConsoleColor)random.Next(0, 16));
                if (scelta == opzioni.Length)
                {
                    break;
                }
                IndirizzamentoMetodi(scelta);
                Console.WriteLine();
                Console.Write("Premi un tasto per continuare . . .");
                Console.ReadKey();
            } while (true);
        }
        static void IndirizzamentoMetodi(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserimento");
                    break;
                case 2:
                    Console.WriteLine("Visualizza");
                    break;
                case 3:
                    Console.WriteLine("Modifica");
                    break;
            }
        }
        static int Menu(string[] opzioni, string intestazione, int x, int y, ConsoleColor coloreTesto, ConsoleColor coloreSfondo)
        {
            const string SEPARATOR = "========================", INPUT = "Inserisci la scelta: ";
            int scelta;
            string temp;
            Console.BackgroundColor = coloreSfondo;
            Console.ForegroundColor = coloreTesto;
            Console.Clear();
            Console.SetCursorPosition(x, y++);
            Console.Write(intestazione);
            Console.SetCursorPosition(x, y++);
            Console.Write(SEPARATOR);
            for (int i = 1; i <= opzioni.Length; i++)
            {
                Console.SetCursorPosition(x, y++);
                Console.Write("{0}. {1}", i, opzioni[i - 1]);
            }
            Console.SetCursorPosition(x, y++);
            Console.Write(SEPARATOR);
            Console.SetCursorPosition(x, y);
            Console.Write(INPUT);
            temp = Console.ReadLine();
            while (!int.TryParse(temp, out scelta) || scelta < 1 || scelta > opzioni.Length)
            {
                Console.SetCursorPosition(x + INPUT.Length, y);
                for (int i = 0; i < temp.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x + INPUT.Length, y);
                temp = Console.ReadLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            return scelta;
        }
    }
}
