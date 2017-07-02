﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Menu;

namespace UberFrba.Abm_Rol
{
    public partial class Alta : Form
    {
        private Form parent;

        public Alta(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Alta_Load(object sender, EventArgs e)
        {
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void limpiarCampos_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
        }
    }
}
