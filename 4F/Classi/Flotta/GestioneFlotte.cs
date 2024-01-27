using System;
using System.Collections.Generic;
using System.IO;

namespace FlottaDiAuto
{
    static internal class GestioneFlotte
    {
        public static void Add(List<Flotta> flotte, string nome)
        {
            string autorizzazione;
            do
            {
                autorizzazione = Ministero.AutorizzazioneStatale();
            } while (Exist(flotte, autorizzazione));
            flotte.Add(new Flotta(nome, autorizzazione));
        }
        public static bool Exist(List<Flotta> flotte, string autorizzazioneStatale)
        {
            return flotte.Exists(f => f.AutorizzazioneStatale == autorizzazioneStatale);
        }
        public static bool ExistTarga(List<Flotta> flotte, string targa)
        {
            return flotte.Exists(f => f.Exists(targa));
        }
        public static string[] DescrizioneFlotte(List<Flotta> flotte)
        {
            string[] descrizioni = new string[flotte.Count];
            for (int i = 0; i < flotte.Count; i++)
            {
                descrizioni[i] = string.Format("{0} {1}", flotte[i].AutorizzazioneStatale, flotte[i].Nome);
            }
            return descrizioni;
        }
        public static void Salva(List<Flotta> flotte)
        {
            string directory = Path.Combine(Gestione.path, "saves");
            Gestione.PreparaDirectory(directory);
            StreamWriter stream;
            List<Auto> parco;
            flotte.ForEach(f =>
            {
                stream = new StreamWriter(Path.Combine(directory, string.Format("{0} {1}.csv", f.AutorizzazioneStatale, f.Nome)));
                parco = f.ParcoMacchine;
                stream.WriteLine("Codice,Marca,Modello,Targa,Posti");
                parco.ForEach(a =>
                {
                    stream.WriteLine("{0},{1},{2},{3},{4}", a.Codice, a.Marca, a.Modello, a.Targa, a.Posti);
                });
                stream.Close();
            });
        }
        public static void Importa(List<Flotta> flotte)
        {
            flotte.Clear();
            string fileName;
            string directory = Path.Combine(Gestione.path, "saves");
            Gestione.PreparaDirectory(directory);
            string[] saves = Directory.GetFiles(directory, "*.csv");
            string[] values;
            StreamReader stream;
            foreach (string save in saves)
            {
                stream = new StreamReader(save);
                stream.ReadLine();
                fileName = Path.GetFileName(save).Replace(".csv", "");
                flotte.Add(new Flotta(fileName.Substring(7), fileName.Substring(0,6)));
                while (!stream.EndOfStream)
                {
                    values = stream.ReadLine().Split(',');
                    flotte[flotte.Count - 1].Add(new Auto(
                        values[1],
                        values[2],
                        values[3],
                        (NumeroPosti)Enum.Parse(typeof(NumeroPosti), values[4]),
                        int.Parse(values[0])
                    ));
                }
                stream.Close();
            }
        }
    }
}
