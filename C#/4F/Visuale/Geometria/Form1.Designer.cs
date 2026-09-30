namespace Geometria
{
    partial class Form1
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
            this.textboxx = new System.Windows.Forms.TextBox();
            this.labelx = new System.Windows.Forms.Label();
            this.labely = new System.Windows.Forms.Label();
            this.textboxy = new System.Windows.Forms.TextBox();
            this.labellato1 = new System.Windows.Forms.Label();
            this.textBoxLato1 = new System.Windows.Forms.TextBox();
            this.labelato2 = new System.Windows.Forms.Label();
            this.textBoxlato2 = new System.Windows.Forms.TextBox();
            this.labelProdondità = new System.Windows.Forms.Label();
            this.textBoxProfondità = new System.Windows.Forms.TextBox();
            this.buttonRettangolo = new System.Windows.Forms.Button();
            this.buttonQuadrato = new System.Windows.Forms.Button();
            this.buttonParallelepipedo = new System.Windows.Forms.Button();
            this.Figure = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textboxx
            // 
            this.textboxx.Location = new System.Drawing.Point(21, 125);
            this.textboxx.Name = "textboxx";
            this.textboxx.Size = new System.Drawing.Size(100, 20);
            this.textboxx.TabIndex = 0;
            this.textboxx.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(18, 109);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(68, 13);
            this.labelx.TabIndex = 1;
            this.labelx.Text = "Coordinata X";
            // 
            // labely
            // 
            this.labely.AutoSize = true;
            this.labely.Location = new System.Drawing.Point(18, 158);
            this.labely.Name = "labely";
            this.labely.Size = new System.Drawing.Size(68, 13);
            this.labely.TabIndex = 3;
            this.labely.Text = "Coordinata Y";
            // 
            // textboxy
            // 
            this.textboxy.Location = new System.Drawing.Point(21, 174);
            this.textboxy.Name = "textboxy";
            this.textboxy.Size = new System.Drawing.Size(100, 20);
            this.textboxy.TabIndex = 2;
            this.textboxy.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // labellato1
            // 
            this.labellato1.AutoSize = true;
            this.labellato1.Location = new System.Drawing.Point(18, 198);
            this.labellato1.Name = "labellato1";
            this.labellato1.Size = new System.Drawing.Size(37, 13);
            this.labellato1.TabIndex = 6;
            this.labellato1.Text = "Lato 1";
            // 
            // textBoxLato1
            // 
            this.textBoxLato1.Location = new System.Drawing.Point(21, 214);
            this.textBoxLato1.Name = "textBoxLato1";
            this.textBoxLato1.Size = new System.Drawing.Size(100, 20);
            this.textBoxLato1.TabIndex = 5;
            this.textBoxLato1.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // labelato2
            // 
            this.labelato2.AutoSize = true;
            this.labelato2.Location = new System.Drawing.Point(18, 241);
            this.labelato2.Name = "labelato2";
            this.labelato2.Size = new System.Drawing.Size(37, 13);
            this.labelato2.TabIndex = 8;
            this.labelato2.Text = "Lato 2";
            // 
            // textBoxlato2
            // 
            this.textBoxlato2.Location = new System.Drawing.Point(21, 257);
            this.textBoxlato2.Name = "textBoxlato2";
            this.textBoxlato2.Size = new System.Drawing.Size(100, 20);
            this.textBoxlato2.TabIndex = 7;
            this.textBoxlato2.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // labelProdondità
            // 
            this.labelProdondità.AutoSize = true;
            this.labelProdondità.Location = new System.Drawing.Point(18, 282);
            this.labelProdondità.Name = "labelProdondità";
            this.labelProdondità.Size = new System.Drawing.Size(58, 13);
            this.labelProdondità.TabIndex = 10;
            this.labelProdondità.Text = "Prodondità";
            // 
            // textBoxProfondità
            // 
            this.textBoxProfondità.Location = new System.Drawing.Point(21, 298);
            this.textBoxProfondità.Name = "textBoxProfondità";
            this.textBoxProfondità.Size = new System.Drawing.Size(100, 20);
            this.textBoxProfondità.TabIndex = 9;
            this.textBoxProfondità.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // buttonRettangolo
            // 
            this.buttonRettangolo.Enabled = false;
            this.buttonRettangolo.Location = new System.Drawing.Point(416, 272);
            this.buttonRettangolo.Name = "buttonRettangolo";
            this.buttonRettangolo.Size = new System.Drawing.Size(75, 23);
            this.buttonRettangolo.TabIndex = 11;
            this.buttonRettangolo.Text = "Rettangolo";
            this.buttonRettangolo.UseVisualStyleBackColor = true;
            this.buttonRettangolo.Click += new System.EventHandler(this.buttonRettangolo_Click);
            // 
            // buttonQuadrato
            // 
            this.buttonQuadrato.Enabled = false;
            this.buttonQuadrato.Location = new System.Drawing.Point(323, 272);
            this.buttonQuadrato.Name = "buttonQuadrato";
            this.buttonQuadrato.Size = new System.Drawing.Size(75, 23);
            this.buttonQuadrato.TabIndex = 12;
            this.buttonQuadrato.Text = "Quadrato";
            this.buttonQuadrato.UseVisualStyleBackColor = true;
            this.buttonQuadrato.Click += new System.EventHandler(this.buttonQuadrato_Click);
            // 
            // buttonParallelepipedo
            // 
            this.buttonParallelepipedo.Enabled = false;
            this.buttonParallelepipedo.Location = new System.Drawing.Point(514, 272);
            this.buttonParallelepipedo.Name = "buttonParallelepipedo";
            this.buttonParallelepipedo.Size = new System.Drawing.Size(90, 23);
            this.buttonParallelepipedo.TabIndex = 13;
            this.buttonParallelepipedo.Text = "Parallelepipedo";
            this.buttonParallelepipedo.UseVisualStyleBackColor = true;
            this.buttonParallelepipedo.Click += new System.EventHandler(this.buttonParallelepipedo_Click);
            // 
            // Figure
            // 
            this.Figure.Location = new System.Drawing.Point(139, 159);
            this.Figure.Name = "Figure";
            this.Figure.Size = new System.Drawing.Size(649, 95);
            this.Figure.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Figure);
            this.Controls.Add(this.buttonParallelepipedo);
            this.Controls.Add(this.buttonQuadrato);
            this.Controls.Add(this.buttonRettangolo);
            this.Controls.Add(this.labelProdondità);
            this.Controls.Add(this.textBoxProfondità);
            this.Controls.Add(this.labelato2);
            this.Controls.Add(this.textBoxlato2);
            this.Controls.Add(this.labellato1);
            this.Controls.Add(this.textBoxLato1);
            this.Controls.Add(this.labely);
            this.Controls.Add(this.textboxy);
            this.Controls.Add(this.labelx);
            this.Controls.Add(this.textboxx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxx;
        private System.Windows.Forms.Label labelx;
        private System.Windows.Forms.Label labely;
        private System.Windows.Forms.TextBox textboxy;
        private System.Windows.Forms.Label labellato1;
        private System.Windows.Forms.TextBox textBoxLato1;
        private System.Windows.Forms.Label labelato2;
        private System.Windows.Forms.TextBox textBoxlato2;
        private System.Windows.Forms.Label labelProdondità;
        private System.Windows.Forms.TextBox textBoxProfondità;
        private System.Windows.Forms.Button buttonRettangolo;
        private System.Windows.Forms.Button buttonQuadrato;
        private System.Windows.Forms.Button buttonParallelepipedo;
        private System.Windows.Forms.ListBox Figure;
    }
}

