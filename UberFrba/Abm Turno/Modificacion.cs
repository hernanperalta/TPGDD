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
using System.Data.SqlClient;

namespace UberFrba.Abm_Turno
{
    public partial class Modificacion : Form
    {
        private string errores = "";
        private Form parent;
        private Turno turno;
        
        public Modificacion(Form parent, Turno turno)
        {
            InitializeComponent();
            this.parent = parent;
            this.turno = turno;
            this.setCampos();
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
                try
                {
                    this.actualizarTurno();
                    MessageBox.Show("Se ha actualizado el turno correctamente");
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Ha habido un error en la actualización");
                }
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

        private void volver_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
            if (Int32.Parse(this.horaFin.Text) - Int32.Parse(this.horaInicio.Text) > 24)
                errores += "No puede ingresar un turno que ocupe mas de un dia";

            if (Int32.Parse(this.horaFin.Text) < Int32.Parse(this.horaInicio.Text))
                errores += "El turno debe finalizar en el mismo dia";
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

        private void setCampos()
        {
            this.horaInicio.Text = this.turno.horaInicio;
            this.horaFin.Text = this.turno.horaFin;
            this.descripcion.Text = this.turno.descripcion;
            this.precioBase.Text = this.turno.precioBase;
            this.valorDelKm.Text = this.turno.valorDelKm;
        }

        private void actualizarTurno()
        {
            DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Turno "
                                        + "SET hora_inicio_turno = " + this.horaInicio.Text + ", "
                                        + "hora_fin_turno = " + this.horaFin.Text + ", "
                                        + "descripcion = '" + this.descripcion.Text + "', "
                                        + "valor_del_kilometro = " + this.valorDelKm.Text + ", "
                                        + "precio_base = " + this.precioBase.Text
                                        + " WHERE hora_inicio_turno = " + this.turno.horaInicio + " AND hora_fin_turno = "
                                        + this.turno.horaFin);
        }

        private void fechaNacCli_TextChanged(object sender, EventArgs e)
        {
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

        private void Modificacion_Load(object sender, EventArgs e)
        {
        }

        private void direccionCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void deptoCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void nombreCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void usernameCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void fechaNacCli_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nroPiso_TextChanged(object sender, EventArgs e)
        {

        }

        private void telefonoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void horaInicio_TextChanged(object sender, EventArgs e)
        {

        }

        
        
        
    }
}
