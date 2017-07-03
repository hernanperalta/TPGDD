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
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace UberFrba.Login_Usuario
{
    public partial class Login : Form
    {
        List<String> intentosFallidos = new List<String>();
        string errores = "";

        public Login()
        {
            InitializeComponent();
            this.password.PasswordChar = '*';
            DBConexion.Conectar();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void ingresar_Click(object sender, EventArgs e)
        {
            if (this.hayCamposObligatoriosVacios())
            {
                MessageBox.Show("Debe llenar todos los campos para loguearse");
                return;
            }

            this.validarUsername();

            if (!this.errores.Equals(""))
            {
                MessageBox.Show(errores);
                this.errores = "";
                return;
            }

            try
            {
                SqlDataReader reader;
                reader = DBConexion.ResolverQuery("SELECT username, password, habilitado FROM [LOS_CHATADROIDES].[Usuario] WHERE username = '" + this.username.Text + "'");
                reader.Read();
                String password = reader.GetString(1);
                bool habilitado = reader.GetBoolean(2);
                reader.Close();

                if (!habilitado)
                    throw new UsuarioDeshabilitadoException("El usuario no esta habilitado");

                if (!this.esPasswordValida(password))
                {
                    intentosFallidos.Add(this.username.Text);

                    if (intentosFallidos.Count(user => user == this.username.Text) == 3)
                    {
                        DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Usuario SET habilitado = 0 WHERE username = '" + this.username.Text + "'");
                        MessageBox.Show("Has sobrepasado la cantidad de intentos posibles, el usuario " + this.username.Text + "ha sido deshabilitado");

                    }
                    else
                    {
                        throw new PasswordInvalidaException("Password incorrecta");
                    }

                }
                else
                {

                    Form seleccionDeRol = new Seleccionar_Rol(this.username.Text);
                    seleccionDeRol.Show();
                    this.Close();
                }

            }
            catch (PasswordInvalidaException t)
            {
                MessageBox.Show(t.Message);

            }
            catch (UsuarioDeshabilitadoException ud)
            {
                MessageBox.Show(ud.Message);
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("No se pudo deshabilitar el usuario");
            }
            catch (Exception m)
            {
                MessageBox.Show("No existe un usuario con ese nombre");
            }


        }

        private bool hayCamposObligatoriosVacios()
        {
            foreach (Control control in this.Controls)
                if (control is TextBox)
                    if (this.estaVacio((control as TextBox).Text))
                        return true;

            return false;
        }

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private void validarUsername()
        {
            this.validarCampoSegunTipo(50, "^[a-zA-Z-_.0-9]+$", this.username.Text, "username", "debe tener letras, números, o los caracteres _ - .");
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

        private bool esPasswordValida(String password)
        {
            String s = (String)DBConexion.ResolverFuncion("SELECT LOS_CHATADROIDES.Hashear_Password('" + this.password.Text + "')");
            return s.Equals(password);
        }

        private void noSoyRobot_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

