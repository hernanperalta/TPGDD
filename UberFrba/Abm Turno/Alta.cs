using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Conexion;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace UberFrba.Abm_Turno
{
    public partial class Alta : Form
    {
        private string errores = "";
        private Form parent;

        public Alta(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void crearTurno_Click(object sender, EventArgs e)
        {
            this.valorDelKm.Text = this.valorDelKm.Text.Replace(",", ".");
            this.precioBase.Text = this.precioBase.Text.Replace(",", ".");

            if (this.hayCamposObligatoriosVacios())
            {
                MessageBox.Show("Debe llenar todos los campos no opcionales antes de crear un chofer");
                return;
            }

            this.validarCampos();

            if (this.errores != "")
            {
                MessageBox.Show(errores);
                this.errores = "";
                return;
            }

            try
            {

                
                DBConexion.ResolverNonQuery("INSERT LOS_CHATADROIDES.Turno (hora_inicio_turno, hora_fin_turno, descripcion, precio_base, valor_del_kilometro, habilitado) "
                                           + " VALUES ("
                                           + this.horaInicio.Value + ", "
                                           + this.horaFin.Value + ", '"
                                           + this.descripcion.Text + "', "
                                           + this.precioBase.Text + ", "
                                           + this.valorDelKm.Text + ", "
                                           + (this.habilitado.Checked ? "1" : "0") + ")");
                
            

                MessageBox.Show("El turno se creó con éxito!");
            }
            catch (SqlException ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private bool hayCamposObligatoriosVacios()
        {
            foreach (Control control in this.Controls)
                if (control is TextBox)
                    if (this.estaVacio((control as TextBox).Text))
                        return true;

            return false;
        }
      
        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void limpiarCampos_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
        }

        private string entreParentesis(string texto)
        {
            return "(" + texto + ")";
        }

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private void validarCampos()
        {
            this.validarRangoHorario();
            this.validarCampo("hora de inicio", this.horaInicio.Text, 18, "^[0-9]+$");
            this.validarCampo("hora de fin", this.horaFin.Text, 18, "^[0-9]+$");
            this.validarCampo("descripcion", this.descripcion.Text, 255, "^[a-zA-Zá-úÁ-Ú0-9- ]+$");
            this.validarCampo("valor del kilometro", this.valorDelKm.Text, 20, "^[0-9]+(.[0-9]+)?$");
            this.validarCampo("precio base", this.precioBase.Text, 20, "^[0-9]+(.[0-9]+)?$");
        }

        private void validarRangoHorario()
        {
            if (this.horaFin.Value - this.horaInicio.Value > 24)
                errores += "No puede ingresar un turno que ocupe mas de un dia";
            if (this.horaFin.Value < this.horaInicio.Value)
                errores += "El turno debe finalizar en el mismo dia";
            if (this.horaFin.Value == this.horaInicio.Value)
                errores += "La hora de inicio del turno no puede ser igual a la hora de finalizacion";

        }

        private void validarCampo(string campoError, string campo, int cantLetras, string expresion)
        {
            this.validarExpresion(expresion, campo, campoError);
            this.validarCantDigitos(cantLetras, campo, campoError);
        }

        private void validarExpresion(string expresion, string campo, string campoError)
        {
            if (campo == "")
                errores += "El campo " + campoError + " esta vacio\n";

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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }
        private void Alta_o_Modificacion_Load(object sender, EventArgs e)
        {
        }

        private void telefonoCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void nombreCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void apellidoCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void dptoYlocalidad_TextChanged(object sender, EventArgs e)
        {
        }

        private void nroPiso_TextChanged(object sender, EventArgs e)
        {
        }

        private void calleYaltura_TextChanged(object sender, EventArgs e)
        {
        }

        private void codPostal_TextChanged(object sender, EventArgs e)
        {
        }

        private void mailCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void fechaNacCli_TextChanged(object sender, EventArgs e)
        {
        }

        private void dniCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void usernameCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void valorDelKm_TextChanged(object sender, EventArgs e)
        {
            //this.validarFloats(20, this.valorDelKm.Text, "valor del kilometro");
        }

        private void horaFin_TextChanged(object sender, EventArgs e)
        {

        }

        private void precioBase_TextChanged(object sender, EventArgs e)
        {
           // this.validarFloats(20, this.precioBase.Text, "precio base");
        }

        private void horaInicio_TextChanged(object sender, EventArgs e)
        {

        }

        private void horaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

   

        private void validarCampoSegunTipo(int tamanio, string regex, string texto, string nombreDeCampo, string mensajeDeError)
        {
            if (!Regex.IsMatch(texto, regex))
            {
                errores += "-El campo " + nombreDeCampo + " " + mensajeDeError + "\n";
            }
            if (texto.Length > tamanio)
            {
                errores += "-El campo " + nombreDeCampo + " no puede tener más de " + tamanio + " dígitos\n";
            }
        }

        private void validarFloats(int tamanio, string texto, string nombreDeCampo)
        {
            this.validarCampoSegunTipo(tamanio, "^[0-9]+(.[0-9]+)?$", texto, nombreDeCampo, "sólo debe tener números y el caracter .");
        }
       
        
    }
}
