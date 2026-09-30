using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Insetto_Killer
{
    public partial class InsectKiller : Form
    {
        Random _random = new Random();
        Point _point;
        Insetto _current;
        int _miss;
        public InsectKiller()

        {
            InitializeComponent();
            _point = new Point();
            Insetti.Items.Add(new Insetto("Tim", "Muscidae", "Mosca", "Vola", "mosca.gif", "moscaX.gif"));
            Insetti.Items.Add(new Insetto("Jonny", "Artropodi", "Ragno", "Cammina", "ragno.gif", "ragnoX.gif"));
            Insetti.Items.Add(new Insetto("Eresh", "Apipi", "Ape", "Vola", "ape.gif", "apeX.gif"));
            Insetti.Items.Add(new Insetto("Sims", "Lepidotteri", "Farfalla", "Vola", "farfalla.gif", "farfallaX.gif"));
            _current = (Insetto)Insetti.Items[0];
            BugImage.Image = _current.Vivo;
            _miss = 0;
        }
        private void InsectKiller_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di voler chiudere?", "Avviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _point.X = _random.Next(0, GardenPanel.Width - BugImage.Width - 1);
            _point.Y = _random.Next(0, GardenPanel.Height - BugImage.Height - 1);
            BugImage.Location = _point;
        }

        private void BugImage_Click(object sender, EventArgs e)
        {
            if (Timer.Enabled)
            {
                Timer.Enabled = false;
                BugImage.Image = _current.Morto;
                if (Facile.Checked)
                {
                    Medio.Checked = true;
                }
                else if (Medio.Checked)
                {
                    Difficile.Checked = true;
                }
                else
                {
                    Estrema.Checked = true;
                }
                MessageBox.Show("Insetto colpito", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BugImage.Image = _current.Vivo;
                Timer.Enabled = true;
                Timer_Tick(null, null);
            }
        }
        private void Toggle_Click(object sender, EventArgs e)
        {
            if (Toggle.Text == "Pausa")
            {
                Toggle.Text = "Riprendi";
            }
            else
            {
                Toggle.Text = "Pausa";
            }
            Timer.Enabled = !Timer.Enabled;
        }

        private void Facile_CheckedChanged(object sender, EventArgs e)
        {
            Timer.Interval = 1400;
        }

        private void Medio_CheckedChanged(object sender, EventArgs e)
        {
            Timer.Interval = 1100;
        }

        private void Difficile_CheckedChanged(object sender, EventArgs e)
        {
            Timer.Interval = 800;
        }

        private void Estrema_CheckedChanged(object sender, EventArgs e)
        {
            Timer.Interval = 500;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Timer.Interval = 1400;
            _miss = 0;
            Facile.Checked = true;
        }

        private void GardenPanel_Click(object sender, EventArgs e)
        {
            if (++_miss == 5)
            {
                MessageBox.Show("Hai sbagliato a cliccare troppe volte", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset_Click(null, null);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _current = (Insetto)Insetti.Items[Insetti.SelectedIndex];
            if (Timer.Enabled)
            {
                BugImage.Image = _current.Vivo;
            }
            else
            {
                BugImage.Image = _current.Morto;
            }
        }

    }
}
