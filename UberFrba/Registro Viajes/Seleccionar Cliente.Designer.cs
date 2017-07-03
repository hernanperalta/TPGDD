namespace UberFrba.Registro_Viajes
{
    partial class Seleccionar_Cliente
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
            this.noClientesLabel = new System.Windows.Forms.Label();
            this.confirmarCliente = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.clientesGrid = new System.Windows.Forms.DataGridView();
            this.BuscarCliente = new System.Windows.Forms.Button();
            this.limpiarCampos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dniCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apellidoCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // noClientesLabel
            // 
            this.noClientesLabel.AutoSize = true;
            this.noClientesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.noClientesLabel.Location = new System.Drawing.Point(351, 117);
            this.noClientesLabel.Name = "noClientesLabel";
            this.noClientesLabel.Size = new System.Drawing.Size(198, 20);
            this.noClientesLabel.TabIndex = 57;
            this.noClientesLabel.Text = "No se encontraron clientes";
            // 
            // confirmarCliente
            // 
            this.confirmarCliente.Location = new System.Drawing.Point(533, 334);
            this.confirmarCliente.Name = "confirmarCliente";
            this.confirmarCliente.Size = new System.Drawing.Size(117, 23);
            this.confirmarCliente.TabIndex = 56;
            this.confirmarCliente.Text = "Confirmar cliente";
            this.confirmarCliente.UseVisualStyleBackColor = true;
            this.confirmarCliente.Click += new System.EventHandler(this.confirmarCliente_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(241, 334);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 55;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click_1);
            // 
            // clientesGrid
            // 
            this.clientesGrid.AllowUserToAddRows = false;
            this.clientesGrid.AllowUserToDeleteRows = false;
            this.clientesGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.clientesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientesGrid.Location = new System.Drawing.Point(23, 148);
            this.clientesGrid.Name = "clientesGrid";
            this.clientesGrid.ReadOnly = true;
            this.clientesGrid.Size = new System.Drawing.Size(878, 171);
            this.clientesGrid.TabIndex = 54;
            this.clientesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientesGrid_CellContentClick_1);
            // 
            // BuscarCliente
            // 
            this.BuscarCliente.Location = new System.Drawing.Point(632, 105);
            this.BuscarCliente.Name = "BuscarCliente";
            this.BuscarCliente.Size = new System.Drawing.Size(101, 25);
            this.BuscarCliente.TabIndex = 53;
            this.BuscarCliente.Text = "Buscar todos";
            this.BuscarCliente.UseVisualStyleBackColor = true;
            this.BuscarCliente.Click += new System.EventHandler(this.BuscarCliente_Click);
            // 
            // limpiarCampos
            // 
            this.limpiarCampos.Location = new System.Drawing.Point(181, 105);
            this.limpiarCampos.Name = "limpiarCampos";
            this.limpiarCampos.Size = new System.Drawing.Size(101, 25);
            this.limpiarCampos.TabIndex = 52;
            this.limpiarCampos.Text = "Limpiar";
            this.limpiarCampos.UseVisualStyleBackColor = true;
            this.limpiarCampos.Click += new System.EventHandler(this.limpiarCampos_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Ingrese los campos por los que quiera filtrar :";
            // 
            // dniCliente
            // 
            this.dniCliente.Location = new System.Drawing.Point(550, 65);
            this.dniCliente.Name = "dniCliente";
            this.dniCliente.Size = new System.Drawing.Size(100, 20);
            this.dniCliente.TabIndex = 49;
            this.dniCliente.TextChanged += new System.EventHandler(this.dniCliente_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(547, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "DNI :";
            // 
            // apellidoCliente
            // 
            this.apellidoCliente.Location = new System.Drawing.Point(402, 65);
            this.apellidoCliente.Name = "apellidoCliente";
            this.apellidoCliente.Size = new System.Drawing.Size(100, 20);
            this.apellidoCliente.TabIndex = 47;
            this.apellidoCliente.TextChanged += new System.EventHandler(this.apellidoCliente_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Apellido :";
            // 
            // nombreCliente
            // 
            this.nombreCliente.Location = new System.Drawing.Point(259, 65);
            this.nombreCliente.Name = "nombreCliente";
            this.nombreCliente.Size = new System.Drawing.Size(100, 20);
            this.nombreCliente.TabIndex = 45;
            this.nombreCliente.TextChanged += new System.EventHandler(this.nombreCliente_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Nombre :";
            // 
            // Seleccionar_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 384);
            this.Controls.Add(this.noClientesLabel);
            this.Controls.Add(this.confirmarCliente);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.clientesGrid);
            this.Controls.Add(this.BuscarCliente);
            this.Controls.Add(this.limpiarCampos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dniCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.apellidoCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreCliente);
            this.Controls.Add(this.label1);
            this.Name = "Seleccionar_Cliente";
            this.Text = "Seleccionar_Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.clientesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noClientesLabel;
        private System.Windows.Forms.Button confirmarCliente;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.DataGridView clientesGrid;
        private System.Windows.Forms.Button BuscarCliente;
        private System.Windows.Forms.Button limpiarCampos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dniCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apellidoCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreCliente;
        private System.Windows.Forms.Label label1;

    }
}