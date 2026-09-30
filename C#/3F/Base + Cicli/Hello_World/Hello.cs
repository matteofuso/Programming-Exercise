//Librerie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    class Hello //Classe principale, contiene variabili e metodi relativi all'applicazione da realizzare
    {
        static void Main(string[] args) //Metodo principale, punto di ingresso del programma
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Hello World!"); //oppure
            System.Console.Write("Benvenuti");
            Console.Write(" Studenti");
            Console.Write(" della 3F");
            Console.Write(" Programmiamo in c#");
            Console.WriteLine();
            Console.ReadLine();
            //WriteLine scrive e va a capo
            //Write scrive ma non va a capo
            //ReadLine legge un valore
            //In una classe ci sono proprietà e metodi
            //carriage return 13
            //line feed 10 fuso
            double doppio=110;
            Console.WriteLine(doppio);
        }
    }
}