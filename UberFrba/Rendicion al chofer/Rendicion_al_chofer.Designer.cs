namespace UberFrba.Rendicion_al_chofer
{
    partial class Rendicion_al_chofer
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
            this.horaFinTurno = new System.Windows.Forms.TextBox();
            this.horaInicioTurno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.turnos = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.telefonoChofer = new System.Windows.Forms.TextBox();
            this.volver = new System.Windows.Forms.Button();
            this.guardarRendicion = new System.Windows.Forms.Button();
            this.importeTotalDia = new System.Windows.Forms.TextBox();
            this.porcentaje = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.noChoferLabel = new System.Windows.Forms.Label();
            this.viajesGrid = new System.Windows.Forms.DataGridView();
            this.fechaRendicion = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cargarDatos = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viajesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // horaFinTurno
            // 
            this.horaFinTurno.Location = new System.Drawing.Point(567, 67);
            this.horaFinTurno.Name = "horaFinTurno";
            this.horaFinTurno.ReadOnly = true;
            this.horaFinTurno.Size = new System.Drawing.Size(100, 20);
            this.horaFinTurno.TabIndex = 52;
            // 
            // horaInicioTurno
            // 
            this.horaInicioTurno.Location = new System.Drawing.Point(449, 67);
            this.horaInicioTurno.Name = "horaInicioTurno";
            this.horaInicioTurno.ReadOnly = true;
            this.horaInicioTurno.Size = new System.Drawing.Size(100, 20);
            this.horaInicioTurno.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Turno";
            // 
            // turnos
            // 
            this.turnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.turnos.FormattingEnabled = true;
            this.turnos.Location = new System.Drawing.Point(320, 66);
            this.turnos.Name = "turnos";
            this.turnos.Size = new System.Drawing.Size(110, 21);
            this.turnos.TabIndex = 49;
            this.turnos.SelectedIndexChanged += new System.EventHandler(this.turnos_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(530, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "Buscar chofer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Numero del chofer";
            // 
            // telefonoChofer
            // 
            this.telefonoChofer.Location = new System.Drawing.Point(321, 25);
            this.telefonoChofer.Name = "telefonoChofer";
            this.telefonoChofer.ReadOnly = true;
            this.telefonoChofer.Size = new System.Drawing.Size(187, 20);
            this.telefonoChofer.TabIndex = 46;
            this.telefonoChofer.TextChanged += new System.EventHandler(this.telefonoChofer_TextChanged);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(257, 430);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(157, 39);
            this.volver.TabIndex = 45;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // guardarRendicion
            // 
            this.guardarRendicion.Location = new System.Drawing.Point(436, 430);
            this.guardarRendicion.Name = "guardarRendicion";
            this.guardarRendicion.Size = new System.Drawing.Size(157, 39);
            this.guardarRendicion.TabIndex = 44;
            this.guardarRendicion.Text = "Guardar rendicion";
            this.guardarRendicion.UseVisualStyleBackColor = true;
            this.guardarRendicion.Click += new System.EventHandler(this.guardarRendicion_Click);
            // 
            // importeTotalDia
            // 
            this.importeTotalDia.Location = new System.Drawing.Point(320, 151);
            this.importeTotalDia.Name = "importeTotalDia";
            this.importeTotalDia.ReadOnly = true;
            this.importeTotalDia.Size = new System.Drawing.Size(208, 20);
            this.importeTotalDia.TabIndex = 43;
            // 
            // porcentaje
            // 
            this.porcentaje.Location = new System.Drawing.Point(320, 110);
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Size = new System.Drawing.Size(208, 20);
            this.porcentaje.TabIndex = 42;
            this.porcentaje.TextChanged += new System.EventHandler(this.porcentaje_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Importe a rendir";
            // 
            // noChoferLabel
            // 
            this.noChoferLabel.AutoSize = true;
            this.noChoferLabel.Location = new System.Drawing.Point(290, 241);
            this.noChoferLabel.Name = "noChoferLabel";
            this.noChoferLabel.Size = new System.Drawing.Size(283, 13);
            this.noChoferLabel.TabIndex = 53;
            this.noChoferLabel.Text = "Debe seleccionar un chofer para ver los turnos disponibles";
            // 
            // viajesGrid
            // 
            this.viajesGrid.AllowUserToAddRows = false;
            this.viajesGrid.AllowUserToDeleteRows = false;
            this.viajesGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.viajesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viajesGrid.Location = new System.Drawing.Point(48, 266);
            this.viajesGrid.Name = "viajesGrid";
            this.viajesGrid.ReadOnly = true;
            this.viajesGrid.Size = new System.Drawing.Size(746, 152);
            this.viajesGrid.TabIndex = 54;
            this.viajesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viajesGrid_CellContentClick);
            // 
            // fechaRendicion
            // 
            this.fechaRendicion.Location = new System.Drawing.Point(321, 190);
            this.fechaRendicion.MaxDate = new System.DateTime(2017, 7, 3, 0, 0, 0, 0);
            this.fechaRendicion.Name = "fechaRendicion";
            this.fechaRendicion.Size = new System.Drawing.Size(207, 20);
            this.fechaRendicion.TabIndex = 55;
            this.fechaRendicion.Value = new System.DateTime(2017, 7, 3, 0, 0, 0, 0);
            this.fechaRendicion.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Fecha de rendicion";
            // 
            // cargarDatos
            // 
            this.cargarDatos.Location = new System.Drawing.Point(639, 220);
            this.cargarDatos.Name = "cargarDatos";
            this.cargarDatos.Size = new System.Drawing.Size(100, 34);
            this.cargarDatos.TabIndex = 57;
            this.cargarDatos.Text = "Cargar datos";
            this.cargarDatos.UseVisualStyleBackColor = true;
            this.cargarDatos.Click += new System.EventHandler(this.cargarDatos_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Porcentaje de rendicion sobre el total";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Rendicion_al_chofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 481);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cargarDatos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fechaRendicion);
            this.Controls.Add(this.viajesGrid);
            this.Controls.Add(this.noChoferLabel);
            this.Controls.Add(this.horaFinTurno);
            this.Controls.Add(this.horaInicioTurno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.turnos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.telefonoChofer);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.guardarRendicion);
            this.Controls.Add(this.importeTotalDia);
            this.Controls.Add(this.porcentaje);
            this.Controls.Add(this.label4);
            this.Name = "Rendicion_al_chofer";
            this.Text = "Rendicion_al_chofer";
            this.Load += new System.EventHandler(this.Rendicion_al_chofer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viajesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox horaFinTurno;
        private System.Windows.Forms.TextBox horaInicioTurno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox turnos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox telefonoChofer;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button guardarRendicion;
        private System.Windows.Forms.TextBox importeTotalDia;
        private System.Windows.Forms.TextBox porcentaje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label noChoferLabel;
        private System.Windows.Forms.DataGridView viajesGrid;
        private System.Windows.Forms.DateTimePicker fechaRendicion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cargarDatos;
        private System.Windows.Forms.Label label6;
    }
}