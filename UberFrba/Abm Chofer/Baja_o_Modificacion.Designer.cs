namespace UberFrba.Abm_Chofer
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
            this.buscar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.bajaOModificacion = new System.Windows.Forms.Button();
            this.dniChofer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apellidoChofer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreChofer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.volver = new System.Windows.Forms.Button();
            this.noChoferesLabel = new System.Windows.Forms.Label();
            this.choferesGrid = new System.Windows.Forms.DataGridView();
            this.rehabilitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.choferesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(578, 150);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(101, 25);
            this.buscar.TabIndex = 49;
            this.buscar.Text = "Buscar todos";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(67, 151);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(101, 25);
            this.limpiar.TabIndex = 48;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            // 
            // bajaOModificacion
            // 
            this.bajaOModificacion.Location = new System.Drawing.Point(467, 371);
            this.bajaOModificacion.Name = "bajaOModificacion";
            this.bajaOModificacion.Size = new System.Drawing.Size(119, 23);
            this.bajaOModificacion.TabIndex = 45;
            this.bajaOModificacion.Text = "Baja/Modif";
            this.bajaOModificacion.UseVisualStyleBackColor = true;
            this.bajaOModificacion.Click += new System.EventHandler(this.bajaOModificacion_Click);
            // 
            // dniChofer
            // 
            this.dniChofer.Location = new System.Drawing.Point(473, 106);
            this.dniChofer.Name = "dniChofer";
            this.dniChofer.Size = new System.Drawing.Size(100, 20);
            this.dniChofer.TabIndex = 44;
            this.dniChofer.TextChanged += new System.EventHandler(this.dniChofer_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "DNI :";
            // 
            // apellidoChofer
            // 
            this.apellidoChofer.Location = new System.Drawing.Point(325, 106);
            this.apellidoChofer.Name = "apellidoChofer";
            this.apellidoChofer.Size = new System.Drawing.Size(100, 20);
            this.apellidoChofer.TabIndex = 42;
            this.apellidoChofer.TextChanged += new System.EventHandler(this.apellidoChofer_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Apellido :";
            // 
            // nombreChofer
            // 
            this.nombreChofer.Location = new System.Drawing.Point(182, 106);
            this.nombreChofer.Name = "nombreChofer";
            this.nombreChofer.Size = new System.Drawing.Size(100, 20);
            this.nombreChofer.TabIndex = 40;
            this.nombreChofer.TextChanged += new System.EventHandler(this.nombreChofer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Nombre :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Ingrese los campos por los que quiera filtrar :";
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(182, 370);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(93, 23);
            this.volver.TabIndex = 53;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // noChoferesLabel
            // 
            this.noChoferesLabel.AutoSize = true;
            this.noChoferesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.noChoferesLabel.Location = new System.Drawing.Point(260, 155);
            this.noChoferesLabel.Name = "noChoferesLabel";
            this.noChoferesLabel.Size = new System.Drawing.Size(206, 20);
            this.noChoferesLabel.TabIndex = 55;
            this.noChoferesLabel.Text = "No se encontraron choferes";
            // 
            // choferesGrid
            // 
            this.choferesGrid.AllowUserToAddRows = false;
            this.choferesGrid.AllowUserToOrderColumns = true;
            this.choferesGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.choferesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.choferesGrid.Location = new System.Drawing.Point(67, 189);
            this.choferesGrid.Name = "choferesGrid";
            this.choferesGrid.ReadOnly = true;
            this.choferesGrid.Size = new System.Drawing.Size(612, 171);
            this.choferesGrid.TabIndex = 56;
            this.choferesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.choferesGrid_CellContentClick);
            // 
            // rehabilitar
            // 
            this.rehabilitar.Location = new System.Drawing.Point(325, 371);
            this.rehabilitar.Name = "rehabilitar";
            this.rehabilitar.Size = new System.Drawing.Size(100, 23);
            this.rehabilitar.TabIndex = 57;
            this.rehabilitar.Text = "Rehabilitar";
            this.rehabilitar.UseVisualStyleBackColor = true;
            this.rehabilitar.Click += new System.EventHandler(this.rehabilitar_Click);
            // 
            // Baja_o_Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 418);
            this.Controls.Add(this.rehabilitar);
            this.Controls.Add(this.choferesGrid);
            this.Controls.Add(this.noChoferesLabel);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.bajaOModificacion);
            this.Controls.Add(this.dniChofer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.apellidoChofer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreChofer);
            this.Controls.Add(this.label1);
            this.Name = "Baja_o_Modificacion";
            this.Text = "Baja y modificacion de chofer";
            this.Load += new System.EventHandler(this.Baja_y_Modificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.choferesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button bajaOModificacion;
        private System.Windows.Forms.TextBox dniChofer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apellidoChofer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreChofer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Label noChoferesLabel;
        private System.Windows.Forms.DataGridView choferesGrid;
        private System.Windows.Forms.Button rehabilitar;
    }
}