using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Policy;
using System.Threading;

namespace Clinica
{
    internal class Reparto
    {
        Specializzazione _specializzazione;
        List<Paziente> _pazienti;
        Termometro _termometro;
        string _identificativo;
        int _letti;
        int _position = 0;
        // Override
        public override string ToString()
        {
            return string.Format("{0} - {1} ({2})", _identificativo, _specializzazione.ToString().Replace('_', ' '), _letti);
        }
        // Costruttori
        public Reparto(Specializzazione specializzazione, string identificativo, int letti)
        {
            _specializzazione = specializzazione;
            _identificativo = identificativo;
            _letti = letti;
            _termometro = new Termometro();
            _pazienti = new List<Paziente>();
        }
        // Metodi
        public Paziente GetPaziente()
        {
            return new Paziente(_pazienti[_position]);
        }
        public void Reset()
        {
            _position = 0;
        }
        public bool Previews()
        {
            if (_position == 0)
            {
                return true;
            }
            _position--;
            return false;
        }
        public bool Next()
        {
            if (_position == _pazienti.Count - 1)
            {
                return true;
            }
            _position++;
            return false;
        }
        public void Visualizza()
        {
            Console.WriteLine(" Reparto {0}", this);
            if (_letti == 0)
            {
                Console.WriteLine(" Non ci sono ancora pazienti");
            }
            else
            {
                Console.WriteLine(" {0,-30} {1,-30} {2}", "Nome", "Cognome", "Temperatura (°C)");
                _pazienti.ForEach(p => Console.WriteLine(" {0,-30} {1,-30} {2}", p.GetNome(), p.GetCognome(), p.GetTemperatura()));
            }
        }
        public void Aggiungi(Paziente paziente)
        {
            if (_pazienti.Count == _letti)
            {
                throw new Exception("Sono esauriti i letti a disposizione");
            }
            _pazienti.Add(paziente);
        }
        public void AggiornaTemperatura(int paziente)
        {
            _pazienti[paziente].AggiornaTemperatura(_termometro);
        }
        public void LeggiTermometro(double temperatura)
        {
            _termometro.SetTemperatura(temperatura);
        }
        // Getters
        public Specializzazione GetSpecializzazione()
        {
            return _specializzazione;
        }
        public List<Paziente> GetPazienti()
        {
            return _pazienti.FindAll(p => true);
        }
        public string GetIdentificativo()
        {
            return _identificativo;
        }
        public int GetLettiOccupati()
        {
            return _pazienti.Count;
        }
        public int GetLettiDisponibili()
        {
            return _letti;
        }
    }
}
