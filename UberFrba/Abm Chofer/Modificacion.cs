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
    public partial class Modificacion : Form
    {
        private string usernameActual;
        private string rolActual;

        public Modificacion(Chofer choferAModificar, string usernameActual, string rolActual)
        {
            InitializeComponent();
            this.usernameActual = usernameActual;
            this.rolActual = rolActual;
            this.telefonoChofer.Text = choferAModificar.telefono.ToString();
            this.apellidoChofer.Text = choferAModificar.apellido;
            this.nombreChofer.Text = choferAModificar.nombre;
            this.fechaNacChofer.Value = choferAModificar.fechaNac;
            this.dniChofer.Text = choferAModificar.dni.ToString();
            this.mailChofer.Text = choferAModificar.mail;
            this.direccionChofer.Text = choferAModificar.domicilio.direccion;
            this.deptoChofer.Text = choferAModificar.domicilio.depto;
            this.nroPisoChofer.Text = choferAModificar.domicilio.nroPiso;
            this.localidadChofer.Text = choferAModificar.domicilio.localidad;

            // TODO ver que onda con el tema del username de chofer en modificar
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            /*Form menu = new Menu.Menu(this.usernameActual, this.rolActual);
            menu.Show();
            this.Close();*/
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox)
                    (ctrl as TextBox).Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        
    }
}
