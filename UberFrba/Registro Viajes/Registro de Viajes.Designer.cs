namespace UberFrba.Registro_Viajes
{
    partial class Registro_Viajes
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
            this.turnos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.telefonoCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.patente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cantKm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fechaDelViaje = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.telefonoChofer = new System.Windows.Forms.TextBox();
            this.limpiar = new System.Windows.Forms.Button();
            this.registrarCliente = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.horaInicioTurno = new System.Windows.Forms.TextBox();
            this.horaFinTurno = new System.Windows.Forms.TextBox();
            this.horaInicio = new System.Windows.Forms.DateTimePicker();
            this.horaFin = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // turnos
            // 
            this.turnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.turnos.FormattingEnabled = true;
            this.turnos.Location = new System.Drawing.Point(58, 156);
            this.turnos.Name = "turnos";
            this.turnos.Size = new System.Drawing.Size(110, 21);
            this.turnos.TabIndex = 5;
            this.turnos.SelectedIndexChanged += new System.EventHandler(this.turnos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Turno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cantidad de kilometros del viaje";
            // 
            // telefonoCliente
            // 
            this.telefonoCliente.Location = new System.Drawing.Point(193, 113);
            this.telefonoCliente.Name = "telefonoCliente";
            this.telefonoCliente.ReadOnly = true;
            this.telefonoCliente.Size = new System.Drawing.Size(187, 20);
            this.telefonoCliente.TabIndex = 2;
            this.telefonoCliente.TextChanged += new System.EventHandler(this.telefonoCliente_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patente del automovil";
            // 
            // patente
            // 
            this.patente.Location = new System.Drawing.Point(194, 72);
            this.patente.Name = "patente";
            this.patente.ReadOnly = true;
            this.patente.Size = new System.Drawing.Size(187, 20);
            this.patente.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Numero del cliente";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cantKm
            // 
            this.cantKm.Location = new System.Drawing.Point(193, 204);
            this.cantKm.Name = "cantKm";
            this.cantKm.Size = new System.Drawing.Size(187, 20);
            this.cantKm.TabIndex = 10;
            this.cantKm.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Fecha del viaje";
            // 
            // fechaDelViaje
            // 
            this.fechaDelViaje.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDelViaje.Location = new System.Drawing.Point(109, 257);
            this.fechaDelViaje.Name = "fechaDelViaje";
            this.fechaDelViaje.Size = new System.Drawing.Size(106, 20);
            this.fechaDelViaje.TabIndex = 20;
            this.fechaDelViaje.ValueChanged += new System.EventHandler(this.fechaDelViaje_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Numero del chofer";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // telefonoChofer
            // 
            this.telefonoChofer.Location = new System.Drawing.Point(193, 30);
            this.telefonoChofer.Name = "telefonoChofer";
            this.telefonoChofer.ReadOnly = true;
            this.telefonoChofer.Size = new System.Drawing.Size(187, 20);
            this.telefonoChofer.TabIndex = 23;
            this.telefonoChofer.TextChanged += new System.EventHandler(this.telefonoChofer_TextChanged);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(285, 313);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(126, 23);
            this.limpiar.TabIndex = 25;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // registrarCliente
            // 
            this.registrarCliente.Location = new System.Drawing.Point(286, 254);
            this.registrarCliente.Name = "registrarCliente";
            this.registrarCliente.Size = new System.Drawing.Size(126, 23);
            this.registrarCliente.TabIndex = 26;
            this.registrarCliente.Text = "Registrar";
            this.registrarCliente.UseVisualStyleBackColor = true;
            this.registrarCliente.Click += new System.EventHandler(this.registrarCliente_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(286, 374);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(126, 23);
            this.volver.TabIndex = 27;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Buscar cliente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buscarCliente_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(403, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Buscar chofer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buscarChofer_Click);
            // 
            // horaInicioTurno
            // 
            this.horaInicioTurno.Location = new System.Drawing.Point(193, 157);
            this.horaInicioTurno.Name = "horaInicioTurno";
            this.horaInicioTurno.ReadOnly = true;
            this.horaInicioTurno.Size = new System.Drawing.Size(100, 20);
            this.horaInicioTurno.TabIndex = 30;
            this.horaInicioTurno.TextChanged += new System.EventHandler(this.horaInicioTurno_TextChanged);
            // 
            // horaFinTurno
            // 
            this.horaFinTurno.Location = new System.Drawing.Point(311, 157);
            this.horaFinTurno.Name = "horaFinTurno";
            this.horaFinTurno.ReadOnly = true;
            this.horaFinTurno.Size = new System.Drawing.Size(100, 20);
            this.horaFinTurno.TabIndex = 31;
            this.horaFinTurno.TextChanged += new System.EventHandler(this.horaFinTurno_TextChanged);
            // 
            // horaInicio
            // 
            this.horaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.horaInicio.Location = new System.Drawing.Point(109, 316);
            this.horaInicio.Name = "horaInicio";
            this.horaInicio.ShowUpDown = true;
            this.horaInicio.Size = new System.Drawing.Size(106, 20);
            this.horaInicio.TabIndex = 32;
            this.horaInicio.ValueChanged += new System.EventHandler(this.horaInicio_ValueChanged);
            // 
            // horaFin
            // 
            this.horaFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.horaFin.Location = new System.Drawing.Point(110, 374);
            this.horaFin.Name = "horaFin";
            this.horaFin.ShowUpDown = true;
            this.horaFin.Size = new System.Drawing.Size(105, 20);
            this.horaFin.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(107, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Hora de inicio";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(108, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Hora de fin";
            // 
            // Registro_Viajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 422);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.horaFin);
            this.Controls.Add(this.horaInicio);
            this.Controls.Add(this.horaFinTurno);
            this.Controls.Add(this.horaInicioTurno);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.registrarCliente);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.telefonoChofer);
            this.Controls.Add(this.fechaDelViaje);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cantKm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.turnos);
            this.Controls.Add(this.patente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.telefonoCliente);
            this.Name = "Registro_Viajes";
            this.Text = "Registro de Viajes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox turnos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox telefonoCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox patente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cantKm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker fechaDelViaje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox telefonoChofer;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button registrarCliente;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox horaInicioTurno;
        private System.Windows.Forms.TextBox horaFinTurno;
        private System.Windows.Forms.DateTimePicker horaInicio;
        private System.Windows.Forms.DateTimePicker horaFin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;

    }
}