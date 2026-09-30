using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobeNuove
{
    internal class Persona
    {
        string _nome;
        string _cognome;
        // Proprietà
        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        // Costruttore
        public Persona(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }
        public Persona() : this("Federico", "Melon") { }
        // Override
        public override string ToString()
        {
            return string.Format("{0} {1}", Nome, Cognome);
        }
    }
}
