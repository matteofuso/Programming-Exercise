namespace PersoneStudenti
{
    partial class FormPersone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPersone));
            this.DropDownSesso = new System.Windows.Forms.ComboBox();
            this.DropDownNazionalità = new System.Windows.Forms.ComboBox();
            this.TextBoxNome = new System.Windows.Forms.TextBox();
            this.TextBoxCognome = new System.Windows.Forms.TextBox();
            this.LabelNome = new System.Windows.Forms.Label();
            this.LabelCognome = new System.Windows.Forms.Label();
            this.LabelSesso = new System.Windows.Forms.Label();
            this.LabelNazionalità = new System.Windows.Forms.Label();
            this.RadioButtonPersona = new System.Windows.Forms.RadioButton();
            this.RadioButtonStudente = new System.Windows.Forms.RadioButton();
            this.LabelMatricola = new System.Windows.Forms.Label();
            this.TextBoxMatricola = new System.Windows.Forms.TextBox();
            this.GroupBoxOggetto = new System.Windows.Forms.GroupBox();
            this.ButtonAggiungi = new System.Windows.Forms.Button();
            this.ListBoxOggetti = new System.Windows.Forms.ListBox();
            this.GroupBoxOggetto.SuspendLayout();
            this.SuspendLayout();
            // 
            // DropDownSesso
            // 
            this.DropDownSesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDownSesso.FormattingEnabled = true;
            this.DropDownSesso.Location = new System.Drawing.Point(36, 144);
            this.DropDownSesso.Name = "DropDownSesso";
            this.DropDownSesso.Size = new System.Drawing.Size(121, 24);
            this.DropDownSesso.TabIndex = 0;
            // 
            // DropDownNazionalità
            // 
            this.DropDownNazionalità.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropDownNazionalità.FormattingEnabled = true;
            this.DropDownNazionalità.Location = new System.Drawing.Point(36, 190);
            this.DropDownNazionalità.Name = "DropDownNazionalità";
            this.DropDownNazionalità.Size = new System.Drawing.Size(121, 24);
            this.DropDownNazionalità.TabIndex = 1;
            // 
            // TextBoxNome
            // 
            this.TextBoxNome.Location = new System.Drawing.Point(36, 56);
            this.TextBoxNome.Name = "TextBoxNome";
            this.TextBoxNome.Size = new System.Drawing.Size(100, 22);
            this.TextBoxNome.TabIndex = 2;
            this.TextBoxNome.TextChanged += new System.EventHandler(this.FormTextChange);
            // 
            // TextBoxCognome
            // 
            this.TextBoxCognome.Location = new System.Drawing.Point(36, 100);
            this.TextBoxCognome.Name = "TextBoxCognome";
            this.TextBoxCognome.Size = new System.Drawing.Size(100, 22);
            this.TextBoxCognome.TabIndex = 3;
            this.TextBoxCognome.TextChanged += new System.EventHandler(this.FormTextChange);
            // 
            // LabelNome
            // 
            this.LabelNome.AutoSize = true;
            this.LabelNome.Location = new System.Drawing.Point(33, 37);
            this.LabelNome.Name = "LabelNome";
            this.LabelNome.Size = new System.Drawing.Size(44, 16);
            this.LabelNome.TabIndex = 4;
            this.LabelNome.Text = "Nome";
            // 
            // LabelCognome
            // 
            this.LabelCognome.AutoSize = true;
            this.LabelCognome.Location = new System.Drawing.Point(33, 81);
            this.LabelCognome.Name = "LabelCognome";
            this.LabelCognome.Size = new System.Drawing.Size(66, 16);
            this.LabelCognome.TabIndex = 5;
            this.LabelCognome.Text = "Cognome";
            // 
            // LabelSesso
            // 
            this.LabelSesso.AutoSize = true;
            this.LabelSesso.Location = new System.Drawing.Point(33, 125);
            this.LabelSesso.Name = "LabelSesso";
            this.LabelSesso.Size = new System.Drawing.Size(46, 16);
            this.LabelSesso.TabIndex = 6;
            this.LabelSesso.Text = "Sesso";
            // 
            // LabelNazionalità
            // 
            this.LabelNazionalità.AutoSize = true;
            this.LabelNazionalità.Location = new System.Drawing.Point(33, 171);
            this.LabelNazionalità.Name = "LabelNazionalità";
            this.LabelNazionalità.Size = new System.Drawing.Size(74, 16);
            this.LabelNazionalità.TabIndex = 7;
            this.LabelNazionalità.Text = "Nazionalità";
            // 
            // RadioButtonPersona
            // 
            this.RadioButtonPersona.AutoSize = true;
            this.RadioButtonPersona.Checked = true;
            this.RadioButtonPersona.Location = new System.Drawing.Point(6, 21);
            this.RadioButtonPersona.Name = "RadioButtonPersona";
            this.RadioButtonPersona.Size = new System.Drawing.Size(79, 20);
            this.RadioButtonPersona.TabIndex = 8;
            this.RadioButtonPersona.TabStop = true;
            this.RadioButtonPersona.Text = "Persona";
            this.RadioButtonPersona.UseVisualStyleBackColor = true;
            this.RadioButtonPersona.Click += new System.EventHandler(this.RadioButtonPersona_Click);
            // 
            // RadioButtonStudente
            // 
            this.RadioButtonStudente.AutoSize = true;
            this.RadioButtonStudente.Location = new System.Drawing.Point(6, 47);
            this.RadioButtonStudente.Name = "RadioButtonStudente";
            this.RadioButtonStudente.Size = new System.Drawing.Size(81, 20);
            this.RadioButtonStudente.TabIndex = 9;
            this.RadioButtonStudente.Text = "Studente";
            this.RadioButtonStudente.UseVisualStyleBackColor = true;
            this.RadioButtonStudente.Click += new System.EventHandler(this.RadioButtonStudente_Click);
            // 
            // LabelMatricola
            // 
            this.LabelMatricola.AutoSize = true;
            this.LabelMatricola.Location = new System.Drawing.Point(33, 217);
            this.LabelMatricola.Name = "LabelMatricola";
            this.LabelMatricola.Size = new System.Drawing.Size(62, 16);
            this.LabelMatricola.TabIndex = 10;
            this.LabelMatricola.Text = "Matricola";
            // 
            // TextBoxMatricola
            // 
            this.TextBoxMatricola.Enabled = false;
            this.TextBoxMatricola.Location = new System.Drawing.Point(36, 236);
            this.TextBoxMatricola.Name = "TextBoxMatricola";
            this.TextBoxMatricola.Size = new System.Drawing.Size(100, 22);
            this.TextBoxMatricola.TabIndex = 11;
            this.TextBoxMatricola.TextChanged += new System.EventHandler(this.FormTextChange);
            // 
            // GroupBoxOggetto
            // 
            this.GroupBoxOggetto.Controls.Add(this.RadioButtonStudente);
            this.GroupBoxOggetto.Controls.Add(this.RadioButtonPersona);
            this.GroupBoxOggetto.Location = new System.Drawing.Point(35, 264);
            this.GroupBoxOggetto.Name = "GroupBoxOggetto";
            this.GroupBoxOggetto.Size = new System.Drawing.Size(101, 84);
            this.GroupBoxOggetto.TabIndex = 12;
            this.GroupBoxOggetto.TabStop = false;
            this.GroupBoxOggetto.Text = "Oggetto";
            // 
            // ButtonAggiungi
            // 
            this.ButtonAggiungi.Enabled = false;
            this.ButtonAggiungi.Location = new System.Drawing.Point(32, 381);
            this.ButtonAggiungi.Name = "ButtonAggiungi";
            this.ButtonAggiungi.Size = new System.Drawing.Size(75, 31);
            this.ButtonAggiungi.TabIndex = 13;
            this.ButtonAggiungi.Text = "Aggiungi";
            this.ButtonAggiungi.UseVisualStyleBackColor = true;
            this.ButtonAggiungi.Click += new System.EventHandler(this.ButtonAggiungi_Click);
            // 
            // ListBoxOggetti
            // 
            this.ListBoxOggetti.FormattingEnabled = true;
            this.ListBoxOggetti.ItemHeight = 16;
            this.ListBoxOggetti.Location = new System.Drawing.Point(191, 56);
            this.ListBoxOggetti.Name = "ListBoxOggetti";
            this.ListBoxOggetti.Size = new System.Drawing.Size(571, 356);
            this.ListBoxOggetti.TabIndex = 14;
            // 
            // FormPersone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListBoxOggetti);
            this.Controls.Add(this.ButtonAggiungi);
            this.Controls.Add(this.GroupBoxOggetto);
            this.Controls.Add(this.TextBoxMatricola);
            this.Controls.Add(this.LabelMatricola);
            this.Controls.Add(this.LabelNazionalità);
            this.Controls.Add(this.LabelSesso);
            this.Controls.Add(this.LabelCognome);
            this.Controls.Add(this.LabelNome);
            this.Controls.Add(this.TextBoxCognome);
            this.Controls.Add(this.TextBoxNome);
            this.Controls.Add(this.DropDownNazionalità);
            this.Controls.Add(this.DropDownSesso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPersone";
            this.Text = "Persone e Studenti";
            this.GroupBoxOggetto.ResumeLayout(false);
            this.GroupBoxOggetto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DropDownSesso;
        private System.Windows.Forms.ComboBox DropDownNazionalità;
        private System.Windows.Forms.TextBox TextBoxNome;
        private System.Windows.Forms.TextBox TextBoxCognome;
        private System.Windows.Forms.Label LabelNome;
        private System.Windows.Forms.Label LabelCognome;
        private System.Windows.Forms.Label LabelSesso;
        private System.Windows.Forms.Label LabelNazionalità;
        private System.Windows.Forms.RadioButton RadioButtonPersona;
        private System.Windows.Forms.RadioButton RadioButtonStudente;
        private System.Windows.Forms.Label LabelMatricola;
        private System.Windows.Forms.TextBox TextBoxMatricola;
        private System.Windows.Forms.GroupBox GroupBoxOggetto;
        private System.Windows.Forms.Button ButtonAggiungi;
        private System.Windows.Forms.ListBox ListBoxOggetti;
    }
}

