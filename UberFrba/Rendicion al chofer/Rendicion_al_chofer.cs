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
using UberFrba.Registro_Viajes;
using System.Data.SqlClient;

namespace UberFrba.Rendicion_al_chofer
{
    public partial class Rendicion_al_chofer : Form
    {
        /*
        5598227
        6473234
        */
        private string username;
        private string rol;
        private string errores = "";
        private DataTable viajes = new DataTable();

        public Rendicion_al_chofer(string username, string rol)
        {
            InitializeComponent();
            this.username = username;
            this.rol = rol;
            this.porcentaje.Text = "100";
        }

        private void Rendicion_al_chofer_Load(object sender, EventArgs e)
        {

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
            return DBConexion.ResolverQuery("SELECT T.hora_inicio_turno, T.hora_fin_turno, descripcion FROM LOS_CHATADROIDES.Turno T JOIN LOS_CHATADROIDES.Viaje V "
                                            + "ON(T.hora_inicio_turno = V.hora_inicio_turno AND T.hora_fin_turno = V.hora_fin_turno) "
                                            + "WHERE V.telefono_chofer = " + this.telefonoChofer.Text
                                            + " GROUP BY T.hora_inicio_turno, T.hora_fin_turno, descripcion");
        }

        public void setChofer(string telefono)
        {
            this.turnos.Items.Clear();
            this.telefonoChofer.Text = telefono;
            this.noChoferLabel.Text = "";
            this.cargarTurnos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Seleccion_de_choferes(this).Show();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            new Menu.Menu(this.username, this.rol).Show();
        }

        private void turnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.telefonoChofer.Text.Equals(""))
            {
                MessageBox.Show("Primero debe oprimir el boton \"Buscar chofer\"");
                return;
            }

            if (this.turnos.SelectedIndex != -1)
            {
                Turno turnoElegido = (Turno)this.turnos.SelectedItem;
                this.horaInicioTurno.Text = turnoElegido.horaInicioTurno;
                this.horaFinTurno.Text = turnoElegido.horaFinTurno;
            }
        }

        private void cargarViajes()
        {
            this.viajes.Clear();

            string query = "SELECT numero_viaje as 'Nro. Viaje', telefono_chofer as 'Telefono chofer', "
                                                            + "patente as Patente, telefono_cliente as 'Telefono cliente', fecha_y_hora_inicio_viaje  "
                                                            + "as 'Fecha y comienzo del viaje' , fecha_y_hora_fin_viaje as 'Fecha y fin de viaje' , "
                                                            + "precio_base as 'Precio base', valor_del_kilometro as 'Valor del kilometro', "
                                                            + "precio_base + (valor_del_kilometro * kilometros_del_viaje) as 'Importe del viaje' "
                                                            + "FROM LOS_CHATADROIDES.Viaje V "
                                                            + "JOIN LOS_CHATADROIDES.Turno T "
                                                            + "ON ( V.hora_inicio_turno = T.hora_inicio_turno AND V.hora_fin_turno = T.hora_fin_turno ) "
                                                            + "WHERE telefono_chofer = " + this.telefonoChofer.Text
                                                            + " AND V.hora_inicio_turno = " + this.horaInicioTurno.Text
                                                            + " AND V.hora_fin_turno = " + this.horaFinTurno.Text
                                                            + " AND CAST(fecha_y_hora_inicio_viaje AS DATE) = '" + this.fechaRendicion.Value.ToString("d")
                                                            + "' AND nro_rendicion IS NULL";

            SqlDataReader reader = DBConexion.ResolverQuery(query);

            this.viajes.Load(reader);

            this.viajesGrid.DataSource = this.viajes;
        }


        private void telefonoChofer_TextChanged(object sender, EventArgs e)
        {

        }

        private void guardarRendicion_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cargarDatos_Click(object sender, EventArgs e)
        {
            
            if (this.telefonoChofer.Text.Equals(""))
            {
                MessageBox.Show("Debe oprimir el boton \"Buscar chofer\".");
                return;
            }
            if (this.turnos.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un turno para cargar los datos.");
                return;
            }

            this.validarPorcentaje();

            if(!this.errores.Equals(""))
            {
                MessageBox.Show(this.errores);
                this.errores = "";
                return;
            }

            try
            {
                this.cargarViajes();
                this.obtenerImporteTotal();
            }
            catch (SinRegistrosException)
            {
                MessageBox.Show("No hay viajes pendientes de rendir para ese chofer, dia y turno");
            }
            
        }

        private void obtenerImporteTotal()
        {
            double impTotal = 0.0;
            double porc = 1.0;
            if (this.porcentaje.Text != "")
                porc = Convert.ToDouble(this.porcentaje.Text) / 100;

            foreach (DataGridViewRow importe in this.viajesGrid.Rows)
            {
                impTotal += Convert.ToDouble(importe.Cells[8].Value);
            }

            this.importeTotalDia.Text = (porc * impTotal).ToString();
 
        }

        private void validarPorcentaje()
        {
            this.validarExpresion("^[0-9]+$", this.porcentaje.Text, "porcentaje");
            this.validarCantDigitos(5, this.porcentaje.Text, "porcentaje");
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

        private void viajesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void porcentaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}
