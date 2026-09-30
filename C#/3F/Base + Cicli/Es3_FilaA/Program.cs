using System;

public class MyProgram
{
    public static void Main(string[] args)
    {
        // Matteo Fuso, 3F, Fila A
        int numeroUno, numeroDue, risultato;
        string operatore;
        
        Console.WriteLine("Inserisci il primo numero:");
        numeroUno = (int) readValue();
        Console.WriteLine("Inserisci il secondo numero:");
        numeroDue = (int) readValue();
        do
        {
            Console.WriteLine("Inserisci un operatore matematico (Accettati: +, -, *, /)");
            operatore = Console.ReadLine();
        }
        while (operatore != "-" && operatore != "+" && operatore != "*" && operatore != "/");
        if (operatore == "+")
        {
            risultato = numeroUno + numeroDue;
        }
        else
        {
            if (operatore == "-")
            {
                risultato = numeroUno - numeroDue;
            }
            else
            {
                if (operatore == "*")
                {
                    risultato = numeroUno * numeroDue;
                }
                else
                {
                    while (numeroDue == 0)
                    {
                        Console.WriteLine("Non puoi dividere per 0, reinserisci il numero");
                        numeroDue = (int) readValue();
                    }
                    risultato = (int) ((double) numeroUno / numeroDue);
                }
            }
        }
        do
        {
            Console.WriteLine("Inserisci =");
            operatore = Console.ReadLine();
        }
        while (operatore != "=");
        Console.WriteLine("Il risultato è " + risultato);
    }
    
    // .NET can only read single characters or entire lines from the console.
    // The following function safely reads a double value.
    private static double readValue()
    {
        double result;
        while (!double.TryParse(Console.ReadLine(), out result));
        return result;
    }
}
