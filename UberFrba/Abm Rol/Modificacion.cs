using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Rol
{
    public partial class Modificacion : Form
    {
        private String username;
        private String rol;

        public Modificacion(String username, String rol)
        {
            InitializeComponent();
            this.username = username;
            this.rol = rol;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Modificacion_Load(object sender, EventArgs e)
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
