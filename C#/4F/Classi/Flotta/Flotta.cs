using System;
using System.Collections.Generic;

namespace FlottaDiAuto
{
    internal class Flotta
    {
        List<Auto> _parcoMacchine;
        string _nome;
        string _autorizzazione;
        public List<Auto> ParcoMacchine
        {
            get { return _parcoMacchine.FindAll(a => true); }
        }
        public string Nome
        {
            get { return _nome; }
        }
        public string AutorizzazioneStatale
        {
            get { return _autorizzazione; }
        }
        public Auto Last
        {
            get { return _parcoMacchine[_parcoMacchine.Count - 1].Copy(); }
        }
        public Flotta(string nome, string autorizzazioneStatale)
        {
            _parcoMacchine = new List<Auto>();
            _nome = nome;
            _autorizzazione = autorizzazioneStatale;
        }
        public Flotta()
        {

        }
        void VisualizzaLista(List<Auto> vetture)
        {
            Console.WriteLine("Flotta {0}:", _nome);
            if (vetture.Count > 0)
            {
                Console.WriteLine("{0, -10} {1, -15} {2, -15} {3, -15} {4}", "Codice", "Marca", "Modello", "Targa", "Numero di Posti");
                vetture.ForEach(a =>
                {
                    Console.WriteLine("{0, -10} {1, -15} {2, -15} {3, -15} {4}", a.Codice, a.Marca, a.Modello, a.Targa, a.Posti);
                });
            }
            else
            {
                Console.WriteLine("Non ci sono veicoli");
            }
        }
        public void Visualizza()
        {
            VisualizzaLista(_parcoMacchine);
        }
        public void VisualizzaPerMarca(string marca)
        {
            VisualizzaLista(_parcoMacchine.FindAll(v => v.Marca == marca));
        }
        public void VisualizzaPerNumeroDiPosti(NumeroPosti posti)
        {
            VisualizzaLista(_parcoMacchine.FindAll(v => v.Posti == posti));
        }
        public bool Exists(string targa)
        {
            return _parcoMacchine.Exists(a => a.Targa == targa);
        }
        public bool Exists(int codice)
        {
            return _parcoMacchine.Exists(a => a.Codice == codice);
        }
        public Auto Find(string targa)
        {
            return _parcoMacchine.Find(a => a.Targa == targa);
        }
        public Auto Find(int codice)
        {
            return _parcoMacchine.Find(a => a.Codice == codice);
        }
        public void Add(string marca, string modello, string targa, NumeroPosti posti)
        {
            _parcoMacchine.Add(new Auto(marca, modello, targa, posti));
        }
        public void Add(Auto auto)
        {
            _parcoMacchine.Add(auto);
        }
        public void Elimina(string targa)
        {
            _parcoMacchine.RemoveAll(v => v.Targa == targa);
        }
        public void Elimina(int codice)
        {
            _parcoMacchine.RemoveAll(v => v.Codice == codice);
        }
        void Visualizza(Auto auto)
        {
            Console.WriteLine("Veicolo:");
            Console.WriteLine("========================");
            Console.WriteLine("Codice: {0}", auto.Codice);
            Console.WriteLine("Marca: {0}", auto.Marca);
            Console.WriteLine("Modello: {0}", auto.Modello);
            Console.WriteLine("Targa: {0}", auto.Targa);
            Console.WriteLine("Numero di posti: {0}", auto.Posti);
        }
        public void Visualizza(string targa)
        {
            Visualizza(_parcoMacchine.Find(v => v.Targa == targa));
        }
        public void Visualizza(int codice)
        {
            Visualizza(_parcoMacchine.Find(v => v.Codice == codice));
        }
    }
}
