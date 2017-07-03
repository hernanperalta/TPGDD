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
using System.Configuration;

namespace UberFrba.Abm_Cliente
{
    public partial class Modificacion : Form
    {
        string errores = "";
        private Form parent;
        Cliente cliente;
        private DateTime fechaActual = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["Fecha"]);
        public Modificacion(Form parent, Cliente cliente)
        {
            InitializeComponent();
            this.parent = parent;
            this.cliente = cliente;
            this.setCampos();
        }

        private void guardarCliente_Click(object sender, EventArgs e)
        {
            this.validarCampos();
            if (this.errores != "")
            {
                MessageBox.Show(errores);
                this.errores = "";
            }
            else
            {
                try
                {
                    this.actualizarCliente();
                    MessageBox.Show("Se ha actualizado el cliente correctamente");
                    this.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ha habido un error en la actualización");
                }
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
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private string entreParentesis(string texto)
        {
            return "(" + texto + ")";
        }

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private void validarCampos()
        {
            this.validarCampo("telefono", this.telefonoCliente.Text, 18, "^[0-9]+$");
            this.validarCampo("DNI", this.dniCliente.Text, 18, "^[0-9]+$");
            this.validarCampo("Localidad", this.localidadCliente.Text, 20, "^[a-zA-Z0-9- ]+$");
            this.validarCampo("Departamento", this.deptoCliente.Text, 3, "^(NA|[a-zA-Z0-9]+)$");
            this.validarCampo("Direccion y calle", this.direccionCliente.Text, 255, "^[a-zA-Z0-9- ]+$");
            this.validarCampo("Nombre", this.nombreCliente.Text, 255, "^[a-zA-Z-á-úÁ-Ú ]+$");
            this.validarCampo("Apellido", this.apellidoCliente.Text, 255, "^[a-zA-Z-á-úÁ-Ú ]+$");
            this.validarCampo("Codigo Postal", this.codPostal.Text, 5, "^(NA|[0-9]+)$");
            this.validarCampo("Nro de Piso", this.nroPiso.Text, 5, "^(NA|[0-9]+)$");
            if (!this.estaVacio(this.mailCliente.Text))
                this.validarCampo("Mail", this.mailCliente.Text, 255, "^[a-zA-Z]+[a-zA-Z0-9-._]*@[a-zA-Z]+(.[a-zA-Z]+)+$");
            this.validarFecha();
            this.validarCampo("Nombre de usuario", this.usernameCliente.Text, 50, "^[a-zA-Z-_.0-9]+$");
        }

        private void validarFecha()
        {

            if (this.fechaNacCli.Value > fechaActual)
                errores += "-No puede ingresar una fecha de nacimiento posterior a la actual\n";
        }


        private void validarCampo(string campoError, string campo, int cantLetras, string expresion)
        {
            this.validarExpresion(expresion, campo, campoError);
            this.validarCantDigitos(cantLetras, campo, campoError);
        }

        private void validarExpresion(string expresion, string campo, string campoError)
        {
            if (campo == "")
                errores += "El campo " + campoError + " esta vacio\n";

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

        private void setCampos() 
        {
            this.nombreCliente.Text = this.cliente.nombre;
            this.apellidoCliente.Text = this.cliente.apellido;
            this.dniCliente.Text = this.cliente.dni;
            this.mailCliente.Text = this.cliente.mail;
            this.direccionCliente.Text = this.cliente.direccion;
            this.nroPiso.Text = this.cliente.nroPiso;
            this.deptoCliente.Text = this.cliente.departamento;
            this.codPostal.Text = this.cliente.codigoPostal;
            this.localidadCliente.Text = this.cliente.localidad;
            this.usernameCliente.Text = this.cliente.username;
            this.telefonoCliente.Text = this.cliente.telefono;
            string mes = this.cliente.fechaNac.Substring(0, 2);
            string dia = this.cliente.fechaNac.Substring(3, 2);
            string anio = this.cliente.fechaNac.Substring(6, 4);
            this.fechaNacCli.Value = new DateTime( Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia) );
        }

        private void actualizarCliente()
        {
            DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Cliente "
                                            + "SET nombre = '" + this.nombreCliente.Text + "', "
                                            + "apellido = '" + this.apellidoCliente.Text + "', "
                                            + "telefono = " + this.telefonoCliente.Text + ", "
                                            + "dni = " + this.dniCliente.Text + ", "
                                            + "mail ='" + this.mailCliente.Text + "', "
                                            + "localidad = '" + this.localidadCliente.Text + "', "
                                            + "direccion = '" + this.direccionCliente.Text + "', "
                                            + "depto = '" + this.deptoCliente.Text + "', "
                                            + "nro_piso = '" + this.nroPiso.Text + "', "
                                            + "codigo_postal = '" + this.codPostal.Text + "', "
                                            + "fecha_de_nacimiento = '" + this.fechaNacCli.Value + "' " 
                                            +"WHERE telefono = " + this.cliente.telefono);
        }

        private void fechaNacCli_TextChanged(object sender, EventArgs e)
        {
        }
        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void apellidoCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void dniCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
        }

        private void direccionCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void deptoCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void nombreCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void usernameCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void fechaNacCli_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nroPiso_TextChanged(object sender, EventArgs e)
        {

        }

        private void telefonoCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
