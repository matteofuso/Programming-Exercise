using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Channels;

namespace FlottaAuto
{
    internal class Flotta
    {
        List<Auto> _parcoMacchine;
        string _nome;
        string _autorizzazione;
        int _veicoli;
        // Proprietà
        public string Nome
        {
            get { return _nome; }
        }
        public string AutorizzazioneStatale
        {
            get { return _autorizzazione; }
        }
        public int Veicoli
        {
            get { return _parcoMacchine.Count; }
        }
        public List<Auto> ParcoMacchine
        {
            get
            {
                List<Auto> copia = new List<Auto>();
                _parcoMacchine.ForEach(a => copia.Add(a.Copy()));
                return copia;
            }
        }
        public Auto UltimaAuto
        {
            get
            {
                if (_parcoMacchine.Count != 0)
                {
                    return _parcoMacchine[_parcoMacchine.Count - 1].Copy();
                }
                else
                {
                    return null;
                }
            }
        }
        // Costruttore
        public Flotta(string nome, string autorizzazioneStatale)
        {
            _nome = nome;
            _autorizzazione = autorizzazioneStatale;
            _parcoMacchine = new List<Auto>();
            _veicoli = 0;
        }
        // Metodi
        static void VisualizzaLista(List<Auto> auto, string header)
        {
            if (auto.Count == 0)
            {
                throw new Exception("Impossibile trovare veicoli");
            }
            Console.WriteLine(header);
            Console.WriteLine("{0, -10} {1, -15} {2, -15} {3, -15} {4}", "Codice", "Marca", "Modello", "Targa", "Numero di Posti");
            auto.ForEach(a =>
            {
                Console.WriteLine("{0, -10} {1, -15} {2, -15} {3, -15} {4}", a.Codice, a.Marca, a.Modello, a.Targa, a.Posti);
            });
        }
        static void VisualizzaAuto(Auto auto, string header)
        {
            if (auto == null)
            {
                throw new Exception("Il veicolo non esiste");
            }
            Console.WriteLine(header);
            Console.WriteLine("========================");
            Console.WriteLine("Codice: {0}", auto.Codice);
            Console.WriteLine("Marca: {0}", auto.Marca);
            Console.WriteLine("Modello: {0}", auto.Modello);
            Console.WriteLine("Targa: {0}", auto.Targa);
            Console.WriteLine("Numero di posti: {0}", auto.Posti);
        }
        public void VisualizzaParco()
        {
            VisualizzaLista(_parcoMacchine, string.Format("Flotta {0}", _nome));
        }
        public void VisualizzaPer(string marca)
        {
            VisualizzaLista(_parcoMacchine.FindAll(v => v.Marca == marca), string.Format("Flotta {0}", _nome));
        }
        public void VisualizzaPer(NumeroPosti posti)
        {
            VisualizzaLista(_parcoMacchine.FindAll(v => v.Posti == posti), string.Format("Flotta {0}", _nome));
        }
        public void Visualizza(string targa)
        {
            VisualizzaAuto(_parcoMacchine.Find(v => v.Targa == targa), string.Format("Flotta {0}", _nome));
        }
        public void Visualizza(int codice)
        {
            VisualizzaAuto(_parcoMacchine.Find(v => v.Codice == codice), string.Format("Flotta {0}", _nome));
        }
        public void Add(string marca, string modello, string targa, NumeroPosti posti)
        {
            _parcoMacchine.Add(new Auto(_veicoli++, marca, modello, targa, posti));
        }
        void Add(int codice, string marca, string modello, string targa, NumeroPosti posti)
        {
            _parcoMacchine.Add(new Auto(codice, marca, modello, targa, posti));
            if (codice >= _veicoli)
            {
                _veicoli = codice + 1;
            }
        }
        public bool Exist(string targa)
        {
            return _parcoMacchine.Exists(v => v.Targa == targa);
        }
        public bool Exist(int codice)
        {
            return _parcoMacchine.Exists(v => v.Codice == codice);
        }
        public void Elimina(string targa)
        {
            if (_parcoMacchine.RemoveAll(v => v.Targa == targa) == 0)
            {
                throw new Exception(string.Format("Impossibile trovare veicoli con la targa {0}", targa));
            }
        }
        public void Elimina(int codice)
        {
            if (_parcoMacchine.RemoveAll(v => v.Codice == codice) == 0)
            {
                throw new Exception(string.Format("Impossibile trovare veicoli con il codice {0}", codice));
            }
        }
        public void Esporta(string file)
        {
            StreamWriter stream;
            try
            {
                stream = new StreamWriter(file);
            }
            catch (Exception)
            {
                throw new Exception("Impossibile aprire il file");
            }
            stream.WriteLine("Nome,Autorizzazione Statale");
            stream.WriteLine("{0},{1}", _nome, _autorizzazione);
            stream.WriteLine("Codice,Marca,Modello,Targa,Posti");
            _parcoMacchine.ForEach(a =>
            {
                stream.WriteLine("{0},{1},{2},{3},{4}", a.Codice, a.Marca, a.Modello, a.Targa, a.Posti);
            });
            stream.Close();
        }
        public void Importa(string file)
        {
            string[] values;
            StreamReader stream;
            try
            {
                stream = new StreamReader(file);
            }
            catch (Exception)
            {
                throw new Exception("Impossibile aprire il file");
            }
            stream.ReadLine();
            values = stream.ReadLine().Split(',');
            if (values.Length != 2)
            {
                throw new Exception("Errore nel formato del file");
            }
            _parcoMacchine.Clear();
            _nome = values[0];
            _autorizzazione = values[1];
            stream.ReadLine();
            while (!stream.EndOfStream)
            {
                values = stream.ReadLine().Split(',');
                if (values.Length != 5)
                {
                    throw new Exception("Errore nel formato del file");
                }
                Add(
                    int.Parse(values[0]),
                    values[1],
                    values[2],
                    values[3],
                    (NumeroPosti)Enum.Parse(typeof(NumeroPosti), values[4])
                );
            }
            stream.Close();
        }
    }
}
