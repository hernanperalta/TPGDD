namespace UberFrba.Abm_Rol
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
            this.nombreRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rolesCheckBox = new System.Windows.Forms.CheckedListBox();
            this.crearRol = new System.Windows.Forms.Button();
            this.limpiarCampos = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresar nombre de Rol :";
            // 
            // nombreRol
            // 
            this.nombreRol.Location = new System.Drawing.Point(88, 64);
            this.nombreRol.Name = "nombreRol";
            this.nombreRol.Size = new System.Drawing.Size(174, 20);
            this.nombreRol.TabIndex = 1;
            this.nombreRol.TextChanged += new System.EventHandler(this.nombreRol_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione las funcionalidades para el Rol :";
            // 
            // rolesCheckBox
            // 
            this.rolesCheckBox.FormattingEnabled = true;
            this.rolesCheckBox.Items.AddRange(new object[] {
            "Funcionalidad 1 ",
            "Funcionalidad 2 ",
            "...",
            "...",
            "...",
            "Funcionalidad n "});
            this.rolesCheckBox.Location = new System.Drawing.Point(114, 140);
            this.rolesCheckBox.Name = "rolesCheckBox";
            this.rolesCheckBox.Size = new System.Drawing.Size(120, 64);
            this.rolesCheckBox.TabIndex = 3;
            this.rolesCheckBox.SelectedIndexChanged += new System.EventHandler(this.rolesCheckBox_SelectedIndexChanged);
            // 
            // crearRol
            // 
            this.crearRol.Location = new System.Drawing.Point(250, 224);
            this.crearRol.Name = "crearRol";
            this.crearRol.Size = new System.Drawing.Size(95, 32);
            this.crearRol.TabIndex = 4;
            this.crearRol.Text = "Crear Rol";
            this.crearRol.UseVisualStyleBackColor = true;
            // 
            // limpiarCampos
            // 
            this.limpiarCampos.Location = new System.Drawing.Point(123, 224);
            this.limpiarCampos.Name = "limpiarCampos";
            this.limpiarCampos.Size = new System.Drawing.Size(109, 32);
            this.limpiarCampos.TabIndex = 14;
            this.limpiarCampos.Text = "Limpiar";
            this.limpiarCampos.UseVisualStyleBackColor = true;
            this.limpiarCampos.Click += new System.EventHandler(this.limpiarCampos_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(12, 224);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(96, 32);
            this.volver.TabIndex = 15;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 268);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.limpiarCampos);
            this.Controls.Add(this.crearRol);
            this.Controls.Add(this.rolesCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombreRol);
            this.Controls.Add(this.label1);
            this.Name = "Alta";
            this.Text = "Alta de Rol";
            this.Load += new System.EventHandler(this.Alta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox rolesCheckBox;
        private System.Windows.Forms.Button crearRol;
        private System.Windows.Forms.Button limpiarCampos;
        private System.Windows.Forms.Button volver;
    }
}