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

namespace UberFrba.Abm_Automovil
{
    public partial class Alta : Form
    {
        private Form parent;
        
        private string errores = "";

        public Alta(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.cargarLosHorariosDeLosTurnos();
        }

        /* VALIDACIONES : */

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

        private void validarNumeric(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[0-9]+$", texto, nombreDeCampo, "sólo debe tener números");
        }

        private void validarPalabra(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[a-zA-Zá-úÁ-Ú]+$", texto, nombreDeCampo, "sólo debe tener letras");
        }

        private void validarAlfanumerico(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[a-zA-Zá-úÁ-Ú0-9 ]+$", texto, nombreDeCampo, "debe tener letras o números");
        }

       

       

        private void validarNumeroChofer()
        {
            this.validarNumeric(18, this.numeroChofer.Text, "numero chofer");

        }

        private void validarModelo()
        {

            this.validarAlfanumerico(255, this.modelo.Text, "modelo");
        }

        private void validarMarca()
        {
            this.validarPalabra(255, this.marca.Text, "marca");
        }


        private void validarPatente() 
        {

            this.validarAlfanumerico(18, this.patente.Text, "patente");
      
        }

        private void validarQueLosCamposNoEstenVacios()
        {
            this.estaVacio(this.numeroChofer.Text, "numero chofer");
            this.estaVacio(this.modelo.Text, "modelo");
            this.estaVacio(this.marca.Text, "marca");
            this.estaVacio(this.patente.Text, "patente");
        }

        private void estaVacio(string campo, string nombreCampo)
        {
            if (campo == null || campo.Equals(""))
                this.errores += "El campo " + nombreCampo + " no puede ser vacio. \n";
        }

        private void superaElRango(TextBox campo, string nombreCampo, int rango)
        {
            if (campo.Text.Length > rango)
            {
                MessageBox.Show("El campo " + nombreCampo + " excede los " + rango.ToString() + " digitos.\n");

            }
        }

        private void validarTodosLosCampos()
        {
            this.validarPatente();
            this.validarMarca();
            this.validarModelo();
            this.validarNumeroChofer();

        }

        private bool seleccionoTurno() {

            return this.listaDeTurnos.CheckedItems.Count != 0; 
            
        }
                
        /**  - VALIDACIONES **/

        // Cargar los horarios de los turnos disponibles en la base de datos: 
        private void cargarLosHorariosDeLosTurnos(){
            
            try
            {
                SqlDataReader readerTurnos = DBConexion.ResolverQuery("SELECT hora_inicio_turno, hora_fin_turno, descripcion FROM LOS_CHATADROIDES.Turno");

                while (readerTurnos.Read())
                {
                    Turno nuevoTurno = new Turno(readerTurnos.GetDecimal(0).ToString(), readerTurnos.GetDecimal(1).ToString(), readerTurnos.GetString(2));
                    this.listaDeTurnos.Items.Add(nuevoTurno);
                }
                readerTurnos.Close();
            }
            catch (Exception e) {
                this.listaDeTurnos.Text = "No hay turnos en la base de datos";
            }

        }

        // Se da de alta al nuevo automovil y se insertan sus turnos si no hay errores 
        private void crear_Click(object sender, EventArgs e)
        {
          
            string insertarAutomovil = "INSERT INTO LOS_CHATADROIDES.Automovil (patente, telefono_chofer, marca, modelo) "
			                         + "VALUES ( '"
                                     + this.patente.Text + "', " 
                                     + this.numeroChofer.Text + ", '" 
              						 + this.marca.Text + "', '" 
                                     + this.modelo.Text + "')" ;


            this.validarTodosLosCampos();
            this.validarQueLosCamposNoEstenVacios();
            if (!this.errores.Equals("")) {
                MessageBox.Show(this.errores);
                this.errores = "";
                return;
            }
            try
            {

                DBConexion.ResolverNonQuery(insertarAutomovil);

				this.insertarTurnos();
              
                MessageBox.Show("Se pudo crear el automovil de patente : " + this.patente.Text);

            }
            catch (SqlException sqle)
            {
                MessageBox.Show(sqle.Message);
               
            }
                 
            
        }

        // Se insertan los turnos para el automovil
        private void insertarTurnos()
        {
          string insertarAutoXTurno = "INSERT INTO LOS_CHATADROIDES.Auto_X_Turno (hora_inicio_turno, hora_fin_turno, patente) VALUES ";
  
          foreach(Turno turno in this.listaDeTurnos.CheckedItems)
          {
  		    DBConexion.ResolverNonQuery(insertarAutoXTurno + "(" + turno.horaInicio + ", " + turno.horaFin + ", '" + this.patente.Text + "')" );	
          }
  
        }

        private void limpiarLosCampos()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
                if (ctrl is CheckedListBox)
                {
                    for (int i = 0; i < ((CheckedListBox)ctrl).Items.Count; i++)
                    {
                        ((CheckedListBox)ctrl).SetItemChecked(i, false);
                    }
                }
            }

        }

        
        /* ----------------------- EVENTOS */

        private void Alta_o_Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }


        
        private void limpiar_Click(object sender, EventArgs e)
        {
            this.limpiarLosCampos();
        }


        private void turno_TextChanged(object sender, EventArgs e)
        {

        }

        private void marca_TextChanged(object sender, EventArgs e)
        {

        }

        private void numeroChofer_TextChanged(object sender, EventArgs e)
        {

        }

        private void patente_TextChanged(object sender, EventArgs e)
        {

        }
        private void modelo_TextChanged(object sender, EventArgs e)
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

        private void listaDeTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        /*  EVENTOS  ----------------------- */
      
    }
}
