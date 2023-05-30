using System;

namespace GiornoMeseAnno
{
    class Program
    {
        enum Mesi
        {
            Gennaio,
            Febbraio,
            Marzo,
            Aprile,
            Maggio,
            Giugno,
            Luglio,
            Agosto,
            Settembre,
            Ottobre,
            Novembre,
            Dicembre
        }
        enum Giorni
        {
            Sabato,
            Domenica,
            Lunedì,
            Martedì,
            Mercoledì,
            Giovedì,
            Venerdì,
        }
        struct Cursore
        {
            public ConsoleColor Background;
            public ConsoleColor Foreground;
        }
        static void Main(string[] args)
        {
            string data;
            int giorno, mese, anno;
            Scrittura("Inserisci la data (ddmmaaaa):", 1, 1, ConsoleColor.Black, ConsoleColor.White); //3 2
            do
            {
                data = Lettura(8, 31, 1, ConsoleColor.White, ConsoleColor.Black);
            } while (!IntSepara(data, out giorno, out mese, out anno));
            Scrittura($"{NumeroAGiorno(giorno, mese, anno)} {giorno} {NumeroAMese(mese)} {anno}", 1, 3, ConsoleColor.Black, ConsoleColor.White);
            Scrittura("Premi un tasto per uscire . . .", 1, 5, ConsoleColor.Black, ConsoleColor.White);
            Console.ReadKey();
        }
        static bool IntSepara(string data, out int giorno, out int mese, out int anno)
        {
            if (int.TryParse(data, out giorno))
            {
                anno = giorno % 10000;
                giorno /= 10000;
                mese = giorno % 100;
                giorno /= 100;
                return DataOK(giorno, mese, anno);
            }
            mese = 0;
            anno = 0;
            return false;
        }
        static string NumeroAMese(int mese)
        {
            return Convert.ToString((Mesi)(mese - 1));
        }
        static string NumeroAGiorno(int giorno, int mese, int annoCompleto)
        {
            // https://en.wikipedia.org/wiki/Zeller%27s_congruence
            int anno = annoCompleto % 100;
            int secolo = annoCompleto / 100;
            if (mese < 3)
            {
                mese += 12;
                anno--;
            }
            int h = (giorno + ((13 * (mese + 1)) / 5) + anno + (anno / 4) + (secolo / 4) - (2 * secolo)) % 7;
            return Convert.ToString((Giorni)h);
        }
        static bool Bisestile(int anno)
        {
            return (anno % 100 == 0 && anno % 400 == 0) || (anno % 100 != 0 && anno % 4 == 0);
        }
        static bool DataOK(int giorno, int mese, int anno)
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
        static Cursore PreparaCursore(int x, int y, ConsoleColor coloreSfondo, ConsoleColor coloreTesto)
        {
            Cursore posizione = new Cursore();
            posizione.Background = Console.BackgroundColor;
            posizione.Foreground = Console.ForegroundColor;
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = coloreSfondo;
            Console.ForegroundColor = coloreTesto;
            return posizione;
        }
        static void ResettaCursore(Cursore posizione)
        {
            Console.BackgroundColor = posizione.Background;
            Console.ForegroundColor = posizione.Foreground;
        }
        static void Scrittura(string stringa, int x, int y, ConsoleColor coloreSfondo, ConsoleColor coloreTesto)
        {
            Cursore cursore = PreparaCursore(x, y, coloreSfondo, coloreTesto);
            Console.Write(stringa);
            ResettaCursore(cursore);
        }
        static string Lettura(int dimensione, int x, int y, ConsoleColor coloreSfondo, ConsoleColor coloreTesto)
        {
            string buffer = "";
            char key;
            Cursore posizione = PreparaCursore(x, y, coloreSfondo, coloreTesto);
            for (int i = 0; i < dimensione; i++)
            {
                Console.Write(" ");
            }
            Console.CursorLeft -= dimensione;
            do
            {
                key = Console.ReadKey(true).KeyChar;
                if (!char.IsControl(key))
                {
                    Console.Write(key);
                    buffer += key;
                }
                else if (key == '\b' && buffer.Length != 0)
                {
                    buffer = buffer.Remove(buffer.Length - 1);
                    Console.CursorLeft--;
                    Console.Write(' ');
                    Console.CursorLeft--;
                }
            } while (buffer.Length != dimensione && key != '\r');
            ResettaCursore(posizione);
            Console.WriteLine();
            return buffer;
        }
    }
}