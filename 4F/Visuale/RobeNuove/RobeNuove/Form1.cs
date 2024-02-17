using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobeNuove
{
    public partial class Form1 : Form
    {
        Persona _persona;
        Studente _studente;
        List<Persona> _personaList;
        public Form1()
        {
            InitializeComponent();
            _personaList = new List<Persona>();
        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _persona = new Persona();
            textBox1.Text = _persona.ToString();
            listBox1.Items.Add(_persona.ToString());
            _personaList.Add(_studente);
        }

        private void studenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _studente = new Studente();
            textBox2.Text = _studente.ToString();
            listBox1.Items.Add(_studente.ToString());
            _personaList.Add(_studente);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void personaToolStripMenuItem1_Click(Object sender, EventArgs e)
        {
            _persona = new Persona(textBox3.Text, textBox4.Text);
            textBox1.Text = _persona.ToString();
            listBox1.Items.Add(_persona.ToString());
            _personaList.Add(_persona);
        }

        private void studenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _studente = new Studente(textBox3.Text, textBox4.Text);
            textBox2.Text = _studente.ToString();
            listBox1.Items.Add(_studente.ToString());
            _personaList.Add(_studente);
        }
    }
}
