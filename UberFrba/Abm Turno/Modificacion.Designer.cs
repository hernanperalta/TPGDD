namespace UberFrba.Abm_Turno
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
            this.volver = new System.Windows.Forms.Button();
            this.limpiarCampos = new System.Windows.Forms.Button();
            this.guardarCliente = new System.Windows.Forms.Button();
            this.precioBase = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.horaFin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.horaInicio = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.valorDelKm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(25, 233);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(100, 35);
            this.volver.TabIndex = 125;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click_1);
            // 
            // limpiarCampos
            // 
            this.limpiarCampos.Location = new System.Drawing.Point(166, 236);
            this.limpiarCampos.Name = "limpiarCampos";
            this.limpiarCampos.Size = new System.Drawing.Size(100, 32);
            this.limpiarCampos.TabIndex = 124;
            this.limpiarCampos.Text = "Limpiar";
            this.limpiarCampos.UseVisualStyleBackColor = true;
            this.limpiarCampos.Click += new System.EventHandler(this.limpiarCampos_Click);
            // 
            // guardarCliente
            // 
            this.guardarCliente.Location = new System.Drawing.Point(166, 184);
            this.guardarCliente.Name = "guardarCliente";
            this.guardarCliente.Size = new System.Drawing.Size(100, 32);
            this.guardarCliente.TabIndex = 121;
            this.guardarCliente.Text = "Guardar Cliente";
            this.guardarCliente.UseVisualStyleBackColor = true;
            this.guardarCliente.Click += new System.EventHandler(this.guardarCliente_Click);
            // 
            // precioBase
            // 
            this.precioBase.Location = new System.Drawing.Point(25, 196);
            this.precioBase.Name = "precioBase";
            this.precioBase.Size = new System.Drawing.Size(100, 20);
            this.precioBase.TabIndex = 116;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 114;
            this.label7.Text = "Precio base :";
            // 
            // horaFin
            // 
            this.horaFin.Location = new System.Drawing.Point(166, 78);
            this.horaFin.Name = "horaFin";
            this.horaFin.Size = new System.Drawing.Size(100, 20);
            this.horaFin.TabIndex = 113;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "Hora de fin :";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(25, 136);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(100, 20);
            this.descripcion.TabIndex = 109;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 108;
            this.label2.Text = "Descripcion :";
            // 
            // horaInicio
            // 
            this.horaInicio.Location = new System.Drawing.Point(25, 78);
            this.horaInicio.Name = "horaInicio";
            this.horaInicio.Size = new System.Drawing.Size(100, 20);
            this.horaInicio.TabIndex = 107;
            this.horaInicio.TextChanged += new System.EventHandler(this.horaInicio_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 106;
            this.label13.Text = "Hora de inicio :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(191, 13);
            this.label12.TabIndex = 105;
            this.label12.Text = "Ingrese los datos del turno a modificar :";
            // 
            // valorDelKm
            // 
            this.valorDelKm.Location = new System.Drawing.Point(166, 136);
            this.valorDelKm.Name = "valorDelKm";
            this.valorDelKm.Size = new System.Drawing.Size(100, 20);
            this.valorDelKm.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Valor del kilometro :";
            // 
            // Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 291);
            this.Controls.Add(this.valorDelKm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.limpiarCampos);
            this.Controls.Add(this.guardarCliente);
            this.Controls.Add(this.precioBase);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.horaFin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.horaInicio);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Name = "Modificacion";
            this.Text = "Modificacion";
            this.Load += new System.EventHandler(this.Modificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button limpiarCampos;
        private System.Windows.Forms.Button guardarCliente;
        private System.Windows.Forms.TextBox precioBase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox horaFin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox horaInicio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox valorDelKm;
        private System.Windows.Forms.Label label1;
    }
}