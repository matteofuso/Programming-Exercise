using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobeNuove
{
    internal class Studente : Persona
    {
        static int _matricole;
        int _matricola;
        // Proprietà
        public int Matricola { get => _matricola; set => _matricola = value; }
        // Costruttori
        public Studente(string nome, string cognome) : base(nome, cognome)
        {
            _matricola = ++_matricole;
        }
        public Studente() : base("Nino", "Di Bianca") { }
        // Override
        new public string ToString()
        {
            return string.Format("{0} ({1})", base.ToString(), Matricola);
        }
    }
}
