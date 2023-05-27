using System;

namespace GiornoMeseAnno
{
    class Program
    {
        struct Posizione
        {
            public int x;
            public int y;
            public ConsoleColor Background;
            public ConsoleColor Foreground;
        }
        static void Main(string[] args)
        {
            int intData, giorno, mese, anno;
            Scrittura("Inserisci la data (ddmmaaaa):", 3, 2, ConsoleColor.Black, ConsoleColor.White, false);
            IntSepara(out intData, out giorno, out mese, out anno);
            Scrittura("Con numero", 3, 4, ConsoleColor.Black, ConsoleColor.White, false);
            Scrittura($"{Zeller(giorno, mese, anno)} {giorno} {NumeroAMese(mese)} {anno}", 3, 5, ConsoleColor.Black, ConsoleColor.White, false);
            Scrittura("Premi un tasto per uscire . . .", 3, 7, ConsoleColor.Black, ConsoleColor.White, false);
            Console.ReadKey();
        }
        static Posizione PreparaCursore(int x, int y, ConsoleColor coloreSfondo, ConsoleColor coloreTesto)
        {
            Posizione posizione = new Posizione();
            posizione.x = Console.CursorLeft;
            posizione.y = Console.CursorTop;
            posizione.Background = Console.BackgroundColor;
            posizione.Foreground = Console.ForegroundColor;
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = coloreSfondo;
            Console.ForegroundColor = coloreTesto;
            return posizione;
        }
        static void RiposizionaCursore(Posizione posizione, bool riposiziona)
        {
            if (riposiziona)
            {
                Console.SetCursorPosition(posizione.x, posizione.y);
            }
            Console.BackgroundColor = posizione.Background;
            Console.ForegroundColor = posizione.Foreground;
        }
        static void Scrittura(string stringa, int x, int y, ConsoleColor coloreSfondo, ConsoleColor coloreTesto, bool riposiziona)
        {
            Posizione posizione = PreparaCursore(x, y, coloreSfondo, coloreTesto);
            Console.Write(stringa);
            RiposizionaCursore(posizione, riposiziona);
        }
        static string Lettura(int dimensione, int x, int y, ConsoleColor coloreSfondo, ConsoleColor coloreTesto)
        {
            string buffer = "";
            ConsoleKeyInfo key;
            Posizione posizione = PreparaCursore(x, y, coloreSfondo, coloreTesto);
            for (int i = 0; i < dimensione; i++)
            {
                Console.Write(" ");
            }
            Console.CursorLeft -= dimensione;
            do
            {
                key = Console.ReadKey();
                buffer += key.KeyChar;
            } while (buffer.Length != dimensione && key.Key != ConsoleKey.Enter);
            RiposizionaCursore(posizione, false);
            Console.WriteLine();
            return buffer;
        }
        static string NumeroAMese(int mese)
        {
            string[] mesi = { "Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre" };
            return mesi[mese - 1];
        }
        static string Zeller(int giorno, int mese, int annoCompleto)
        {
            // https://en.wikipedia.org/wiki/Zeller%27s_congruence
            string[] giorni = { "Sabato", "Domenica", "Lunedì", "Martedì", "Mercoledì", "Giovedì", "Venerdì" };
            int anno = annoCompleto % 100;
            int secolo = annoCompleto / 100;
            if (mese < 3)
            {
                mese += 12;
                anno--;
            }
            int h = (giorno + ((13 * (mese + 1)) / 5) + anno + (anno / 4) + (secolo / 4) - (2 * secolo)) % 7;
            return giorni[h];
        }
        static bool Bisestile(int anno)
        {
            return (anno % 100 == 0 && anno % 400 == 0) || (anno % 100 != 0 && anno % 4 == 0);
        }
        static bool DateCorrect(int giorno, int mese, int anno)
        {
            int max;
            if (mese < 1 || mese > 12)
            {
                return false;
            }
            if (mese == 2)
            {
                if (Bisestile(anno))
                {
                    max = 29;
                }
                else
                {
                    max = 28;
                }
            }
            else if (mese == 4 || mese == 6 || mese == 9 || mese == 11)
            {
                max = 30;
            }
            else
            {
                max = 31;
            }
            if (giorno > max)
            {
                return false;
            }
            return true;
        }
        static void IntSepara(out int intData, out int giorno, out int mese, out int anno)
        {
            do
            {
                while (!int.TryParse(Lettura(8, 33, 2, ConsoleColor.White, ConsoleColor.Black), out giorno) || giorno < 1000000 || giorno > 100000000) { }
                intData = giorno;
                anno = giorno % 10000;
                giorno /= 10000;
                mese = giorno % 100;
                giorno /= 100;
            } while (!DateCorrect(giorno, mese, anno));
        }
        static void StringSepara(string data, out int giorno, out int mese, out int anno)
        {
            if (data.Length == 7)
            {
                data = " " + data;
            }
            giorno = Convert.ToInt32(data.Substring(0, 2));
            mese = Convert.ToInt32(data.Substring(2, 2));
            anno = Convert.ToInt32(data.Substring(4));
        }
    }
}