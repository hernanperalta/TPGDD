namespace UberFrba.Menu
{
    partial class Menu_ABM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitulo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.selectorABM = new System.Windows.Forms.ComboBox();
            this.botonVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(118, 51);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(49, 13);
            this.labelTitulo.TabIndex = 5;
            this.labelTitulo.Text = "ABM Rol";
            this.labelTitulo.Click += new System.EventHandler(this.labelTitulo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Continuar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleccione Alta/Baja/Modificacion";
            // 
            // selectorABM
            // 
            this.selectorABM.FormattingEnabled = true;
            this.selectorABM.Items.AddRange(new object[] {
            "Alta ",
            "Baja",
            "Modificacion"});
            this.selectorABM.Location = new System.Drawing.Point(90, 123);
            this.selectorABM.Name = "selectorABM";
            this.selectorABM.Size = new System.Drawing.Size(121, 21);
            this.selectorABM.TabIndex = 7;
            this.selectorABM.SelectedIndexChanged += new System.EventHandler(this.selectorABM_SelectedIndexChanged);
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(57, 168);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(75, 23);
            this.botonVolver.TabIndex = 9;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.button2_Click);
            // 
            // Menu_ABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 215);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectorABM);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTitulo);
            this.Name = "Menu_ABM";
            this.Text = "Menu ABM";
            this.Load += new System.EventHandler(this.Menu_ABM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectorABM;
        private System.Windows.Forms.Button botonVolver;

    }
}