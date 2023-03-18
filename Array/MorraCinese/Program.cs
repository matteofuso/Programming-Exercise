using System;

namespace MorraCinese
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dichiarazione e inizializzazione variabili
            string giocatoreUno, giocatoreDue, combo;
            int i, vinciteUno = 0, vinciteDue = 0;
            bool esci = false;
            byte winner = 0;
            // Chiedo i nomi dei giocatori
            Console.Write("Nome giocatore uno:");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("Nome giocatore due:");
            giocatoreUno = Console.ReadLine();
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.CursorTop--;
            giocatoreDue = Console.ReadLine();
            Console.WriteLine();
            // Stampo le informazioni di base come la legenda e i punteggi
            Console.WriteLine("Legenda mosse:");
            Console.Write("A = carta");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("J = carta");
            Console.Write("S = sasso");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("K = sasso");
            Console.Write("D = forbici");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("L = forbici");
            Console.Write("Punteggio:");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("Punteggio:");
            Console.WriteLine();
            Console.WriteLine("Inserite le mosse e poi premete invio");
            do
            {
                // Stampo i punteggi attuali e cancello la riga scritta precedentemente
                Console.SetCursorPosition(11, 7);
                Console.Write(vinciteUno);
                Console.SetCursorPosition(Console.WindowWidth / 2 + 11, 7);
                Console.Write(vinciteDue);
                Console.SetCursorPosition(0, 10);
                for (i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }
                // Riposiziono il cursore e cambio calore per nascondere le mosse
                Console.CursorTop--;
                Console.ForegroundColor = ConsoleColor.Black;
                combo = Console.ReadLine().ToLower();
                // Riposiziono il cursore dove verranno scritti i messaggi e resetto il colore
                Console.SetCursorPosition(0, 10);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.CursorLeft = 0;
                // Controllo se sono state inserite due mosse
                if (combo.Length == 2)
                {
                    // Controllo se le mosse del giocatore uno sono valide
                    if (combo[0] == 'a' || combo[0] == 's' || combo[0] == 'd')
                    {
                        // Controllo se le mosse del giocatore due sono valide
                        if (combo[1] == 'j' || combo[1] == 'k' || combo[1] == 'l')
                        {
                            // Controllo la carta inserita dal primo utente e la confronto con la seconda
                            switch (combo[0])
                            {
                                case 'a':
                                    // Carta
                                    switch (combo[1])
                                    {
                                        case 'j':
                                            // Carta
                                            winner = 2;
                                            break;
                                        case 'k':
                                            // Sasso
                                            winner = 0;
                                            break;
                                        case 'l':
                                            // Forbici
                                            winner = 1;
                                            break;
                                    }
                                    break;
                                case 's':
                                    // Sasso
                                    switch (combo[1])
                                    {
                                        case 'j':
                                            // Carta
                                            winner = 1;
                                            break;
                                        case 'k':
                                            // Sasso
                                            winner = 2;
                                            break;
                                        case 'l':
                                            // Forbici
                                            winner = 0;
                                            break;
                                    }
                                    break;
                                case 'd':
                                    // Forbici
                                    switch (combo[1])
                                    {
                                        case 'j':
                                            // Carta
                                            winner = 0;
                                            break;
                                        case 'k':
                                            // Sasso
                                            winner = 1;
                                            break;
                                        case 'l':
                                            // Forbici
                                            winner = 2;
                                            break;
                                    }
                                    break;
                            }
                            // Controllo il vincitore e stampo il messaggio
                            switch (winner)
                            {
                                case 0:
                                    Console.Write("{0} ha vinto la battaglia ma non la sfida! ", giocatoreUno);
                                    vinciteUno++;
                                    break;
                                case 1:
                                    Console.Write("{0} ha vinto la battaglia ma non la sfida! ", giocatoreDue);
                                    vinciteDue++;
                                    break;
                                case 2:
                                    Console.Write("Avete pareggiato. ");
                                    break;
                            }
                        }
                        else
                        {
                            Console.Write("Mossa giocatore due non valida. ");
                        }
                    }
                    else
                    {
                        Console.Write("Mossa giocatore uno non valida. ");
                    }
                }
                // Controllo se si vuole uscire
                else if (combo == "x")
                {
                    esci = true;
                }
                // L'input non è valido
                else
                {
                    Console.Write("Devi inserire due mosse. ");
                }
                // Chiedo di premere invio perchè all'inizio cancello il messaggio precedente
                Console.Write("Premi invio per continuare . . .");
                Console.ReadLine();
            } while (!esci);
            Console.WriteLine();
            // Scrivo il vincitore della partita
            if (vinciteUno > vinciteDue)
            {
                Console.WriteLine("{0} ha vinto la battaglia!", giocatoreUno);
            }
            else if (vinciteDue > vinciteUno)
            {
                Console.WriteLine("{0} ha vinto la battaglia!", giocatoreDue);
            }
            else
            {
                Console.WriteLine("La battaglia è risultata in un pareggio.");
            }
            Console.ReadLine();
        }
    }
}