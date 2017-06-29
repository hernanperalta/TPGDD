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
       // private string errores = "";
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
                //errores += "Debe insertar un telefono para el chofer.\n";
                this.listaDeErrores.Add(new ErrorTextBox(this.numeroChofer, "El telefono esta vacio.\n"));

            if (this.numeroChofer.Text.Any(char.IsLetter))
                //errores += "El telefono solo puede tener numeros.\n";
                this.listaDeErrores.Add(new ErrorTextBox(this.numeroChofer, "El telefono solo puede tener numeros.\n"));

            if (this.numeroChofer.Text.Length > 18)
                //errores += "El telefono excede los 18 digitos.\n";
                this.listaDeErrores.Add(new ErrorTextBox(this.numeroChofer, "El telefono excede los 18 digitos.\n"));
           
            
        }
        /* ASUMIMOS QUE LA MARCA NO PUEDE TENER NUMEROS PERO EL MODELO SI */
        private void validarModelo()
        {
            if (this.estaVacio(this.modelo.Text))
                //errores += "Debe insertar un modelo para el automovil.\n";
                this.listaDeErrores.Add(new ErrorTextBox(this.modelo, "Debe insertar un modelo para el automovil.\n" ));

            if (this.modelo.Text.Length > 255)
                //errores += "El modelo excede el numero de caracteres permitidos (255).\n";
                this.listaDeErrores.Add(new ErrorTextBox(this.modelo, "El modelo excede el numero de caracteres permitidos (255).\n"));
        }

        private void validarMarca() {
            if (this.estaVacio(this.marca.Text))
                //errores += "Debe insertar una marca para el automovil.\n";
                this.listaDeErrores.Add(new ErrorTextBox(this.marca, "Debe insertar una marca para el automovil.\n"));
            if (this.marca.Text.Any(char.IsDigit))
                //errores += "La marca no puede contener numeros.\n";
                this.listaDeErrores.Add(new ErrorTextBox(this.marca, "La marca no puede contener numeros.\n"));
            if (this.marca.Text.Length > 255)
                //errores += "La marca excede el numero de caracteres permitidos (255)";
                this.listaDeErrores.Add(new ErrorTextBox(this.marca, "La marca excede el numero de caracteres permitidos (255)"));
            
        }

        private void validarPatente() {
            if (this.estaVacio(this.patente.Text))
               //errores += "Debe insertar una patente para el automovil.\n";
                this.listaDeErrores.Add(new ErrorTextBox(this.patente, "La patente esta vacia.\n"));

            if (this.patente.Text.Length > 10)
                //errores += "La patente excede los 10 caracteres.\n";
                this.listaDeErrores.Add(new ErrorTextBox(this.patente, "La patente excede los 10 caracteres.\n"));
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
            /*ANTES DEL REFACTOR DEL MANEJO DE ERRORES: 
             * if (!this.errores.Equals(""))
            {
                MessageBox.Show(errores);
                this.limpiarLosCampos();
                this.errores = "";
            }*/
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
                     DBConexion.ResolverNonQuery("INSERT INTO LOS_CHATADROIDES.Automovil (patente, telefono_chofer, marca, modelo)" +
                                                 "VALUES ( '"+ this.patente.Text +"', " 
                                                 + Convert.ToDouble(this.numeroChofer.Text) + ", '" 
                                                 + this.marca.Text + "', '" 
                                                 + this.modelo.Text + "' )" 
                                                );
                    // ESTA PRIMER NONQUERY ANDA BARBARO,  LA SEGUNDA CREO QUE ESTA FALLANDO... 
                    /*
                     if (!selectorTurno.SelectedItem.Equals("No asignar turno") && !selectorTurno.Text.Equals("No hay turnos en la base de datos"))
                        DBConexion.ResolverNonQuery("INSERT INTO LOS_CHATADROIDES.Auto_X_Turno (patente, hora_inicio_turno, hora_fin_turno)" +
	                                                "VALUES( '"
                                                    + this.patente.Text + ", "
                                                    + ((Turno)this.selectorTurno.SelectedItem).horaInicioDouble() + ", "
                                                    + ((Turno)this.selectorTurno.SelectedItem).horaFinDouble()
                                                    + ")"
                                                    );
                                              
                    */
                     MessageBox.Show("Se pudo crear el automovil de patente nro: " + this.patente.Text);
                 }
                 catch (SqlException sqle)
                 {
                     MessageBox.Show("No se pudo crear el automovil de patente nro: " + this.patente.Text);
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
