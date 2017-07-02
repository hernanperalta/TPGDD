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
        private List<Funcionalidad> funcionalidadesAAgregar = new List<Funcionalidad>();
        private List<Funcionalidad> funcionalidadesAQuitar = new List<Funcionalidad>();
        private bool habilitado = true;

        public Modificacion(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.cargarRoles();
            this.rolDeshabilitadoLabel.Text = "";
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
            this.rolDeshabilitadoLabel.Text = "";
            if(this.roles.SelectedItem != null)
                this.setRolDeshabilitadoLabel();
            this.funcsAQuitar.Items.Clear();
            this.funcsAAgregar.Items.Clear();
            if (this.roles.SelectedItem == null || !habilitado)
                return;
            this.funcionalidadesAAgregar = new List<Funcionalidad>();
            this.funcionalidadesAQuitar = new List<Funcionalidad>();
            try
            {
                this.cargarFuncionalidades(this.funcionalidadesAAgregar, this.funcsAAgregar, false);
                this.cargarFuncionalidades(this.funcionalidadesAQuitar, this.funcsAQuitar, true);
            }
            catch (SinRegistrosException) { }
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
            this.limpiarCampos();
        }

        private void rehabilitar_Click(object sender, EventArgs e)
        {
            if (habilitado)
            {
                MessageBox.Show("El rol seleccionado ya se encuentra dado de alta");
                return;
            }
            DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Rol "
                                       + "SET habilitado = 1 "
                                       + "WHERE nombre_del_rol = '" + this.roles.SelectedItem.ToString() + "'");
            MessageBox.Show("El rol ha sido actualizado correctamente");
            this.limpiarCampos();
        }

        private void guardarRol_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.funcsAAgregar.CheckedItems != null)
                {
                    this.agregarFuncs();
                }
                 
                if(this.funcsAQuitar.CheckedItems != null)
                    this.quitarFuncs();

                if (!this.estaVacio(this.nuevoNombreRol.Text))
                {
                    this.actualizarRol(this.roles.SelectedItem.ToString());
                }

                MessageBox.Show("El rol ha sido actualizado correctamente");
                this.limpiarCampos();
            }
            catch (SqlException)
            {
                MessageBox.Show("Ha habido un error en la actualizacion");
            }
        }

        private void actualizarRol(string nuevoNombre)
        {
            DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Rol "
                                        +"SET nombre_del_rol = '" + this.nuevoNombreRol.Text + "' "
                                        +"WHERE nombre_del_rol = '" + this.roles.SelectedItem.ToString() + "'");
        }


        private void agregarFuncs()
        {
            {
                foreach (string funcionalidad in this.funcsAAgregar.CheckedItems)
                {
                    string codigo = this.funcionalidadesAAgregar.Find(unaFunc => unaFunc.nombre == funcionalidad).codigo;
                    DBConexion.ResolverNonQuery("INSERT INTO LOS_CHATADROIDES.Funcionalidad_X_Rol (nombre_del_rol, codigo_funcionalidad) VALUES ("
                                                + "'" + this.roles.SelectedItem.ToString() + "', "
                                                + codigo + ")");
                }
            }
        }
        private void quitarFuncs()
        {
            {
                foreach (string funcionalidad in this.funcsAQuitar.CheckedItems)
                {
                    string codigo = this.funcionalidadesAQuitar.Find(unaFunc => unaFunc.nombre == funcionalidad).codigo;
                    DBConexion.ResolverNonQuery("DELETE LOS_CHATADROIDES.Funcionalidad_X_Rol "
                                                + "WHERE nombre_del_rol = '" + this.roles.SelectedItem.ToString() + "' AND "
                                                        +"codigo_funcionalidad = " + codigo);
                }
            }
        }
 
        private void cargarFuncionalidades(List<Funcionalidad> funcionalidad,  CheckedListBox checkList, bool quitar)
        {

            SqlDataReader funcionalidadesReader = this.leerFuncionalidades(quitar);

            while (funcionalidadesReader.Read())
            {
                funcionalidad.Add(new Funcionalidad(funcionalidadesReader.GetByte(0).ToString(), funcionalidadesReader.GetString(1)));
                checkList.Items.Add(funcionalidadesReader.GetString(1));
            }

            funcionalidadesReader.Close();
        }

        private SqlDataReader leerFuncionalidades(bool quitar)
        {
            if (quitar)
            {
                return DBConexion.ResolverQuery("SELECT F.codigo_funcionalidad, descripcion "
                                               + "FROM LOS_CHATADROIDES.Funcionalidad F JOIN LOS_CHATADROIDES.Funcionalidad_X_Rol FXR "
                                               + "ON(F.codigo_funcionalidad = FXR.codigo_funcionalidad) "
                                               + "WHERE FXR.nombre_del_rol = '" + this.roles.SelectedItem.ToString() + "'");
            }
            else 
            {
                return DBConexion.ResolverQuery("SELECT codigo_funcionalidad, descripcion "
                               + "FROM LOS_CHATADROIDES.Funcionalidad "
                               + "WHERE codigo_funcionalidad NOT IN "
                                                                + "(SELECT FXR.codigo_funcionalidad "
                                                                + "FROM LOS_CHATADROIDES.Funcionalidad_X_Rol FXR "
                                                                + "WHERE nombre_del_rol = '" + this.roles.SelectedItem.ToString()+"')");
            }
        }

        private void limpiarCampos()
        {
            this.rolDeshabilitadoLabel.Text = "";
            this.roles.SelectedItem = null;
            this.funcsAQuitar.Items.Clear();
            this.funcsAAgregar.Items.Clear();
            this.funcionalidadesAAgregar = new List<Funcionalidad>();
            this.funcionalidadesAQuitar = new List<Funcionalidad>();
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

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private void setRolDeshabilitadoLabel()
        {
            this.validarRol();
            if (!habilitado)
            {
                this.rolDeshabilitadoLabel.Text = "El rol seleccionado se encuentra dado de baja. Para poder actualizarlo, primero haga click en rehabilitar";
                return;
            }
        }

        private void validarRol()
        {
            SqlDataReader habilitadoReader = this.leerHabilitacion();
            if (habilitadoReader.Read())
            {
                habilitado = habilitadoReader.GetBoolean(0);
            }
            habilitadoReader.Close();
        }
        private SqlDataReader leerHabilitacion()
        {
            return DBConexion.ResolverQuery("SELECT habilitado FROM LOS_CHATADROIDES.Rol "
                            + "WHERE nombre_del_rol = '" + this.roles.SelectedItem.ToString() + "'");
        }

        private void funcsAAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nuevoNombreRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void funcsAQuitar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rolDeshabilitadoLabel_Click(object sender, EventArgs e)
        {
        }
    }
}
