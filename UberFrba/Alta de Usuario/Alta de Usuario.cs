using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Alta_de_Usuario
{
    public partial class Alta_de_Usuario : Form
    {

        private String rol;
        private String username;

        public Alta_de_Usuario(String username, String rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.username = username;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Alta_de_Usuario_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
