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

namespace UberFrba.Registro_Viajes
{
    public partial class Registro_Viajes : Form
    {

        private string rol;
        private string username;
        private string errores;

        public Registro_Viajes(String username, String rol)
        {
            InitializeComponent();
            this.username = username;
            this.rol = rol;
            this.cargarTurnos();

            this.fechaDelViaje.Format = DateTimePickerFormat.Custom;
            this.fechaDelViaje.CustomFormat = "dd-MM-yyyy";

            this.horaInicio.Format = DateTimePickerFormat.Custom;
            this.horaInicio.CustomFormat = "HH:mm:ss";

            this.horaFin.Format = DateTimePickerFormat.Custom;
            this.horaFin.CustomFormat = "HH:mm:ss";
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();
        }

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }

        private bool hayCamposObligatoriosVacios()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    if (this.estaVacio((control as TextBox).Text))
                        return true;

                if (control is ComboBox)
                    if ((control as ComboBox).SelectedIndex == -1)
                        return true;
            }

            return false;
        }

        private void registrarCliente_Click(object sender, EventArgs e)
        {
            if (this.hayCamposObligatoriosVacios())
            {
                MessageBox.Show("Debe llenar todos los campos obligatorios para registrar un viaje");
                return;
            }

            this.errores = "";
            this.validarCampos();

            if (errores != "")
            {
                MessageBox.Show(errores);
                return;
            }

            try
            {
                this.registrarViaje();
                MessageBox.Show("El viaje se ha registrado con exito");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void setCliente(string telefonoCliente)
        {
            this.telefonoCliente.Text = telefonoCliente;
        }

        private void buscarCliente_Click(object sender, EventArgs e)
        {
            new Seleccionar_Cliente(this).Show();
        }

        private void validarCampos()
        {
            this.validarCampo("Cantidad de kilometros del viaje", this.cantKm.Text, 18, "^[0-9]+$");
        }

        private void validarCampo(string campoError, string campo, int cantLetras, string expresion)
        {
            this.validarExpresion(expresion, campo, campoError);
            this.validarCantDigitos(cantLetras, campo, campoError);
        }

        private void validarExpresion(string expresion, string campo, string campoError)
        {
            if (campo == "")
            {
                errores += "El campo " + campoError + " esta vacio\n";
                
            }
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

        private void limpiar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Clear();
                }

                if (ctrl is ComboBox)
                    (ctrl as ComboBox).SelectedIndex = -1;
            }
        }

        private void buscarChofer_Click(object sender, EventArgs e)
        {
            new Seleccionar_Choferes(this).Show();
        }

        private void registrarViaje()
        {
            string insert = "INSERT INTO LOS_CHATADROIDES.Viaje "
                        + "(telefono_chofer, patente, telefono_cliente, hora_inicio_turno, hora_fin_turno, "
                        + " fecha_y_hora_inicio_viaje, fecha_y_hora_fin_viaje, kilometros_del_viaje) VALUES "
                        + "(" + this.telefonoChofer.Text + "," + "'" + this.patente.Text + "'," + this.telefonoCliente.Text + ", "
                        + ((Turno)this.turnos.SelectedItem).horaInicioTurno + "," + ((Turno)this.turnos.SelectedItem).horaFinTurno + ",'" 
                        + this.fechaDelViaje.Value.ToString("d") + " " + this.horaInicio.Value.TimeOfDay + "', '"
                        + this.fechaDelViaje.Value.ToString("d") + " " + this.horaFin.Value.TimeOfDay + "', " + this.cantKm.Text + ")";
            
            MessageBox.Show(insert);

            DBConexion.ResolverNonQuery(insert);
        }

        public void setChofer(string telefono, string patente)
        {
            this.telefonoChofer.Text = telefono;
            this.patente.Text = patente;
        }

        private void cargarTurnos()
        {
            SqlDataReader turno = this.leerTurnos();

            while (turno.Read())
            {
                this.turnos.Items.Add(new Turno(turno.GetDecimal(0).ToString(), turno.GetDecimal(1).ToString(), turno.GetString(2)));
            }
            turno.Close();
        }

        private SqlDataReader leerTurnos()
        {
            return DBConexion.ResolverQuery("SELECT hora_inicio_turno, hora_fin_turno, descripcion FROM LOS_CHATADROIDES.Turno WHERE habilitado = 1");
        }

        private void turnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.turnos.SelectedIndex != -1)
            {
                Turno turnoElegido = (Turno)this.turnos.SelectedItem;
                this.horaInicioTurno.Text = turnoElegido.horaInicioTurno;
                this.horaFinTurno.Text = turnoElegido.horaFinTurno;
            }
        }

        private void telefonoChofer_TextChanged(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void telefonoCliente_TextChanged(object sender, EventArgs e)
        {
        }
        private void label7_Click(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void horaInicioTurno_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void horaFinTurno_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void horaInicio_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void fechaDelViaje_ValueChanged(object sender, EventArgs e)
        {
           
        }
     }
}
