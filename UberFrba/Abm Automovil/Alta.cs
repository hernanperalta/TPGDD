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
        private List<ErrorTextBox> listaDeErrores = new List<ErrorTextBox>();

        public Alta(string username, string rol)
        {
            InitializeComponent();
            this.username = username;
            this.rol = rol;
            this.cargarLosHorariosDeLosTurnos();
        }

        private void limpiarLosCampos() {
            this.marca.ResetText();
            this.modelo.ResetText();
            this.patente.ResetText();
            this.numeroChofer.ResetText();
            this.selectorTurno.ResetText();
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
                this.listaDeErrores.Add(new ErrorTextBox(this.numeroChofer, "El telefono esta vacio.\n"));

            if (this.numeroChofer.Text.Any(char.IsLetter))
                this.listaDeErrores.Add(new ErrorTextBox(this.numeroChofer, "El telefono del chofer solo puede tener numeros.\n"));

            if (this.numeroChofer.Text.Length > 18)
                this.listaDeErrores.Add(new ErrorTextBox(this.numeroChofer, "El telefono excede los 18 digitos.\n"));
           
            
        }

        /* ASUMIMOS QUE LA MARCA NO PUEDE TENER NUMEROS PERO EL MODELO SI */
        private void validarModelo()
        {
            if (this.estaVacio(this.modelo.Text))
                this.listaDeErrores.Add(new ErrorTextBox(this.modelo, "Debe insertar un modelo para el automovil.\n" ));

            if (this.modelo.Text.Length > 255)
                this.listaDeErrores.Add(new ErrorTextBox(this.modelo, "El modelo excede el numero de caracteres permitidos (255).\n"));
        }

        private void validarMarca() {
            if (this.estaVacio(this.marca.Text))
                this.listaDeErrores.Add(new ErrorTextBox(this.marca, "Debe insertar una marca para el automovil.\n"));

            if (this.marca.Text.Any(char.IsDigit))
                this.listaDeErrores.Add(new ErrorTextBox(this.marca, "La marca no puede contener numeros.\n"));

            if (this.marca.Text.Length > 255)
                this.listaDeErrores.Add(new ErrorTextBox(this.marca, "La marca excede el numero de caracteres permitidos (255)"));
            
        }

        private void validarPatente() {
            if (this.estaVacio(this.patente.Text))
                this.listaDeErrores.Add(new ErrorTextBox(this.patente, "La patente esta vacia.\n"));

            if (this.patente.Text.Length > 10)
                this.listaDeErrores.Add(new ErrorTextBox(this.patente, "La patente excede los 10 caracteres.\n"));
        }

        private void validarLosCampos() {
            this.validarMarca();
            this.validarModelo();
            this.validarPatente();
            this.validarNumeroChofer();
        }

        private bool seleccionoTurno() {
            return selectorTurno.SelectedItem.Equals("No asignar turno") || selectorTurno.Text.Equals("No asignar turno");
            
        }

        /**  - VALIDACIONES **/

        private Turno turnoSeleccionado() {
            return (Turno) this.selectorTurno.SelectedItem;
        }

        private void cargarLosHorariosDeLosTurnos(){
            
            try
            {
                SqlDataReader readerTurnos = DBConexion.ResolverQuery("SELECT hora_inicio_turno, hora_fin_turno, descripcion FROM LOS_CHATADROIDES.Turno");

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
          
            if (listaDeErrores.Any()) {
                string errores = "";
                listaDeErrores.ForEach(error => { errores += error.descripcionError; error.limpiarContenedor(); });
                MessageBox.Show(errores);
                listaDeErrores = new List<ErrorTextBox>();
            }
            else
            {
                try
                 {

                     DBConexion.ResolverNonQuery("EXEC LOS_CHATADROIDES.Dar_de_alta_automovil '" 
                                                + this.patente.Text +"', " 
                                                + this.numeroChofer.Text + ", '"
                                                + this.marca.Text + "', '"
                                                + this.modelo.Text + "', " 
                                                + (this.seleccionoTurno() ? "NULL, " :  this.turnoSeleccionado().horaInicio + ",")
                                                + (this.seleccionoTurno() ? "NULL" :  this.turnoSeleccionado().horaFin) 
                                               );


                     MessageBox.Show("Se pudo crear el automovil de patente nro: " + this.patente.Text);
                 }
                 catch (SqlException sqle)
                 {
                     
                     if(sqle.Number == 2627)
                            MessageBox.Show("No se pudo crear el automovil porque existe otro registro de automovil con patente nro: " + this.patente.Text );
                            
                     if(sqle.Number == 547) {
                        if(sqle.Message.Contains("'telefono'"))
                            MessageBox.Show("No se pudo crear el automovil porque no existe un chofer con el numero: " + this.numeroChofer.Text);
                     }
                          
                     }
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
