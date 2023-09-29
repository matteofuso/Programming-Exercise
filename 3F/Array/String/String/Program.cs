using System;

namespace String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Realizzare un programma che permetta di togliere gli spazi bianchi da una frase in modo che fra
                una parola e l'altra rimanga un solo spazio.
                es:
                Input:
                  La       mamma va      al mercato    a comprare le albicocche.   
                Output:
                La mamma va al mercato a comprare le albicocche.
                (metti frase costante)
            */
            const string frase = "    La       mamma va      al mercato    a comprare le albicocche.   ";
            Console.WriteLine(RemoveUnecessaryBlanks(frase));
            Console.ReadLine();
        }
        static private string RemoveUnecessaryBlanks(string frase)
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