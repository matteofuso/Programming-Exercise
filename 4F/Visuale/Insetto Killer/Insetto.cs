using System;
using System.IO;

namespace Insetto_Killer
{
    internal class Insetto
    {
        string _directory;
        string _bugAlive;
        string _bugDead;
        public string Alive
        {
            get { return Path.Combine(_directory, _bugAlive); }
            set { _bugAlive = value; }
        }
        public string Dead
        {
            get { return Path.Combine(_directory, _bugDead); }
            set { _bugDead = value; }
        }
        public Insetto(string alive, string dead)
        {
            _directory = Path.Combine(Environment.CurrentDirectory, "mosca_immagini");
            _bugAlive = alive;
            _bugDead = dead;
        }
    }
}
