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
            this.label3 = new System.Windows.Forms.Label();
            this.limpiar = new System.Windows.Forms.Button();
            this.buscarTodos = new System.Windows.Forms.Button();
            this.tablaAutomovil = new System.Windows.Forms.DataGridView();
            this.volver = new System.Windows.Forms.Button();
            this.bajaOModificacion = new System.Windows.Forms.Button();
            this.noAutosLabel = new System.Windows.Forms.Label();
            this.selectorDeMarcas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAutomovil)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Ingrese los campos por los que quiera filtrar :";
            // 
            // numeroChoferBM
            // 
            this.numeroChoferBM.Location = new System.Drawing.Point(578, 79);
            this.numeroChoferBM.Name = "numeroChoferBM";
            this.numeroChoferBM.Size = new System.Drawing.Size(100, 20);
            this.numeroChoferBM.TabIndex = 32;
            this.numeroChoferBM.TextChanged += new System.EventHandler(this.numeroChoferBM_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(562, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Número de chofer :";
            // 
            // patenteBM
            // 
            this.patenteBM.Location = new System.Drawing.Point(425, 79);
            this.patenteBM.Name = "patenteBM";
            this.patenteBM.Size = new System.Drawing.Size(100, 20);
            this.patenteBM.TabIndex = 30;
            this.patenteBM.TextChanged += new System.EventHandler(this.patenteBM_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Patente :";
            // 
            // modeloBM
            // 
            this.modeloBM.Location = new System.Drawing.Point(272, 79);
            this.modeloBM.Name = "modeloBM";
            this.modeloBM.Size = new System.Drawing.Size(100, 20);
            this.modeloBM.TabIndex = 28;
            this.modeloBM.TextChanged += new System.EventHandler(this.modeloBM_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Modelo :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Marca :";
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(129, 133);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(101, 25);
            this.limpiar.TabIndex = 34;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // buscarTodos
            // 
            this.buscarTodos.Location = new System.Drawing.Point(578, 133);
            this.buscarTodos.Name = "buscarTodos";
            this.buscarTodos.Size = new System.Drawing.Size(101, 25);
            this.buscarTodos.TabIndex = 35;
            this.buscarTodos.Text = "Buscar todos";
            this.buscarTodos.UseVisualStyleBackColor = true;
            this.buscarTodos.Click += new System.EventHandler(this.buscarTodos_Click);
            // 
            // tablaAutomovil
            // 
            this.tablaAutomovil.AllowUserToAddRows = false;
            this.tablaAutomovil.AllowUserToDeleteRows = false;
            this.tablaAutomovil.AllowUserToResizeRows = false;
            this.tablaAutomovil.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.tablaAutomovil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaAutomovil.Location = new System.Drawing.Point(30, 187);
            this.tablaAutomovil.Name = "tablaAutomovil";
            this.tablaAutomovil.ReadOnly = true;
            this.tablaAutomovil.Size = new System.Drawing.Size(757, 149);
            this.tablaAutomovil.TabIndex = 37;
            this.tablaAutomovil.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(181, 360);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 42;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // bajaOModificacion
            // 
            this.bajaOModificacion.Location = new System.Drawing.Point(511, 360);
            this.bajaOModificacion.Name = "bajaOModificacion";
            this.bajaOModificacion.Size = new System.Drawing.Size(105, 23);
            this.bajaOModificacion.TabIndex = 43;
            this.bajaOModificacion.Text = "Baja/Modificacion";
            this.bajaOModificacion.UseVisualStyleBackColor = true;
            this.bajaOModificacion.Click += new System.EventHandler(this.bajaOModificacion_Click);
            // 
            // noAutosLabel
            // 
            this.noAutosLabel.AutoSize = true;
            this.noAutosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noAutosLabel.Location = new System.Drawing.Point(268, 138);
            this.noAutosLabel.Name = "noAutosLabel";
            this.noAutosLabel.Size = new System.Drawing.Size(0, 20);
            this.noAutosLabel.TabIndex = 44;
            this.noAutosLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // selectorDeMarcas
            // 
            this.selectorDeMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorDeMarcas.FormattingEnabled = true;
            this.selectorDeMarcas.Location = new System.Drawing.Point(108, 78);
            this.selectorDeMarcas.Name = "selectorDeMarcas";
            this.selectorDeMarcas.Size = new System.Drawing.Size(121, 21);
            this.selectorDeMarcas.TabIndex = 45;
            this.selectorDeMarcas.SelectedIndexChanged += new System.EventHandler(this.selectorDeMarcas_SelectedIndexChanged);
            // 
            // Baja_o_Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 405);
            this.Controls.Add(this.selectorDeMarcas);
            this.Controls.Add(this.noAutosLabel);
            this.Controls.Add(this.bajaOModificacion);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.tablaAutomovil);
            this.Controls.Add(this.buscarTodos);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.numeroChoferBM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.patenteBM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modeloBM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "Baja_o_Modificacion";
            this.Text = "Selección de Automóvil";
            this.Load += new System.EventHandler(this.Baja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaAutomovil)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button buscarTodos;
        private System.Windows.Forms.DataGridView tablaAutomovil;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button bajaOModificacion;
        private System.Windows.Forms.Label noAutosLabel;
        private System.Windows.Forms.ComboBox selectorDeMarcas;
    }
}