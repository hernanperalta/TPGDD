namespace UberFrba.Login_Usuario
{
    partial class Seleccionar_Rol
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
            this.selectorRol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aceptar = new System.Windows.Forms.Button();
            this.noPoseeRolesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectorRol
            // 
            this.selectorRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectorRol.FormattingEnabled = true;
            this.selectorRol.Location = new System.Drawing.Point(54, 55);
            this.selectorRol.Name = "selectorRol";
            this.selectorRol.Size = new System.Drawing.Size(176, 21);
            this.selectorRol.TabIndex = 0;
            this.selectorRol.SelectedIndexChanged += new System.EventHandler(this.selectorRol_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione su Rol : ";
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(102, 132);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 2;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // noPoseeRolesLabel
            // 
            this.noPoseeRolesLabel.AutoSize = true;
            this.noPoseeRolesLabel.Location = new System.Drawing.Point(80, 91);
            this.noPoseeRolesLabel.Name = "noPoseeRolesLabel";
            this.noPoseeRolesLabel.Size = new System.Drawing.Size(129, 13);
            this.noPoseeRolesLabel.TabIndex = 3;
            this.noPoseeRolesLabel.Text = "No posee roles asignados";
            this.noPoseeRolesLabel.UseMnemonic = false;
            this.noPoseeRolesLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // Seleccionar_Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 201);
            this.Controls.Add(this.noPoseeRolesLabel);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectorRol);
            this.Name = "Seleccionar_Rol";
            this.Text = "Seleccionar_Rol";
            this.Load += new System.EventHandler(this.Seleccionar_Rol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectorRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Label noPoseeRolesLabel;
    }
}