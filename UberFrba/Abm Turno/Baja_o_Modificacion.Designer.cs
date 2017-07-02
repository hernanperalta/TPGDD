namespace UberFrba.Abm_Turno
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
            this.noTurnosLabel = new System.Windows.Forms.Label();
            this.rehabilitar = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.turnosGrid = new System.Windows.Forms.DataGridView();
            this.buscarTurnos = new System.Windows.Forms.Button();
            this.limpiarCampos = new System.Windows.Forms.Button();
            this.bajaOModificacion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.turnosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // noTurnosLabel
            // 
            this.noTurnosLabel.AutoSize = true;
            this.noTurnosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.noTurnosLabel.Location = new System.Drawing.Point(348, 130);
            this.noTurnosLabel.Name = "noTurnosLabel";
            this.noTurnosLabel.Size = new System.Drawing.Size(189, 20);
            this.noTurnosLabel.TabIndex = 57;
            this.noTurnosLabel.Text = "No se encontraron turnos";
            // 
            // rehabilitar
            // 
            this.rehabilitar.Location = new System.Drawing.Point(415, 366);
            this.rehabilitar.Name = "rehabilitar";
            this.rehabilitar.Size = new System.Drawing.Size(117, 23);
            this.rehabilitar.TabIndex = 56;
            this.rehabilitar.Text = "Rehabilitar";
            this.rehabilitar.UseVisualStyleBackColor = true;
            this.rehabilitar.Click += new System.EventHandler(this.rehabilitar_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(271, 366);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 55;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // turnosGrid
            // 
            this.turnosGrid.AllowUserToAddRows = false;
            this.turnosGrid.AllowUserToOrderColumns = true;
            this.turnosGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.turnosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.turnosGrid.Location = new System.Drawing.Point(20, 168);
            this.turnosGrid.Name = "turnosGrid";
            this.turnosGrid.ReadOnly = true;
            this.turnosGrid.Size = new System.Drawing.Size(878, 171);
            this.turnosGrid.TabIndex = 54;
            // 
            // buscarTurnos
            // 
            this.buscarTurnos.Location = new System.Drawing.Point(629, 125);
            this.buscarTurnos.Name = "buscarTurnos";
            this.buscarTurnos.Size = new System.Drawing.Size(101, 25);
            this.buscarTurnos.TabIndex = 53;
            this.buscarTurnos.Text = "Buscar todos";
            this.buscarTurnos.UseVisualStyleBackColor = true;
            this.buscarTurnos.Click += new System.EventHandler(this.buscarTurnos_Click);
            // 
            // limpiarCampos
            // 
            this.limpiarCampos.Location = new System.Drawing.Point(178, 125);
            this.limpiarCampos.Name = "limpiarCampos";
            this.limpiarCampos.Size = new System.Drawing.Size(101, 25);
            this.limpiarCampos.TabIndex = 52;
            this.limpiarCampos.Text = "Limpiar";
            this.limpiarCampos.UseVisualStyleBackColor = true;
            this.limpiarCampos.Click += new System.EventHandler(this.limpiarCampos_Click);
            // 
            // bajaOModificacion
            // 
            this.bajaOModificacion.Location = new System.Drawing.Point(601, 366);
            this.bajaOModificacion.Name = "bajaOModificacion";
            this.bajaOModificacion.Size = new System.Drawing.Size(117, 23);
            this.bajaOModificacion.TabIndex = 51;
            this.bajaOModificacion.Text = "Baja/Modif";
            this.bajaOModificacion.UseVisualStyleBackColor = true;
            this.bajaOModificacion.Click += new System.EventHandler(this.bajaOModificacion_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Ingrese la descripcion para filtrar :";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(387, 72);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(150, 20);
            this.descripcion.TabIndex = 45;
            this.descripcion.TextChanged += new System.EventHandler(this.descripcion_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Descripcion :";
            // 
            // Baja_o_Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 401);
            this.Controls.Add(this.noTurnosLabel);
            this.Controls.Add(this.rehabilitar);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.turnosGrid);
            this.Controls.Add(this.buscarTurnos);
            this.Controls.Add(this.limpiarCampos);
            this.Controls.Add(this.bajaOModificacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.label1);
            this.Name = "Baja_o_Modificacion";
            this.Text = "Baja_o_Modificacion";
            this.Load += new System.EventHandler(this.Baja_o_Modificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.turnosGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noTurnosLabel;
        private System.Windows.Forms.Button rehabilitar;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.DataGridView turnosGrid;
        private System.Windows.Forms.Button buscarTurnos;
        private System.Windows.Forms.Button limpiarCampos;
        private System.Windows.Forms.Button bajaOModificacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.Label label1;
    }
}