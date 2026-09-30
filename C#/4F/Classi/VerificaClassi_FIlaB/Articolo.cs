using Microsoft.SqlServer.Server;
using System;

namespace VerificaClassi_FIlaB
{
    internal class Articolo
    {
        int _codice;
        string _descrizione;
        double _giacenza;
        double _prezzo;
        // Proprietà
        public int Codice { get { return _codice; } }
        public string Descrizione { get { return _descrizione; } }
        public double Giacenza { get { return _giacenza; } }
        public double Prezzo { get { return _prezzo; } }
        // Costruttori
        private Articolo(int codice, string descrizione, double prezzo, double giacenza)
        {
            _codice = codice;
            _descrizione = descrizione;
            _prezzo = prezzo;
            _giacenza = giacenza;
        }
        public Articolo(int codice, string descrizione, double prezzo) : this(codice, descrizione, prezzo, 10) { }
        public Articolo(string descrizione, double prezz) : this(0, descrizione, prezz, 10) { }
        // Metodi
        public Articolo Copy()
        {
            return new Articolo(_codice, _descrizione, _prezzo, _giacenza);
        }
        public string Movimento(double valore)
        {
            if (_giacenza + valore < 0)
            {
                throw new Exception("Quantità non sufficente per il prelievo");
            }
            _giacenza += valore;
            return string.Format("{0} - {1}, {2}", _codice, _descrizione, valore);
        }
        // Overload
        public override string ToString()
        {
            return string.Format("{0,-10} {1, -20} {2, -10} {3}", _codice, _descrizione, _giacenza, _prezzo);
        }
    }
}
