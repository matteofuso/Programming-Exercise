using System;
using System.Threading;

namespace dadiMultiplayer
{
    internal class wiiParty
    {
        static void Main(string[] args)
        {
            // Dichiarazione variabili
            Random casual = new Random();
            string zero, unoPrima, unoCentro, unoDopo, due, giocatoreUno = "", giocatoreDue = "", winner;
            int centerX, centerY, sleep, num, faccia, scoreUno = 0, scoreDue = 0, vinteUno = 0, vinteDue = 0;
            ConsoleColor dado, pallini;
            char pallino, continua;
            // Personalizzazione del dado
            dado = ConsoleColor.White;
            pallini = ConsoleColor.Black;
            sleep = 700; // ms
            pallino = 'O';
            zero = "                   ";
            unoPrima = "    " + pallino + "              ";
            unoCentro = "         " + pallino + "         ";
            unoDopo = "              " + pallino + "    ";
            due = "    " + pallino + "         " + pallino + "    ";
            centerY = Console.WindowHeight / 2;
            do
            {
                // Nel caso si rigiochi
                Console.Clear();
                // Stampo i nomi dei giocatori
                Console.WriteLine("Nome del giocatore numero uno:");
                if (giocatoreUno == "")
                {
                    giocatoreUno = Console.ReadLine();
                    Console.SetCursorPosition(Console.WindowWidth / 2, 0);
                    Console.Write("Nome del giocatore numero due:");
                    Console.SetCursorPosition(Console.WindowWidth / 2, 1);
                    giocatoreDue = Console.ReadLine();
                }
                else
                {
                    Console.Write("{0} - Vinte: {1}", giocatoreUno, vinteUno);
                    Console.SetCursorPosition(Console.WindowWidth / 2, 0);
                    Console.Write("Nome del giocatore numero due:");
                    Console.SetCursorPosition(Console.WindowWidth / 2, 1);
                    Console.WriteLine("{0} - Vinte: {1}", giocatoreDue, vinteDue);
                }
                Console.Write("{0} premi invio per tirare il dado...", giocatoreUno);
                Console.ReadLine();
                // Metto i colori del dado
                Console.BackgroundColor = dado;
                Console.ForegroundColor = pallini;
                // Stampo la parte di faccia comune
                centerX = Console.WindowWidth / 4 - 9;
                Console.SetCursorPosition(centerX, centerY - 3);
                Console.WriteLine(zero);
                Console.SetCursorPosition(centerX, centerY - 1);
                Console.WriteLine(zero);
                Console.SetCursorPosition(centerX, centerY + 1);
                Console.WriteLine(zero);
                Console.SetCursorPosition(centerX, centerY + 3);
                Console.WriteLine(zero);
                faccia = 1;
                num = casual.Next(1, 7);
                for (int i = 0; i < 13; i++)
                {
                    if (i == 7)
                    {
                        // Assegnazione punteggi
                        scoreUno = num;
                        num = casual.Next(1, 7);
                        scoreDue = num;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.SetCursorPosition(Console.WindowWidth / 2, 2);
                        Console.Write("{0} premi invio per tirare il dado...", giocatoreDue);
                        Console.ReadLine();
                        // Reinizializza il secondo dado
                        centerX = centerX + Console.WindowWidth / 2;
                        faccia = 1;
                        Console.BackgroundColor = dado;
                        Console.ForegroundColor = pallini;
                        Console.SetCursorPosition(centerX, centerY - 3);
                        Console.Write(zero);
                        Console.SetCursorPosition(centerX, centerY - 1);
                        Console.Write(zero);
                        Console.SetCursorPosition(centerX, centerY + 1);
                        Console.Write(zero);
                        Console.SetCursorPosition(centerX, centerY + 3);
                        Console.Write(zero);
                    }
                    // Alineamento iniziale
                    Console.SetCursorPosition(centerX, centerY - 2);
                    // Costruzione facce
                    if (faccia == 1)
                    {
                        Console.Write(zero);
                        Console.SetCursorPosition(centerX, centerY);
                        Console.Write(unoCentro);
                        Console.SetCursorPosition(centerX, centerY + 2);
                        Console.Write(zero);
                    }
                    else if (faccia == 2)
                    {
                        Console.Write(unoDopo);
                        Console.SetCursorPosition(centerX, centerY);
                        Console.Write(zero);
                        Console.SetCursorPosition(centerX, centerY + 2);
                        Console.Write(unoPrima);
                    }
                    else if (faccia == 3)
                    {
                        Console.Write(unoDopo);
                        Console.SetCursorPosition(centerX, centerY);
                        Console.Write(unoCentro);
                        Console.SetCursorPosition(centerX, centerY + 2);
                        Console.Write(unoPrima);
                    }
                    else if (faccia == 4)
                    {
                        Console.Write(due);
                        Console.SetCursorPosition(centerX, centerY);
                        Console.Write(zero);
                        Console.SetCursorPosition(centerX, centerY + 2);
                        Console.Write(due);
                    }
                    else if (faccia == 5)
                    {
                        Console.Write(due);
                        Console.SetCursorPosition(centerX, centerY);
                        Console.Write(unoCentro);
                        Console.SetCursorPosition(centerX, centerY + 2);
                        Console.Write(due);
                    }
                    else
                    {
                        Console.Write(due);
                        Console.SetCursorPosition(centerX, centerY);
                        Console.Write(due);
                        Console.SetCursorPosition(centerX, centerY + 2);
                        Console.Write(due);
                        faccia = num - 1;
                    }
                    // Imposta la prossima faccia
                    faccia++;
                    Thread.Sleep(sleep);
                }
                // Allineamento
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(0, centerY + 7);
                // Assegnazione vincitori
                if (scoreUno == scoreDue)
                {
                    Console.WriteLine("Avete pareggiato!");
                }
                else
                {
                    if (scoreUno > scoreDue)
                    {
                        winner = giocatoreUno;
                        vinteUno++;
                    }
                    else
                    {
                        winner = giocatoreDue;
                        vinteDue++;
                    }
                    Console.WriteLine("Ha vinto {0}, congratulazioni!", winner);
                }
                // Chiede di rigiocare
                do
                {
                    Console.Write("Vuoi ripetere il ciclo? (S/N) ");
                    continua = Convert.ToChar(Console.ReadLine());
                } while (Char.ToUpper(continua) != 'S' && Char.ToUpper(continua) != 'N');
            } while (Char.ToUpper(continua) == 'S');
            Console.ReadLine();
        }
    }
}