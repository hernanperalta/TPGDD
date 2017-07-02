namespace UberFrba.Abm_Rol
{
    partial class Baja
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
            this.roles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.darDeBaja = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // roles
            // 
            this.roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roles.FormattingEnabled = true;
            this.roles.Location = new System.Drawing.Point(71, 71);
            this.roles.Name = "roles";
            this.roles.Size = new System.Drawing.Size(121, 21);
            this.roles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Elija el rol a dar de baja :";
            // 
            // darDeBaja
            // 
            this.darDeBaja.Location = new System.Drawing.Point(154, 117);
            this.darDeBaja.Name = "darDeBaja";
            this.darDeBaja.Size = new System.Drawing.Size(75, 23);
            this.darDeBaja.TabIndex = 2;
            this.darDeBaja.Text = "Dar de baja";
            this.darDeBaja.UseVisualStyleBackColor = true;
            this.darDeBaja.Click += new System.EventHandler(this.darDeBaja_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(43, 117);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 3;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.button2_Click);
            // 
            // Baja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 167);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.darDeBaja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roles);
            this.Name = "Baja";
            this.Text = "Baja de Rol";
            this.Load += new System.EventHandler(this.Baja_Rol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox roles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button darDeBaja;
        private System.Windows.Forms.Button volver;
    }
}