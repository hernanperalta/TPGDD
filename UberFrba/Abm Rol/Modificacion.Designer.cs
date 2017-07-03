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
            this.guardarRol = new System.Windows.Forms.Button();
            this.funcsAAgregar = new System.Windows.Forms.CheckedListBox();
            this.funcsAQuitar = new System.Windows.Forms.CheckedListBox();
            this.limpiar = new System.Windows.Forms.Button();
            this.rehabilitar = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.rolDeshabilitadoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elija el Rol a modificar :";
            // 
            // roles
            // 
            this.roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roles.FormattingEnabled = true;
            this.roles.Location = new System.Drawing.Point(55, 38);
            this.roles.Name = "roles";
            this.roles.Size = new System.Drawing.Size(176, 21);
            this.roles.TabIndex = 1;
            this.roles.SelectedIndexChanged += new System.EventHandler(this.roles_SelectedIndexChanged);
            // 
            // nuevoNombreRol
            // 
            this.nuevoNombreRol.Location = new System.Drawing.Point(349, 39);
            this.nuevoNombreRol.Name = "nuevoNombreRol";
            this.nuevoNombreRol.Size = new System.Drawing.Size(176, 20);
            this.nuevoNombreRol.TabIndex = 2;
            this.nuevoNombreRol.TextChanged += new System.EventHandler(this.nuevoNombreRol_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ingrese el nuevo nombre :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Seleccione las funcionalidades a agregar : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Seleccione las funcionalidades a quitar : ";
            // 
            // guardarRol
            // 
            this.guardarRol.Location = new System.Drawing.Point(441, 249);
            this.guardarRol.Name = "guardarRol";
            this.guardarRol.Size = new System.Drawing.Size(117, 23);
            this.guardarRol.TabIndex = 12;
            this.guardarRol.Text = "Guardar rol";
            this.guardarRol.UseVisualStyleBackColor = true;
            this.guardarRol.Click += new System.EventHandler(this.guardarRol_Click);
            // 
            // funcsAAgregar
            // 
            this.funcsAAgregar.FormattingEnabled = true;
            this.funcsAAgregar.Location = new System.Drawing.Point(24, 137);
            this.funcsAAgregar.Name = "funcsAAgregar";
            this.funcsAAgregar.Size = new System.Drawing.Size(254, 94);
            this.funcsAAgregar.TabIndex = 13;
            this.funcsAAgregar.SelectedIndexChanged += new System.EventHandler(this.funcsAAgregar_SelectedIndexChanged);
            // 
            // funcsAQuitar
            // 
            this.funcsAQuitar.FormattingEnabled = true;
            this.funcsAQuitar.Location = new System.Drawing.Point(319, 137);
            this.funcsAQuitar.Name = "funcsAQuitar";
            this.funcsAQuitar.Size = new System.Drawing.Size(271, 94);
            this.funcsAQuitar.TabIndex = 14;
            this.funcsAQuitar.SelectedIndexChanged += new System.EventHandler(this.funcsAQuitar_SelectedIndexChanged);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(131, 249);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(105, 23);
            this.limpiar.TabIndex = 15;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // rehabilitar
            // 
            this.rehabilitar.Location = new System.Drawing.Point(281, 249);
            this.rehabilitar.Name = "rehabilitar";
            this.rehabilitar.Size = new System.Drawing.Size(119, 23);
            this.rehabilitar.TabIndex = 41;
            this.rehabilitar.Text = "Rehabilitar";
            this.rehabilitar.UseVisualStyleBackColor = true;
            this.rehabilitar.Click += new System.EventHandler(this.rehabilitar_Click);
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
            // rolDeshabilitadoLabel
            // 
            this.rolDeshabilitadoLabel.AutoSize = true;
            this.rolDeshabilitadoLabel.Location = new System.Drawing.Point(52, 73);
            this.rolDeshabilitadoLabel.Name = "rolDeshabilitadoLabel";
            this.rolDeshabilitadoLabel.Size = new System.Drawing.Size(113, 13);
            this.rolDeshabilitadoLabel.TabIndex = 43;
            this.rolDeshabilitadoLabel.Text = "Rol deshabilitado label";
            this.rolDeshabilitadoLabel.Click += new System.EventHandler(this.rolDeshabilitadoLabel_Click);
            // 
            // Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 303);
            this.Controls.Add(this.rolDeshabilitadoLabel);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.rehabilitar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.funcsAQuitar);
            this.Controls.Add(this.funcsAAgregar);
            this.Controls.Add(this.guardarRol);
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
        private System.Windows.Forms.Button guardarRol;
        private System.Windows.Forms.CheckedListBox funcsAAgregar;
        private System.Windows.Forms.CheckedListBox funcsAQuitar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button rehabilitar;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Label rolDeshabilitadoLabel;
    }
}