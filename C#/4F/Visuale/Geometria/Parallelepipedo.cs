using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Parallelepipedo : Rettangolo
    {
        double _profondità;
        public double Prodondità
        {
            get { return _profondità; }
            set { if (value <= 0) throw new Exception("Un lato non può essere negativo o nullo"); _profondità = value; }
        }
        public Parallelepipedo(Punto punto, double height, double width, double profondità) : base(punto, height, width)
        {
            Prodondità = profondità;
        }
        public Parallelepipedo(double height, double width, double profondità) : base(height, width)
        {
            Prodondità = profondità;
        }
        public double CalcoloVolume()
        {
            return base.CalcoloArea() * Prodondità;
        }
        public override string ToString()
        {
            return string.Format("Parallelepipedo - Posizione: ({0};{1}), Larghezza: {2}, Altezza: {3}, Prodondità: {4}, Area Base: {5}, Perimetro Base: {6}, Volume: {7}", _puntoBase.X, _puntoBase.Y, Width, Height, Prodondità, CalcoloArea(), CalcolaPerimetro(), CalcoloVolume());
        }
    }
}
