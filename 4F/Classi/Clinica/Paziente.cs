using System;

namespace Clinica
{
    internal class Paziente
    {
        string _cognome;
        string _nome;
        double _temperatura;
        // Override
        public override string ToString()
        {
            return string.Format("{0} {1} ({2} °C)", _nome, _cognome, _temperatura);
        }
        // Costruttori
        public Paziente(Paziente paziente)
        {
            _cognome = paziente._cognome;
            _nome = paziente._nome;
            _temperatura = paziente._temperatura;
        }
        public Paziente(string nome, string cognome, double temperatura = 36)
        {
            _cognome = cognome;
            _nome = nome;
            _temperatura = temperatura;
        }
        // Getters
        public string GetNome()
        {
            return _nome;
        }
        public string GetCognome()
        {
            return _cognome;
        }
        public double GetTemperatura()
        {
            return _temperatura;
        }
        // Setters
        public void AggiornaTemperatura(Termometro termometro)
        {
            _temperatura = termometro.GetTemperatura();
        }
    }
}
