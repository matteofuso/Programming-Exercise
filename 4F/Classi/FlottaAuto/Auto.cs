using System;

namespace FlottaAuto
{
    internal class Auto
    {
        int _codice;
        string _marca;
        string _modello;
        string _targa;
        NumeroPosti _posti;
        // Proprietà
        public int Codice
        {
            get { return _codice; }
        }
        public string Marca
        {
            get { return _marca; }
        }
        public string Modello
        {
            get { return _modello; }
        }
        public string Targa
        {
            get { return _targa; }
        }
        public NumeroPosti Posti
        {
            get { return _posti; }
        }
        // Costruttori
        public Auto(int codice, string marca, string modello, string targa, NumeroPosti posti)
        {
            _codice = codice;
            _marca = marca;
            _modello = modello;
            _targa = targa;
            _posti = posti;
        }
        // Metodi
        public Auto Copy()
        {
            return new Auto(_codice, _marca, _modello, _targa, _posti);
        }
        // Override
        public override string ToString()
        {
            return string.Format("({0} - {1}) {2} {3} a {4} posti", _codice, _targa, _marca, _modello, _posti);
        }
    }
}
