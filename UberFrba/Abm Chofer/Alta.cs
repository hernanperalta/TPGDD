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
using System.Text.RegularExpressions;

namespace UberFrba.Abm_Chofer // TODO decidir si el username de chofer es opcional o no
{
    public partial class Alta : Form
    {
        private string usernameActual;
        private string rol;
        private string errores = "";

        public Alta(string usernameActual, string rol)
        {
            InitializeComponent();
            this.usernameActual = usernameActual;
            this.rol = rol;
        }

        private void Alta_o_Modificacion_Load(object sender, EventArgs e)
        {

        }
        
        private void validarCampoSegunTipo(int tamanio, string regex, string texto, string nombreDeCampo, string mensajeDeError)
        {
           if (!Regex.IsMatch(texto, regex))
            {
                errores += "-El campo " + nombreDeCampo + " " + mensajeDeError + "\n";
            }
            if ( texto.Length > tamanio ) {
                errores += "-El campo " + nombreDeCampo + " no puede tener más de " + tamanio + " dígitos\n";
            }
        }
        /*
        private bool estructuraSegun(string regex, string texto)
        {
            return Regex.IsMatch(texto, regex);
        }*/

        private void validarNumeric(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[0-9]+$", texto, nombreDeCampo, "sólo debe tener números");
        }

        private void validarPalabra(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[a-zA-Z]+$", texto, nombreDeCampo, "sólo debe tener letras");
        }

        private void validarMail()
        {
            this.validarCampoSegunTipo(50,
                                       "^[a-zA-Z]+[a-zA-Z0-9-._]*@[a-zA-Z]+(.[a-zA-Z]+)+$",
                                       this.mailChofer.Text, 
                                       "mail", 
                                       "debe comenzar con letras, puede tener números, debe terminar con " +
                                       "@'nombre del dominio'.'nombre de la organizacion', y puede tener los caracteres . - _");
        }

        private void validarUsername()
        {
            this.validarCampoSegunTipo(50, "^[a-zA-Z-_.0-9]+$", this.usernameChofer.Text, "username", "debe tener letras, números, o los caracteres _ - .");
        }

        private void validarAlfanumerico(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[a-zA-Z0-9 ]+$", texto, nombreDeCampo, "debe tener letras o números");
        }

        private void validarTodosLosCamposNoVacios() 
        {
            this.validarPalabra(255, this.nombreChofer.Text, "nombre");
            this.validarPalabra(255, this.apellidoChofer.Text, "apellido");
            this.validarNumeric(18, this.telefonoChofer.Text, "teléfono");
            this.validarNumeric(18, this.dniChofer.Text, "dni");
            this.validarNumeric(5, this.nroPisoChofer.Text, "número de piso");
            this.validarAlfanumerico(255, this.direccionChofer.Text, "dirección y calle");
            this.validarAlfanumerico(3, this.deptoChofer.Text, "departamento");
            this.validarAlfanumerico(20, this.localidadChofer.Text, "localidad");
            this.validarUsername();
            this.validarFecha();

            if( !this.campoVacio(this.mailChofer) )
                this.validarMail();

            /* Si el username es opcional:
             * if (!this.campoVacio(this.usernameChofer))
                this.validarUsername();*/

        }

        private void validarFecha()
        {
            if (this.fechaNacChofer.Value > DateTime.Today)
                errores += "-No puede ingresar una fecha de nacimiento posterior a la actual\n";
        }

        private bool campoVacio(Control campo)
        {
            return campo == null || this.estaVacio(campo.Text);
        }

        private bool hayCamposObligatoriosVacios() 
        {
            return this.campoVacio(this.telefonoChofer) || this.campoVacio(this.apellidoChofer)
                || this.campoVacio(this.nombreChofer) || this.campoVacio(this.fechaNacChofer)
                || this.campoVacio(this.dniChofer) || this.campoVacio(this.direccionChofer)
                || this.campoVacio(this.deptoChofer) || this.campoVacio(this.nroPisoChofer)
                || this.campoVacio(this.usernameChofer) || this.campoVacio(this.localidadChofer);
        }

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private void crear_chofer_Click(object sender, EventArgs e)
        {
            if ( this.hayCamposObligatoriosVacios() )
            {
                MessageBox.Show("Debe llenar todos los campos no opcionales antes de crear un chofer");
                return;
            }

            this.validarTodosLosCamposNoVacios();

            if (!this.errores.Equals(""))
            {
                MessageBox.Show(this.errores);
                this.errores = "";
                return;
            }
            
            try
            {
                DBConexion.ResolverNonQuery("EXEC LOS_CHATADROIDES.Dar_de_alta_chofer '" 
                                           + this.localidadChofer.Text + "', '"
                                           + this.direccionChofer.Text + "', "
                                           + this.nroPisoChofer.Text + ", '"
                                           + this.deptoChofer.Text + "', "
                                           + this.telefonoChofer.Text + ", '"
                                           + this.nombreChofer.Text + "', '"
                                           + this.apellidoChofer.Text + "', "
                                           + this.dniChofer.Text + ", '"
                                           + this.fechaNacChofer.Value + "', "
                                           + (this.estaVacio(this.mailChofer.Text) ? "NULL" : "'" + this.mailChofer.Text + "'") + ", '"
                                           + this.usernameChofer.Text + "'"
                                           );
                
                MessageBox.Show("El chofer se creó con éxito!");
            }
            catch (SqlException ex) 
            {
                if (ex.Number == 2627)
                    if( ex.Message.Contains(this.entreParentesis(this.telefonoChofer.Text)) )                 
                        MessageBox.Show("Ya existe un chofer con el teléfono " + this.telefonoChofer.Text);
                    if (ex.Message.Contains(this.entreParentesis(this.usernameChofer.Text)) )
                        MessageBox.Show("Ya existe un chofer con el usuario " + this.usernameChofer.Text);

                if( ex.Number == 547 )
                    MessageBox.Show("No existe un usuario de nombre " + this.usernameChofer.Text);
            }
            
        }

        private string entreParentesis(string texto)
        {
            return "(" + texto + ")";
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.usernameActual, this.rol);
            menu.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void telefonoChofer_TextChanged(object sender, EventArgs e)
        {
            
          
        }

        private void nombreChofer_TextChanged(object sender, EventArgs e)
        {
                        
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
        }

    }
}
