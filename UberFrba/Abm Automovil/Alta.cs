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
        private Form parent;
        
        
        private string errores = "";

        public Alta(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.cargarLosHorariosDeLosTurnos();
        }

        private void limpiarLosCampos() {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                }
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            this.limpiarLosCampos();
        }
        /* ----------------------- CUANDO CAMBIAN LOS CAMPOS */
        private void turno_TextChanged(object sender, EventArgs e){
        
        }

        private void marca_TextChanged(object sender, EventArgs e)
        {
            this.validarMarca();
        }

        private void numeroChofer_TextChanged(object sender, EventArgs e)
        {
            this.validarNumeroChofer();   
        }

        private void patente_TextChanged(object sender, EventArgs e)
        {
            this.validarPatente();
        }
        private void modelo_TextChanged(object sender, EventArgs e)
        {
            this.validarModelo();
        }

        /*  CUANDO CAMBIAN LOS CAMPOS  ----------------------- */

        /* VALIDACIONES : */
        private void estaVacio(string campo, string nombreCampo) {
            if(campo == null || campo.Equals(""))
                this.errores += "El campo " + nombreCampo + " no puede ser vacio. \n";
        }

        private void superaElRango(TextBox campo, string nombreCampo, int rango) {
            if (campo.Text.Length > rango)
            {
                MessageBox.Show("El campo "+ nombreCampo + " excede los " + rango.ToString() + " digitos.\n");
                
            }
        }

        private void validarNumeroChofer()
        {
            this.superaElRango(this.numeroChofer, "numero chofer", 18);

            if (this.numeroChofer.Text.Any(char.IsLetter))
            {
                MessageBox.Show("El telefono del chofer solo puede tener numeros.\n");
   
            }

            

        }
        private void validarModelo()
        {
            
            this.superaElRango(this.modelo, "modelo", 255);
        }

        private void validarMarca()
        {
            
            this.superaElRango(this.marca, "marca", 255);

            if (this.marca.Text.Any(char.IsDigit))
            {
                MessageBox.Show("La marca no puede contener numeros.");
                
            }

            
        }


        private void validarPatente() {

           
            this.superaElRango(this.patente, "patente", 10);

        }

        private void validarQueLosCamposNoEstenVacios()
        {
            this.estaVacio(this.numeroChofer.Text, "numero chofer");
            this.estaVacio(this.modelo.Text, "modelo");
            this.estaVacio(this.marca.Text, "marca");
            this.estaVacio(this.patente.Text, "patente");
        }

        private bool seleccionoTurno() {

            return this.listaDeTurnos.CheckedItems.Count != 0; 
            
        }

        /**  - VALIDACIONES **/

    
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

        private void crear_Click(object sender, EventArgs e)
        {

            string insertarAutomovil = "INSERT INTO LOS_CHATADROIDES.Automovil (patente, telefono_chofer, marca, modelo) "
			                         + "VALUES ( '"
                                     + this.patente.Text + "', " 
                                     + this.numeroChofer.Text + ", '" 
              						 + this.marca.Text + "', '" 
                                     + this.modelo.Text + "')" ;
          


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

        private void insertarTurnos()
        {
          string insertarAutoXTurno = "INSERT INTO LOS_CHATADROIDES.Auto_X_Turno (hora_inicio_turno, hora_fin_turno, patente) VALUES ";
  
          foreach(Turno turno in this.listaDeTurnos.CheckedItems)
          {
  		    DBConexion.ResolverNonQuery(insertarAutoXTurno + "(" + turno.horaInicio + ", " + turno.horaFin + ", '" + this.patente.Text + "')" );	
          }
  
        }
        

        private void Alta_o_Modificacion_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();*/
            this.Close();
            this.parent.Show();
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

        
      
    }
}
