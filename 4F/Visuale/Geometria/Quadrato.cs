using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Quadrato : Rettangolo
    {
        public double Lato
        {
            get { return Height; }
            set { Height = value; Width = value; }
        }
        public Quadrato(Punto punto, double lato) : base(punto, lato, lato) { }
        public Quadrato(double lato) : base(lato, lato) { }
    }
}
