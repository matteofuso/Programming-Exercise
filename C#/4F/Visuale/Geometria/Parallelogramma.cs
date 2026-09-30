using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Parallelogramma : Rettangolo
    {
        double _latoObliquo;
        public double LatoObliquo
        {
            get {  return _latoObliquo; }
            set { if (value <= 0) throw new Exception("Un lato non può essere negativo o nullo"); _latoObliquo = value; }
        }
        public Parallelogramma(Punto punto, double height, double width, double latoObliquo) : base(punto, height, width)
        {
            LatoObliquo = latoObliquo;
        }
        public Parallelogramma(double height, double width, double latoObliquo) : base(height, width)
        {
            LatoObliquo = latoObliquo;
        }
    }
}
