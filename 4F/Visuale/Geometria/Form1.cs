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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonRettangolo_Click(object sender, EventArgs e)
        {
            try
            {
                Figure.Items.Add(new Rettangolo(
                    new Punto(int.Parse(textboxx.Text), int.Parse(textboxy.Text)),
                    double.Parse(textBoxLato1.Text),
                    double.Parse(textBoxlato2.Text)
                ));
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nell'inserimento dei dati", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonQuadrato_Click(object sender, EventArgs e)
        {
            try
            {
                Figure.Items.Add(new Quadrato(
                    new Punto(int.Parse(textboxx.Text), int.Parse(textboxy.Text)),
                    double.Parse(textBoxLato1.Text)
                ));
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nell'inserimento dei dati", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonParallelepipedo_Click(object sender, EventArgs e)
        {
            try
            {
                Figure.Items.Add(new Parallelepipedo(
                    new Punto(int.Parse(textboxx.Text), int.Parse(textboxy.Text)),
                    double.Parse(textBoxLato1.Text),
                    double.Parse(textBoxlato2.Text),
                    double.Parse(textBoxProfondità.Text)
                ));
            }
            catch (Exception)
            {
                MessageBox.Show("Errore nell'inserimento dei dati", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            int x, y;
            double lato1, lato2, prodondità;
            try
            {
                x = int.Parse(textboxx.Text);
                y = int.Parse(textboxy.Text);
                lato1 = double.Parse(textBoxLato1.Text);
                if (x <= 0 || y <= 0 || lato1 <= 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                buttonQuadrato.Enabled = false;
                buttonRettangolo.Enabled = false;
                buttonParallelepipedo.Enabled = false;
                return;
            }
            buttonQuadrato.Enabled = true;
            if (double.TryParse(textBoxlato2.Text, out lato2) && lato2 > 0)
            {
                buttonRettangolo.Enabled = true;
            }
            else
            {
                buttonRettangolo.Enabled = false;
                buttonParallelepipedo.Enabled = false;
                return;
            }
            if (double.TryParse(textBoxProfondità.Text, out prodondità) && prodondità > 0)
            {
                buttonParallelepipedo.Enabled = true;
            }
            else
            {
                buttonParallelepipedo.Enabled = false;
            }
        }
    }
}
