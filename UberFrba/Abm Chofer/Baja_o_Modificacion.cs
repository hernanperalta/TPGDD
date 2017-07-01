using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Conexion;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace UberFrba.Abm_Chofer
{
    public partial class Baja_o_Modificacion : Form
    {
        private string usernameActual;
        private string rol;
        private bool puedeDarDeBaja;
        private string errores = "";
        private DataTable choferes = new DataTable();
        private string query = "SELECT nombre Nombre, apellido Apellido, dni DNI, telefono Telefono, username USERNAME, habilitado Habilitado, mail Mail, direccion Direccion, depto Departamento,  nro_piso AS 'Numero de piso', localidad Localidad,fecha_de_nacimiento AS 'Fecha de nacimiento'  "
                             + " FROM LOS_CHATADROIDES.Chofer";

        public Baja_o_Modificacion(bool puedeDarDeBaja, string username, string rol)
        {
            InitializeComponent();
            this.usernameActual = username;
            this.rol = rol;
            this.puedeDarDeBaja = puedeDarDeBaja;
            this.noChoferesLabel.Text = "";

            if (puedeDarDeBaja)
            {
                this.Text = "Baja Chofer";
                this.bajaOModificacion.Text = "Dar de baja";
                this.rehabilitar.Visible = false;
            }
            else
            {
                this.Text = "Modificar Chofer";
                this.bajaOModificacion.Text = "Modificar";
            }
        }

        private void Baja_y_Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.usernameActual, this.rol);
            menu.Show();
            this.Close();
        }

        private void bajaOModificacion_Click(object sender, EventArgs e)
        {
            if (this.choferesGrid.RowCount == 0)
            {
                MessageBox.Show("Para llenar la lista de choferes disponibles haga click en el boton 'Buscar'");
                return;
            }

            if (this.choferesGrid.SelectedRows.Count > 1 && !puedeDarDeBaja)
            {
                MessageBox.Show("Sólo puede modificar de a un chofer a la vez");
                return;
            }

            if (this.choferesGrid.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Primero debe seleccionar un chofer, tocando la flecha a la izquierda de la fila");
                return;
            }

            if (this.puedeDarDeBaja)
            {
                this.deshabilitarChoferes();
                this.buscarChoferes();
                return;
            }
            
            Chofer choferSeleccionado = this.setChofer();

            Form modificar = new Modificacion(choferSeleccionado, this.usernameActual, this.rol);
            modificar.Show();
        }

        private Chofer setChofer()
        {
            int index = this.choferesGrid.SelectedRows[0].Index;
            DataRow row = choferes.Rows[index];

            Domicilio domicilio = new Domicilio(row["Direccion"].ToString(),
                                                row["Numero de piso"].ToString(),
                                                row["Departamento"].ToString(),
                                                row["Localidad"].ToString());

            Persona datos = new Persona(row["Nombre"].ToString(),
                                        row["Apellido"].ToString(),
                                        row["DNI"].ToString(),
                                        row["Mail"].ToString(),
                                        row["Fecha de nacimiento"].ToString());

            Chofer choferSeleccionado = new Chofer(datos, domicilio,
                                                    row["Telefono"].ToString(),
                                                    row["USERNAME"].ToString(),
                                                    Convert.ToBoolean(row["Habilitado"].ToString()));

            return choferSeleccionado;
        }

        private void deshabilitarChoferes()
        {
            string chofsDeshabilitados = "";

            foreach(DataGridViewRow fila in this.choferesGrid.SelectedRows)
            {
                if ((bool)fila.Cells[11].Value)
                {
                    this.deshabilitarChofer(fila.Cells[7].Value.ToString());
                    chofsDeshabilitados += fila.Cells[0].Value.ToString() + " " + fila.Cells[1].Value.ToString() + "\n";
                }
            }

            if (chofsDeshabilitados.Equals(""))
                MessageBox.Show("Todos los choferes seleccionados se encuentran habilitados");
            else
            { 
                MessageBox.Show("Se deshabilitaron los siguientes choferes: \n" + chofsDeshabilitados);
            }

        }

        private void deshabilitarChofer(string telefono)
        {
            DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Chofer "
                                        +"SET habilitado = 0 "
                                     +"WHERE telefono = " + telefono);
        }

        private void buscarChoferes()
        {
            
            /*
            this.choferes.Clear();
            this.noChoferesLabel.Text = "";
            this.validarTodosLosCamposNoVacios();

            if (!this.errores.Equals(""))
            {
                MessageBox.Show(this.errores);
                this.errores = "";
                return;
            }
            
            string query = this.agregarFiltros("SELECT nombre, apellido, dni, direccion, nro_piso, depto, localidad, telefono, "
                + "mail, fecha_de_nacimiento, username, habilitado "
                + "FROM LOS_CHATADROIDES.Chofer");

            try
            {
                SqlDataReader reader = DBConexion.ResolverQuery(query);
                this.choferes.Load(reader);
                this.choferesGrid.DataSource = choferes;
            }
            catch (SinRegistrosException)
            {
                this.noChoferesLabel.Text = "No se encontraron choferes";
                this.choferes.Clear();
            }*/
        }

        private void buscarChoferesSegun(string select)
        {
            this.choferes.Clear();
            this.noChoferesLabel.Text = "";
            this.validarTodosLosCamposNoVacios();

            if (!this.errores.Equals(""))
            {
                MessageBox.Show(this.errores);
                this.errores = "";
                return;
            }
            /*
            string query = this.agregarFiltros("SELECT nombre, apellido, dni, direccion, nro_piso, depto, localidad, telefono, "
                + "mail, fecha_de_nacimiento, username, habilitado "
                + "FROM LOS_CHATADROIDES.Chofer");*/

            try
            {
                SqlDataReader reader = DBConexion.ResolverQuery(select);
                this.choferes.Load(reader);
                this.choferesGrid.DataSource = choferes;
            }
            catch (SinRegistrosException)
            {
                this.noChoferesLabel.Text = "No se encontraron choferes";
                this.choferes.Clear();
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            //this.buscarChoferes();   
            this.buscarChoferesSegun(this.query);   
        }

        private void validarTodosLosCamposNoVacios()
        {
            if(!this.campoVacio(this.nombreChofer))
                this.validarPalabra(255, this.nombreChofer.Text, "nombre");

            if (!this.campoVacio(this.apellidoChofer))
                this.validarPalabra(255, this.apellidoChofer.Text, "apellido");

            if (!this.campoVacio(this.dniChofer))
                this.validarNumeric(18, this.dniChofer.Text, "dni");
        }

        private void validarNumeric(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[0-9]+$", texto, nombreDeCampo, "sólo debe tener números");
        }

        private void validarPalabra(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[a-zA-Z]+$", texto, nombreDeCampo, "sólo debe tener letras");
        }

        private void validarCampoSegunTipo(int tamanio, string regex, string texto, string nombreDeCampo, string mensajeDeError)
        {
            if (!Regex.IsMatch(texto, regex))
            {
                errores += "-El campo " + nombreDeCampo + " " + mensajeDeError + "\n";
            }
            if (texto.Length > tamanio)
            {
                errores += "-El campo " + nombreDeCampo + " no puede tener más de " + tamanio + " dígitos\n";
            }
        }

        private string agregarFiltrosAQuery()
        {
            string ret = this.query;
            int cantFiltrosPuestos = 0;

            this.agregarCampoAQuery(ref ret, this.nombreChofer, "nombre", ref cantFiltrosPuestos);
            this.agregarCampoAQuery(ref ret, this.apellidoChofer, "apellido", ref cantFiltrosPuestos);
            this.agregarCampoAQuery(ref ret, this.dniChofer, "dni", ref cantFiltrosPuestos);

            return ret;
        }

        private void agregarCampoAQuery(ref string query, Control campo, string nombreDeCampo, ref int cantFiltrosPuestos)
        {
            if (!this.campoVacio(campo))
            {
                string prefijo = "";

                if (cantFiltrosPuestos == 0)
                    query += " where";
                else prefijo = " and";

                query += prefijo + " " + nombreDeCampo + " LIKE '" + campo.Text + "%'";
                cantFiltrosPuestos++;
            }
        }

        private bool campoVacio(Control campo)
        {
            return campo == null || this.estaVacio(campo.Text);
        }

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private void nombreChofer_TextChanged(object sender, EventArgs e)
        {
            this.buscarChoferesSegun(this.agregarFiltrosAQuery());  
        }

        private void apellidoChofer_TextChanged(object sender, EventArgs e)
        {
            this.buscarChoferesSegun(this.agregarFiltrosAQuery());  
        }

        private void dniChofer_TextChanged(object sender, EventArgs e)
        {
            this.buscarChoferesSegun(this.agregarFiltrosAQuery());  
        }

        private void choferesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rehabilitar_Click(object sender, EventArgs e)
        {
            if (this.choferesGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("Sólo puede rehabilitar de a un chofer a la vez");
                return;
            }
            if (this.choferesGrid.RowCount == 0)
            {
                MessageBox.Show("Para llenar la lista de clientes disponibles haga click en el boton 'Buscar todos'");
                return;
            }
            this.habilitarCliente();
        }


        private void habilitarCliente()
        {
            try
            {
                Chofer chofer = this.setChofer();
                if (!chofer.habilitado)
                {
                    DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Chofer "
                                               + "SET habilitado = 1 "
                                               + "WHERE telefono = " + chofer.telefono);

                    this.buscarChoferesSegun(this.agregarFiltrosAQuery());

                    MessageBox.Show("El chofer " + chofer.datos.apellido + ", " + chofer.datos.nombre + "\n" + "Tel: " + chofer.telefono + " \n" + "Ha sido rehabilitado");
                    return;
                }
                MessageBox.Show("El chofer " + chofer.datos.apellido + ", " + chofer.datos.nombre + "\n" + "Tel: " + chofer.telefono + "\n" + "Ya se encuentra habilitado");
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Para elegir a un chofer debe oprimir la flecha que se encuentra a la izquierda de la fila");
                return;
            }

        }

    }
}
