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
            this.MosquitoRadioBtn = new System.Windows.Forms.RadioButton();
            this.SpiderRadioBtn = new System.Windows.Forms.RadioButton();
            this.BatterflyRadioBtn = new System.Windows.Forms.RadioButton();
            this.BeeRadioBtn = new System.Windows.Forms.RadioButton();
            this.InsectGroupBox = new System.Windows.Forms.GroupBox();
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
            this.InsectGroupBox.SuspendLayout();
            this.GardenPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BugImage)).BeginInit();
            this.Difficoltà.SuspendLayout();
            this.SuspendLayout();
            // 
            // MosquitoRadioBtn
            // 
            this.MosquitoRadioBtn.AutoSize = true;
            this.MosquitoRadioBtn.Checked = true;
            this.MosquitoRadioBtn.Location = new System.Drawing.Point(17, 15);
            this.MosquitoRadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.MosquitoRadioBtn.Name = "MosquitoRadioBtn";
            this.MosquitoRadioBtn.Size = new System.Drawing.Size(57, 17);
            this.MosquitoRadioBtn.TabIndex = 3;
            this.MosquitoRadioBtn.TabStop = true;
            this.MosquitoRadioBtn.Text = "Mosca";
            this.MosquitoRadioBtn.UseVisualStyleBackColor = true;
            this.MosquitoRadioBtn.CheckedChanged += new System.EventHandler(this.MosquitoRadioBtn_CheckedChanged);
            // 
            // SpiderRadioBtn
            // 
            this.SpiderRadioBtn.AutoSize = true;
            this.SpiderRadioBtn.Location = new System.Drawing.Point(17, 46);
            this.SpiderRadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SpiderRadioBtn.Name = "SpiderRadioBtn";
            this.SpiderRadioBtn.Size = new System.Drawing.Size(57, 17);
            this.SpiderRadioBtn.TabIndex = 4;
            this.SpiderRadioBtn.Text = "Ragno";
            this.SpiderRadioBtn.UseVisualStyleBackColor = true;
            this.SpiderRadioBtn.CheckedChanged += new System.EventHandler(this.SpiderRadioBtn_CheckedChanged);
            // 
            // BatterflyRadioBtn
            // 
            this.BatterflyRadioBtn.AutoSize = true;
            this.BatterflyRadioBtn.Location = new System.Drawing.Point(17, 77);
            this.BatterflyRadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BatterflyRadioBtn.Name = "BatterflyRadioBtn";
            this.BatterflyRadioBtn.Size = new System.Drawing.Size(59, 17);
            this.BatterflyRadioBtn.TabIndex = 5;
            this.BatterflyRadioBtn.Text = "Farfalla";
            this.BatterflyRadioBtn.UseVisualStyleBackColor = true;
            this.BatterflyRadioBtn.CheckedChanged += new System.EventHandler(this.BatterflyRadioBtn_CheckedChanged);
            // 
            // BeeRadioBtn
            // 
            this.BeeRadioBtn.AutoSize = true;
            this.BeeRadioBtn.Location = new System.Drawing.Point(17, 107);
            this.BeeRadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BeeRadioBtn.Name = "BeeRadioBtn";
            this.BeeRadioBtn.Size = new System.Drawing.Size(44, 17);
            this.BeeRadioBtn.TabIndex = 6;
            this.BeeRadioBtn.Text = "Ape";
            this.BeeRadioBtn.UseVisualStyleBackColor = true;
            this.BeeRadioBtn.CheckedChanged += new System.EventHandler(this.BeeRadioBtn_CheckedChanged);
            // 
            // InsectGroupBox
            // 
            this.InsectGroupBox.Controls.Add(this.BeeRadioBtn);
            this.InsectGroupBox.Controls.Add(this.BatterflyRadioBtn);
            this.InsectGroupBox.Controls.Add(this.SpiderRadioBtn);
            this.InsectGroupBox.Controls.Add(this.MosquitoRadioBtn);
            this.InsectGroupBox.Location = new System.Drawing.Point(779, 11);
            this.InsectGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.InsectGroupBox.Name = "InsectGroupBox";
            this.InsectGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.InsectGroupBox.Size = new System.Drawing.Size(85, 137);
            this.InsectGroupBox.TabIndex = 7;
            this.InsectGroupBox.TabStop = false;
            this.InsectGroupBox.Text = "Insetti";
            this.InsectGroupBox.Enter += new System.EventHandler(this.InsectGroupBox_Enter);
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
            this.GardenPanel.Location = new System.Drawing.Point(11, 11);
            this.GardenPanel.Margin = new System.Windows.Forms.Padding(2);
            this.GardenPanel.Name = "GardenPanel";
            this.GardenPanel.Size = new System.Drawing.Size(751, 417);
            this.GardenPanel.TabIndex = 2;
            this.GardenPanel.Click += new System.EventHandler(this.GardenPanel_Click);
            // 
            // BugImage
            // 
            this.BugImage.BackColor = System.Drawing.Color.Transparent;
            this.BugImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BugImage.Location = new System.Drawing.Point(151, 141);
            this.BugImage.Margin = new System.Windows.Forms.Padding(2);
            this.BugImage.Name = "BugImage";
            this.BugImage.Size = new System.Drawing.Size(41, 47);
            this.BugImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BugImage.TabIndex = 0;
            this.BugImage.TabStop = false;
            this.BugImage.Click += new System.EventHandler(this.BugImage_Click);
            // 
            // Secret
            // 
            this.Secret.Location = new System.Drawing.Point(887, 224);
            this.Secret.Name = "Secret";
            this.Secret.Size = new System.Drawing.Size(75, 34);
            this.Secret.TabIndex = 8;
            this.Secret.Text = "How did u get here?";
            this.Secret.UseVisualStyleBackColor = true;
            this.Secret.Click += new System.EventHandler(this.BugImage_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(796, 409);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(56, 19);
            this.ExitBtn.TabIndex = 0;
            this.ExitBtn.Text = "Esci";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Facile
            // 
            this.Facile.AutoSize = true;
            this.Facile.Checked = true;
            this.Facile.Location = new System.Drawing.Point(15, 19);
            this.Facile.Name = "Facile";
            this.Facile.Size = new System.Drawing.Size(53, 17);
            this.Facile.TabIndex = 10;
            this.Facile.TabStop = true;
            this.Facile.Text = "Facile";
            this.Facile.UseVisualStyleBackColor = true;
            this.Facile.CheckedChanged += new System.EventHandler(this.Facile_CheckedChanged);
            // 
            // Medio
            // 
            this.Medio.AutoSize = true;
            this.Medio.Location = new System.Drawing.Point(15, 52);
            this.Medio.Name = "Medio";
            this.Medio.Size = new System.Drawing.Size(54, 17);
            this.Medio.TabIndex = 11;
            this.Medio.Text = "Medio";
            this.Medio.UseVisualStyleBackColor = true;
            this.Medio.CheckedChanged += new System.EventHandler(this.Medio_CheckedChanged);
            // 
            // Difficile
            // 
            this.Difficile.AutoSize = true;
            this.Difficile.Location = new System.Drawing.Point(15, 86);
            this.Difficile.Name = "Difficile";
            this.Difficile.Size = new System.Drawing.Size(59, 17);
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
            this.Difficoltà.Location = new System.Drawing.Point(779, 166);
            this.Difficoltà.Name = "Difficoltà";
            this.Difficoltà.Size = new System.Drawing.Size(85, 154);
            this.Difficoltà.TabIndex = 13;
            this.Difficoltà.TabStop = false;
            this.Difficoltà.Text = "Difficoltà";
            // 
            // Estrema
            // 
            this.Estrema.AutoSize = true;
            this.Estrema.Location = new System.Drawing.Point(15, 121);
            this.Estrema.Name = "Estrema";
            this.Estrema.Size = new System.Drawing.Size(63, 17);
            this.Estrema.TabIndex = 13;
            this.Estrema.Text = "Estrema";
            this.Estrema.UseVisualStyleBackColor = true;
            this.Estrema.CheckedChanged += new System.EventHandler(this.Estrema_CheckedChanged);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(796, 386);
            this.Reset.Margin = new System.Windows.Forms.Padding(2);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(56, 19);
            this.Reset.TabIndex = 14;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = false;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // InsectKiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 439);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Difficoltà);
            this.Controls.Add(this.Secret);
            this.Controls.Add(this.InsectGroupBox);
            this.Controls.Add(this.GardenPanel);
            this.Controls.Add(this.ExitBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InsectKiller";
            this.Text = "Insetto Killer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InsectKiller_FormClosing);
            this.InsectGroupBox.ResumeLayout(false);
            this.InsectGroupBox.PerformLayout();
            this.GardenPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BugImage)).EndInit();
            this.Difficoltà.ResumeLayout(false);
            this.Difficoltà.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel GardenPanel;
        private System.Windows.Forms.RadioButton MosquitoRadioBtn;
        private System.Windows.Forms.RadioButton SpiderRadioBtn;
        private System.Windows.Forms.RadioButton BatterflyRadioBtn;
        private System.Windows.Forms.RadioButton BeeRadioBtn;
        private System.Windows.Forms.GroupBox InsectGroupBox;
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
    }
}

