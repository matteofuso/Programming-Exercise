using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntesaSanPaolo
{
    internal class Banca
    {
        static int _id = 1;
        string _nome;
        List<ContoCorrente> _conti;
        // Proprietà
        public string Nome { get => _nome; set => _nome = value; }
        public int NumeroConti { get { return _conti.Count; } }
        public double Valore
        {
            get
            {
                double somma = 0;
                _conti.ForEach(cc => somma += cc.Saldo);
                return somma;
            }
        }
        public List<ContoCorrente> Conti
        {
            get
            {
                List<ContoCorrente> temp = new List<ContoCorrente>();
                _conti.ForEach(cc => temp.Add(cc.Copy()));
                return temp;
            }
        }
        // Costruttore
        Banca(string nome, List<ContoCorrente> conti)
        {
            List<ContoCorrente> temp = new List<ContoCorrente>();
            conti.ForEach(cc => temp.Add(cc.Copy()));
            _conti = temp;
            _nome = nome;
        }
        public Banca(string nome) : this(nome, new List<ContoCorrente>()) { }
        // Metodi
        public Banca Copy()
        {
            return new Banca(Nome, _conti);
        }
        public void Add(ContoCorrente conto)
        {
            _conti.Add(new ContoCorrente(_id++, conto.Nome, conto.Cognome));
        }
        public void Versamento(int codice, double valore)
        {
            ContoCorrente articolo = _conti.Find(cc => cc.Codice == codice);
            if (articolo == null)
            {
                throw new Exception("Non esiste un conto corrente con il codice specificato");
            }
            articolo.Saldo += valore;
        }
        public void Prelievo(int codice, double valore) { Versamento(codice, -valore); }
        public void Stampa()
        {
            if (NumeroConti == 0)
            {
                throw new Exception("Non ci sono conti");
            }
            Console.WriteLine("{0,-10} {1, -20} {2, -20} {3}", "Codice", "Cognome", "Nome", "Saldo (E)");
            _conti.ForEach(a => Console.WriteLine(a));
            Console.WriteLine();
            Console.WriteLine("Valore economico della banca: {0}", Valore);
        }
        // Override
        public override string ToString()
        {
            return Nome;
        }
    }
}
