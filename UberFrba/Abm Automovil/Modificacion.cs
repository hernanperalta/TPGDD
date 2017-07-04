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
using UberFrba.Abm_Chofer;
using System.Text.RegularExpressions;

namespace UberFrba.Abm_Automovil
{
    public partial class Modificacion : Form
    {
        
        private Automovil automovilSeleccionado;
        private Turno turno;
        private Baja_o_Modificacion parent;
        private string errores = "";
        private UpdateBuilder updateBuilder;
        
        public Modificacion(Baja_o_Modificacion parent, Automovil automovilSeleccionado)
        {
            InitializeComponent();
            this.parent = parent;
            this.automovilSeleccionado = automovilSeleccionado;
            this.cargarLosHorariosDeLosTurnos();

            this.updateBuilder = new UpdateBuilder("LOS_CHATADROIDES.Automovil", "WHERE patente = '" + automovilSeleccionado.patente + "'");
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
            this.cargarDatosDelAuto();
            
            this.cargarTurnoDelAutomovilSeleccionado();
            
        }

        private string estaHabilitado(bool habilitado) {

            if (habilitado) return "1";
            return "0";
        }

        private void setearUpdates()
        {
            this.setearUpdateSiCambioCampo("patente", this.patente.Text, this.automovilSeleccionado.patente, "'");
            this.setearUpdateSiCambioCampo("marca", this.marca.Text, this.automovilSeleccionado.marca, "'");
            this.setearUpdateSiCambioCampo("modelo", this.modelo.Text, this.automovilSeleccionado.modelo, "'");
            this.setearUpdateSiCambioCampo("telefono_chofer", this.numeroChofer.Text, this.automovilSeleccionado.telefono_chofer, "");
            this.setearUpdateSiCambioCampo("habilitado", this.estaHabilitado(this.habilitado.Checked), this.estaHabilitado(this.automovilSeleccionado.habilitado), "");
        }

        private void setearUpdateSiCambioCampo(string nombreDeCampo, string valorSegunUsuario, string valorOriginal, string wrap)
        {
            if (!valorSegunUsuario.Equals(valorOriginal) && !this.estaVacio(valorSegunUsuario))
                this.updateBuilder.agregarFiltro(nombreDeCampo, valorSegunUsuario, wrap);
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
                while (readerTurnos.Read())
                {
                    this.turno = new Turno(readerTurnos.GetDecimal(0).ToString(), readerTurnos.GetDecimal(1).ToString(), readerTurnos.GetString(2));
                    this.tildarEnLaLista(turno);
                }
                readerTurnos.Close();
            }
            catch (SinRegistrosException e)
            {
                this.listaDeTurnos.ClearSelected();
            }

          
        }

        private void tildarEnLaLista(Turno nuevoTurno) {
            foreach (Turno turno in this.listaDeTurnos.Items) {
                if (nuevoTurno.horaInicio == turno.horaInicio && nuevoTurno.horaFin == turno.horaFin) {
                    int indice = this.listaDeTurnos.Items.IndexOf(turno);
                    this.listaDeTurnos.SetItemChecked(indice, true);
                    break;
                }
            }
        }

        /* VALIDACIONES  -------------- */
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

        private void validarTodosLosCampos()
        {
            this.validarPatente();
            this.validarMarca();
            this.validarModelo();
            this.validarNumeroChofer();

        }

        private bool estaVacio(string campo) {
            return campo == null || campo.Equals("");
        }

        private void estaVacio(string campo, string nombreCampo)
        {
            if (this.estaVacio(campo))
                this.errores += "El campo " + nombreCampo + " no puede ser vacio. \n";
        }

        private void superaElRango(TextBox campo, string nombreCampo, int rango)
        {
            if (campo.Text.Length > rango)
            {
                MessageBox.Show("El campo " + nombreCampo + " excede los " + rango.ToString() + " digitos.\n");

            }
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

        private void patente_TextChanged(object sender, EventArgs e)
        {
            this.validarPatente();
        }



        /* ---------------------- CUANDO CAMBIAN LOS CAMPOS A MODIFICAR */

        private void restaurar_Click(object sender, EventArgs e)
        {
            this.cargarDatosDelAuto();
            this.cargarTurnoDelAutomovilSeleccionado();
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

            this.setearUpdates();

            this.modificarAutoPorTurno();

            if (!this.updateBuilder.tieneSetsAgregados())
            {
                MessageBox.Show("No cambio el valor de ninguno de los campos originales. Por ende, el automovil quedara sin actualizar");
                return;
            }

            try 
            {
                
                DBConexion.ResolverNonQuery(this.updateBuilder.obtenerUpdate());
                
                MessageBox.Show("Los datos del automovil se modificaron correctamente.");
                
            

            } catch(SqlException sqle)
            {
                this.updateBuilder.resetearUpdate();
                MessageBox.Show(sqle.Message);
            }

            this.Close();
            new Abm_Automovil.Baja_o_Modificacion(this.parent.parent, false).Show();

        }

        public void selectorTurno_SelectedIndexChanged(object sender, EventArgs e) { }


        private void modificarAutoPorTurno() {
            string errores = "";
            string turnosActualizados = "Los turnos asignados son: \n";
            foreach(Turno turno in this.listaDeTurnos.Items){
                try {
                        
                        DBConexion.ResolverNonQuery("EXEC LOS_CHATADROIDES.Modificar_auto_x_turno_si_el_valor_cambia " + turno.horaInicio + ", " + turno.horaFin + ", '" + this.automovilSeleccionado.patente + "', " + (this.esTurnoCheckeado(turno) ? " 1 " : " 0 ") );
                        if(this.esTurnoCheckeado(turno))
                            turnosActualizados += turno.ToString() + "\n";
                } catch(SqlException sqle)
                {
                    errores += "El automovil no pudo actualizarse con el turno : " + turno.descripcion + " \n";
                }
            }

            if (!errores.Equals("")) {
                MessageBox.Show(errores);
                return;
            }
            if (turnosActualizados.Equals("Los turnos asignados son: \n"))
            {
                MessageBox.Show("El automovil se guardo sin turnos asignados. \n");
                return;
            }

            MessageBox.Show(turnosActualizados);
        }

        private bool esTurnoCheckeado(Turno turno) {
            return this.listaDeTurnos.CheckedIndices.Contains(this.listaDeTurnos.Items.IndexOf(turno));
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form bajaOModificacion = new Abm_Automovil.Baja_o_Modificacion(this.parent.parent, false);
            bajaOModificacion.Show();
            this.Close();
        }



        private void cargarLosHorariosDeLosTurnos()
        {

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
            catch (Exception e)
            {
                this.listaDeTurnos.Text = "No hay turnos en la base de datos";
            }

        }

        private void listaDeTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void patente_Click(object sender, EventArgs e)
        {

        }

     


    }
}
