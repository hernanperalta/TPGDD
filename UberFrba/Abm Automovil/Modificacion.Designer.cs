namespace UberFrba.Abm_Automovil
{
    partial class Modificacion
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
            this.marca = new System.Windows.Forms.TextBox();
            this.restaurar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.numeroChofer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.modelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.habilitado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.patente = new System.Windows.Forms.Label();
            this.selectorTurno = new System.Windows.Forms.ComboBox();
            this.turnoActualLabel = new System.Windows.Forms.Label();
            this.volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // marca
            // 
            this.marca.Location = new System.Drawing.Point(48, 104);
            this.marca.Name = "marca";
            this.marca.Size = new System.Drawing.Size(100, 20);
            this.marca.TabIndex = 29;
            this.marca.TextChanged += new System.EventHandler(this.marca_TextChanged);
            // 
            // restaurar
            // 
            this.restaurar.Location = new System.Drawing.Point(185, 240);
            this.restaurar.Name = "restaurar";
            this.restaurar.Size = new System.Drawing.Size(109, 32);
            this.restaurar.TabIndex = 28;
            this.restaurar.Text = "Restaurar Valores";
            this.restaurar.UseVisualStyleBackColor = true;
            this.restaurar.Click += new System.EventHandler(this.restaurar_Click);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(335, 240);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(109, 32);
            this.guardar.TabIndex = 27;
            this.guardar.Text = "Guardar automóvil";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // numeroChofer
            // 
            this.numeroChofer.Location = new System.Drawing.Point(344, 104);
            this.numeroChofer.Name = "numeroChofer";
            this.numeroChofer.Size = new System.Drawing.Size(100, 20);
            this.numeroChofer.TabIndex = 26;
            this.numeroChofer.TextChanged += new System.EventHandler(this.numeroChofer_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Número de chofer :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Seleccion de turno :";
            // 
            // modelo
            // 
            this.modelo.Location = new System.Drawing.Point(48, 173);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(100, 20);
            this.modelo.TabIndex = 21;
            this.modelo.TextChanged += new System.EventHandler(this.modelo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Modelo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Marca :";
            // 
            // habilitado
            // 
            this.habilitado.AutoSize = true;
            this.habilitado.Location = new System.Drawing.Point(208, 104);
            this.habilitado.Name = "habilitado";
            this.habilitado.Size = new System.Drawing.Size(73, 17);
            this.habilitado.TabIndex = 34;
            this.habilitado.Text = "Habilitado";
            this.habilitado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Patente de Automovil : ";
            // 
            // patente
            // 
            this.patente.AutoSize = true;
            this.patente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patente.Location = new System.Drawing.Point(216, 42);
            this.patente.Name = "patente";
            this.patente.Size = new System.Drawing.Size(53, 16);
            this.patente.TabIndex = 36;
            this.patente.Text = "patente";
            // 
            // selectorTurno
            // 
            this.selectorTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorTurno.FormattingEnabled = true;
            this.selectorTurno.Location = new System.Drawing.Point(219, 173);
            this.selectorTurno.Name = "selectorTurno";
            this.selectorTurno.Size = new System.Drawing.Size(225, 21);
            this.selectorTurno.TabIndex = 37;
            this.selectorTurno.SelectedIndexChanged += new System.EventHandler(this.selectorTurno_SelectedIndexChanged);
            // 
            // turnoActualLabel
            // 
            this.turnoActualLabel.AutoSize = true;
            this.turnoActualLabel.Location = new System.Drawing.Point(257, 212);
            this.turnoActualLabel.Name = "turnoActualLabel";
            this.turnoActualLabel.Size = new System.Drawing.Size(68, 13);
            this.turnoActualLabel.TabIndex = 38;
            this.turnoActualLabel.Text = "Turno Actual";
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(35, 240);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(109, 32);
            this.volver.TabIndex = 39;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 298);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.turnoActualLabel);
            this.Controls.Add(this.selectorTurno);
            this.Controls.Add(this.patente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.habilitado);
            this.Controls.Add(this.marca);
            this.Controls.Add(this.restaurar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.numeroChofer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Modificacion";
            this.Text = "Modificacion";
            this.Load += new System.EventHandler(this.Modificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox marca;
        private System.Windows.Forms.Button restaurar;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.TextBox numeroChofer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox habilitado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label patente;
        private System.Windows.Forms.ComboBox selectorTurno;
        private System.Windows.Forms.Label turnoActualLabel;
        private System.Windows.Forms.Button volver;
    }
}