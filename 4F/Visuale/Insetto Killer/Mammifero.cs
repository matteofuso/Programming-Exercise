using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insetto_Killer
{
    internal class Mammifero : EssereVivente
    {
        public string Famiglia { get; set; }
        public string Nome { get; set; }
        // Proprietà

        // Costruttori
        public Mammifero(string nome, string famiglia, string specie, string mobilità, string path, string imgVivo, string imgMorto) : base(specie, mobilità, path, imgVivo, imgMorto)
        {
            Nome = nome;
            Famiglia = famiglia;
        }
        public Mammifero(string nome, string famiglia, string specie, string mobilità, string imgVivo, string imgMorto) : base(specie, mobilità, imgVivo, imgMorto)
        {
            Nome = nome;
            Famiglia = famiglia;
        }

    }
}
