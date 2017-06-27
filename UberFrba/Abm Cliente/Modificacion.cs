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
    public partial class Modificacion : Form
    {
        string errores = "";
        string username;
        string rol;
        public Modificacion(string username, string rol)
        {
            InitializeComponent();
            this.username = username;
            this.rol = rol;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void apellidoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void dniCliente_TextChanged(object sender, EventArgs e)
        {

        }
        private void guardarCliente_Click(object sender, EventArgs e)
        {
            this.validarCampos();
            if (this.errores != "")
            {
                MessageBox.Show(errores);
                this.errores = "";
            }
            else
            {
                MessageBox.Show("Alta de cliente exitosa");
            }
        }

        private void validarCampos()
        {
            this.validarCampo("DNI", this.dniCliente.Text, 18, "^[0-9]+$");
            this.validarCampo("Localidad Y dpto", this.dptoYlocalidad.Text, 20, "^[a-zA-Z0-9- ]+$");
            this.validarCampo("Calle y altura", this.calleYaltura.Text, 255, "^[a-zA-Z0-9- ]+$");
            this.validarCampo("Nombre", this.nombreCliente.Text, 255, "^[a-zA-Z- ]+$");
            this.validarCampo("Apellido", this.apellidoCliente.Text, 255, "^[a-zA-Z- ]+$");
            this.validarCampo("Codigo Postal", this.codPostal.Text, 5, "^[0-9]+$");
            this.validarCampo("Nro de Piso", this.nroPiso.Text, 5, "^[0-9]+$");
            this.validarCampo("Mail", this.mailCliente.Text, 255, "^[a-zA-Z]+[a-zA-Z0-9]*@[a-zA-Z-.]*.[a-zA-Z]$");
            this.validarCampo("Fecha", this.fechaNacCli.Text, 10, "^[0-9]{2}/[0-9]{2}/[0-9]{4}$");
            if (this.fechaNacCli != null)
                this.validarFecha(this.fechaNacCli.Text);

        }

        private void validarFecha(string fecha)
        {

            try
            {
                string dia = fecha.Substring(0, 2);
                string mes = fecha.Substring(3, 2);
                string anio = fecha.Substring(6, 4);
                if (new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia)) > new DateTime())
                    errores += "La Fecha de nacimiento no puede ser mayor a la actual\n";
            }
            catch (System.ArgumentOutOfRangeException)
            {
                errores += "La Fecha de nacimiento tiene un formato invalido\n";
            }
            catch (System.FormatException)
            {
                errores += "La Fecha de nacimiento es invalida\n";
            }
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
            else
                if (!System.Text.RegularExpressions.Regex.IsMatch(campo, expresion))
                {
                    errores += "El campo" + campoError + " posee caracteres invalidos\n";
                }
        }

        private void validarCantDigitos(int cantLetras, string campo, string campoError)
        {
            if (campo.Length > cantLetras)
            {
                errores += "El campo" + campoError + " no puede exceder los " + cantLetras + " digitos\n";
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

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fechaNacCli_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
