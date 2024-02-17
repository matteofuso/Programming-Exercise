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
        Insetto _mosca, _ragno, _ape, _farfalla;
        Insetto _current;
        int _miss;
        public InsectKiller()

        {
            InitializeComponent();
            _point = new Point();
            _mosca = new Insetto("Tim", "Muscidae", "Mosca", "Vola", "mosca.gif", "moscaX.gif");
            _ragno = new Insetto("Jonny", "Artropodi", "Ragno", "Cammina", "ragno.gif", "ragnoX.gif");
            _ape = new Insetto("Eresh", "Apipi", "Ape", "Vola", "ape.gif", "apeX.gif");
            _farfalla = new Insetto("Sims", "Lepidotteri", "Farfalla", "Vola", "farfalla.gif", "farfallaX.gif");
            _current = _mosca;
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
                if(Facile.Checked)
                {
                    Medio.Checked = true;
                } else if (Medio.Checked)
                {
                    Difficile.Checked = true;
                } else
                {
                    Estrema.Checked = true;
                }
                MessageBox.Show("Insetto colpito", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BugImage.Image = _current.Vivo;
                Timer.Enabled = true;
            }
        }
        private void UpdateBug()
        {
            if (Timer.Enabled)
            {
                BugImage.Image = _current.Vivo;
            }
            else
            {
                BugImage.Image = _current.Morto;
            }
        }
        private void SpiderRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _current = _ragno;
            UpdateBug();
        }

        private void InsectGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void Toggle_Click(object sender, EventArgs e)
        {
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
                Reset_Click(sender, e);
            }
        }

        private void MosquitoRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _current = _mosca;
            UpdateBug();
        }

        private void BatterflyRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _current = _farfalla;
            UpdateBug();
        }

        private void BeeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _current = _ape;
            UpdateBug();
        }
    }
}
