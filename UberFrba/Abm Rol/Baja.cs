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
    public partial class Baja : Form
    {
        private Form parent;

        public Baja(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.cargarRoles();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void darDeBaja_Click(object sender, EventArgs e)
        {
            if (this.roles.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar el rol a dar de baja");
                return;
            }
            try
            {
                DBConexion.ResolverNonQuery("DELETE FROM LOS_CHATADROIDES.Rol WHERE nombre_del_rol = '" + this.roles.SelectedItem.ToString() + "'");

                MessageBox.Show("Se ha dado de baja el rol: " + this.roles.SelectedItem.ToString());

                this.cargarRoles();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Baja_Rol_Load(object sender, EventArgs e)
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
            return DBConexion.ResolverQuery("SELECT nombre_del_rol FROM LOS_CHATADROIDES.Rol WHERE habilitado = 1");
        }

    }
}
