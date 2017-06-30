using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UberFrba.Conexion;
using System.Data.SqlClient;

namespace UberFrba.Alta_de_Usuario
{
    public partial class Alta_de_Usuario : Form
    {

        private String rol;
        private String username;
        private String errores = "";

        public Alta_de_Usuario(String username, String rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.username = username;
            this.cargarRoles();
            this.passwordTB.PasswordChar= '•';
        }
        

        private void Alta_de_Usuario_Load(object sender, EventArgs e)
        {

        }

        private void validarCampoSegunTipo(int tamanio, string regex, string texto, string nombreDeCampo, string mensajeNoMatcheo)
        {
            if (texto.Equals(""))
                errores += "-El campo" + nombreDeCampo + " esta vacio \n";

            if (!Regex.IsMatch(texto, regex))
                errores += "-El campo " + nombreDeCampo + " " + mensajeNoMatcheo + "\n";

            if (texto.Length > tamanio)
                errores += "-El campo " + nombreDeCampo + " no puede tener más de " + tamanio + " dígitos\n";
        }
      
        private void usernameTB_TextChanged(object sender, EventArgs e)
        {
            
        }

      
        private void passwordTB_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();
        }

        private void registrarUsuario_Click(object sender, EventArgs e)
        {
           
            
            this.validarCampoSegunTipo(64, "^[a-zA-Z-_.0-9]+$", this.usernameTB.Text, "Nombre de Usuario", "debe tener letras, numeros, guion bajo, guin medio y punto");
            this.validarCampoSegunTipo(50, "^[a-zA-Z-_.0-9]+$", this.passwordTB.Text, "Password", "debe tener letras, numeros, guion bajo, guin medio y punto");

            if (!errores.Equals(""))
            {
                MessageBox.Show(errores);
                errores = "";
                this.passwordTB.Clear();
                return;
            }

            try
            {
                this.crearUsuario();
                this.crearRoles();
                MessageBox.Show("El usuario se creo con exito"); 
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 2627)
                    MessageBox.Show("Ya existe un usuario con ese nombre");
                else MessageBox.Show("No se pudo crear el usuario. Contactese con el quique");

               
            }
                            

        }

        private void crearUsuario(){
            
            DBConexion.ResolverNonQuery(
                                        "INSERT INTO LOS_CHATADROIDES.Usuario (username, password) VALUES ( '"
                                        + this.usernameTB.Text + "', '"
                                        + this.passwordTB.Text + "')"
                                      );
 
        }

        private void crearRoles(){
    
            foreach (string rol in this.roles.CheckedItems)
            {
                DBConexion.ResolverNonQuery(
                                        "INSERT INTO LOS_CHATADROIDES.Rol_X_Usuario (username, nombre_del_rol) VALUES ( '"
                                        + this.usernameTB.Text + "', '"
                                        + rol + "')"
                                      );
               
            }
        }


        private void roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void cargarRoles()
        {
            SqlDataReader roles = this.leerRoles();

            while (roles.Read())
                this.roles.Items.Add(roles.GetString(0));

            roles.Close();
        }

        private SqlDataReader leerRoles()
        {
            return DBConexion.ResolverQuery("SELECT nombre_del_rol FROM LOS_CHATADROIDES.Rol ");
        }
       

    }
}
