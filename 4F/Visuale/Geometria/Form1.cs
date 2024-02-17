using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Punto point = new Punto(50, 50);
            Rettangolo rettangolo = new Rettangolo(point, 100, 200);
            Quadrato quadrato = new Quadrato(300);
            point.X += 100;
            Parallelogramma parallelogramma = new Parallelogramma(point, 100, 200, 50);
            MessageBox.Show(rettangolo.ToString(), "Rettangolo");
            MessageBox.Show(quadrato.ToString(), "Quadrato");
            MessageBox.Show(parallelogramma.ToString(), "Parallelogramma");
        }
    }
}
