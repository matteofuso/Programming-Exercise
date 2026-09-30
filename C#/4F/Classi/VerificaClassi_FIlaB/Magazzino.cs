using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;

namespace VerificaClassi_FIlaB
{
    internal class Magazzino
    {
        string _nome;
        List<Articolo> _articoli;
        static int _ultimoCodiceAssegnato = 1;
        // Proprietà
        public string Nome { get { return _nome; } }
        public int NumeroArticoli { get { return _articoli.Count; } }
        double Valore
        {
            get
            {
                double somma = 0;
                _articoli.ForEach(a => somma += a.Giacenza * a.Prezzo);
                return somma;
            }
        }
        public List<Articolo> Articoli
        {
            get
            {
                List<Articolo> copy = new List<Articolo>();
                _articoli.ForEach(a => copy.Add(a.Copy()));
                return copy;
            }
        }
        // Costruttore
        public Magazzino(string nome)
        {
            _nome = nome;
            _articoli = new List<Articolo>();
        }
        // Metodi
        public void Add(string descrizione, double prezzo)
        {
            _articoli.Add(new Articolo(_ultimoCodiceAssegnato++, descrizione, prezzo));
        }
        public string Movimento(int codice, double valore)
        {
            Articolo articolo = _articoli.Find(a => a.Codice == codice);
            if (articolo == null)
            {
                throw new Exception("Non esiste un articolo con il codice specificato");
            }
            return articolo.Movimento(valore);
        }
        public void Stampa()
        {
            Console.WriteLine("{0,-10} {1, -20} {2, -10} {3}", "Codice", "Descrizione", "Giacenza", "Prezzo (E)");
            _articoli.ForEach(a => Console.WriteLine(a));
            Console.WriteLine();
            Console.WriteLine("Valore economico del magazzino: {0}", Valore);
        }
        // Overload
        public override string ToString()
        {
            return _nome;
        }
    }
}
