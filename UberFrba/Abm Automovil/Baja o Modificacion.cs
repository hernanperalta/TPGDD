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
    public partial class Baja_o_Modificacion : Form
    {
        private string username;
        private string rol;
        private bool puedeDarDeBaja;
        public Form parent;
        private List<Automovil> autosSeleccionados = new List<Automovil>();
        DataTable automoviles = new DataTable();
       

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

        
        }
        /* VALIDACIONES  -------------- */

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

            this.superaElRango(this.numeroChoferBM, "numero chofer", 18);

            if (this.numeroChoferBM.Text.Any(char.IsLetter))
            {
                MessageBox.Show("El telefono del chofer solo puede tener numeros.\n");
                this.numeroChoferBM.Text = this.numeroChoferBM.Text.Remove(this.numeroChoferBM.Text.Length - 1);
            }



        }
        private void validarModelo()
        {

            this.superaElRango(this.modeloBM, "modelo", 255);
        }

        private void validarMarca()
        {

            this.superaElRango(this.marcaBM, "marca", 255);

            if (this.marcaBM.Text.Any(char.IsDigit))
            {
                MessageBox.Show("La marca no puede contener numeros.");
                this.marcaBM.Text = this.marcaBM.Text.Remove(this.marcaBM.Text.Length - 1);
            }

        }


        private void validarPatente()
        {
            this.superaElRango(this.patenteBM, "patente", 10);
        }

        /* -----------   VALIDACIONES */


        /* CUANDO CAMBIAN LOS CAMPOS DE FILTRO ----------------------*/

        private void marcaBM_TextChanged(object sender, EventArgs e)
        {
            // FIXME : ESTO TIENE QUE SER UN COMBO !!!! En el enunciado dice seleccion acotada 
            this.validarMarca();
            this.llenarTablaSiSePuede();
            
        }

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



        /* ---------------------- CUANDO CAMBIAN LOS CAMPOS DE FILTRO */



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void limpiarLosCampos()
        {
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
                if (!errores.Equals(""))
                {
                    MessageBox.Show(errores);
                    errores = "";
                }
                else MessageBox.Show(dadosDeBaja);

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

        private void button4_Click(object sender, EventArgs e)
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
                                            + " WHERE marca LIKE '" + this.marcaBM.Text + "%' AND "
                                            + " modelo LIKE '" + this.modeloBM.Text + "%' AND "
                                            + " patente LIKE '" + this.patenteBM.Text + "%' AND "
                                            + " CONVERT(VARCHAR(18),telefono_chofer) LIKE '" + this.numeroChoferBM.Text + "%' "
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


    }
}
