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
using UberFrba.Menu;
using System.Configuration;

                
namespace UberFrba.Abm_Chofer
{
    public partial class Baja_o_Modificacion : Form
    {
        private Form parent;
        private Registro_Viajes.Registro_Viajes parentSeleccionRegistro;
        private Rendicion_al_chofer.Rendicion_al_chofer parentSeleccionRendicion;
        private bool puedeDarDeBaja;
        private bool soloSeleccion = false;
        private bool soloSeleccionRendicion = false;
        private string errores = "";
        private DataTable choferes = new DataTable();
        private string query = "SELECT nombre Nombre, apellido Apellido, dni DNI, telefono Telefono, username USERNAME, habilitado Habilitado, mail Mail, direccion Direccion, depto Departamento,  nro_piso AS 'Numero de piso', localidad Localidad,fecha_de_nacimiento AS 'Fecha de nacimiento'  "
                               + "FROM LOS_CHATADROIDES.Chofer ";

        public Baja_o_Modificacion(Rendicion_al_chofer.Rendicion_al_chofer parent)
        {
            InitializeComponent();
            this.parentSeleccionRendicion = parent;
            this.soloSeleccionRendicion = true;
            this.parent = parent;
            this.setPanelSeleccion();
        }

        public Baja_o_Modificacion(Registro_Viajes.Registro_Viajes parent)
        {
            InitializeComponent();
            this.parentSeleccionRegistro = parent;
            this.parent = parent;
            this.setPanelSeleccion();
        }

        public Baja_o_Modificacion(Form parent, bool puedeDarDeBaja)
        {
            InitializeComponent();
            this.parent = parent;
            this.puedeDarDeBaja = puedeDarDeBaja;
            this.noChoferesLabel.Text = "";
            this.setPanel();
        }

        private void setPanelSeleccion()
        {
            this.puedeDarDeBaja = true;
            this.soloSeleccion = true;
            this.noChoferesLabel.Text = "";
            if (soloSeleccion)
            {
                this.query = "SELECT nombre Nombre, apellido Apellido, dni DNI, telefono Telefono, username USERNAME, C.habilitado Habilitado, patente as 'Patente', mail Mail, direccion Direccion, depto Departamento,  nro_piso AS 'Numero de piso', localidad Localidad,fecha_de_nacimiento AS 'Fecha de nacimiento'  "
                               + "FROM LOS_CHATADROIDES.Chofer C JOIN LOS_CHATADROIDES.Automovil A "
                               + "ON(C.telefono = A.telefono_chofer) WHERE C.habilitado = 1 AND A.habilitado = 1";

            }
            this.setPanel();
        }

        private void setPanel()
        {
            if (soloSeleccion)
            {
                this.Text = "Seleccionar chofer";
                this.bajaOModificacion.Text = "Confirmar chofer";
                this.rehabilitar.Visible = false;
            }
            else
            {
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
        }

        private void Baja_y_Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void bajaOModificacion_Click(object sender, EventArgs e)
        {
            if (this.choferesGrid.RowCount == 0)
            {
                MessageBox.Show("Para llenar la lista de choferes disponibles haga click en el boton 'Buscar'");
                return;
            }

            if (this.choferesGrid.SelectedRows.Count > 1 && (!puedeDarDeBaja || soloSeleccion))
            {
                MessageBox.Show("Sólo puede seleccionar de a un chofer a la vez");
                return;
            }

            if (this.choferesGrid.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Primero debe seleccionar un chofer, tocando la flecha a la izquierda de la fila");
                return;
            }

            Chofer choferSeleccionado = this.setChofer();

            if (soloSeleccion)
            {
                if (soloSeleccionRendicion)
                {
                    parentSeleccionRendicion.setChofer(choferSeleccionado.telefono);
                }
                else
                {
                    parentSeleccionRegistro.setChofer(choferSeleccionado.telefono, choferSeleccionado.patente);
                }
                this.Close();
                return;
            }
            if (this.puedeDarDeBaja)
            {
                this.deshabilitarChoferes();
                this.buscarChoferesSegun(this.query);
                return;
            }

            Form modificar = new Modificacion(this, choferSeleccionado);
            modificar.Show();

            this.buscarChoferesSegun(this.query);
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

            Chofer choferSeleccionado;
            
            if (soloSeleccion)
            {
                 choferSeleccionado = new Chofer(datos, domicilio,
                                                        row["Telefono"].ToString(),
                                                        row["USERNAME"].ToString(),
                                                        row["Patente"].ToString(),
                                                        Convert.ToBoolean(row["Habilitado"].ToString()));
            }
            else 
            {
                 choferSeleccionado = new Chofer(datos, domicilio,
                            row["Telefono"].ToString(),
                            row["USERNAME"].ToString(),
                            Convert.ToBoolean(row["Habilitado"].ToString()));
            }

            return choferSeleccionado;
        }

        private void deshabilitarChoferes()
        {
            string chofsDeshabilitados = "";

            foreach(DataGridViewRow fila in this.choferesGrid.SelectedRows)
            {
                if ((bool)fila.Cells[5].Value)
                {
                    this.deshabilitarChofer(fila.Cells[3].Value.ToString());
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
            if (soloSeleccion) cantFiltrosPuestos = 1;

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

        private void noChoferesLabel_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void limpiarCampos()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                    (ctrl as TextBox).Clear();
            }
            this.choferesGrid.DataSource = null;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
