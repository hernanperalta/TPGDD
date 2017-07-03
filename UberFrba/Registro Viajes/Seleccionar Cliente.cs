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
using System.Data.SqlClient;

namespace UberFrba.Registro_Viajes
{
    public partial class Seleccionar_Cliente : Form
    {
        string errores = "";
        private Registro_Viajes parent;
        Cliente cliente = new Cliente();
        DataTable clientes = new DataTable();


        public Seleccionar_Cliente(Registro_Viajes parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.noClientesLabel.Text = "";
        } 

        private void confirmarCliente_Click(object sender, EventArgs e)
        {
            if (this.clientesGrid.RowCount == 0)
            {
                MessageBox.Show("Para llenar la lista de clientes disponibles haga click en el boton 'Buscar todos'");
                return;
            }
            if (this.clientesGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar de a un cliente");
                return;
            }
            try
            {
                this.setCliente();

                parent.setCliente(this.cliente.telefono);
                this.Close();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Para elegir a un cliente debe oprimir la flecha que se encuentra a la izquierda de la fila");
                return;
            }

        }

        private void limpiarCampos_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                }
            }
            this.clientesGrid.DataSource = null;
        }




        private void validarCampos()
        {
            this.validarCampo("DNI", this.dniCliente.Text, 18, "^[0-9]+$");
            this.validarCampo("Nombre", this.nombreCliente.Text, 255, "^[a-zA-Z- ]+$");
            this.validarCampo("Apellido", this.apellidoCliente.Text, 255, "^[a-zA-Z- ]+$");
        }

        private void validarCampo(string campoError, string campo, int cantLetras, string expresion)
        {
            this.validarExpresion(expresion, campo, campoError);
            this.validarCantDigitos(cantLetras, campo, campoError);
        }

        private void validarExpresion(string expresion, string campo, string campoError)
        {
            if (campo == "")
                return;
            else if (!System.Text.RegularExpressions.Regex.IsMatch(campo, expresion))
            {
                errores += "El campo " + campoError + " posee caracteres invalidos\n";
            }
        }

        private void validarCantDigitos(int cantLetras, string campo, string campoError)
        {
            if (campo.Length > cantLetras)
            {
                errores += "El campo " + campoError + " no puede exceder los " + cantLetras + " digitos\n";
            }
        }

        private void setCliente()
        {
            int i = this.clientesGrid.SelectedRows[0].Index;
            DataRow row = clientes.Rows[i];

            cliente.nombre = row["Nombre"].ToString();
            cliente.apellido = row["Apellido"].ToString();
            cliente.dni = row["DNI"].ToString();
            cliente.mail = row["Mail"].ToString();
            cliente.telefono = row["Telefono"].ToString();
            cliente.direccion = row["Direccion"].ToString();
            cliente.codigoPostal = row["Codigo postal"].ToString();
            cliente.fechaNac = row["Fecha de nacimiento"].ToString();
            cliente.departamento = row["Departamento"].ToString();
            cliente.nroPiso = row["Numero de piso"].ToString();
            cliente.localidad = row["Localidad"].ToString();
            cliente.username = row["USERNAME"].ToString();
            cliente.habilitado = Convert.ToBoolean(row["Habilitado"].ToString());
        }

        private void listarClientes(string nombre, string apellido, string dni)
        {
            clientes.Clear();
            try
            {
                clientes.Load(DBConexion.ResolverQuery("SELECT nombre Nombre, apellido Apellido, dni DNI, telefono Telefono, username USERNAME, habilitado Habilitado, mail Mail, direccion Direccion, depto Departamento,  nro_piso AS 'Numero de piso', localidad Localidad, codigo_postal AS 'Codigo postal',fecha_de_nacimiento AS 'Fecha de nacimiento' "
                                            + "FROM LOS_CHATADROIDES.Cliente "
                                            + "WHERE nombre LIKE '%" + nombre + "%' AND "
                                                     + "apellido LIKE '%" + apellido + "%' AND "
                                                     + "DNI LIKE '%" + dni + "%'"));

                this.noClientesLabel.Text = "";
            } catch (SinRegistrosException)
            {

                this.noClientesLabel.Text = "No se encontraron clientes";
                return;
            }
        }


        private void BuscarCliente_Click(object sender, EventArgs e)
        {
            this.buscarTodos("", "", "");
        }

        private void buscarTodos(string nombre, string apellido, string dni)
        {
            this.validarCampos();
            if (this.errores != "")
            {
                MessageBox.Show(errores);
                this.errores = "";
                return;
            }
            this.listarClientes(nombre, apellido, dni);

            this.clientesGrid.DataSource = clientes;
        }

        private void nombreCliente_TextChanged(object sender, EventArgs e)
        {
            this.buscarTodos(this.nombreCliente.Text, this.apellidoCliente.Text, this.dniCliente.Text);
        }

        private void apellidoCliente_TextChanged(object sender, EventArgs e)
        {
            this.buscarTodos(this.nombreCliente.Text, this.apellidoCliente.Text, this.dniCliente.Text);
        }

        private void dniCliente_TextChanged(object sender, EventArgs e)
        {
            this.buscarTodos(this.nombreCliente.Text, this.apellidoCliente.Text, this.dniCliente.Text);
        }

        private void Baja_o_Modificacion_Load(object sender, EventArgs e)
        {
        }
        private void clientesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void noClientesLabel_Click(object sender, EventArgs e)
        {

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

        private void clientesGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void volver_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
