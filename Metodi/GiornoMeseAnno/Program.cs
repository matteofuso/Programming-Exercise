using System;

namespace GiornoMeseAnno
{
    class Program
    {
        static void Main(string[] args)
        {
            int intData, giorno, mese, anno;

            IntSepara(out intData, out giorno, out mese, out anno);
            Console.WriteLine();
            Console.WriteLine("Con numero");
            Console.WriteLine("{0:00} {1} {2:0000}", giorno, NumeroAMese(mese), anno);
            Console.WriteLine();

            StringSepara(Convert.ToString(intData), out giorno, out mese, out anno);
            Console.WriteLine("Con stringa");
            Console.WriteLine("{0:00} {1} {2:0000}", giorno, NumeroAMese(mese), anno);

            Console.WriteLine();
            Console.WriteLine("Premi un tasto per uscire . . .");
            Console.ReadKey();
        }
        static string NumeroAMese(int mese)
        {
            string[] mesi = { "Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre" };
            return mesi[mese - 1];
        }
        static bool DateCorrect(int giorno, int mese, int anno, ref string messaggio)
        {
            int max;
            if (mese < 1 || mese > 12)
            {
                messaggio = "Mese non valido. ";
                return false;
            }
            if (mese == 2)
            {
                if (anno % 4 == 0) // Bisestile
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
                messaggio = NumeroAMese(mese) + " ha solo " + max + " giorni. ";
                return false;
            }
            return true;
        }
        static void IntSepara(out int intData, out int giorno, out int mese, out int anno)
        {
            string messaggio = "";
            do
            {
                Console.Write("{0}Inserisci la data (ddmmaaaa): ", messaggio);
                while (!int.TryParse(Console.ReadLine(), out giorno) || giorno < 1000000 || giorno > 100000000)
                {
                    Console.Write("Inserisci un numero valido: ");
                }
                intData = giorno;
                anno = giorno % 10000;
                giorno /= 10000;
                mese = giorno % 100;
                giorno /= 100;
            } while (!DateCorrect(giorno, mese, anno, ref messaggio));
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