using System;
using System.Drawing;

namespace Insetto_Killer
{
    internal class EssereVivente
    {
        public string Mobilità { get; set; }
        public string Specie { get; set; }
        public string Path { get; set; }
        public Image Vivo { get; }
        public Image Morto { get; }
        // Costruttori
        public EssereVivente(string specie, string mobilità, string path, string imgVivo, string imgMorto)
        {
            Specie = specie;
            Mobilità = mobilità;
            Path = path;
            try
            {
                Vivo = Image.FromFile(System.IO.Path.Combine(path, imgVivo));
                Morto = Image.FromFile(System.IO.Path.Combine(path, imgMorto));
            }
            catch (Exception)
            {
                throw new Exception("Immagini non trovate");
            }
        }
        public EssereVivente(string specie, string mobilità, string imgVivo, string imgMorto) : this(specie , mobilità, System.IO.Path.Combine(Environment.CurrentDirectory, "assets"), imgVivo, imgMorto) { }
        public EssereVivente(string path, string imgVivo, string imgMorto) : this(null, null, path, imgVivo, imgMorto) { }
        public EssereVivente(string imgVivo, string imgMorto) : this(null, null, imgVivo, imgMorto) { }
        // Metodi

    }
}
