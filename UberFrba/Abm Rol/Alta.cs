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
        private string errores = "";
        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

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
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
                if (ctrl is CheckedListBox)
                {
                    for (int i = 0; i < ((CheckedListBox)ctrl).Items.Count; i++)
                    {
                        ((CheckedListBox)ctrl).SetItemChecked(i,false);
                    }
                }
            }
        }

        private void nombreRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void funcionalidadesCheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void cargarFuncionalidades()
        {
            
            SqlDataReader funcionalidadesReader = this.leerFuncionalidades();

            while (funcionalidadesReader.Read())
            {
                this.funcionalidades.Add(new Funcionalidad(funcionalidadesReader.GetByte(0).ToString(), funcionalidadesReader.GetString(1)));
                this.funcionalidadesCheckBox.Items.Add(funcionalidadesReader.GetString(1));
            }

            funcionalidadesReader.Close();
        }

        private SqlDataReader leerFuncionalidades()
        {
            return DBConexion.ResolverQuery("SELECT codigo_funcionalidad, descripcion FROM LOS_CHATADROIDES.Funcionalidad");
        }

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private void crearRol_Click(object sender, EventArgs e)
        {
            if (this.estaVacio(this.nombreRol.Text))
            {
                MessageBox.Show("Inserte un nombre de rol");
                return;
            }

            if (this.nombreRol.Text.Count() > 25)
            {
                MessageBox.Show("El nombre de rol elegido excede los 25 caracteres");
                return;
            }

            try
            {
                DBConexion.ResolverNonQuery("INSERT INTO LOS_CHATADROIDES.Rol (nombre_del_rol, habilitado) VALUES ("
                                            + "'" + this.nombreRol.Text + "', "
                                            + "1)");

                this.insertarFuncionalidades();

                MessageBox.Show("Se pudo cargar el rol!");
            }
            catch (SqlException ex)
            {
                if( ex.Number == 2627 )
                    MessageBox.Show("Ya existe un rol de nombre " + this.nombreRol.Text);
            }
        }

        private void insertarFuncionalidades()
        { 
            foreach (string funcionalidad in this.funcionalidadesCheckBox.CheckedItems)
            {
                string codigo = this.funcionalidades.Find(unaFunc => unaFunc.nombre == funcionalidad).codigo;
                DBConexion.ResolverNonQuery("INSERT INTO LOS_CHATADROIDES.Funcionalidad_X_Rol (nombre_del_rol, codigo_funcionalidad) VALUES ("
                                            + "'" + this.nombreRol.Text + "', "
                                            + codigo + ")");
            }
        }

    }
}
