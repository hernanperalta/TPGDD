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
    public partial class Modificacion : Form
    {
        
        private Automovil automovilSeleccionado;
        private Turno turno;
        private Baja_o_Modificacion parent;
        private string errores = "";
        private string estadoOriginalDelTurno;
        
        public Modificacion(Baja_o_Modificacion parent, Automovil automovilSeleccionado)
        {
            InitializeComponent();
            this.parent = parent;
            this.automovilSeleccionado = automovilSeleccionado;
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
            this.cargarDatosDelAuto();
            this.cargarTurnoDelAutomovilSeleccionado();
            this.cargarTodosLosTurnosDisponibles();
            
        }

        private void cargarDatosDelAuto() {
            this.patente.Text = automovilSeleccionado.patente;
            this.marca.Text = automovilSeleccionado.marca;
            this.modelo.Text = automovilSeleccionado.modelo;
            this.numeroChofer.Text = automovilSeleccionado.telefono_chofer;
            this.habilitado.Checked = automovilSeleccionado.habilitado;

            if (this.habilitado.Checked) {
                this.habilitado.Enabled = false;
            }

        }

        private void cargarTurnoDelAutomovilSeleccionado() {

            string queryTurno = "SELECT t.hora_inicio_turno, t.hora_fin_turno, descripcion "
                                + " FROM LOS_CHATADROIDES.Turno t "
                                + " JOIN LOS_CHATADROIDES.Auto_X_Turno axt "
                                + " ON(t.hora_inicio_turno = axt.hora_inicio_turno AND t.hora_fin_turno = axt.hora_fin_turno AND axt.patente = '" + this.automovilSeleccionado.patente + "')";

            try
            {

                SqlDataReader readerTurnos = DBConexion.ResolverQuery(queryTurno);
                readerTurnos.Read();
                this.turno = new Turno(readerTurnos.GetDecimal(0).ToString(), readerTurnos.GetDecimal(1).ToString(), readerTurnos.GetString(2));
                readerTurnos.Close();
            }
            catch (SinRegistrosException e)
            {
                this.turno = new Turno("", "", "");
            }

            this.turnoActualLabel.Text = "Turno Actual :" + turno.ToString();
            this.estadoOriginalDelTurno = this.selectorTurno.Text;
        }

        private void cargarTodosLosTurnosDisponibles() {
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
            catch (Exception e)
            {
                this.selectorTurno.Text = "No hay turnos en la base de datos";
            }
            
        }

        /* VALIDACIONES  -------------- */
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
                campo.Text = campo.Text.Remove(campo.Text.Length - 1);
            }
        }

        private void validarNumeroChofer()
        {

            this.superaElRango(this.numeroChofer, "numero chofer", 18);

            if (this.numeroChofer.Text.Any(char.IsLetter))
            {
                MessageBox.Show("El telefono del chofer solo puede tener numeros.\n");
                this.numeroChofer.Text = this.numeroChofer.Text.Remove(this.numeroChofer.Text.Length - 1);
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
                this.marca.Text = this.marca.Text.Remove(this.marca.Text.Length - 1);
            }
        }


        private void validarQueLosCamposNoEstenVacios()
        {
            this.estaVacio(this.numeroChofer.Text, "numero chofer");
            this.estaVacio(this.modelo.Text, "modelo");
            this.estaVacio(this.marca.Text, "marca");
        }

        private bool seleccionoTurno()
        {
            return this.selectorTurno.SelectedIndex != -1 && !selectorTurno.SelectedItem.Equals("No asignar turno") && !selectorTurno.Text.Equals("No asignar turno") ;

        }
      
        /* -----------   VALIDACIONES */


        /* CUANDO CAMBIAN LOS CAMPOS A MODIFICAR ----------------------*/

        private void numeroChofer_TextChanged(object sender, EventArgs e)
        {
            this.validarNumeroChofer();
        }

        private void marca_TextChanged(object sender, EventArgs e)
        {
            this.validarMarca();
        }

        private void modelo_TextChanged(object sender, EventArgs e)
        {
            this.validarModelo();
        }

        /* ---------------------- CUANDO CAMBIAN LOS CAMPOS A MODIFICAR */

        private void restaurar_Click(object sender, EventArgs e)
        {
            this.cargarDatosDelAuto();
            this.selectorTurno.SelectedIndex = -1;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            this.validarQueLosCamposNoEstenVacios();
            if (!errores.Equals(""))
            {
                MessageBox.Show(this.errores);
                this.errores = "";
                return;
            }

            string modificarAutomovil = "EXEC LOS_CHATADROIDES.Modificar_automovil  '"
                                       + this.patente.Text + "', "
                                       + this.numeroChofer.Text + ", '"
                                       + this.marca.Text + "', '"
                                       + this.modelo.Text + "', "
                                       + ((this.habilitado.Checked) ? " 1, " : " 0, ")
                                       + (this.turno.horaInicio.Equals("")? " NULL, " : this.turno.horaInicio + ", ")
                                       + (this.turno.horaFin.Equals("")? " NULL " : this.turno.horaFin )
                                     
                                       ;

            try 
            { 
                DBConexion.ResolverNonQuery(modificarAutomovil);
                MessageBox.Show("Los datos del automovil se modificaron correctamente. A continuacion se muestra el estado actual del mismo.");
                this.automovilSeleccionado = new Automovil(this.patente.Text, this.numeroChofer.Text, this.marca.Text, this.modelo.Text, this.automovilSeleccionado.licencia, this.automovilSeleccionado.rodado, this.habilitado.Checked);
                this.cargarDatosDelAuto();
                this.cargarTurnoDelAutomovilSeleccionado();
            } catch(SqlException sqle)
            {
                MessageBox.Show(sqle.Message);
            } 
        }

        private void selectorTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.seleccionoTurno()) {
                this.turno = (Turno)this.selectorTurno.SelectedItem;
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form bajaOModificacion = new Abm_Automovil.Baja_o_Modificacion(this.parent.parent, false);
            bajaOModificacion.Show();
            this.Close();
        }
        

        
    }
}
