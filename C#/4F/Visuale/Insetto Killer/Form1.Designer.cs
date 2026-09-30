namespace Insetto_Killer
{
    partial class InsectKiller
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.GardenPanel = new System.Windows.Forms.Panel();
            this.BugImage = new System.Windows.Forms.PictureBox();
            this.Secret = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.Facile = new System.Windows.Forms.RadioButton();
            this.Medio = new System.Windows.Forms.RadioButton();
            this.Difficile = new System.Windows.Forms.RadioButton();
            this.Difficoltà = new System.Windows.Forms.GroupBox();
            this.Estrema = new System.Windows.Forms.RadioButton();
            this.Reset = new System.Windows.Forms.Button();
            this.Insetti = new System.Windows.Forms.ListBox();
            this.Toggle = new System.Windows.Forms.Button();
            this.GardenPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BugImage)).BeginInit();
            this.Difficoltà.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1400;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // GardenPanel
            // 
            this.GardenPanel.BackgroundImage = global::Insetto_Killer.Properties.Resources.prato2;
            this.GardenPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GardenPanel.Controls.Add(this.BugImage);
            this.GardenPanel.Location = new System.Drawing.Point(15, 14);
            this.GardenPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GardenPanel.Name = "GardenPanel";
            this.GardenPanel.Size = new System.Drawing.Size(1001, 569);
            this.GardenPanel.TabIndex = 2;
            this.GardenPanel.Click += new System.EventHandler(this.GardenPanel_Click);
            // 
            // BugImage
            // 
            this.BugImage.BackColor = System.Drawing.Color.Transparent;
            this.BugImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BugImage.Location = new System.Drawing.Point(201, 174);
            this.BugImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BugImage.Name = "BugImage";
            this.BugImage.Size = new System.Drawing.Size(55, 58);
            this.BugImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BugImage.TabIndex = 0;
            this.BugImage.TabStop = false;
            this.BugImage.Click += new System.EventHandler(this.BugImage_Click);
            // 
            // Secret
            // 
            this.Secret.Location = new System.Drawing.Point(1183, 276);
            this.Secret.Margin = new System.Windows.Forms.Padding(4);
            this.Secret.Name = "Secret";
            this.Secret.Size = new System.Drawing.Size(100, 42);
            this.Secret.TabIndex = 8;
            this.Secret.Text = "How did u get here?";
            this.Secret.UseVisualStyleBackColor = true;
            this.Secret.Click += new System.EventHandler(this.BugImage_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(1049, 560);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 0;
            this.ExitBtn.Text = "Esci";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Facile
            // 
            this.Facile.AutoSize = true;
            this.Facile.Checked = true;
            this.Facile.Location = new System.Drawing.Point(20, 23);
            this.Facile.Margin = new System.Windows.Forms.Padding(4);
            this.Facile.Name = "Facile";
            this.Facile.Size = new System.Drawing.Size(65, 20);
            this.Facile.TabIndex = 10;
            this.Facile.TabStop = true;
            this.Facile.Text = "Facile";
            this.Facile.UseVisualStyleBackColor = true;
            this.Facile.CheckedChanged += new System.EventHandler(this.Facile_CheckedChanged);
            // 
            // Medio
            // 
            this.Medio.AutoSize = true;
            this.Medio.Location = new System.Drawing.Point(20, 64);
            this.Medio.Margin = new System.Windows.Forms.Padding(4);
            this.Medio.Name = "Medio";
            this.Medio.Size = new System.Drawing.Size(66, 20);
            this.Medio.TabIndex = 11;
            this.Medio.Text = "Medio";
            this.Medio.UseVisualStyleBackColor = true;
            this.Medio.CheckedChanged += new System.EventHandler(this.Medio_CheckedChanged);
            // 
            // Difficile
            // 
            this.Difficile.AutoSize = true;
            this.Difficile.Location = new System.Drawing.Point(20, 106);
            this.Difficile.Margin = new System.Windows.Forms.Padding(4);
            this.Difficile.Name = "Difficile";
            this.Difficile.Size = new System.Drawing.Size(71, 20);
            this.Difficile.TabIndex = 12;
            this.Difficile.Text = "Difficile";
            this.Difficile.UseVisualStyleBackColor = true;
            this.Difficile.CheckedChanged += new System.EventHandler(this.Difficile_CheckedChanged);
            // 
            // Difficoltà
            // 
            this.Difficoltà.Controls.Add(this.Estrema);
            this.Difficoltà.Controls.Add(this.Difficile);
            this.Difficoltà.Controls.Add(this.Medio);
            this.Difficoltà.Controls.Add(this.Facile);
            this.Difficoltà.Location = new System.Drawing.Point(1032, 188);
            this.Difficoltà.Margin = new System.Windows.Forms.Padding(4);
            this.Difficoltà.Name = "Difficoltà";
            this.Difficoltà.Padding = new System.Windows.Forms.Padding(4);
            this.Difficoltà.Size = new System.Drawing.Size(113, 190);
            this.Difficoltà.TabIndex = 13;
            this.Difficoltà.TabStop = false;
            this.Difficoltà.Text = "Difficoltà";
            // 
            // Estrema
            // 
            this.Estrema.AutoSize = true;
            this.Estrema.Location = new System.Drawing.Point(20, 149);
            this.Estrema.Margin = new System.Windows.Forms.Padding(4);
            this.Estrema.Name = "Estrema";
            this.Estrema.Size = new System.Drawing.Size(78, 20);
            this.Estrema.TabIndex = 13;
            this.Estrema.Text = "Estrema";
            this.Estrema.UseVisualStyleBackColor = true;
            this.Estrema.CheckedChanged += new System.EventHandler(this.Estrema_CheckedChanged);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(1049, 522);
            this.Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 14;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = false;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Insetti
            // 
            this.Insetti.FormattingEnabled = true;
            this.Insetti.ItemHeight = 16;
            this.Insetti.Location = new System.Drawing.Point(1032, 76);
            this.Insetti.Name = "Insetti";
            this.Insetti.Size = new System.Drawing.Size(120, 68);
            this.Insetti.TabIndex = 15;
            this.Insetti.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Toggle
            // 
            this.Toggle.Location = new System.Drawing.Point(1049, 482);
            this.Toggle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Toggle.Name = "Toggle";
            this.Toggle.Size = new System.Drawing.Size(75, 23);
            this.Toggle.TabIndex = 16;
            this.Toggle.Text = "Pausa";
            this.Toggle.UseVisualStyleBackColor = false;
            this.Toggle.Click += new System.EventHandler(this.Toggle_Click);
            // 
            // InsectKiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 594);
            this.Controls.Add(this.Toggle);
            this.Controls.Add(this.Insetti);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Difficoltà);
            this.Controls.Add(this.Secret);
            this.Controls.Add(this.GardenPanel);
            this.Controls.Add(this.ExitBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InsectKiller";
            this.Text = "Insetto Killer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InsectKiller_FormClosing);
            this.GardenPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BugImage)).EndInit();
            this.Difficoltà.ResumeLayout(false);
            this.Difficoltà.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel GardenPanel;
        private System.Windows.Forms.PictureBox BugImage;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button Secret;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.RadioButton Facile;
        private System.Windows.Forms.RadioButton Medio;
        private System.Windows.Forms.RadioButton Difficile;
        private System.Windows.Forms.GroupBox Difficoltà;
        private System.Windows.Forms.RadioButton Estrema;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.ListBox Insetti;
        private System.Windows.Forms.Button Toggle;
    }
}

