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

namespace UberFrba.Abm_Chofer
{
    public partial class Modificacion : Form
    {
        private string usernameActual;
        private string rolActual;
        private Chofer choferAModificar;

        public Modificacion(Chofer choferAModificar, string usernameActual, string rolActual)
        {
            InitializeComponent();

            this.choferAModificar = choferAModificar;
            this.usernameActual = usernameActual;
            this.rolActual = rolActual;

            this.telefonoChofer.Text = choferAModificar.telefono;
            this.apellidoChofer.Text = choferAModificar.datos.apellido;
            this.nombreChofer.Text = choferAModificar.datos.nombre;
            this.fechaNacChofer.Value = choferAModificar.datos.fechaNac;
            this.dniChofer.Text = choferAModificar.datos.dni;
            this.mailChofer.Text = choferAModificar.datos.mail;
            this.direccionChofer.Text = choferAModificar.domicilio.direccion;
            this.deptoChofer.Text = choferAModificar.domicilio.depto;
            this.nroPisoChofer.Text = choferAModificar.domicilio.nroPiso;
            this.localidadChofer.Text = choferAModificar.domicilio.localidad;
            this.usernameChofer.Text = choferAModificar.username;
            this.habilitado.Checked = choferAModificar.habilitado;
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            /*Form menu = new Menu.Menu(this.usernameActual, this.rolActual);
            menu.Show();
            this.Close();*/
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox)
                    (ctrl as TextBox).Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void crear_Click(object sender, EventArgs e)
        {/*
            if (this.todosLosCamposEstanVacios())
            {
                MessageBox.Show("Si deja todos los campos vacios, el chofer quedara sin actualizar");
                return;
            }

            this.validarYSetearCamposNoVacios();

            if (!this.errores.Equals(""))
            {
                MessageBox.Show(this.errores);
                this.errores = "";
                return;
            }

            try
            {
                DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Chofer "
                                                + "SET direccion = '" + this.choferAModificar.domicilio.direccion + "', "
                                                + "localidad = '" + this.choferAModificar.domicilio.localidad + "', "
                                                + "nro_piso = '" + this.choferAModificar.domicilio.nroPiso + "', '"
                                                + "depto = '" + this.choferAModificar.domicilio.depto + "', "
                                                + "nombre = '" + this.choferAModificar.datos.nombre + "', "
                                                + "apellido = '" + this.choferAModificar.datos.apellido + "', "
                                                + "dni = " + this.choferAModificar.datos.dni + ", "
                                                + "fecha_de_nacimiento = '" + this.choferAModificar.datos.fechaNac + "', "
                                                + "mail = '" + (this.estaVacio(this.choferAModificar.datos.mail) ? "NULL" : "'" + this.mailChofer.Text + "'") + "', "
                                                + "username = '" + this.choferAModificar.username + "'"
                                            + "WHERE telefono = " + this.choferAModificar.telefono);

                MessageBox.Show("El chofer se actualizó con éxito!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    if (ex.Message.Contains(this.entreParentesis(this.telefonoChofer.Text)))
                        MessageBox.Show("Ya existe un chofer con el teléfono " + this.telefonoChofer.Text);
                if (ex.Message.Contains(this.entreParentesis(this.usernameChofer.Text)))
                    MessageBox.Show("Ya existe un chofer con el usuario " + this.usernameChofer.Text);

                if (ex.Number == 547)
                    MessageBox.Show("No existe un usuario de nombre " + this.usernameChofer.Text);
            }*/
        }

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private string entreParentesis(string texto)
        {
            return "(" + texto + ")";
        }
        
    }
}

/*
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
            foreach (Control control in this.Controls)
                if (control is TextBox || control is DateTimePicker)
                    if (control != this.mailChofer)
                        if (this.campoVacio(control))
                            return true;

            return false;
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
                DBConexion.ResolverNonQuery("INSERT INTO LOS_CHATADROIDES.Chofer (localidad, direccion, nro_piso, depto, telefono, nombre, apellido, dni, fecha_de_nacimiento, mail, username) VALUES ('" 
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
                                           + this.usernameChofer.Text + "')"
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
 */