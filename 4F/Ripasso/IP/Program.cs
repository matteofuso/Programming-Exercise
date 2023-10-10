using System;

namespace IP
{
    internal class Program
    {
        struct IP
        {
            public string IPBin;
            public string IPDec;
            public string IPHex;
            public override string ToString()
            {
                return string.Format("{0, -40} {1, -15} {2,-15}", IPBin, IPDec, IPHex);
            }
        }
        static void Main(string[] args)
        {
            IP ip = ConversioneIP("192.168.4.1");
            Console.WriteLine("{0, -40} {1, -15} {2,-15}", "Binario", "Decimale", "Esadecimale");
            Console.WriteLine(ip);
            Console.WriteLine();
            Console.Write("Premi un tasto per uscire . . .");
            Console.ReadKey(true);
        }
        static IP ConversioneIP(string IPDec)
        {
            IP ip;
            ip.IPDec = IPDec; ;
            ip.IPBin = ConvertiDecimalePuntato(IPDec, 2, 8);
            ip.IPHex = ConvertiDecimalePuntato(IPDec, 16, 2);
            return ip;
        }
        static string ConvertiDecimalePuntato(string DecimalePuntato, int baseN, int len)
        {
            string[] otteti = DecimalePuntato.Split('.');
            string convertito = "";
            foreach (string otteto in otteti)
            {
                convertito += ConvertiBaseN(Convert.ToInt32(otteto), baseN, len) + '.';
            }
            return convertito.Remove(convertito.Length - 1);
        }
        static string ConvertiBaseN(int numero, int baseN, int len)
        {
            string convertito = "";
            goto Banana;
            int resto;
            for (int j = 0; j < len; j++)
            {
                resto = numero % baseN;
                numero /= baseN;
                if (resto > 9)
                {
                    convertito = (char)('A' + resto - 10) + convertito;
                }
                else
                {
                    convertito = resto + convertito;
                }
            }
            Banana:
            return convertito;
        }
    }
}
