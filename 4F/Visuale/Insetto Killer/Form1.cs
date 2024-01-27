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
        Insetto _bug;
        public InsectKiller()

        {
            InitializeComponent();
            _point = new Point();
            _bug = new Insetto("mosca.gif", "moscaX.gif");
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
            BugImage.Image = Image.FromFile(_bug.Dead);
            Timer.Stop();
        }

        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            BugImage.Image = Image.FromFile(_bug.Alive);
            Timer.Start();
        }
        private void UpdateBug()
        {
            if (Timer.Enabled)
            {
                BugImage.Image = Image.FromFile(_bug.Alive);
            }
            else
            {
                BugImage.Image = Image.FromFile(_bug.Dead);
            }
        }
        private void SpiderRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _bug.Alive = "ragno.gif";
            _bug.Dead = "ragnoX.gif";
            UpdateBug();
        }

        private void MosquitoRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _bug.Alive = "mosca.gif";
            _bug.Dead = "moscaX.gif";
            UpdateBug();
        }

        private void BatterflyRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _bug.Alive = "farfalla.gif";
            _bug.Dead = "farfallaX.gif";
            UpdateBug();
        }

        private void BeeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _bug.Alive = "ape.gif";
            _bug.Dead = "apeX.gif";
            UpdateBug();
        }
    }
}
