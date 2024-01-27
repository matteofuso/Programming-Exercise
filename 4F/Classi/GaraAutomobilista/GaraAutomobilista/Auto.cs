using System;

namespace GaraAutomobilista
{
    internal class Auto
    {
        Pilota _pilota;
        string _scuderia;
        TimeSpan _tempo;
        // Proprietà
        public TimeSpan Tempo
        {
            get { return _tempo; }
            set { _tempo = value; }
        }
        public Pilota Pilota
        {
            get { return _pilota.Copy(); }
        }
        public string Scuderia
        {
            get { return _scuderia; }
        }
        // Override
        public override string ToString()
        {
            return string.Format("Scuderia: {0}, pilota: {1}", _scuderia, _pilota);
        }
        // Costruttori
        public Auto(Pilota pilota, string scuderia)
        {
            _pilota = pilota;
            _scuderia = scuderia;
        }
        //Metodi
    }
}
