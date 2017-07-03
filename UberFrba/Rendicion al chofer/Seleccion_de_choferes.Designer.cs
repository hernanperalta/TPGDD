namespace UberFrba.Rendicion_al_chofer
{
    partial class Seleccion_de_choferes
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
            this.choferesGrid = new System.Windows.Forms.DataGridView();
            this.noChoferesLabel = new System.Windows.Forms.Label();
            this.volver = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buscar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.confirmarChofer = new System.Windows.Forms.Button();
            this.dniChofer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apellidoChofer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreChofer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.choferesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // choferesGrid
            // 
            this.choferesGrid.AllowUserToAddRows = false;
            this.choferesGrid.AllowUserToDeleteRows = false;
            this.choferesGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.choferesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.choferesGrid.Location = new System.Drawing.Point(23, 182);
            this.choferesGrid.Name = "choferesGrid";
            this.choferesGrid.ReadOnly = true;
            this.choferesGrid.Size = new System.Drawing.Size(808, 171);
            this.choferesGrid.TabIndex = 83;
            // 
            // noChoferesLabel
            // 
            this.noChoferesLabel.AutoSize = true;
            this.noChoferesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.noChoferesLabel.Location = new System.Drawing.Point(290, 144);
            this.noChoferesLabel.Name = "noChoferesLabel";
            this.noChoferesLabel.Size = new System.Drawing.Size(206, 20);
            this.noChoferesLabel.TabIndex = 82;
            this.noChoferesLabel.Text = "No se encontraron choferes";
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(212, 359);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(93, 23);
            this.volver.TabIndex = 81;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 13);
            this.label4.TabIndex = 80;
            this.label4.Text = "Ingrese los campos por los que quiera filtrar :";
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(608, 139);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(101, 25);
            this.buscar.TabIndex = 79;
            this.buscar.Text = "Buscar todos";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click_1);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(97, 140);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(101, 25);
            this.limpiar.TabIndex = 78;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click_1);
            // 
            // confirmarChofer
            // 
            this.confirmarChofer.Location = new System.Drawing.Point(497, 360);
            this.confirmarChofer.Name = "confirmarChofer";
            this.confirmarChofer.Size = new System.Drawing.Size(119, 23);
            this.confirmarChofer.TabIndex = 77;
            this.confirmarChofer.Text = "Confirmar chofer";
            this.confirmarChofer.UseVisualStyleBackColor = true;
            this.confirmarChofer.Click += new System.EventHandler(this.confirmarChofer_Click_1);
            // 
            // dniChofer
            // 
            this.dniChofer.Location = new System.Drawing.Point(503, 95);
            this.dniChofer.Name = "dniChofer";
            this.dniChofer.Size = new System.Drawing.Size(100, 20);
            this.dniChofer.TabIndex = 76;
            this.dniChofer.TextChanged += new System.EventHandler(this.dniChofer_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(500, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "DNI :";
            // 
            // apellidoChofer
            // 
            this.apellidoChofer.Location = new System.Drawing.Point(355, 95);
            this.apellidoChofer.Name = "apellidoChofer";
            this.apellidoChofer.Size = new System.Drawing.Size(100, 20);
            this.apellidoChofer.TabIndex = 74;
            this.apellidoChofer.TextChanged += new System.EventHandler(this.apellidoChofer_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Apellido :";
            // 
            // nombreChofer
            // 
            this.nombreChofer.Location = new System.Drawing.Point(212, 95);
            this.nombreChofer.Name = "nombreChofer";
            this.nombreChofer.Size = new System.Drawing.Size(100, 20);
            this.nombreChofer.TabIndex = 72;
            this.nombreChofer.TextChanged += new System.EventHandler(this.nombreChofer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Nombre :";
            // 
            // Seleccion_de_choferes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 436);
            this.Controls.Add(this.choferesGrid);
            this.Controls.Add(this.noChoferesLabel);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.confirmarChofer);
            this.Controls.Add(this.dniChofer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.apellidoChofer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreChofer);
            this.Controls.Add(this.label1);
            this.Name = "Seleccion_de_choferes";
            this.Text = "Seleccion_de_choferes";
            this.Load += new System.EventHandler(this.Seleccion_de_choferes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.choferesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView choferesGrid;
        private System.Windows.Forms.Label noChoferesLabel;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button confirmarChofer;
        private System.Windows.Forms.TextBox dniChofer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apellidoChofer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreChofer;
        private System.Windows.Forms.Label label1;
    }
}