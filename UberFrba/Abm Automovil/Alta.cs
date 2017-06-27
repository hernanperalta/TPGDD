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
            this.cargarLosHorariosDeLosTurnos();
        }

        private void limpiarLosCampos() {
            this.marca.ResetText();
            this.patente.ResetText();
            this.numeroChofer.ResetText();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            this.limpiarLosCampos();
        }

        private void turno_TextChanged(object sender, EventArgs e){
        
        }

        private void marca_TextChanged(object sender, EventArgs e)
        {
        }

        private void numeroChofer_TextChanged(object sender, EventArgs e)
        {
            
        }
        /* VALIDACIONES : */
        private bool estaVacio(string campo) {
            return campo == null || campo.Equals("") || campo.Any(char.IsWhiteSpace);
        }

        private void validarNumeroChofer() {
            if (this.estaVacio(this.numeroChofer.Text)) 
                errores += "El telefono esta vacio.\n";

            if (this.numeroChofer.Text.Any(char.IsLetter))
                errores += "El telefono solo puede tener numeros.\n";

            if (this.numeroChofer.Text.Length > 18) 
                errores += "El telefono excede los 18 digitos.\n";
            
        }

        private void validarModelo()
        {
            if (this.estaVacio(this.modelo.Text))
                errores += "Debe insertar un modelo para el automovil.\n";
            if (this.modelo.Text.Any(char.IsDigit))
                errores += "El modelo del automovil no puede contener numeros.\n";
            
            if (this.modelo.Text.Length > 255) 
                errores += "El modelo excede el numero de caracteres permitidos (255).\n";
        }

        private void validarMarca() {
            if (this.estaVacio(this.marca.Text))
                errores += "Debe insertar una marca para el automovil.\n";
            if (this.marca.Text.Any(char.IsDigit))
                errores += "La marca no puede contener numeros.\n";

            if (this.marca.Text.Length > 255) 
                errores += "La marca excede el numero de caracteres permitidos (255)";
            
        }

        private void validarPatente() {
            if (this.estaVacio(this.patente.Text))
                errores += "La patente esta vacia.\n";
                
            if (this.patente.Text.Length > 10)
                errores += "La patente excede los 10 caracteres.\n";
        }

        private void validarLosCampos() {
            this.validarMarca();
            this.validarModelo();
            this.validarPatente();
            this.validarNumeroChofer();
        }

        /**  - VALIDACIONES **/

        private void cargarLosHorariosDeLosTurnos(){
            
            try
            {
                SqlDataReader readerTurnos = DBConexion.ResolverConsulta("SELECT hora_inicio_turno, hora_fin_turno, descripcion FROM LOS_CHATADROIDES.Turno");

                while (readerTurnos.Read())
                {
                    Turno nuevoTurno = new Turno(readerTurnos.GetDecimal(0).ToString(), readerTurnos.GetDecimal(1).ToString(), readerTurnos.GetString(2));
                    this.selectorTurno.Items.Add(nuevoTurno);
                }
                selectorTurno.Items.Add("No asignar turno");
                readerTurnos.Close();

            }
            catch (Exception e) {
                this.selectorTurno.Text = "No hay turnos en la base de datos";
            }

        }

        private void crear_Click(object sender, EventArgs e)
        {
            this.validarLosCampos();
            if (!this.errores.Equals(""))
            {
                MessageBox.Show(errores);
                this.limpiarLosCampos();
                this.errores = "";
            }
            else
            {
               /* try
                {
                    DBConexion.ResolverNonQuery("INSERT LOS_CHATADROIDES.Automovil SET"
                                               + " marca = '" + this.marca.Text +
                                                "', modelo =  '" + this.modelo.Text +
                                                "', telefono_chofer = '" + this.numeroChofer.Text +
                                                "', WHERE patente = '" + this.patente.Text + "'");



                    MessageBox.Show("Se pudo crear el automovil de patente nro: " + this.patente.Text);
                }
                catch (SqlException sqle)
                {
                    MessageBox.Show("No se pudo crear el automovil de patente nro: " + this.patente.Text);
                }*/
                MessageBox.Show("TODO OK :D ");
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

        private void selectorTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

      
    }
}
