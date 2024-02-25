using System;

namespace PersoneStudenti
{
    enum Genere
    {
        Maschio,
        Femmina
    }
    enum Nazionalità
    {
        Italiana,
        UE,
        Estera
    }
    internal class Persona
    {
        string _nome;
        string _cognome;
        Genere _sesso;
        Nazionalità _nazionalità;
        
        // Proprietà
        public string Nome
        {
            get { return _nome; }
            set { if (string.IsNullOrEmpty(value)) throw new Exception(""); _nome = value; }
        }
        public string Cognome
        {
            get { return _cognome; }
            set { if (string.IsNullOrEmpty(value)) throw new Exception(""); _cognome = value; }
        }
        public Genere Sesso { get => _sesso; protected set => _sesso = value; }
        public Nazionalità Nazionalità { get => _nazionalità; protected set => _nazionalità = value; }
        
        // Costruttori
        public Persona(string nome, string cognome, Genere sesso, Nazionalità nazionalità)
        {
            _nome = nome;
            _cognome = cognome;
            _sesso = sesso;
            _nazionalità = nazionalità;
        }
        public Persona(string nome, string cognome) : this(nome, cognome, Genere.Maschio, Nazionalità.Italiana) { }

        // Override
        public override string ToString()
        {
            return string.Format("Persona: {0} {1} (Sesso: {2}, Nazionalità: {3})", Cognome, Nome, Sesso, Nazionalità);
        }
    }
}
