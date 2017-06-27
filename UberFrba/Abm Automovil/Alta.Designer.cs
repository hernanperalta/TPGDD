namespace UberFrba.Abm_Automovil
{
    partial class Alta
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
            this.modelo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.patente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.horaInicioTurno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numeroChofer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.crear = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.marca = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.horaFinTurno = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca :";
            // 
            // modelo
            // 
            this.modelo.Location = new System.Drawing.Point(44, 105);
            this.modelo.Name = "modelo";
            this.modelo.Size = new System.Drawing.Size(100, 20);
            this.modelo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modelo :";
            // 
            // patente
            // 
            this.patente.Location = new System.Drawing.Point(44, 165);
            this.patente.Name = "patente";
            this.patente.Size = new System.Drawing.Size(100, 20);
            this.patente.TabIndex = 5;
            this.patente.TextChanged += new System.EventHandler(this.patente_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Patente :";
            // 
            // horaInicioTurno
            // 
            this.horaInicioTurno.Location = new System.Drawing.Point(199, 46);
            this.horaInicioTurno.Name = "horaInicioTurno";
            this.horaInicioTurno.Size = new System.Drawing.Size(100, 20);
            this.horaInicioTurno.TabIndex = 15;
            this.horaInicioTurno.TextChanged += new System.EventHandler(this.horaInicioTurno_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Turno hora inicio :";
            // 
            // numeroChofer
            // 
            this.numeroChofer.Location = new System.Drawing.Point(199, 165);
            this.numeroChofer.Name = "numeroChofer";
            this.numeroChofer.Size = new System.Drawing.Size(100, 20);
            this.numeroChofer.TabIndex = 11;
            this.numeroChofer.TextChanged += new System.EventHandler(this.numeroChofer_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Número de chofer :";
            // 
            // crear
            // 
            this.crear.Location = new System.Drawing.Point(108, 207);
            this.crear.Name = "crear";
            this.crear.Size = new System.Drawing.Size(109, 32);
            this.crear.TabIndex = 12;
            this.crear.Text = "Crear automóvil";
            this.crear.UseVisualStyleBackColor = true;
            this.crear.Click += new System.EventHandler(this.crear_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 32);
            this.button2.TabIndex = 13;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // marca
            // 
            this.marca.Location = new System.Drawing.Point(44, 46);
            this.marca.Name = "marca";
            this.marca.Size = new System.Drawing.Size(100, 20);
            this.marca.TabIndex = 14;
            this.marca.TextChanged += new System.EventHandler(this.marca_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(31, 256);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 32);
            this.button3.TabIndex = 16;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Turno hora fin :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // horaFinTurno
            // 
            this.horaFinTurno.Location = new System.Drawing.Point(199, 105);
            this.horaFinTurno.Name = "horaFinTurno";
            this.horaFinTurno.Size = new System.Drawing.Size(100, 20);
            this.horaFinTurno.TabIndex = 18;
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 304);
            this.Controls.Add(this.horaFinTurno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.marca);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.crear);
            this.Controls.Add(this.numeroChofer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.horaInicioTurno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.patente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modelo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Alta";
            this.Text = "Alta de automóvil";
            this.Load += new System.EventHandler(this.Alta_o_Modificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modelo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox patente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox horaInicioTurno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numeroChofer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button crear;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox marca;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox horaFinTurno;
    }
}