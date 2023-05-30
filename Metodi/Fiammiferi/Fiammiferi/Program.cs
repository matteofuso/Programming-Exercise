using System;

namespace Fiammiferi
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] giocatori = new string[2];
            bool turno = true, CPUOppnent, impossible = false; //False Giocatore1, True Giocatore2
            byte fiammiferi = 21, withdraw;
            const byte maxWithdraw = 3;
            //Chiedo all'utente se vuole giocare con il computer, in modalità impossibile e infine i nomi dei giocatori
            CPUOppnent = YesNo("Vuoi giocare con il computer");
            if (CPUOppnent)
            {
                impossible = YesNo("Vuoi giocare in difficoltà estrema");
            }
            // Per vincere sempre, il computer deve iniziare per primo
            if (impossible)
            {
                turno = !turno;
            }
            ChiediNomi(giocatori, CPUOppnent);
            Console.WriteLine();
            // Inizio di ogni turno
            do
            {
                // Do il turno all'altro giocatore
                turno = !turno;
                // Se è il turno del PC
                if (turno && CPUOppnent)
                {
                    // Calcolo il numero di fiammiferi da prelevare, li stampo
                    withdraw = CPUMove(fiammiferi, maxWithdraw, impossible);
                    Console.WriteLine("Il computer ha preso {0} fiammiferi", withdraw);
                }
                else
                {
                    // Chiedo il numero di fiammiferi al giocatore finchè i dati non sono accettabili
                    withdraw = PlayerMove(turno, giocatori, fiammiferi, maxWithdraw);
                }
                // Rimuovo i fiammiferi
                fiammiferi -= withdraw;
                Console.WriteLine();
                // Fichè non è rimasto al massimo un fiammifero
            } while (fiammiferi > 1);
            // Se è rimasto un solo fiammifero sulla tavola allora la vincita sarà dall'altro giocatore
            if (fiammiferi == 1)
            {
                turno = !turno;
            }
            // Stampo il vincitore
            Console.WriteLine("Ha vinto {0}!", PlayerName(turno, giocatori));
            Console.ReadLine();
        }
        static private bool PrelevaOK(byte withdraw, byte fiammiferi, byte maxWithdraw)
        {
            //     Numero minimo        Chiedi più fiammiferi di quelli che ci sono                      Chiedo troppi fiammiferi
            return withdraw < 1 || (fiammiferi <= maxWithdraw && withdraw > fiammiferi) || (fiammiferi > maxWithdraw && withdraw > maxWithdraw);
        }
        static private void StampaTavolo(byte fiammiferi)
        {
            const int fiammifero = 7;
            int x = 0;
            // Preparo la zona dove andranno i fiammiferi per evitare lo scroll
            for (int i = 0; i <= fiammifero; i++)
            {
                Console.WriteLine();
            }
            int y = Console.CursorTop - fiammifero;
            // Stampo i fiammiferi
            for (int j = 0; j < fiammiferi; j++)
            {
                x += 4;
                // Spazio ogni 4
                if (j % 4 == 0)
                {
                    x += 3;
                }
                Console.CursorTop = y;
                // Stampo un fiammifero
                for (int i = 0; i < 7; i++)
                {
                    Console.CursorLeft = x;
                    if (i == 0)
                    {
                        Console.WriteLine('░');
                    }
                    else
                    {
                        Console.WriteLine('█');
                    }
                }
            }
            Console.WriteLine();
        }
        static private void ChiediNomi(string[] giocatori, bool CPUOppnent)
        {
            for (int i = 0; i < 2; i++)
            {
                do
                {
                    Console.Write("Giocatore {0} inserisci il tuo nome: ", i + 1);
                    giocatori[i] = Console.ReadLine();
                } while (giocatori[i] == "");
                // Se giocatore 2 è il computer esce
                if (CPUOppnent)
                {
                    giocatori[1] = "il computer";
                    return;
                }
            }
        }
        // Da una richiesta promt ritorno true se l'utente risponde con "s", false se risponde "n"
        static private bool YesNo(string promt)
        {
            string input;
            do
            {
                Console.Write("{0}? (S/n) ", promt);
                input = Console.ReadLine().ToLower();
            } while (input != "s" && input != "n");
            return input == "s";
        }
        static private string PlayerName(bool turno, string[] giocatori)
        {
            // Posso convertire il booleano in intero in modo che true == 1 e false == 0
            return giocatori[Convert.ToInt32(turno)];
        }
        static private byte CPUMove(byte fiammiferi, byte maxWithdraw, bool impossible)
        {
            Random random = new Random();
            // Se la modalità è impossibile
            if (impossible)
            {
                // Bisogna portare il gioco ad una situazione dove c'è un multiplo di 4 sul tavolo
                // Alla fine l'avversari si troverà con 4 fiammiferi, lasciandoci la vittoria
                if (fiammiferi % 4 == 0)
                {
                    return 1;
                }
                return (byte)(fiammiferi % 4);
            }
            else
            {
                // Se posso svuotare il tavolo, lo faccio
                if (fiammiferi <= maxWithdraw)
                {
                    return fiammiferi;
                }
                // Ritorno un valore random
                else
                {
                    return (byte)random.Next(1, 4);
                }
            }
        }
        static private byte PlayerMove(bool turno, string[] giocatori, byte fiammiferi, byte maxWithdraw)
        {
            byte withdraw;
            // Chiedo il numero di fiammiferi al giocatore finchè i dati non sono accettabili
            Console.WriteLine("Turno di {0}. Questo è il tavolo:", PlayerName(turno, giocatori));
            StampaTavolo(fiammiferi);
            Console.Write("Inserisci il numero di fiammiferi da prendere: ");
            while (!byte.TryParse(Console.ReadLine(), out withdraw) || PrelevaOK(withdraw, fiammiferi, maxWithdraw))
            {
                Console.Write("Inserisci un numero corretto di fiammiferi: ");
            }
            return withdraw;
        }
    }
}