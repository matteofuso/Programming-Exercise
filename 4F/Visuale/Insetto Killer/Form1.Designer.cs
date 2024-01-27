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
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ReloadBtn = new System.Windows.Forms.Button();
            this.MosquitoRadioBtn = new System.Windows.Forms.RadioButton();
            this.SpiderRadioBtn = new System.Windows.Forms.RadioButton();
            this.BatterflyRadioBtn = new System.Windows.Forms.RadioButton();
            this.BeeRadioBtn = new System.Windows.Forms.RadioButton();
            this.InsectGroupBox = new System.Windows.Forms.GroupBox();
            this.GardenPanel = new System.Windows.Forms.Panel();
            this.BugImage = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.InsectGroupBox.SuspendLayout();
            this.GardenPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BugImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(693, 415);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 0;
            this.ExitBtn.Text = "Esci";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ReloadBtn
            // 
            this.ReloadBtn.Location = new System.Drawing.Point(693, 386);
            this.ReloadBtn.Name = "ReloadBtn";
            this.ReloadBtn.Size = new System.Drawing.Size(75, 23);
            this.ReloadBtn.TabIndex = 1;
            this.ReloadBtn.Text = "Ricarica";
            this.ReloadBtn.UseVisualStyleBackColor = true;
            this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
            // 
            // MosquitoRadioBtn
            // 
            this.MosquitoRadioBtn.AutoSize = true;
            this.MosquitoRadioBtn.Checked = true;
            this.MosquitoRadioBtn.Location = new System.Drawing.Point(23, 19);
            this.MosquitoRadioBtn.Name = "MosquitoRadioBtn";
            this.MosquitoRadioBtn.Size = new System.Drawing.Size(69, 20);
            this.MosquitoRadioBtn.TabIndex = 3;
            this.MosquitoRadioBtn.TabStop = true;
            this.MosquitoRadioBtn.Text = "Mosca";
            this.MosquitoRadioBtn.UseVisualStyleBackColor = true;
            this.MosquitoRadioBtn.CheckedChanged += new System.EventHandler(this.MosquitoRadioBtn_CheckedChanged);
            // 
            // SpiderRadioBtn
            // 
            this.SpiderRadioBtn.AutoSize = true;
            this.SpiderRadioBtn.Location = new System.Drawing.Point(23, 57);
            this.SpiderRadioBtn.Name = "SpiderRadioBtn";
            this.SpiderRadioBtn.Size = new System.Drawing.Size(69, 20);
            this.SpiderRadioBtn.TabIndex = 4;
            this.SpiderRadioBtn.Text = "Ragno";
            this.SpiderRadioBtn.UseVisualStyleBackColor = true;
            this.SpiderRadioBtn.CheckedChanged += new System.EventHandler(this.SpiderRadioBtn_CheckedChanged);
            // 
            // BatterflyRadioBtn
            // 
            this.BatterflyRadioBtn.AutoSize = true;
            this.BatterflyRadioBtn.Location = new System.Drawing.Point(23, 95);
            this.BatterflyRadioBtn.Name = "BatterflyRadioBtn";
            this.BatterflyRadioBtn.Size = new System.Drawing.Size(73, 20);
            this.BatterflyRadioBtn.TabIndex = 5;
            this.BatterflyRadioBtn.Text = "Farfalla";
            this.BatterflyRadioBtn.UseVisualStyleBackColor = true;
            this.BatterflyRadioBtn.CheckedChanged += new System.EventHandler(this.BatterflyRadioBtn_CheckedChanged);
            // 
            // BeeRadioBtn
            // 
            this.BeeRadioBtn.AutoSize = true;
            this.BeeRadioBtn.Location = new System.Drawing.Point(23, 132);
            this.BeeRadioBtn.Name = "BeeRadioBtn";
            this.BeeRadioBtn.Size = new System.Drawing.Size(53, 20);
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
            this.InsectGroupBox.Location = new System.Drawing.Point(675, 12);
            this.InsectGroupBox.Name = "InsectGroupBox";
            this.InsectGroupBox.Size = new System.Drawing.Size(113, 169);
            this.InsectGroupBox.TabIndex = 7;
            this.InsectGroupBox.TabStop = false;
            // 
            // GardenPanel
            // 
            this.GardenPanel.BackgroundImage = global::Insetto_Killer.Properties.Resources.prato2;
            this.GardenPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GardenPanel.Controls.Add(this.BugImage);
            this.GardenPanel.Location = new System.Drawing.Point(12, 12);
            this.GardenPanel.Name = "GardenPanel";
            this.GardenPanel.Size = new System.Drawing.Size(652, 426);
            this.GardenPanel.TabIndex = 2;
            // 
            // BugImage
            // 
            this.BugImage.BackColor = System.Drawing.Color.Transparent;
            this.BugImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BugImage.Image = global::Insetto_Killer.Properties.Resources.mosca;
            this.BugImage.Location = new System.Drawing.Point(3, 3);
            this.BugImage.Name = "BugImage";
            this.BugImage.Size = new System.Drawing.Size(83, 83);
            this.BugImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BugImage.TabIndex = 0;
            this.BugImage.TabStop = false;
            this.BugImage.Click += new System.EventHandler(this.BugImage_Click);
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 700;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // InsectKiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InsectGroupBox);
            this.Controls.Add(this.GardenPanel);
            this.Controls.Add(this.ReloadBtn);
            this.Controls.Add(this.ExitBtn);
            this.Name = "InsectKiller";
            this.Text = "Insetto Killer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InsectKiller_FormClosing);
            this.InsectGroupBox.ResumeLayout(false);
            this.InsectGroupBox.PerformLayout();
            this.GardenPanel.ResumeLayout(false);
            this.GardenPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BugImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button ReloadBtn;
        private System.Windows.Forms.Panel GardenPanel;
        private System.Windows.Forms.RadioButton MosquitoRadioBtn;
        private System.Windows.Forms.RadioButton SpiderRadioBtn;
        private System.Windows.Forms.RadioButton BatterflyRadioBtn;
        private System.Windows.Forms.RadioButton BeeRadioBtn;
        private System.Windows.Forms.GroupBox InsectGroupBox;
        private System.Windows.Forms.PictureBox BugImage;
        private System.Windows.Forms.Timer Timer;
    }
}

