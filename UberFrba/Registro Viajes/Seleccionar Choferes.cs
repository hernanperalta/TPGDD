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

namespace UberFrba.Registro_Viajes
{
    public partial class Seleccionar_Choferes : Form
    {
        private Registro_Viajes parent;
        private string errores = "";
        private DataTable choferes = new DataTable();
        private string query;

        public Seleccionar_Choferes(Registro_Viajes parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.noChoferesLabel.Text = "";
            this.query = "SELECT nombre Nombre, apellido Apellido, dni DNI, telefono Telefono, username USERNAME, patente Patente, "
                       + "mail Mail, direccion Direccion, depto Departamento, nro_piso AS 'Numero de piso', localidad Localidad, fecha_de_nacimiento AS 'Fecha de nacimiento' "
                       + "FROM LOS_CHATADROIDES.Chofer C JOIN LOS_CHATADROIDES.Automovil A "
                       + "ON(C.telefono = A.telefono_chofer)"
                       + "WHERE C.habilitado = 1 AND A.habilitado = 1";
        }

        private void Baja_y_Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void confirmarChofer_Click(object sender, EventArgs e)
        {
            if (this.choferesGrid.RowCount == 0)
            {
                MessageBox.Show("Para llenar la lista de choferes disponibles haga click en el boton 'Buscar'");
                return;
            }

            if (this.choferesGrid.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Primero debe seleccionar un chofer, tocando la flecha a la izquierda de la fila");
                return;
            }

            if (this.choferesGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar de a un chofer");
                return;
            }

            Chofer choferSeleccionado = this.setChofer();

            //Form modificar = new Modificacion(choferSeleccionado, this.usernameActual, this.rol);
            this.Close();
            this.parent.setChofer(choferSeleccionado.telefono, choferSeleccionado.patente);
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
                                                    true,
                                                    row["Patente"].ToString());

            return choferSeleccionado;
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
            this.buscarChoferesSegun(this.query);
        }
        
        private void validarTodosLosCamposNoVacios()
        {
            if (!this.campoVacio(this.nombreChofer))
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
            int cantFiltrosPuestos = 1;

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

                query += prefijo + " " + nombreDeCampo + " LIKE '%" + campo.Text + "%'";
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

        private void apellidoChofer_TextChanged_1(object sender, EventArgs e)
        {
            this.buscarChoferesSegun(this.agregarFiltrosAQuery());
        }


        private void dniChofer_TextChanged_1(object sender, EventArgs e)
        {
            this.buscarChoferesSegun(this.agregarFiltrosAQuery());
        }

        private void choferesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Seleccionar_Choferes_Load(object sender, EventArgs e)
        {
        
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox)
                    (ctrl as TextBox).Clear();
        }

        private void volver_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
