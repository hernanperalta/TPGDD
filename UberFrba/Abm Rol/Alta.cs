using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Menu;
using UberFrba.Conexion;
using System.Data.SqlClient;

namespace UberFrba.Abm_Rol
{
    public partial class Alta : Form
    {
        private Form parent;

        public Alta(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.cargarFuncionalidades();
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

        private void nombreRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void rolesCheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void cargarFuncionalidades()
        {
            SqlDataReader funcionalidadesReader = this.leerFuncionalidades();

            while (funcionalidadesReader.Read())
            {
                Funcionalidad funcAAgregar = this.rolesCheckBox.obtenerFuncionalidad(funcionalidadesReader.GetByte(0));
                this.rolesCheckBox.Items.Add(funcAAgregar);
            }

            funcionalidadesReader.Close();
        }
    }
}
