using System;

namespace MorraCinese
{
    class Program
    {
        enum Mossa
        {
            Nessuna,
            Sasso,
            Carta,
            Forbice
        }
        enum Vincitore
        {
            Pareggio,
            Uno,
            Due
        }
        struct Game
        {
            public Mossa mossaUno, mossaDue;
            public Vincitore vincitore;
        }
        struct Giocatore
        {
            public string nome;
            public int punteggio;
        }
        static void Main(string[] args)
        {
            // Dichiarazione e inizializzazione variabili
            const int partiteMassime = 10;
            int i, giocate = 0;
            Game[] partite = new Game[partiteMassime];
            Giocatore giocatoreUno, giocatoreDue;
            ConsoleKey key;
            giocatoreUno.punteggio = giocatoreDue.punteggio = 0;
            // Chiedo i nomi dei giocatori
            Console.Write("Nome giocatore uno:");
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.WriteLine("Nome giocatore due:");
            giocatoreUno.nome = Console.ReadLine();
            Console.CursorLeft = Console.WindowWidth / 2;
            Console.CursorTop--;
            giocatoreDue.nome = Console.ReadLine();
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
            do
            {
                // Stampo i punteggi attuali e cancello la riga scritta precedentemente
                Console.SetCursorPosition(11, 7);
                Console.Write(giocatoreUno.punteggio);
                Console.SetCursorPosition(Console.WindowWidth / 2 + 11, 7);
                Console.Write(giocatoreDue.punteggio);
                Console.SetCursorPosition(0, 9);
                // Cancello la riga
                for (i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\r");
                // Mossa G1
                Console.Write("{0} inserisci la mossa: ", giocatoreUno.nome);
                do
                {
                    key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.A:
                            partite[giocate].mossaUno = Mossa.Carta;
                            break;
                        case ConsoleKey.S:
                            partite[giocate].mossaUno = Mossa.Sasso;
                            break;
                        case ConsoleKey.D:
                            partite[giocate].mossaUno = Mossa.Forbice;
                            break;
                    }
                } while (partite[giocate].mossaUno == Mossa.Nessuna && key != ConsoleKey.X);
                // Esco se G1 preme x
                if (key == ConsoleKey.X)
                {
                    break;
                }
                // Cancello la riga
                Console.Write("\r");
                for (i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\r");
                // Mossa G2
                Console.Write("{0} inserisci la mossa: ", giocatoreDue.nome);
                do
                {
                    key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.J:
                            partite[giocate].mossaDue = Mossa.Carta;
                            break;
                        case ConsoleKey.K:
                            partite[giocate].mossaDue = Mossa.Sasso;
                            break;
                        case ConsoleKey.L:
                            partite[giocate].mossaDue = Mossa.Forbice;
                            break;
                    }
                } while (partite[giocate].mossaDue == Mossa.Nessuna);
                // Cancello la riga
                Console.Write("\r");
                for (i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("\r");
                // Se ha vinto G1
                if (
                    (partite[giocate].mossaUno == Mossa.Carta && partite[giocate].mossaDue == Mossa.Sasso) ||
                    (partite[giocate].mossaUno == Mossa.Sasso && partite[giocate].mossaDue == Mossa.Forbice) ||
                    (partite[giocate].mossaUno == Mossa.Forbice && partite[giocate].mossaDue == Mossa.Carta)
                )
                {
                    Console.Write("{0} ha vinto la battaglia ma non la sfida! ", giocatoreUno.nome);
                    giocatoreUno.punteggio++;
                    partite[giocate].vincitore = Vincitore.Uno;
                }
                // Se ha vinto G2
                else if (
                    (partite[giocate].mossaDue == Mossa.Carta && partite[giocate].mossaUno == Mossa.Sasso) ||
                    (partite[giocate].mossaDue == Mossa.Sasso && partite[giocate].mossaUno == Mossa.Forbice) ||
                    (partite[giocate].mossaDue == Mossa.Forbice && partite[giocate].mossaUno == Mossa.Carta)
                )
                {
                    Console.Write("{0} ha vinto la battaglia ma non la sfida! ", giocatoreDue.nome);
                    giocatoreDue.punteggio++;
                    partite[giocate].vincitore = Vincitore.Due;
                }
                // Se hanno pareggiato
                else
                {
                    Console.Write("Avete pareggiato. ");
                }
                giocate++;
                // Chiedo di premere invio perchè all'inizio cancello il messaggio precedente
                Console.Write("Premi un tasto per continuare . . .");
                Console.ReadKey();
            } while (giocate != partiteMassime);
            Console.WriteLine("\r\n");
            // Stampo le varie partite
            Console.WriteLine("Ecco le partite: ");
            for (i = 0; i < giocate; i++)
            {
                Console.Write("Nella {0} paritta {1} ha giocato {2} e {3} ha giocato {4}. ", i + 1, giocatoreUno.nome, partite[i].mossaUno, giocatoreDue.nome, partite[i].mossaDue);
                switch (partite[i].vincitore)
                {
                    case Vincitore.Uno:
                        Console.WriteLine("Ha vinto {0}", giocatoreUno.nome);
                        break;
                    case Vincitore.Due:
                        Console.WriteLine("Ha vinto {0}", giocatoreDue.nome);
                        break;
                    default:
                        Console.WriteLine("Avete pareggiato");
                        break;
                }
            }
            // Scrivo il vincitore della partita
            Console.WriteLine();
            if (giocatoreUno.punteggio > giocatoreDue.punteggio)
            {
                Console.WriteLine("{0} ha vinto la battaglia!", giocatoreUno.nome);
            }
            else if (giocatoreDue.punteggio > giocatoreUno.punteggio)
            {
                Console.WriteLine("{0} ha vinto la battaglia!", giocatoreDue.nome);
            }
            else
            {
                Console.WriteLine("La battaglia è risultata in un pareggio.");
            }
            Console.Write("Premere invio per uscire . . .");
            Console.ReadLine();
        }
    }
}