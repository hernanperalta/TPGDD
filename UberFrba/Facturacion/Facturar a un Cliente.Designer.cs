namespace UberFrba.Facturacion
{
    partial class Facturacion_Cliente
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.telefonoTB = new System.Windows.Forms.TextBox();
            this.viajesSinFacturarGrid = new System.Windows.Forms.DataGridView();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fechaInicio = new System.Windows.Forms.DateTimePicker();
            this.fechaFin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.importeTotal = new System.Windows.Forms.TextBox();
            this.nombreTB = new System.Windows.Forms.TextBox();
            this.apellidoTB = new System.Windows.Forms.TextBox();
            this.nombreUsuarioTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cargarDatos = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viajesSinFacturarGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefono Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Viajes facturados";
            // 
            // telefonoTB
            // 
            this.telefonoTB.Location = new System.Drawing.Point(140, 28);
            this.telefonoTB.Name = "telefonoTB";
            this.telefonoTB.ReadOnly = true;
            this.telefonoTB.Size = new System.Drawing.Size(200, 20);
            this.telefonoTB.TabIndex = 8;
            this.telefonoTB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // viajesSinFacturarGrid
            // 
            this.viajesSinFacturarGrid.AllowUserToAddRows = false;
            this.viajesSinFacturarGrid.AllowUserToDeleteRows = false;
            this.viajesSinFacturarGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.viajesSinFacturarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viajesSinFacturarGrid.Location = new System.Drawing.Point(37, 254);
            this.viajesSinFacturarGrid.Name = "viajesSinFacturarGrid";
            this.viajesSinFacturarGrid.ReadOnly = true;
            this.viajesSinFacturarGrid.Size = new System.Drawing.Size(746, 152);
            this.viajesSinFacturarGrid.TabIndex = 53;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(369, 426);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botonLimpiar.TabIndex = 54;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(540, 426);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 55;
            this.button2.Text = "Facturar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(192, 426);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 56;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de fin";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // fechaInicio
            // 
            this.fechaInicio.Enabled = false;
            this.fechaInicio.Location = new System.Drawing.Point(140, 74);
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.Size = new System.Drawing.Size(200, 20);
            this.fechaInicio.TabIndex = 6;
            this.fechaInicio.Value = new System.DateTime(2017, 6, 1, 0, 21, 0, 0);
            this.fechaInicio.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // fechaFin
            // 
            this.fechaFin.Enabled = false;
            this.fechaFin.Location = new System.Drawing.Point(140, 121);
            this.fechaFin.Name = "fechaFin";
            this.fechaFin.Size = new System.Drawing.Size(200, 20);
            this.fechaFin.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Importe total";
            // 
            // importeTotal
            // 
            this.importeTotal.Location = new System.Drawing.Point(140, 169);
            this.importeTotal.Name = "importeTotal";
            this.importeTotal.ReadOnly = true;
            this.importeTotal.Size = new System.Drawing.Size(200, 20);
            this.importeTotal.TabIndex = 9;
            // 
            // nombreTB
            // 
            this.nombreTB.Location = new System.Drawing.Point(512, 46);
            this.nombreTB.Name = "nombreTB";
            this.nombreTB.ReadOnly = true;
            this.nombreTB.Size = new System.Drawing.Size(200, 20);
            this.nombreTB.TabIndex = 57;
            // 
            // apellidoTB
            // 
            this.apellidoTB.Location = new System.Drawing.Point(512, 105);
            this.apellidoTB.Name = "apellidoTB";
            this.apellidoTB.ReadOnly = true;
            this.apellidoTB.Size = new System.Drawing.Size(200, 20);
            this.apellidoTB.TabIndex = 58;
            // 
            // nombreUsuarioTB
            // 
            this.nombreUsuarioTB.Location = new System.Drawing.Point(512, 162);
            this.nombreUsuarioTB.Name = "nombreUsuarioTB";
            this.nombreUsuarioTB.ReadOnly = true;
            this.nombreUsuarioTB.Size = new System.Drawing.Size(200, 20);
            this.nombreUsuarioTB.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(481, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Nombre";
            // 
            // cargarDatos
            // 
            this.cargarDatos.Location = new System.Drawing.Point(369, 214);
            this.cargarDatos.Name = "cargarDatos";
            this.cargarDatos.Size = new System.Drawing.Size(75, 23);
            this.cargarDatos.TabIndex = 61;
            this.cargarDatos.Text = "Cargar datos";
            this.cargarDatos.UseVisualStyleBackColor = true;
            this.cargarDatos.Click += new System.EventHandler(this.cargarDatos_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(481, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Apellido";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(481, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "Username";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 64;
            this.button1.Text = "Buscar cliente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buscarCliente_Click);
            // 
            // Facturacion_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 467);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cargarDatos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nombreUsuarioTB);
            this.Controls.Add(this.apellidoTB);
            this.Controls.Add(this.nombreTB);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.viajesSinFacturarGrid);
            this.Controls.Add(this.importeTotal);
            this.Controls.Add(this.telefonoTB);
            this.Controls.Add(this.fechaFin);
            this.Controls.Add(this.fechaInicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Facturacion_Cliente";
            this.Text = "Facturar a un Cliente";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viajesSinFacturarGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox telefonoTB;
        private System.Windows.Forms.DataGridView viajesSinFacturarGrid;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fechaInicio;
        private System.Windows.Forms.DateTimePicker fechaFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox importeTotal;
        private System.Windows.Forms.TextBox nombreTB;
        private System.Windows.Forms.TextBox apellidoTB;
        private System.Windows.Forms.TextBox nombreUsuarioTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cargarDatos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}