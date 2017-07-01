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
    public partial class Baja : Form
    {/*
        private String username;
        private String rol;*/
        private Form parent;

        //public Baja_Rol(String username, String rol)
        public Baja(Form parent)
        {
            InitializeComponent();/*
            this.username = username;
            this.rol = rol;*/
            this.parent = parent;
        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();*/
            this.Close();
            this.parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*HACER UN RRECONTRA TRIGGER (porque hay que quitarle el rol inhabilitado a los usuarios que lo tengan)*/
        }

        private void Baja_Rol_Load(object sender, EventArgs e)
        {

        }
    }
}
