using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    public partial class Alta_o_Modificacion : Form
    {

        private string username;
        private string rol;
        private bool puedeDarDeAlta;

        public Alta_o_Modificacion(bool puedeDarDeAlta, string username, string rol)
        {
            InitializeComponent();
            this.username = username;
            this.rol = rol;
            this.puedeDarDeAlta = puedeDarDeAlta;
            if (puedeDarDeAlta)
            {
                this.Text = "Alta de Turno";
                this.button1.Text = "Crear Turno";
            }
            else
            {
                this.Text = "Modificacion de Turno";
                this.button1.Text = "Guardar Turno";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Alta_o_Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();
        }
    }
}
