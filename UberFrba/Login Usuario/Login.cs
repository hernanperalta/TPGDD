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

namespace UberFrba.Login_Usuario
{
    public partial class Login : Form
    {
        List<String> intentosFallidos = new List<String>();

        public Login()
        {
            InitializeComponent();
            this.password.PasswordChar = '*';
            DBConexion.Conectar();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                SqlDataReader reader ;
                reader = DBConexion.ResolverConsulta("SELECT username, password, habilitado FROM [LOS_CHATADROIDES].[Usuario] WHERE username = '" + this.username.Text + "'");
                reader.Read();
                String password = reader.GetString(1);
                bool habilitado = reader.GetBoolean(2);
                reader.Close();
 
                if (!habilitado)
                    throw new UsuarioDeshabilitadoException("El usuario no esta habilitado");

                if (!this.ValidarPassword(password))
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
                else {

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
            catch (SqlException sqle){
                   MessageBox.Show("No se pudo deshabilitar el usuario");
            }
            catch (Exception m)
            {
                MessageBox.Show("No existe un usuario con ese nombre");
            }
              
             */


            Form seleccionDeRol = new Seleccionar_Rol("admin");
            seleccionDeRol.Show();
            this.Close();

        }
        
        private bool ValidarPassword(String password)
        {
            String s = (String) DBConexion.ResolverFuncion("SELECT LOS_CHATADROIDES.Hashear_Password('" + this.password.Text + "')");
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

