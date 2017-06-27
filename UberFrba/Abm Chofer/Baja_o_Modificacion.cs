using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Chofer
{
    public partial class Baja_o_Modificacion : Form
    {
        private string username;
        private string rol;
        private bool puedeDarDeBaja;

        public Baja_o_Modificacion(bool puedeDarDeBaja, string p1, string p2)
        {
            InitializeComponent();
            this.username = p1;
            this.rol = p2;
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
            Form menu = new Menu.Menu(this.username, this.rol);
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
                Form modificar = new Modificacion(choferSeleccionado, this.username, this.rol);
                modificar.Show();
            }
        }
    }
}
