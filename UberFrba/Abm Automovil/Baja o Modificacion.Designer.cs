namespace UberFrba.Abm_Automovil
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
            this.label4 = new System.Windows.Forms.Label();
            this.numeroChoferBM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.patenteBM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.modeloBM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.marcaBM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroChofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.volver = new System.Windows.Forms.Button();
            this.bajaOModificacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Ingrese los campos por los que quiera filtrar :";
            // 
            // numeroChoferBM
            // 
            this.numeroChoferBM.Location = new System.Drawing.Point(506, 78);
            this.numeroChoferBM.Name = "numeroChoferBM";
            this.numeroChoferBM.Size = new System.Drawing.Size(100, 20);
            this.numeroChoferBM.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Número de chofer :";
            // 
            // patenteBM
            // 
            this.patenteBM.Location = new System.Drawing.Point(200, 78);
            this.patenteBM.Name = "patenteBM";
            this.patenteBM.Size = new System.Drawing.Size(100, 20);
            this.patenteBM.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Patente :";
            // 
            // modeloBM
            // 
            this.modeloBM.Location = new System.Drawing.Point(359, 78);
            this.modeloBM.Name = "modeloBM";
            this.modeloBM.Size = new System.Drawing.Size(100, 20);
            this.modeloBM.TabIndex = 28;
            this.modeloBM.TextChanged += new System.EventHandler(this.modeloBM_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Modelo :";
            // 
            // marcaBM
            // 
            this.marcaBM.Location = new System.Drawing.Point(52, 78);
            this.marcaBM.Name = "marcaBM";
            this.marcaBM.Size = new System.Drawing.Size(100, 20);
            this.marcaBM.TabIndex = 26;
            this.marcaBM.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Marca :";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(57, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 25);
            this.button3.TabIndex = 34;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(506, 132);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 25);
            this.button4.TabIndex = 35;
            this.button4.Text = "Buscar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patente,
            this.modelo,
            this.marca,
            this.numeroChofer,
            this.habilitado,
            this.seleccionar});
            this.dataGridView1.Location = new System.Drawing.Point(22, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 149);
            this.dataGridView1.TabIndex = 37;
            // 
            // patente
            // 
            this.patente.HeaderText = "Patente";
            this.patente.Name = "patente";
            // 
            // modelo
            // 
            this.modelo.HeaderText = "Modelo";
            this.modelo.Name = "modelo";
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            // 
            // numeroChofer
            // 
            this.numeroChofer.HeaderText = "Numero de chofer";
            this.numeroChofer.Name = "numeroChofer";
            // 
            // habilitado
            // 
            this.habilitado.HeaderText = "Habilitado";
            this.habilitado.Name = "habilitado";
            // 
            // seleccionar
            // 
            this.seleccionar.HeaderText = "Seleccionar";
            this.seleccionar.Name = "seleccionar";
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(225, 362);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 42;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // bajaOModificacion
            // 
            this.bajaOModificacion.Location = new System.Drawing.Point(380, 362);
            this.bajaOModificacion.Name = "bajaOModificacion";
            this.bajaOModificacion.Size = new System.Drawing.Size(105, 23);
            this.bajaOModificacion.TabIndex = 43;
            this.bajaOModificacion.Text = "Baja/Modificacion";
            this.bajaOModificacion.UseVisualStyleBackColor = true;
            this.bajaOModificacion.Click += new System.EventHandler(this.bajaOModificacion_Click);
            // 
            // Baja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 405);
            this.Controls.Add(this.bajaOModificacion);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numeroChoferBM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.patenteBM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modeloBM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.marcaBM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "Baja";
            this.Text = "Selección de Automóvil";
            this.Load += new System.EventHandler(this.Baja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button baja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numeroChoferBM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox patenteBM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modeloBM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox marcaBM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroChofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitado;
        private System.Windows.Forms.DataGridViewButtonColumn seleccionar;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button bajaOModificacion;
    }
}