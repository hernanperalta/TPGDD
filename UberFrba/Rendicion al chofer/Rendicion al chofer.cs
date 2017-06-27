using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Rendicion_Al_Chofer
{
    public partial class Rendicion_Al_Chofer : Form
    {

        private String rol;
        private String username;

        public Rendicion_Al_Chofer(String username, String rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.username = username;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
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
