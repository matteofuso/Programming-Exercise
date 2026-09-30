using System;

namespace FlottaDiAuto
{
    internal class Auto
    {
        string _marca;
        int _codice;
        string _modello;
        string _targa;
        NumeroPosti _posti;
        static int _codiceSequenziale = 0;
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
        public int Codice
        {
            get { return _codice; }
        }
        public NumeroPosti Posti
        {
            get { return _posti; }
        }
        public override string ToString()
        {
            return string.Format("({0} - {1}) {2} {3} a {4} posti", _codice, _targa, _marca, _modello, _posti);
        }
        public Auto(string marca, string modello, string targa, NumeroPosti posti)
        {
            _codice = _codiceSequenziale++;
            _marca = marca;
            _modello = modello;
            _targa = targa;
            _posti = posti;
        }
        public Auto(string marca, string modello, string targa, NumeroPosti posti, int codice)
        {
            _codice = codice;
            _marca = marca;
            _modello = modello;
            _targa = targa;
            _posti = posti;
            if (codice > _codiceSequenziale)
            {
                _codiceSequenziale = codice + 1;
            }
        }
        public Auto Copy()
        {
            return new Auto(_marca, _modello, _targa, _posti, _codice);
        }
    }
}
