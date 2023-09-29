using System;

namespace DividiFrase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string frase = "Loreabcdefghigklmnopqrstuwxyzabcdefghijklmnopqrst dolorrrrrrrrrrrrrrrrr00000r sit amet, consectetur adipiscing elit. Cras in elit accumsan, interdum erat ultricies, porttitor justo. Etiam commodo dapibus elit, dapibus commodo dui. Loreabcdefghigklmnopqrstuwxyzabcdefghijklmnopqrst curabitur ornare nisi erat, id ullamcorper augue sodales in. Duis commodo libero erat, et vestibulum urna suscipit eu. Praesent suscipit lacinia neque in dictum. Aenean auctor tellus urna, sed sodales dolor consectetur non. In nec facilisis leo. Donec semper est enim, ac dictum velit commodo vel. Nam fringilla elementum nisl, porttitor tincidunt odio pretium id. Ut aliquet, nunc vitae imperdiet pretium, justo libero aliquam turpis, id tincidunt dui libero ac enim. Praesent bibendum interdum elit, et rutrum purus. Nunc dapibus augue non lobortis porta. In sed nibh urna. Suspendisse et metus quis ante bibendum euismod gravida id magna. Praesent ultrices congue arcu, ac pharetra orci ornare in.";
            //string frase = "La mamma va al mercato a compraree";
            //string frase = "";
            const int max = 34, minWrap = 5, minToNewLine = 5;
            int l = 0, w, step;
            if (frase != "")
            {
                foreach (string parola in frase.Split(' '))
                {
                    if (l > max)
                    {
                        l = 0;
                        Console.WriteLine();
                    }
                    l += parola.Length;
                    if (l > max)
                    {
                        l -= parola.Length;
                        // Se lo spazio rimanente nella riga è maggiore di minWrap e la parte della parola
                        // che andrà a capo è maggiore di minToNewLine
                        if (max - l > minWrap && parola.Length - (max - l) > minToNewLine)
                        {
                            w = 0;
                            do
                            {
                                step = parola.Length - w - l + max;
                                if (step >= max - l)
                                {
                                    Console.WriteLine("{0}-", parola.Substring(w, max - 2 - l));
                                    w += max - l - 2;
                                    l = 0;
                                }
                            } while (parola.Length - w > max);
                            step %= max;
                            Console.Write("{0} ", parola.Substring(w));
                            l = step + 1;
                            continue;
                        }
                        l = parola.Length;
                        Console.WriteLine();
                    }
                    Console.Write("{0} ", parola);
                    l++;
                }
            }
            else
            {
                Console.WriteLine("La frase non può essere nulla");
            }
            Console.ReadLine();
        }
    }
}