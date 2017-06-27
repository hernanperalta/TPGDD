using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
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
                this.Text = "Baja Automovil";
                this.bajaOModificacion.Text = "Dar de baja";
            }
            else {
                this.Text = "Modificar Automovil";
                this.bajaOModificacion.Text = "Modificar";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

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

        private void modeloBM_TextChanged(object sender, EventArgs e)
        {

        }

        private void bajaOModificacion_Click(object sender, EventArgs e)
        {
            if (puedeDarDeBaja)
            {
                /*baja*/
            }
            else {
                /*aca crear el objeto con los datos que selecciono del auto y pasarselo a la ventana siguiente para que lo pueda ver antes de modificar*/
                Form modificar = new Modificacion(automovilSeleccionado, this.username, this.rol);
                modificar.Show();
            }
        }
    }
}
