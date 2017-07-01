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
using System.Text.RegularExpressions;
using UberFrba.Menu;

namespace UberFrba.Abm_Chofer
{
    public partial class Modificacion : Form
    {/*
        private string usernameActual;
        private string rolActual;*/
        private Form parent;
        private Chofer choferAModificar;
        private UpdateBuilder updateBuilder;
        private string errores = "";

        //public Modificacion(Chofer choferAModificar, string usernameActual, string rolActual)
        public Modificacion(Form parent, Chofer choferAModificar)
        {
            InitializeComponent();

            this.parent = parent;

            this.choferAModificar = choferAModificar;/*
            this.usernameActual = usernameActual;
            this.rolActual = rolActual;*/

            this.updateBuilder = new UpdateBuilder("LOS_CHATADROIDES.Chofer", "WHERE telefono = " + choferAModificar.telefono);

            this.telefonoChofer.Text = choferAModificar.telefono;
            this.apellidoChofer.Text = choferAModificar.datos.apellido;
            this.nombreChofer.Text = choferAModificar.datos.nombre;
            this.fechaNacChofer.Text = choferAModificar.datos.fechaNac;
            this.dniChofer.Text = choferAModificar.datos.dni;
            this.mailChofer.Text = choferAModificar.datos.mail;
            this.direccionChofer.Text = choferAModificar.domicilio.direccion;
            this.deptoChofer.Text = choferAModificar.domicilio.depto;
            this.nroPisoChofer.Text = choferAModificar.domicilio.nroPiso;
            this.localidadChofer.Text = choferAModificar.domicilio.localidad;
            this.usernameChofer.Text = choferAModificar.username;
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            /*Form menu = new Menu.Menu(this.usernameActual, this.rolActual);
            menu.Show();
            this.Close();*/
            this.Close();
            //this.parent.Show();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox)
                    (ctrl as TextBox).Clear();
        }

     

        private void setearUpdateSiCambioCampo(string nombreDeCampo, string valorSegunUsuario, string valorOriginal, string wrap)
        {
            if (!valorSegunUsuario.Equals(valorOriginal) && !this.estaVacio(valorSegunUsuario))
                this.updateBuilder.agregarFiltro(nombreDeCampo, valorSegunUsuario, wrap);
        }

        private void validarCamposNoVacios()
        {
            this.validarPalabra(255, this.nombreChofer.Text, "nombre");
            this.validarPalabra(255, this.apellidoChofer.Text, "apellido");
            this.validarNumeric(18, this.telefonoChofer.Text, "teléfono");
            this.validarNumeric(18, this.dniChofer.Text, "dni");
            this.validarNroDePiso(3, this.nroPisoChofer.Text, "número de piso");
            this.validarAlfanumerico(255, this.direccionChofer.Text, "dirección y calle");
            this.validarAlfanumerico(3, this.deptoChofer.Text, "departamento");
            this.validarAlfanumerico(20, this.localidadChofer.Text, "localidad");
            this.validarFecha();
            this.validarMail();
        }

        private bool todosLosCamposEstanVacios()
        { 
            bool losTBEstanVacios = true;

            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox)
                    if (!this.estaVacio((ctrl as TextBox).Text))
                        losTBEstanVacios = false;

            return this.fechaNacChofer.Value.ToString() == this.choferAModificar.datos.fechaNac 
                && losTBEstanVacios;
        }

        private void setearUpdates()
        {
            this.setearUpdateSiCambioCampo("telefono", this.telefonoChofer.Text, this.choferAModificar.telefono, "");
            this.setearUpdateSiCambioCampo("apellido", this.apellidoChofer.Text, this.choferAModificar.datos.apellido, "'");
            this.setearUpdateSiCambioCampo("nombre", this.nombreChofer.Text, this.choferAModificar.datos.nombre, "'");
            this.setearUpdateSiCambioCampo("fecha_de_nacimiento", this.fechaNacChofer.Value.ToString(), this.choferAModificar.datos.fechaNac.ToString(), "'");
            this.setearUpdateSiCambioCampo("dni", this.dniChofer.Text, this.choferAModificar.datos.dni, "");
            this.setearUpdateSiCambioCampo("mail", this.mailChofer.Text, this.choferAModificar.datos.mail, "'");
            this.setearUpdateSiCambioCampo("direccion", this.direccionChofer.Text, this.choferAModificar.domicilio.direccion, "'");
            this.setearUpdateSiCambioCampo("depto", this.deptoChofer.Text, this.choferAModificar.domicilio.depto, "'");
            this.setearUpdateSiCambioCampo("nro_piso", this.nroPisoChofer.Text, this.choferAModificar.domicilio.nroPiso, "'");
            this.setearUpdateSiCambioCampo("localidad", this.localidadChofer.Text, this.choferAModificar.domicilio.localidad, "'");
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (this.todosLosCamposEstanVacios())
            {
                MessageBox.Show("Si deja todos los campos vacios, el chofer quedara sin actualizar");
                return;
            }

            this.validarCamposNoVacios();

            if (!this.errores.Equals(""))
            {
                MessageBox.Show(this.errores);
                this.errores = "";
                return;
            }

            this.setearUpdates();

            if(!this.updateBuilder.tieneSetsAgregados())
            {
                MessageBox.Show("No cambio el valor de ninguno de los campos originales. Por ende, el chofer quedara sin actualizar");
                return;
            }

            try
            {
                DBConexion.ResolverNonQuery(this.updateBuilder.obtenerUpdate());

                MessageBox.Show("El chofer se actualizó con éxito!");

                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    if (ex.Message.Contains(this.entreParentesis(this.telefonoChofer.Text)))
                        MessageBox.Show("Ya existe un chofer con el teléfono " + this.telefonoChofer.Text);
            }
        }

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private string entreParentesis(string texto)
        {
            return "(" + texto + ")";
        }

        private void validarNroDePiso(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^(NA|[0-9]+)$", texto, nombreDeCampo, "sólo debe tener números");
        }

        

        private void validarNumeric(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[0-9]+$", texto, nombreDeCampo, "sólo debe tener números");
        }

        private void validarFecha()
        {
            if (this.fechaNacChofer.Value > DateTime.Today)
                errores += "-No puede ingresar una fecha de nacimiento posterior a la actual\n";
        }

        private void validarCampoSegunTipo(int tamanio, string regex, string texto, string nombreDeCampo, string mensajeDeError)
        {
            if (!this.estaVacio(texto))
            {
                if (!Regex.IsMatch(texto, regex))
                    errores += "-El campo " + nombreDeCampo + " " + mensajeDeError + "\n";

                if (texto.Length > tamanio)
                    errores += "-El campo " + nombreDeCampo + " no puede tener más de " + tamanio + " dígitos\n";
            }
        }

        private void validarPalabra(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[a-zA-Zá-úÁ-Ú]+$", texto, nombreDeCampo, "sólo debe tener letras");
        }

        private void validarMail()
        {
            this.validarCampoSegunTipo(50,
                                       "^[a-zA-Zá-úÁ-Ú]+[a-zA-Zá-úÁ-Ú0-9-._]*@[a-zA-Zá-úÁ-Ú]+(.[a-zA-Zá-úÁ-Ú]+)+$",
                                       this.mailChofer.Text,
                                       "mail",
                                       "debe comenzar con letras, puede tener números, debe terminar con " +
                                       "@'nombre del dominio'.'nombre de la organizacion', y puede tener los caracteres . - _");
        }

        private void validarAlfanumerico(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[a-zA-Zá-úÁ-Ú0-9 ]+$", texto, nombreDeCampo, "debe tener letras o números");
        }

        private string deBoolABit(bool boolean)
        {
            return boolean? "1" : "0";
        }

        private void habilitado_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void usernameChofer_TextChanged(object sender, EventArgs e)
        {

        }

        private void volver_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

    }
}
