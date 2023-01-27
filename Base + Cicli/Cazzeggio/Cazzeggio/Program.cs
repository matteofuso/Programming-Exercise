using System;

namespace Cazzeggio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pag = 1, max = 483, len = 0;
            while (len < max){
                len = len + Convert.ToString(pag).Length;
                Console.WriteLine(pag);
                pag++;
            }
            Console.ReadLine();
        }
    }
}
