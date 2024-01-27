using System;

namespace Rettangolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Microsoft World 2019";
            Rettangolo rettangolo;
            try
            {
                rettangolo = new Rettangolo(Double.Parse(Console.In.ReadLine()), Double.Parse(Console.In.ReadLine()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                rettangolo = new Rettangolo(1, 1);
            }
            Console.WriteLine("Base x Altezza = {0}", rettangolo);
            Console.WriteLine();
            Console.WriteLine("Area: {0} unita^2", rettangolo.Area());
            Console.WriteLine("Perimetro: {0} unita", rettangolo.Perimeter());
            Console.ReadLine();
        }
    }
}
