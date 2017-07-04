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

namespace UberFrba.Abm_Cliente
{
    public partial class Baja_o_Modificacion : Form
    {
        string errores = "";
        private Form parent;
        private Registro_Viajes.Registro_Viajes parentSeleccion;
        private bool puedeDarDeBaja;
        private bool soloSeleccion;
        Cliente cliente = new Cliente();
        DataTable clientes = new DataTable();

        public Baja_o_Modificacion(Registro_Viajes.Registro_Viajes parent)
        {
            InitializeComponent();
            this.parentSeleccion = parent;
            this.soloSeleccion = true;
            this.puedeDarDeBaja = true;
            this.setNombrePanel();
            this.noClientesLabel.Text = "";
        }

        public Baja_o_Modificacion(Form parent, bool puedeDarDeBaja)
        {
            InitializeComponent();
            this.parent = parent;
            this.puedeDarDeBaja = puedeDarDeBaja;
            this.setNombrePanel();
            this.noClientesLabel.Text = "";
        } 

        private void bajaOModificacion_Click(object sender, EventArgs e)
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
            this.validarCampos();
            if (this.errores != "")
            {
                MessageBox.Show(errores);
                this.errores = "";
                return;
            }
            try
            {
                this.setCliente();
                if (this.soloSeleccion)
                {
                    parentSeleccion.setCliente(cliente.telefono);
                    this.Close();
                    return;
                }
                if (this.puedeDarDeBaja)
                {
                    this.deshabilitarCliente();
                    return;
                }
                
                Form modificar = new Modificacion(this, cliente);
                modificar.Show();
            }
            catch (ArgumentOutOfRangeException) 
            {
                MessageBox.Show("Para elegir a un cliente debe oprimir la flecha que se encuentra a la izquierda de la fila");
                return;
            }

        }

        public void setSoloSeleccion() 
        {
            this.bajaOModificacion.Hide();
            
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

        private void buscarCliente_Click(object sender, EventArgs e)
        {
            this.buscarTodos("","","");
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            if (soloSeleccion)
            {
                parentSeleccion.Show();
                return;
            }
            this.parent.Show();
        }

        private void rehabilitar_Click(object sender, EventArgs e)
        {
            if (this.clientesGrid.RowCount == 0)
            {
                MessageBox.Show("Para llenar la lista de clientes disponibles haga click en el boton 'Buscar todos'");
                return;
            }
            this.habilitarCliente();
        }






        private void deshabilitarCliente()
        {
            if (cliente.habilitado)
            {
                DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Cliente "
                                           + "SET habilitado = 0 "
                                           + "WHERE telefono = '" + cliente.telefono + "'");
                this.listarClientes(this.nombreCliente.Text, this.apellidoCliente.Text, this.dniCliente.Text);
                MessageBox.Show("El cliente " + cliente.apellido + ", " + cliente.nombre + "\n" + "Tel: " + cliente.telefono + " \n" + "Ha sido dado de baja");
                return;
            }
            MessageBox.Show("El cliente " + cliente.apellido + ", " + cliente.nombre + "\n" + "Tel: " + cliente.telefono + "\n" + "Ya se encuentra deshabilitado");
            return;
        }

        private void habilitarCliente()
        {
            try
            {
                this.setCliente();
                if (!cliente.habilitado)
                {
                    DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Cliente "
                                               + "SET habilitado = 1 "
                                               + "WHERE telefono = '" + cliente.telefono + "'");
                    this.listarClientes(this.nombreCliente.Text, this.apellidoCliente.Text, this.dniCliente.Text);
                    MessageBox.Show("El cliente " + cliente.apellido + ", " + cliente.nombre + "\n" + "Tel: " + cliente.telefono + " \n" + "Ha sido rehabilitado");
                    return;
                }
                MessageBox.Show("El cliente " + cliente.apellido + ", " + cliente.nombre + "\n" + "Tel: " + cliente.telefono + "\n" + "Ya se encuentra habilitado");
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Para elegir a un cliente debe oprimir la flecha que se encuentra a la izquierda de la fila");
                return;
            }

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
                string filtrarHabilitado = "";
                if(soloSeleccion) filtrarHabilitado = "  AND habilitado = 1";
                clientes.Load(DBConexion.ResolverQuery("SELECT nombre Nombre, apellido Apellido, dni DNI, telefono Telefono, username USERNAME, habilitado Habilitado, mail Mail, direccion Direccion, depto Departamento,  nro_piso AS 'Numero de piso', localidad Localidad, codigo_postal AS 'Codigo postal',fecha_de_nacimiento AS 'Fecha de nacimiento' "
                                            + "FROM LOS_CHATADROIDES.Cliente "
                                            + "WHERE nombre LIKE '%" + nombre + "%' AND "
                                                     + "apellido LIKE '%" + apellido + "%' AND "
                                                     + "DNI LIKE '%" + dni + "%'" + filtrarHabilitado));

                this.noClientesLabel.Text = "";
            } catch (SinRegistrosException)
            {

                this.noClientesLabel.Text = "No se encontraron clientes";
                return;
            }
        }

        private void setNombrePanel()
        {
            if (this.soloSeleccion)
            {
                this.Text = "Seleccion de cliente";
                this.bajaOModificacion.Text = "Confirmar cliente";
                this.rhabilitar.Visible = false;
            }
            else
            {
                if (puedeDarDeBaja)
                {
                    this.Text = "Baja Cliente";
                    this.bajaOModificacion.Text = "Dar de baja";
                    this.rhabilitar.Visible = false;
                }
                else
                {
                    this.Text = "Modificar Cliente";
                    this.bajaOModificacion.Text = "Modificar";
                }
            }
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

        private void Baja_o_Modificacion_Load(object sender, EventArgs e)
        {
        }
        private void clientesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
    }
}
