namespace UberFrba.Abm_Rol
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
            this.label1 = new System.Windows.Forms.Label();
            this.roles = new System.Windows.Forms.ComboBox();
            this.nuevoNombreRol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.funcsAAgregar = new System.Windows.Forms.CheckedListBox();
            this.funcsAQuitar = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elija el Rol a modificar :";
            // 
            // roles
            // 
            this.roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roles.FormattingEnabled = true;
            this.roles.Location = new System.Drawing.Point(201, 46);
            this.roles.Name = "roles";
            this.roles.Size = new System.Drawing.Size(176, 21);
            this.roles.TabIndex = 1;
            this.roles.SelectedIndexChanged += new System.EventHandler(this.roles_SelectedIndexChanged);
            // 
            // nuevoNombreRol
            // 
            this.nuevoNombreRol.Location = new System.Drawing.Point(201, 107);
            this.nuevoNombreRol.Name = "nuevoNombreRol";
            this.nuevoNombreRol.Size = new System.Drawing.Size(176, 20);
            this.nuevoNombreRol.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ingrese el nuevo nombre :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Seleccione las funcionalidades a agregar : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Seleccione las funcionalidades a quitar : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Guardar rol";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // funcsAAgregar
            // 
            this.funcsAAgregar.FormattingEnabled = true;
            this.funcsAAgregar.Location = new System.Drawing.Point(24, 167);
            this.funcsAAgregar.Name = "funcsAAgregar";
            this.funcsAAgregar.Size = new System.Drawing.Size(254, 64);
            this.funcsAAgregar.TabIndex = 13;
            // 
            // funcsAQuitar
            // 
            this.funcsAQuitar.FormattingEnabled = true;
            this.funcsAQuitar.Location = new System.Drawing.Point(319, 167);
            this.funcsAQuitar.Name = "funcsAQuitar";
            this.funcsAQuitar.Size = new System.Drawing.Size(271, 64);
            this.funcsAQuitar.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(281, 249);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(119, 23);
            this.button5.TabIndex = 41;
            this.button5.Text = "Rehabilitar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(13, 249);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 42;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 303);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.funcsAQuitar);
            this.Controls.Add(this.funcsAAgregar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nuevoNombreRol);
            this.Controls.Add(this.roles);
            this.Controls.Add(this.label1);
            this.Name = "Modificacion";
            this.Text = "Modificacion de Rol";
            this.Load += new System.EventHandler(this.Modificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox roles;
        private System.Windows.Forms.TextBox nuevoNombreRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox funcsAAgregar;
        private System.Windows.Forms.CheckedListBox funcsAQuitar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button volver;
    }
}