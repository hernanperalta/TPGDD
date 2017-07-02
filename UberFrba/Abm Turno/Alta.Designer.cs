namespace UberFrba.Abm_Turno
{
    partial class Alta
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
            this.crearTurno = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.valorDelKm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.horaFin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.precioBase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.horaInicio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.habilitado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(26, 223);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(100, 35);
            this.volver.TabIndex = 80;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // limpiarCampos
            // 
            this.limpiarCampos.Location = new System.Drawing.Point(26, 271);
            this.limpiarCampos.Name = "limpiarCampos";
            this.limpiarCampos.Size = new System.Drawing.Size(100, 32);
            this.limpiarCampos.TabIndex = 79;
            this.limpiarCampos.Text = "Limpiar";
            this.limpiarCampos.UseVisualStyleBackColor = true;
            this.limpiarCampos.Click += new System.EventHandler(this.limpiarCampos_Click);
            // 
            // crearTurno
            // 
            this.crearTurno.Location = new System.Drawing.Point(181, 223);
            this.crearTurno.Name = "crearTurno";
            this.crearTurno.Size = new System.Drawing.Size(100, 38);
            this.crearTurno.TabIndex = 76;
            this.crearTurno.Text = "Crear turno";
            this.crearTurno.UseVisualStyleBackColor = true;
            this.crearTurno.Click += new System.EventHandler(this.crearTurno_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "Ingrese los datos del nuevo turno :";
            // 
            // valorDelKm
            // 
            this.valorDelKm.Location = new System.Drawing.Point(181, 131);
            this.valorDelKm.Name = "valorDelKm";
            this.valorDelKm.Size = new System.Drawing.Size(100, 20);
            this.valorDelKm.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 68;
            this.label7.Text = "Valor de kilometro :";
            // 
            // horaFin
            // 
            this.horaFin.Location = new System.Drawing.Point(181, 73);
            this.horaFin.Name = "horaFin";
            this.horaFin.Size = new System.Drawing.Size(100, 20);
            this.horaFin.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(178, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Hora de fin :";
            // 
            // precioBase
            // 
            this.precioBase.Location = new System.Drawing.Point(26, 188);
            this.precioBase.Name = "precioBase";
            this.precioBase.Size = new System.Drawing.Size(100, 20);
            this.precioBase.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Precio base :";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(26, 131);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(100, 20);
            this.descripcion.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Descripcion :";
            // 
            // horaInicio
            // 
            this.horaInicio.Location = new System.Drawing.Point(26, 73);
            this.horaInicio.Name = "horaInicio";
            this.horaInicio.Size = new System.Drawing.Size(100, 20);
            this.horaInicio.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Hora de inicio :";
            // 
            // habilitado
            // 
            this.habilitado.AutoSize = true;
            this.habilitado.Location = new System.Drawing.Point(181, 175);
            this.habilitado.Name = "habilitado";
            this.habilitado.Size = new System.Drawing.Size(73, 17);
            this.habilitado.TabIndex = 81;
            this.habilitado.Text = "Habilitado";
            this.habilitado.UseVisualStyleBackColor = true;
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 329);
            this.Controls.Add(this.habilitado);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.limpiarCampos);
            this.Controls.Add(this.crearTurno);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.valorDelKm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.horaFin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.precioBase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.horaInicio);
            this.Controls.Add(this.label1);
            this.Name = "Alta";
            this.Text = "Alta de Turno";
            this.Load += new System.EventHandler(this.Alta_o_Modificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button limpiarCampos;
        private System.Windows.Forms.Button crearTurno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox valorDelKm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox horaFin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox precioBase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox horaInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox habilitado;


    }
}