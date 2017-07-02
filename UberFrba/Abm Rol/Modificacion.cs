using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.Conexion;

namespace UberFrba.Abm_Rol
{
    public partial class Modificacion : Form
    {
        private Form parent;

        public Modificacion(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.cargarRoles();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cargarRoles()
        {
            this.roles.Items.Clear();

            SqlDataReader rolesReader = this.leerRoles();

            while (rolesReader.Read())
            {
                this.roles.Items.Add(rolesReader.GetString(0));
            }

            rolesReader.Close();
        }

        private SqlDataReader leerRoles()
        {
            return DBConexion.ResolverQuery("SELECT nombre_del_rol FROM LOS_CHATADROIDES.Rol");
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            this.roles.SelectedItem = null;

            this.nuevoNombreRol.Clear();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is CheckedListBox)
                {
                    for (int i = 0; i < ((CheckedListBox)ctrl).Items.Count; i++)
                    {
                        ((CheckedListBox)ctrl).SetItemChecked(i, false);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

    }
}
