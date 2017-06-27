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
    public partial class Baja_o_Modificacion : Form
    {
        string errores = "";
        private string username;
        private string rol;
        private bool puedeDarDeBaja;

        public Baja_o_Modificacion(bool puedeDarDeBaja, string username, string rol)
        {
            InitializeComponent();
            this.username = username;
            this.rol = rol;
            this.puedeDarDeBaja = puedeDarDeBaja;
            if (puedeDarDeBaja)
            {
                this.Text = "Baja Cliente";
                this.bajaOModificacion.Text = "Dar de baja";
            }
            else
            {
                this.Text = "Modificar Cliente";
                this.bajaOModificacion.Text = "Modificar";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();
        }

        private void bajaOModificacion_Click(object sender, EventArgs e)
        {
            this.validarCampos();
            if (this.errores != "")
            {
                MessageBox.Show(errores);
                this.errores = "";
            }
            else
            {
<<<<<<< HEAD
                /*aca crear el objeto con los datos que selecciono del cliente y pasarselo a la ventana siguiente para que lo pueda ver antes de modificar*/
                Form modificar = new Modificacion(this.username, this.rol);
                modificar.Show();
=======
                /*aca crear el objeto con los datos que selecciono del cliente y pasarselo a la ventana siguiente para que lo pueda ver antes de modificar
                Form modificar = new Modificacion(clienteSeleccionado, this.username, this.rol);
                modificar.Show();*/
>>>>>>> d94bfc6f05c23077cd18a0f3e1ca92333c665987
            }
        }

        private void Baja_o_Modificacion_Load(object sender, EventArgs e)
        {

        }
        private void validarCampos()
        {
            this.validarCampo("DNI", this.dniCliente.Text, 18, "^[0-9]+$");
            this.validarCampo("Nombre", this.nombreCliente.Text, 255, "^[a-zA-Z- ]+$");
            this.validarCampo("Apellido", this.apellidoCliente.Text, 255, "^[a-zA-Z- ]+$");
        }

        private void validarCampo(string campoError, string campo, int cantLetras, string expresion)
        {
            this.validarExpresion(expresion, campo, campoError);
            this.validarCantDigitos(cantLetras, campo, campoError);
        }

        private void validarExpresion(string expresion, string campo, string campoError)
        {
            if (campo == "")
                errores += "El campo" + campoError + " esta vacio\n";
            else if (!System.Text.RegularExpressions.Regex.IsMatch(campo, expresion))
            {
                errores += "El campo " + campoError + " posee caracteres invalidos\n";
            }
        }

        private void validarCantDigitos(int cantLetras, string campo, string campoError)
        {
            if (campo.Length > cantLetras)
            {
                errores += "El campo " + campoError + " no puede exceder los " + cantLetras + " digitos\n";
            }
        }

        private void limpiarCampos_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                }
            }
        }
    }
}
