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
        private List<ErrorTextBox> listaDeErrores = new List<ErrorTextBox>();
        private List<Automovil> autosSeleccionados = new List<Automovil>();
        DataTable automoviles = new DataTable();
        private List<Filtro> filtrosTabla;
        

        public Baja_o_Modificacion(bool puedeDarDeBaja, string p1, string p2)
        {
            InitializeComponent();
            this.username = p1;
            this.rol = p2;
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

            this.nuevaListaDeFiltros();
        }
        /* VALIDACIONES  -------------- */
        private bool estaVacio(string campo)
        {
            return campo == null || campo.Equals("") || campo.Any(char.IsWhiteSpace);
        }

        private void validarNumeroChofer()
        {

            if (this.numeroChoferBM.Text.Any(char.IsLetter))
                this.listaDeErrores.Add(new ErrorTextBox(this.numeroChoferBM, "El telefono del chofer solo puede tener numeros.\n"));

            if (this.numeroChoferBM.Text.Length > 18)
                this.listaDeErrores.Add(new ErrorTextBox(this.numeroChoferBM, "El telefono excede los 18 digitos.\n"));


        }
        private void validarModelo()
        {

            if (this.modeloBM.Text.Length > 255)
                this.listaDeErrores.Add(new ErrorTextBox(this.modeloBM, "El modeloBM excede el numero de caracteres permitidos (255).\n"));
        }

        private void validarMarca()
        {
            if (this.marcaBM.Text.Any(char.IsDigit))
                this.listaDeErrores.Add(new ErrorTextBox(this.marcaBM, "La marca no puede contener numeros.\n"));

            if (this.marcaBM.Text.Length > 255)
                this.listaDeErrores.Add(new ErrorTextBox(this.marcaBM, "La marca excede el numero de caracteres permitidos (255)"));

        }

        private void validarPatente()
        {
            if (this.patenteBM.Text.Length > 10)
                this.listaDeErrores.Add(new ErrorTextBox(this.patenteBM, "La patente excede los 10 caracteres.\n"));
        }

        private void validarLosCampos()
        {
            this.validarMarca();
            this.validarModelo();
            this.validarPatente();
            this.validarNumeroChofer();
        }

        /* -----------   VALIDACIONES */


        /* CUANDO CAMBIAN LOS CAMPOS DE FILTRO ----------------------*/

        private void marcaBM_TextChanged(object sender, EventArgs e)
        {
            this.filtrosTabla[0].agregarFiltro(this.marcaBM.Text);
            this.validarMarca();
            this.llenarTablaSiSePuede();
            
        }

        private void modeloBM_TextChanged(object sender, EventArgs e)
        {
            this.filtrosTabla[1].agregarFiltro(this.modeloBM.Text);
            this.validarModelo();
            this.llenarTablaSiSePuede();
        }


        private void patenteBM_TextChanged(object sender, EventArgs e)
        {
            this.filtrosTabla[2].agregarFiltro(this.patenteBM.Text); 
            this.validarPatente();
            this.llenarTablaSiSePuede();
        }

        private void numeroChoferBM_TextChanged(object sender, EventArgs e)
        {
            this.filtrosTabla[3].agregarFiltro(this.numeroChoferBM.Text);
            this.validarNumeroChofer();
            this.llenarTablaSiSePuede();
        }



        /* ---------------------- CUANDO CAMBIAN LOS CAMPOS DE FILTRO */



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void limpiarLosCampos()
        {
            this.marcaBM.ResetText();
            this.modeloBM.ResetText();
            this.patenteBM.ResetText();
            this.numeroChoferBM.ResetText();
        }


        private void limpiar_Click(object sender, EventArgs e)
        {
            this.limpiarLosCampos();
            this.nuevaListaDeFiltros();
        }

        private void nuevaListaDeFiltros() {
            this.filtrosTabla = new List<Filtro> { 
                                                    new Filtro("Marca"),
                                                    new Filtro("Modelo"),
                                                    new Filtro("Patente"),
                                                    new Filtro("Numero Chofer")
                                                 };
        }

        private void baja_Click(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();
        }

        private void Baja_Load(object sender, EventArgs e)
        {

        }


       
        private void cargarLosAutomovilesSeleccionados()
        {

            foreach (DataGridViewRow fila in this.tablaAutomovil.SelectedRows)
            {
                Automovil filaAutomovil = new Automovil(fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString(), fila.Cells[2].Value.ToString(), fila.Cells[3].Value.ToString(), fila.Cells[4].Value.ToString(), fila.Cells[5].Value.ToString(), (fila.Cells[6].Value.ToString().Equals("1") ? true : false));
                autosSeleccionados.Add(filaAutomovil);
            }

        }

        private void bajaOModificacion_Click(object sender, EventArgs e)
        {
            this.cargarLosAutomovilesSeleccionados();
            // FIJARSE SI TENGO QUE CONTROLAR QUE NO HAYA SELECCIONADO NADA... 
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

                    }
                    catch (SqlException sqle)
                    {
                        errores += "El automovil de patente " + auto.patente + " no pudo darse de baja.\n";
                    }
                }
                if (!errores.Equals(""))
                    MessageBox.Show(errores);
                else MessageBox.Show(dadosDeBaja);


                /*baja*/
            }
            else
            {
                /*
                Form modificar = new Modificacion(automovilSeleccionado, this.username, this.rol);
                modificar.Show();*/
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.validarLosCampos();

            if (listaDeErrores.Any())
            {
                this.mostrarErrores();
            }
            else
            {
                this.llenarTabla();

            }
        }

        private void llenarTabla()
        {
            DataTable autos = new DataTable();
            try
            {
               
                autos.Load(DBConexion.ResolverQuery("SELECT patente as Patente, modelo as Modelo, marca as Marca, rodado as Rodado, telefono_chofer as 'Numero Chofer', licencia as Licencia, habilitado as Habilitado "
                                                       + "FROM LOS_CHATADROIDES.Automovil "
                                                       + "ORDER BY patente"));
                

                this.tablaAutomovil.DataSource = autos;
                
            }
            catch (SinRegistrosException e)
            {
                MessageBox.Show("No hay registros de automoviles");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        private void mostrarErrores() {
            string errores = "";
            listaDeErrores.ForEach(error => { errores += error.descripcionError; error.limpiarContenedor(); });
            MessageBox.Show(errores);
            listaDeErrores = new List<ErrorTextBox>();
        }

        private void llenarTablaSiSePuede()
        {
            if (listaDeErrores.Any())
            {
                this.mostrarErrores();
            }
            else
            {
                this.llenarTabla();
                /*foreach (Filtro filtro in this.filtrosTabla) {
                    
                    (this.tablaAutomovil.DataSource as DataTable).DefaultView.RowFilter += filtro.filtroActual;
                }
               */
                string rowFilter = "";

                string valorAnterior = "";

                for (int i = 0; i < this.filtrosTabla.Count; i++) {
                /*    if (this.filtrosTabla[i].filtroActual.Equals("")) {
                        break;
                    }
                    rowFilter += this.filtrosTabla[i].filtroActual;

                    int siguiente = i+1;
                    if (siguiente < this.filtrosTabla.Count && !this.filtrosTabla[siguiente].filtroActual.Equals("") && !this.filtrosTabla[i].filtroActual.Equals(""))
                    {
                        rowFilter += " AND ";
                    }
                 * */

                    if (i != 0)
                    {
                        if (!valorAnterior.Equals("") && !this.filtrosTabla[i].filtroActual.Equals(""))
                        {
                            // NO ESTA ENTRANDO ACA Y POR LO TANTO NO LE CONCATENA EL AND !!! 
                            rowFilter += " AND ";
                        }
                    }
                   
                    rowFilter += this.filtrosTabla[i].filtroActual;
                    valorAnterior = this.filtrosTabla[i].filtroActual;
                   
                    

                }
               
                (this.tablaAutomovil.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
                       
            }

        }


    }
}
