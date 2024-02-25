using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public override string ToString()
        {
            return string.Format("Quadrato - Posizione: ({0};{1}), Lato: {2}, Area: {3}, Perimetro: {4}", _puntoBase.X, _puntoBase.Y, Width, CalcoloArea(), CalcolaPerimetro());
        }
    }
}
