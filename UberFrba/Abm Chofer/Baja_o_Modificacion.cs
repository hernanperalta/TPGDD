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
using System.Text.RegularExpressions;

namespace UberFrba.Abm_Chofer
{
    public partial class Baja_o_Modificacion : Form
    {
        private string usernameActual;
        private string rol;
        private bool puedeDarDeBaja;
        private string errores = "";

        public Baja_o_Modificacion(bool puedeDarDeBaja, string username, string rol)
        {
            InitializeComponent();
            this.usernameActual = username;
            this.rol = rol;
            this.puedeDarDeBaja = puedeDarDeBaja;
            if (puedeDarDeBaja)
            {
                this.Text = "Baja Chofer";
                this.bajaOModificacion.Text = "Dar de baja";
            }
            else
            {
                this.Text = "Modificar Chofer";
                this.bajaOModificacion.Text = "Modificar";
            }
        }
        private void Baja_y_Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.usernameActual, this.rol);
            menu.Show();
            this.Close();
        }

        private void bajaOModificacion_Click(object sender, EventArgs e)
        {            
            /*foreach (DataGridViewRow row in this.choferesGrid.SelectedRows)
            {
                string chofer = "";
                for (int i = 0; i < 9; i++)
                    chofer += row.Cells[i].Value.ToString() + "\n";

                MessageBox.Show(chofer);
            }*/
            if (puedeDarDeBaja)
            {
                //baja
            }
            else
            {
                if (this.choferesGrid.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Sólo puede modificar de a un cliente a la vez");
                    return;
                }

                DataGridViewRow fila = this.choferesGrid.SelectedRows[0];

                Domicilio domicilio = new Domicilio(fila.Cells[3].Value.ToString(), fila.Cells[4].Value.ToString(), fila.Cells[5].Value.ToString(), fila.Cells[6].Value.ToString());

                Chofer choferSeleccionado = new Chofer(fila.Cells[0].Value as string, fila.Cells[1].Value as string, Int32.Parse(fila.Cells[2].Value.ToString()), domicilio, Int32.Parse(fila.Cells[7].Value.ToString()), fila.Cells[8].Value as string, (DateTime)fila.Cells[9].Value);
                //Chofer choferSeleccionado = new Chofer(fila.Cells[0].Value as string, fila.Cells[1].Value as string, (int)fila.Cells[2].Value, domicilio, (int)fila.Cells[7].Value, fila.Cells[8].Value as string, (DateTime)fila.Cells[9].Value);
                
                //aca crear el objeto con los datos que selecciono del chofer y pasarselo a la ventana siguiente para que lo pueda ver antes de modificar
                Form modificar = new Modificacion(choferSeleccionado, this.usernameActual, this.rol);
                modificar.Show();
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            this.validarTodosLosCamposNoVacios();

            if (!this.errores.Equals(""))
            {
                MessageBox.Show(this.errores);
                this.errores = "";
                return;
            }

            string query = this.agregarFiltros("SELECT nombre, apellido, dni, direccion, nro_piso, depto, localidad, telefono, "
                + "mail, fecha_de_nacimiento "
                + "FROM LOS_CHATADROIDES.Chofer");

            DataTable choferes = new DataTable();
            choferes.Load(DBConexion.ResolverQuery(query));
            this.choferesGrid.DataSource = choferes;
                      
        }

        private void validarTodosLosCamposNoVacios()
        {
            if(!this.campoVacio(this.nombreChofer))
                this.validarPalabra(255, this.nombreChofer.Text, "nombre");

            if (!this.campoVacio(this.apellidoChofer))
                this.validarPalabra(255, this.apellidoChofer.Text, "apellido");

            if (!this.campoVacio(this.dniChofer))
            this.validarNumeric(18, this.dniChofer.Text, "dni");
        }

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

        private string agregarFiltros(string query)
        {
            string ret = query;
            int cantFiltrosPuestos = 0;


            this.agregarCampoAQuery(ref ret, this.nombreChofer, "nombre", "'", ref cantFiltrosPuestos);
            this.agregarCampoAQuery(ref ret, this.apellidoChofer, "apellido", "'", ref cantFiltrosPuestos);
            this.agregarCampoAQuery(ref ret, this.dniChofer, "dni", "", ref cantFiltrosPuestos);

            return ret;
        }

        private void agregarCampoAQuery(ref string query, Control campo, string nombreDeCampo, string wrap, ref int cantFiltrosPuestos)
        {
            if (!this.campoVacio(campo))
            {
                string prefijo = "";

                if (cantFiltrosPuestos == 0)
                    query += " where";
                else prefijo = " and";

                query += prefijo + " " + nombreDeCampo + " = " + wrap + campo.Text + wrap;
                cantFiltrosPuestos++;
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

    }
}
