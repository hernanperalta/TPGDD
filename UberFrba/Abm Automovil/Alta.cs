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

namespace UberFrba.Abm_Automovil
{
    public partial class Alta : Form
    {

        private string username;
        private string rol;
        private string errores = "";

        public Alta(string username, string rol)
        {
            InitializeComponent();
            this.username = username;
            this.rol = rol;
        }


        private void limpiar_Click(object sender, EventArgs e)
        {
            this.marca.ResetText();
            this.horaInicioTurno.ResetText();
            this.modelo.ResetText();
            this.patente.ResetText();
            this.numeroChofer.ResetText();
        }

        private void turno_TextChanged(object sender, EventArgs e){
        
        }

        private void marca_TextChanged(object sender, EventArgs e)
        {
        }

        private void numeroChofer_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void validarNumeroChofer() {
            if (System.Text.RegularExpressions.Regex.IsMatch(numeroChofer.Text, "[^0-9]"))
            {
                errores += "El telefono solo puede tener numeros\n";
            }
            else if (this.numeroChofer.Text.Length > 18) {
                errores += "El telefono excede los 18 digitos\n";
            }
        }

        private void validarModelo()
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(numeroChofer.Text, "[^0-9]"))
            {
                errores += "El telefono solo puede tener numeros\n";
            }
            else if (this.numeroChofer.Text.Length > 18)
            {
                errores += "El telefono excede los 18 digitos\n";
            }
        }

        private void crear_Click(object sender, EventArgs e)
        {
         
           try
                {
                    DBConexion.ResolverNonQuery("INSERT LOS_CHATADROIDES.Automovil SET"
                                               + " marca = '" + this.marca.Text +
                                                "', modelo =  '" + this.modelo.Text +
                                                "', telefono_chofer = '" + this.numeroChofer.Text +
                                                "', WHERE patente = '" + this.patente.Text + "'");



                    MessageBox.Show("Se pudo crear el automovil de patente nro: " + this.patente.Text);
                }
                catch (SqlException sqle) {
                    MessageBox.Show("No se pudo crear el automovil de patente nro: " + this.patente.Text);
                } 
                
            
        }

        private void Alta_o_Modificacion_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();
        }

        private void patente_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        
        }

        private void horaInicioTurno_TextChanged(object sender, EventArgs e)
        {
        
        }

      
    }
}
