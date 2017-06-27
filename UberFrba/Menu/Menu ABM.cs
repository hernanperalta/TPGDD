using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Menu
{
    public partial class Menu_ABM : Form
    {
        private FuncionalidadABM funcionalidadABM;
        private String username;
        private String rol;
        private String titulo;

        public Menu_ABM(String titulo, String username, String rol, FuncionalidadABM funcionalidadABM)
        {
            InitializeComponent();
            this.titulo = titulo;
            this.username = username;
            this.rol = rol;
            this.funcionalidadABM = funcionalidadABM;
            this.labelTitulo.Text = "ABM " + titulo;
            this.cargarSelectorABM();
        }


        private void labelTitulo_Click(object sender, EventArgs e)
        {
           
        }

        private void Menu_ABM_Load(object sender, EventArgs e)
        {

        }


        private void cargarSelectorABM() {
            this.selectorABM.Items.Clear();
            this.selectorABM.Items.Add("Alta");
            this.selectorABM.Items.Add("Baja");
            this.selectorABM.Items.Add("Modificar");
        }

        private void selectorABM_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectorABM.SelectedItem == null) {
              MessageBox.Show("Debe seleccionar alguna opcion");
            } else {
                switch (selectorABM.SelectedItem.ToString()) {
                    case "Alta": 
                        this.funcionalidadABM.abrirVentanaAlta();
                        this.Close();
                        break;
                    case "Baja":
                        this.funcionalidadABM.abrirVentanaBaja();
                        this.Close();
                        break;
                    case "Modificar":
                        this.funcionalidadABM.abrirVentanaModificar();
                        this.Close();
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form menu = new Menu(this.username, this.rol);
            menu.Show();
            this.Close();
        }
    }
}

