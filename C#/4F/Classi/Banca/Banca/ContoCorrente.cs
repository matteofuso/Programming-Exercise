using System;

namespace IntesaSanPaolo
{
    internal class ContoCorrente
    {
        int _codice;
        double _saldo;
        string _nome;
        string _cognome;
        // Proprietà
        public double Saldo
        {
            get { return _saldo; }
            set { if (value < 0) throw new Exception("Saldo insufficente"); _saldo = value; }
        }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public int Codice { get => _codice; private set => _codice = value; }
        // Costruttore
        ContoCorrente(int codice, string nome, string cognome, double saldo)
        {
            Codice = codice;
            Nome = nome;
            Cognome = cognome;
            Saldo = saldo;
        }
        public ContoCorrente(int codice, string nome, string cognome) : this (codice, nome, cognome, 10) {}
        public ContoCorrente(string nome, string cognome) : this(0, nome, cognome, 10) { }
        // Metodi
        public ContoCorrente Copy()
        {
            return new ContoCorrente(Codice, Nome, Cognome, Saldo);
        }
        // Override
        public override string ToString()
        {
            return string.Format("{0,-10} {1, -20} {2, -20} {3}", Codice, Cognome, Nome, Saldo);
        }
    }
}
