using System;
using System.Collections.Generic;

namespace GaraAutomobilista
{
    internal class Gara
    {
        List<Auto> _griglia;
        Stato _stato;
        int _posti;
        int _vincitore;
        string _nome;
        // Proprietà
        public string Nome
        {
            get { return _nome; }
        }
        public string Vincitore
        {
            get { return _griglia[_vincitore].Pilota.ToString(); }
        }
        public Stato StatoGara
        {
            get { return _stato; }
        }
        public bool Piena
        {
            get { return _griglia.Count == _posti; }
        }
        public bool Vuota
        {
            get { return _griglia.Count == 0; }
        }
        // Costruttore
        public Gara(string nome, int posti)
        {
            _nome = nome;
            _griglia = new List<Auto>(posti);
            _posti = posti;
        }
        // Metodi
        public bool Exists(Auto auto)
        {
            return _griglia.Exists(
                a => a.Scuderia == auto.Scuderia &&
                a.Pilota.Nome == auto.Pilota.Nome &&
                a.Pilota.Cognome == auto.Pilota.Cognome
        );
        }
        public void Add(Auto auto)
        {
            if (_posti == _griglia.Count)
            {
                throw new Exception("Posti finiti");
            }
            _griglia.Add(auto);
            _stato = Stato.Deve_Iniziare;
        }
        public void Avvia()
        {
            _stato = Stato.In_Corso;
            Cronometro cronometro = new Cronometro();
            foreach (Auto auto in _griglia)
            {
                cronometro.Simulate();
                auto.Tempo = cronometro.Time;
            }
            _griglia.Sort((a, b) => (int)(a.Tempo.TotalMilliseconds - b.Tempo.TotalMilliseconds));
            _stato = Stato.Finita;
        }
        public void Visualizza()
        {
            switch (_stato)
            {
                case Stato.Deve_Iniziare:
                    Console.WriteLine("La gara non è ancora iniziata");
                    break;
                case Stato.In_Corso:
                    Console.WriteLine("La gara è in esecuzione");
                    break;
                case Stato.Finita:
                    Console.WriteLine("La gara è terminata");
                    Console.WriteLine("Il vincitore è: ");
                    Console.WriteLine(Vincitore);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Lista dei partecipanti");
            VisualizzaPartecipanti();
        }
        public void VisualizzaPartecipanti()
        {
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3}", "Nome", "Cognome", "Scuderia", "Tempo (mm:ss:ms)");
            _griglia.ForEach(p =>
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3:00}:{4:00}:{5:000}", p.Pilota.Nome, p.Pilota.Cognome, p.Scuderia, p.Tempo.Minutes, p.Tempo.Seconds, p.Tempo.Milliseconds);
            });
        }
    }
}
