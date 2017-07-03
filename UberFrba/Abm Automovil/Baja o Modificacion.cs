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
    public partial class Baja_o_Modificacion : Form
    {
        private string username;
        private string rol;
        private bool puedeDarDeBaja;
        public Form parent;
        private List<Automovil> autosSeleccionados = new List<Automovil>();
        DataTable automoviles = new DataTable();
        private string errores = "";
       

        public Baja_o_Modificacion(Form parent, bool puedeDarDeBaja)
        {
            InitializeComponent();
            this.parent = parent;
            this.puedeDarDeBaja = puedeDarDeBaja;
            if (puedeDarDeBaja)
            {
                this.Text = "Baja Automovil";
                this.bajaOModificacion.Text = "Dar de baja";
            }
            else
            {
                this.Text = "Modificar Automovil";
                this.bajaOModificacion.Text = "Modificar";
            }

            this.cargarMarcasExistentes();

        
        }
        /* VALIDACIONES  -------------- */



        private void validarNumeric(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[0-9]+$", texto, nombreDeCampo, "sólo debe tener números");
        }

        private void validarPalabra(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[a-zA-Z]+$", texto, nombreDeCampo, "sólo debe tener letras");
        }

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

        private bool campoVacio(Control campo)
        {
            return campo == null || this.estaVacio(campo.Text);
        }


        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private void validarNumeroChofer()
        {
            if (!this.campoVacio(this.numeroChoferBM))
                this.validarNumeric(18, this.numeroChoferBM.Text, "numero chofer");
            this.siHayErroresMostrarlos();
        }

        private void validarModelo()
        {
            if (!this.campoVacio(this.modeloBM))
                this.validarPalabra(255, this.modeloBM.Text, "modelo");
            this.siHayErroresMostrarlos();
        }

       

        private void validarPatente()
        {
            if (!this.campoVacio(this.patenteBM))
                this.validarPalabra(255, this.patenteBM.Text, "patente");
            this.siHayErroresMostrarlos();
        }

        /* -----------   VALIDACIONES */

        private void siHayErroresMostrarlos(){

            if (!errores.Equals("")) {
                MessageBox.Show(errores);
                this.errores = "";
            } 
            
        }

        /* CUANDO CAMBIAN LOS CAMPOS DE FILTRO ----------------------*/

      
        private void modeloBM_TextChanged(object sender, EventArgs e)
        {
            this.validarModelo();
            this.llenarTablaSiSePuede();
        }


        private void patenteBM_TextChanged(object sender, EventArgs e)
        {
            this.validarPatente();
            this.llenarTablaSiSePuede();
        }

        private void numeroChoferBM_TextChanged(object sender, EventArgs e)
        {
            this.validarNumeroChofer();
            this.llenarTablaSiSePuede();
        }

        public void cargarMarcasExistentes() {

            try
            {
                SqlDataReader reader = DBConexion.ResolverQuery("SELECT marca FROM LOS_CHATADROIDES.Automovil GROUP BY marca");
                while (reader.Read())
                {
                    this.selectorDeMarcas.Items.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (SinRegistrosException sre) {
                MessageBox.Show("No hay marcas en la base de datos, no podra utilizar este filtro.");
                this.selectorDeMarcas.Enabled = false;
            }
               
        }

        /* ---------------------- CUANDO CAMBIAN LOS CAMPOS DE FILTRO */



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void limpiarLosCampos()
        {
            this.tablaAutomovil.DataSource = null;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                }
            }

            this.selectorDeMarcas.SelectedIndex = -1;
            this.tablaAutomovil.DataSource = null;

        }


        private void limpiar_Click(object sender, EventArgs e)
        {
            this.limpiarLosCampos();
        }

        private void baja_Click(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void Baja_Load(object sender, EventArgs e)
        {

        }


       
        private void cargarLosAutomovilesSeleccionados()
        {

            foreach (DataGridViewRow fila in this.tablaAutomovil.SelectedRows)
            {                                                                                                                                                                                                                                             
                Automovil filaAutomovil = new Automovil(fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString(), fila.Cells[2].Value.ToString(), fila.Cells[3].Value.ToString(), fila.Cells[4].Value.ToString(), fila.Cells[5].Value.ToString(), Convert.ToBoolean(fila.Cells[6].Value.ToString()));
                autosSeleccionados.Add(filaAutomovil);
            }

        }

        private void bajaOModificacion_Click(object sender, EventArgs e)
        {
            this.cargarLosAutomovilesSeleccionados();
          
            if (this.tablaAutomovil.RowCount == 0)
            {
                MessageBox.Show("Para llenar la lista de automoviles disponibles haga click en el boton 'Buscar todos' o añada algun filtro");
                return;
            }

            string errores = "";
            string dadosDeBaja = "Los autos dados de baja corresponden a las patentes : \n";
            if (puedeDarDeBaja)
            {
                
                foreach (Automovil auto in this.autosSeleccionados)
                {
                    if (!auto.habilitado)
                    {
                        errores += "El auto de patente : " + auto.patente + " ya se encuentra deshabilitado.\n";
                    }
                    else
                    {
                        try
                        {

                            DBConexion.ResolverNonQuery("DELETE FROM LOS_CHATADROIDES.Automovil WHERE patente = '" + auto.patente + "'");

                            dadosDeBaja += auto.patente + "\n";

                            this.llenarTablaSiSePuede();

                        }
                        catch (SqlException sqle)
                        {
                            errores += "El automovil de patente " + auto.patente + " no pudo darse de baja.\n";
                        }
                    }
                }

                if (!errores.Equals(""))
                {
                    MessageBox.Show(errores);
                    errores = "";
                }

                if (!dadosDeBaja.Equals("Los autos dados de baja corresponden a las patentes : \n"))
                    MessageBox.Show(dadosDeBaja);

            }
            else
            {
                

                if (this.autosSeleccionados.Count > 1)
                {
                    MessageBox.Show("Debe seleccionar de a un automovil para modificar");
                    this.autosSeleccionados.Clear();
                    return;
                }
                try
                {
                    Form modificar = new Modificacion(this, (Automovil)this.autosSeleccionados.First());
                    this.autosSeleccionados.Clear();
                    modificar.Show();
                    this.Close();
                }
                catch (InvalidOperationException) {
                    MessageBox.Show("Para elegir un automovil debe oprimir la flecha que se encuentra a la izquierda de la fila");
                    return;
                }
               
            }
        }

        private void buscarTodos_Click(object sender, EventArgs e)
        {
                this.llenarTablaSiSePuede();
                this.limpiarLosCampos();
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        private void llenarTablaSiSePuede()
        {
    
            automoviles.Clear();
            try
            {

                automoviles.Load(DBConexion.ResolverQuery("SELECT patente as Patente,telefono_chofer as 'Numero Chofer', marca as Marca, modelo as Modelo,  licencia as Licencia, rodado as Rodado, habilitado as Habilitado "
                                            + " FROM LOS_CHATADROIDES.Automovil "
                                            + " WHERE " + this.filtrarPorLaMarcaSiSelecciono()      
                                            + " modelo LIKE '%" + this.modeloBM.Text + "%' AND "
                                            + " patente LIKE '%" + this.patenteBM.Text + "%' AND "
                                            + " CONVERT(VARCHAR(18),telefono_chofer) LIKE '%" + this.numeroChoferBM.Text + "%' "
                                            + " ORDER BY patente"
                                            )

                                            );

                this.tablaAutomovil.DataSource = automoviles;
                this.noAutosLabel.Text = "";
            }
            catch (SinRegistrosException)
            {
                this.noAutosLabel.Text = "No se encontraron automoviles";
                return;
            }
            
        }

        private string filtrarPorLaMarcaSiSelecciono() {
            if (this.selectorDeMarcas.SelectedIndex > -1) {
                return "marca LIKE '" + this.selectorDeMarcas.SelectedItem.ToString() + "%' AND ";
            } 
            return "";
        }

        private void selectorDeMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.llenarTablaSiSePuede();
        }


    }
}
