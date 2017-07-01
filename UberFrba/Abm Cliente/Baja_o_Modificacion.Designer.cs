namespace UberFrba.Abm_Cliente
{
    partial class Baja_o_Modificacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.nombreCliente = new System.Windows.Forms.TextBox();
            this.apellidoCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dniCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bajaOModificacion = new System.Windows.Forms.Button();
            this.BuscarCliente = new System.Windows.Forms.Button();
            this.limpiarCampos = new System.Windows.Forms.Button();
            this.clientesGrid = new System.Windows.Forms.DataGridView();
            this.volver = new System.Windows.Forms.Button();
            this.rhabilitar = new System.Windows.Forms.Button();
            this.noClientesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre :";
            // 
            // nombreCliente
            // 
            this.nombreCliente.Location = new System.Drawing.Point(260, 73);
            this.nombreCliente.Name = "nombreCliente";
            this.nombreCliente.Size = new System.Drawing.Size(100, 20);
            this.nombreCliente.TabIndex = 1;
            this.nombreCliente.TextChanged += new System.EventHandler(this.nombreCliente_TextChanged);
            // 
            // apellidoCliente
            // 
            this.apellidoCliente.Location = new System.Drawing.Point(403, 73);
            this.apellidoCliente.Name = "apellidoCliente";
            this.apellidoCliente.Size = new System.Drawing.Size(100, 20);
            this.apellidoCliente.TabIndex = 9;
            this.apellidoCliente.TextChanged += new System.EventHandler(this.apellidoCliente_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Apellido :";
            // 
            // dniCliente
            // 
            this.dniCliente.Location = new System.Drawing.Point(551, 73);
            this.dniCliente.Name = "dniCliente";
            this.dniCliente.Size = new System.Drawing.Size(100, 20);
            this.dniCliente.TabIndex = 11;
            this.dniCliente.TextChanged += new System.EventHandler(this.dniCliente_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "DNI :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ingrese los campos por los que quiera filtrar :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // bajaOModificacion
            // 
            this.bajaOModificacion.Location = new System.Drawing.Point(605, 354);
            this.bajaOModificacion.Name = "bajaOModificacion";
            this.bajaOModificacion.Size = new System.Drawing.Size(117, 23);
            this.bajaOModificacion.TabIndex = 14;
            this.bajaOModificacion.Text = "Baja/Modif";
            this.bajaOModificacion.UseVisualStyleBackColor = true;
            this.bajaOModificacion.Click += new System.EventHandler(this.bajaOModificacion_Click);
            // 
            // BuscarCliente
            // 
            this.BuscarCliente.Location = new System.Drawing.Point(633, 113);
            this.BuscarCliente.Name = "BuscarCliente";
            this.BuscarCliente.Size = new System.Drawing.Size(101, 25);
            this.BuscarCliente.TabIndex = 38;
            this.BuscarCliente.Text = "Buscar todos";
            this.BuscarCliente.UseVisualStyleBackColor = true;
            this.BuscarCliente.Click += new System.EventHandler(this.buscarCliente_Click);
            // 
            // limpiarCampos
            // 
            this.limpiarCampos.Location = new System.Drawing.Point(182, 113);
            this.limpiarCampos.Name = "limpiarCampos";
            this.limpiarCampos.Size = new System.Drawing.Size(101, 25);
            this.limpiarCampos.TabIndex = 37;
            this.limpiarCampos.Text = "Limpiar";
            this.limpiarCampos.UseVisualStyleBackColor = true;
            this.limpiarCampos.Click += new System.EventHandler(this.limpiarCampos_Click);
            // 
            // clientesGrid
            // 
            this.clientesGrid.AllowUserToAddRows = false;
            this.clientesGrid.AllowUserToOrderColumns = true;
            this.clientesGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.clientesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientesGrid.Location = new System.Drawing.Point(24, 156);
            this.clientesGrid.Name = "clientesGrid";
            this.clientesGrid.ReadOnly = true;
            this.clientesGrid.Size = new System.Drawing.Size(878, 171);
            this.clientesGrid.TabIndex = 39;
            this.clientesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientesGrid_CellContentClick);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(275, 354);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 41;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // rhabilitar
            // 
            this.rhabilitar.Location = new System.Drawing.Point(419, 354);
            this.rhabilitar.Name = "rhabilitar";
            this.rhabilitar.Size = new System.Drawing.Size(117, 23);
            this.rhabilitar.TabIndex = 42;
            this.rhabilitar.Text = "Rehabilitar";
            this.rhabilitar.UseVisualStyleBackColor = true;
            this.rhabilitar.Click += new System.EventHandler(this.rehabilitar_Click);
            // 
            // noClientesLabel
            // 
            this.noClientesLabel.AutoSize = true;
            this.noClientesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.noClientesLabel.Location = new System.Drawing.Point(352, 125);
            this.noClientesLabel.Name = "noClientesLabel";
            this.noClientesLabel.Size = new System.Drawing.Size(198, 20);
            this.noClientesLabel.TabIndex = 43;
            this.noClientesLabel.Text = "No se encontraron clientes";
            this.noClientesLabel.Click += new System.EventHandler(this.noClientesLabel_Click);
            // 
            // Baja_o_Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 396);
            this.Controls.Add(this.noClientesLabel);
            this.Controls.Add(this.rhabilitar);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.clientesGrid);
            this.Controls.Add(this.BuscarCliente);
            this.Controls.Add(this.limpiarCampos);
            this.Controls.Add(this.bajaOModificacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dniCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.apellidoCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreCliente);
            this.Controls.Add(this.label1);
            this.Name = "Baja_o_Modificacion";
            this.Load += new System.EventHandler(this.Baja_o_Modificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreCliente;
        private System.Windows.Forms.TextBox apellidoCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dniCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bajaOModificacion;
        private System.Windows.Forms.Button BuscarCliente;
        private System.Windows.Forms.Button limpiarCampos;
        private System.Windows.Forms.DataGridView clientesGrid;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button rhabilitar;
        private System.Windows.Forms.Label noClientesLabel;
    }
}