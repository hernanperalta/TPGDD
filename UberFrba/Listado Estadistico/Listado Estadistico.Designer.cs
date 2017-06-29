namespace UberFrba.Listado_Estadistico
{
    partial class Listado_Estadistico
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
            this.trimestre = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.listados = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listadoEstadistico = new System.Windows.Forms.DataGridView();
            this.consultar = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.anio = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.trimestre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoEstadistico)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese un año ";
            // 
            // trimestre
            // 
            this.trimestre.Location = new System.Drawing.Point(307, 79);
            this.trimestre.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.trimestre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trimestre.Name = "trimestre";
            this.trimestre.ReadOnly = true;
            this.trimestre.Size = new System.Drawing.Size(181, 20);
            this.trimestre.TabIndex = 3;
            this.trimestre.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trimestre.ValueChanged += new System.EventHandler(this.trimestre_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione un trimestre";
            // 
            // listados
            // 
            this.listados.FormattingEnabled = true;
            this.listados.Location = new System.Drawing.Point(307, 133);
            this.listados.Name = "listados";
            this.listados.Size = new System.Drawing.Size(181, 21);
            this.listados.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Seleccione un tipo de listado";
            // 
            // listadoEstadistico
            // 
            this.listadoEstadistico.AllowUserToAddRows = false;
            this.listadoEstadistico.AllowUserToDeleteRows = false;
            this.listadoEstadistico.AllowUserToOrderColumns = true;
            this.listadoEstadistico.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.listadoEstadistico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoEstadistico.Location = new System.Drawing.Point(40, 231);
            this.listadoEstadistico.Name = "listadoEstadistico";
            this.listadoEstadistico.ReadOnly = true;
            this.listadoEstadistico.Size = new System.Drawing.Size(559, 149);
            this.listadoEstadistico.TabIndex = 53;
            // 
            // consultar
            // 
            this.consultar.Location = new System.Drawing.Point(343, 183);
            this.consultar.Name = "consultar";
            this.consultar.Size = new System.Drawing.Size(75, 23);
            this.consultar.TabIndex = 55;
            this.consultar.Text = "Consultar";
            this.consultar.UseVisualStyleBackColor = true;
            this.consultar.Click += new System.EventHandler(this.consultar_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(214, 183);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 56;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // anio
            // 
            this.anio.Location = new System.Drawing.Point(307, 27);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(181, 20);
            this.anio.TabIndex = 57;
            this.anio.ValueChanged += new System.EventHandler(this.anio_ValueChanged);
            // 
            // Listado_Estadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 404);
            this.Controls.Add(this.anio);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.consultar);
            this.Controls.Add(this.listadoEstadistico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trimestre);
            this.Controls.Add(this.label1);
            this.Name = "Listado_Estadistico";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trimestre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoEstadistico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown trimestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox listados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView listadoEstadistico;
        private System.Windows.Forms.Button consultar;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.DateTimePicker anio;
    }
}