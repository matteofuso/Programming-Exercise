using System;

namespace PersoneStudenti
{
    internal class Studente : Persona
    {
        int _matricola;

        // Proprietà
        public int Matricola { get => _matricola; set => _matricola = value; }

        // Costruttori
        public Studente(string nome, string cognome, Genere sesso, Nazionalità nazionalità, int matricola) : base(nome, cognome, sesso, nazionalità)
        {
            _matricola = matricola;
        }
        public Studente(string nome, string cognome, int matricola) : base(nome, cognome)
        {
            _matricola = matricola;
        }

        // Override
        public override string ToString()
        {
            return string.Format("Studente: {0} - {1} {2} (Sesso: {3}, Nazionalità: {4})", Matricola, Cognome, Nome, Sesso, Nazionalità);
        }
    }
}
