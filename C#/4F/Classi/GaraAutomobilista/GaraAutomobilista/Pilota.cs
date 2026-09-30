using System;

namespace GaraAutomobilista
{
    internal class Pilota
    {
        string _nome;
        string _cognome;
        // Proprietà
        public string Nome
        {
            get { return _nome; }
            private set { if (value == "") { throw new Exception("Nome non valido"); } else { _nome = value; } }
        }
        public string Cognome
        {
            get { return _cognome; }
            private set { if (value == "") { throw new Exception("Nome non valido"); } else { _cognome = value; } }

        }
        // Override
        public override string ToString()
        {
            return string.Format("{0} {1}", _nome, _cognome);
        }
        // Costruttori
        public Pilota(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }
        // Metodi
        public Pilota Copy()
        {
            return new Pilota(_nome, _cognome);
        }
    }
}
