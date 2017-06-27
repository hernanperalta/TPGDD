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

namespace UberFrba.Abm_Chofer
{
    public partial class Baja_o_Modificacion : Form
    {
        private string usernameActual;
        private string rol;
        private bool puedeDarDeBaja;

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
            if (puedeDarDeBaja)
            {
                /*baja*/
            }
            else
            {
                /*aca crear el objeto con los datos que selecciono del chofer y pasarselo a la ventana siguiente para que lo pueda ver antes de modificar*/
                //Form modificar = new Modificacion(choferSeleccionado, this.username, this.rol);
                //modificar.Show();
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataTable choferes = new DataTable();
            choferes.Load(DBConexion.ResolverConsulta("select nombre, apellido, dni, C.direccion, nro_piso, depto, D.localidad, telefono, mail, fecha_de_nacimiento from LOS_CHATADROIDES.Chofer C join LOS_CHATADROIDES.Domicilio D ON(C.localidad = D.localidad and C.direccion = D.direccion)"));
            this.choferesGrid.DataSource = choferes;
            //MessageBox.Show(this.choferesGrid.SelectedRows..ToString());
            foreach(Chofer chofer in this.choferesGrid.SelectedRows)
            {
                MessageBox.Show(chofer.telefono.ToString());
            }
        }
    }
}
