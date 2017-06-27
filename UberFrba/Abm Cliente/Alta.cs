using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class Alta : Form
    {
        private string username;
        private string rol;

        public Alta(string username, string rol)
        {
            InitializeComponent();
            this.username = username;
            this.rol = rol;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();
        }

        private void Alta_o_Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!puedeDarDeAlta) { /* hacer update */}
            else { /*hacer insert*/ }
        }
    }
}
