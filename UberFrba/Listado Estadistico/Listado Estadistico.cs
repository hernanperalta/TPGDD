using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Facturacion_Cliente
{
    public partial class Listado_Estadistico : Form
    {

        private String username;
        private String rol;

        public Listado_Estadistico(String username, String rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.username = username;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
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
