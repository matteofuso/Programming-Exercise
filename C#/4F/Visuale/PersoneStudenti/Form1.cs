using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersoneStudenti
{
    public partial class FormPersone : Form
    {
        List<Persona> _persone;
        public FormPersone()
        {
            InitializeComponent();
            _persone = new List<Persona>();
            DropDownSesso.DataSource = Enum.GetValues(typeof(Genere));
            DropDownNazionalità.DataSource = Enum.GetValues(typeof(Nazionalità));
        }

        private void FormTextChange(object sender, EventArgs e)
        {
            int matricola;
            if (TextBoxMatricola.Enabled)
            {
                if (!int.TryParse(TextBoxMatricola.Text, out matricola) || matricola < 0)
                {
                    ButtonAggiungi.Enabled = false;
                    return;
                }
            }
            if (TextBoxNome.Text == "" || TextBoxCognome.Text == "" || _persone.Exists(p => p.Nome == TextBoxNome.Text && p.Cognome == TextBoxCognome.Text))
            {
                ButtonAggiungi.Enabled = false;
            }
            else
            {
                ButtonAggiungi.Enabled = true;
            }
        }

        private void RadioButtonPersona_Click(object sender, EventArgs e)
        {
            TextBoxMatricola.Enabled = false;
        }

        private void RadioButtonStudente_Click(object sender, EventArgs e)
        {
            TextBoxMatricola.Enabled = true;
            FormTextChange(null, null);
        }

        private void ButtonAggiungi_Click(object sender, EventArgs e)
        {
            Genere sesso = (Genere)Enum.Parse(typeof(Genere), DropDownSesso.Text);
            Nazionalità nazionalità = (Nazionalità)Enum.Parse(typeof(Nazionalità), DropDownNazionalità.Text);
            if (TextBoxMatricola.Enabled)
            {
                _persone.Add(new Studente(TextBoxNome.Text, TextBoxCognome.Text, sesso, nazionalità, int.Parse(TextBoxMatricola.Text)));
            }
            else
            {
                _persone.Add(new Persona(TextBoxNome.Text, TextBoxCognome.Text, sesso, nazionalità));
            }
            ListBoxOggetti.Items.Add(_persone[_persone.Count - 1]);
            FormTextChange(null, null);
        }
    }
}
