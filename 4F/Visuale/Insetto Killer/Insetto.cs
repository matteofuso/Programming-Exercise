using System;

namespace Insetto_Killer
{
    internal class Insetto : EssereVivente
    {
        public string Famiglia { get; set; }
        public string Nome { get; set; }
        // Proprietà

        // Costruttori
        public Insetto(string nome, string famiglia, string specie, string mobilità, string path, string imgVivo, string imgMorto) : base(specie, mobilità, path, imgVivo, imgMorto)
        {
            Nome = nome;
            Famiglia = famiglia;
        }
        public Insetto(string nome, string famiglia, string specie, string mobilità, string imgVivo, string imgMorto) : base(specie, mobilità, imgVivo, imgMorto)
        {
            Nome = nome;
            Famiglia = famiglia;
        }
    }
}
