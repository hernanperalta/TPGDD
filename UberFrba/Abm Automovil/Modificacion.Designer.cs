namespace UberFrba.Abm_Automovil
{
    partial class Modificacion
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
            this.marca = new System.Windows.Forms.TextBox();
            this.restaurar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.numeroChofer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.modelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.habilitado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.volver = new System.Windows.Forms.Button();
            this.listaDeTurnos = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.patente = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // marca
            // 
            this.marca.Location = new System.Drawing.Point(48, 104);
            this.marca.Name = "marca";
            this.marca.Size = new System.Drawing.Size(100, 20);
            this.marca.TabIndex = 29;
            this.marca.TextChanged += new System.EventHandler(this.marca_TextChanged);
            // 
            // restaurar
            // 
            this.restaurar.Location = new System.Drawing.Point(224, 309);
            this.restaurar.Name = "restaurar";
            this.restaurar.Size = new System.Drawing.Size(109, 32);
            this.restaurar.TabIndex = 28;
            this.restaurar.Text = "Restaurar Valores";
            this.restaurar.UseVisualStyleBackColor = true;
            this.restaurar.Click += new System.EventHandler(this.restaurar_Click);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(129, 247);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(109, 32);
            this.guardar.TabIndex = 27;
            this.guardar.Text = "Guardar automóvil";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // numeroChofer
            // 
            this.numeroChofer.Location = new System.Drawing.Point(233, 104);
            this.numeroChofer.Name = "numeroChofer";
            this.numeroChofer.Size = new System.Drawing.Size(100, 20);
            this.numeroChofer.TabIndex = 26;
            this.numeroChofer.TextChanged += new System.EventHandler(this.numeroChofer_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Número de chofer :";
            // 
            // modelo
            // 
            this.modelo.Location = new System.Drawing.Point(48, 173);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(100, 20);
            this.modelo.TabIndex = 21;
            this.modelo.TextChanged += new System.EventHandler(this.modelo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Modelo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Marca :";
            // 
            // habilitado
            // 
            this.habilitado.AutoSize = true;
            this.habilitado.Location = new System.Drawing.Point(221, 39);
            this.habilitado.Name = "habilitado";
            this.habilitado.Size = new System.Drawing.Size(73, 17);
            this.habilitado.TabIndex = 34;
            this.habilitado.Text = "Habilitado";
            this.habilitado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Patente de Automovil : ";
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(35, 309);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(109, 32);
            this.volver.TabIndex = 39;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // listaDeTurnos
            // 
            this.listaDeTurnos.FormattingEnabled = true;
            this.listaDeTurnos.Location = new System.Drawing.Point(233, 140);
            this.listaDeTurnos.Name = "listaDeTurnos";
            this.listaDeTurnos.Size = new System.Drawing.Size(158, 79);
            this.listaDeTurnos.TabIndex = 41;
            this.listaDeTurnos.SelectedIndexChanged += new System.EventHandler(this.listaDeTurnos_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Turno:";
            // 
            // patente
            // 
            this.patente.Location = new System.Drawing.Point(48, 41);
            this.patente.Name = "patente";
            this.patente.Size = new System.Drawing.Size(100, 20);
            this.patente.TabIndex = 42;
            this.patente.TextChanged += new System.EventHandler(this.patente_TextChanged);
            // 
            // Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 353);
            this.Controls.Add(this.patente);
            this.Controls.Add(this.listaDeTurnos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.habilitado);
            this.Controls.Add(this.marca);
            this.Controls.Add(this.restaurar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.numeroChofer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Modificacion";
            this.Text = "Modificacion";
            this.Load += new System.EventHandler(this.Modificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox marca;
        private System.Windows.Forms.Button restaurar;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.TextBox numeroChofer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox habilitado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.CheckedListBox listaDeTurnos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox patente;
    }
}