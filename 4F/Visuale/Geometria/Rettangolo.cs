using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometria
{
    internal class Rettangolo
    {
        Punto _puntoBase;
        double _width;
        double _height;

        public double Width
        {
            get { return _width; }
            set { if (value <= 0) throw new Exception("La larghezza deve essere positiva"); _width = value; }
        }
        public double Height
        {
            get { return _height; }
            set { if (value <= 0) throw new Exception("La larghezza deve essere positiva"); _height = value; }
        }
        public Punto PuntoBase
        {
            get { return _puntoBase.Copy(); }
            set { if (value == null) throw new Exception("La larghezza deve essere positiva"); _puntoBase = value.Copy(); }
        }
        public Rettangolo(Punto punto, double height, double width)
        {
            _puntoBase = punto.Copy();
            Width = width;
            Height = height;
        }
        public Rettangolo(double height, double width) : this(new Punto(0, 0), height, width) { }
        public double CalcolaPerimetro()
        {
            return (Width * Height) * 2;
        }
        public double CalcoloArea()
        {
            return (Width * Height);
        }
        public override string ToString()
        {
            return string.Format("Posizione: ({0};{1}), Larghezza: {2}, Altezza: {3}", _puntoBase.X, _puntoBase.Y, Width, Height);
        }
    }
}
