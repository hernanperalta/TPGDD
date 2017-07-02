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
    public partial class Baja_o_Modificacion : Form
    {
        string errores = "";
        private Form parent;
        private bool puedeDarDeBaja;
        Turno turno = new Turno();
        DataTable turnos = new DataTable();

        public Baja_o_Modificacion(Form parent, bool puedeDarDeBaja)
        {
            InitializeComponent();
            this.parent = parent;
            this.puedeDarDeBaja = puedeDarDeBaja;
            this.setNombrePanel();
            this.noTurnosLabel.Text = "";
        }

        private void Baja_o_Modificacion_Load(object sender, EventArgs e)
        {

        }
        private void bajaOModificacion_Click(object sender, EventArgs e)
        {
            if (this.turnosGrid.RowCount == 0)
            {
                MessageBox.Show("Para llenar la lista de turnos disponibles haga click en el boton 'Buscar todos'");
                return;
            }
            if (this.turnosGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar de a un turno");
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
                this.setTurno();

                if (this.puedeDarDeBaja)
                {
                    this.deshabilitarTurno();
                    return;
                }

                Form modificar = new Modificacion(this, turno);
                modificar.Show();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Para elegir a un turno debe oprimir la flecha que se encuentra a la izquierda de la fila");
                return;
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

      

        private void buscarTurnos_Click(object sender, EventArgs e)
        {
            this.buscarTodos("");
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void rehabilitar_Click(object sender, EventArgs e)
        {
            if (this.turnosGrid.RowCount == 0)
            {
                MessageBox.Show("Para llenar la lista de turnos disponibles haga click en el boton 'Buscar todos'");
                return;
            }
            if (this.turnosGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar de a un turno");
                return;
            }
            this.rehabilitarTurno();
        }

        private void deshabilitarTurno()
        {
            if (turno.habilitado)
            {
                DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Turno "
                                           + "SET habilitado = 0 "
                                           + "WHERE hora_inicio_turno = " + turno.horaInicio + " AND hora_fin_turno = " + turno.horaFin);

                this.listarTurnos(this.descripcion.Text);

                MessageBox.Show("El turno " + turno.descripcion + "\nHa sido dado de baja");

                return;
            }
            MessageBox.Show("El turno " + turno.descripcion + "\nYa se encuentra deshabilitado");
            return;
        }

        private void rehabilitarTurno()
        {
            try
            {
                this.setTurno();
                if (!turno.habilitado)
                {
                    DBConexion.ResolverNonQuery("UPDATE LOS_CHATADROIDES.Turno "
                                               + "SET habilitado = 1 "
                                               + "WHERE hora_inicio_turno = " + turno.horaInicio + " AND hora_fin_turno = " + turno.horaFin);

                    this.listarTurnos(this.descripcion.Text);

                    MessageBox.Show("El turno " + turno.descripcion + "\nHa sido rehabilitado");

                    return;
                }
                MessageBox.Show("El turno " + turno.descripcion + "\nYa se encuentra habilitado");
                return;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Ya existe un turno habilitado en esa franja horaria");

                if (ex.Number == 52000)
                    MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Para elegir a un turno debe oprimir la flecha que se encuentra a la izquierda de la fila");
                return;
            }

        }

        private void validarCampos()
        {
            this.validarCampo("Descripcion", this.descripcion.Text, 255, "^[a-zA-Zá-úÁ-Ú ]+$");
        }

        private void validarCampo(string campoError, string campo, int cantLetras, string expresion)
        {
            this.validarExpresion(expresion, campo, campoError);
            this.validarCantDigitos(cantLetras, campo, campoError);
        }

        private void validarExpresion(string expresion, string campo, string campoError)
        {
            if (campo == "")
                return;
            else if (!Regex.IsMatch(campo, expresion))
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

        private void setTurno()
        {
            int i = this.turnosGrid.SelectedRows[0].Index;
            DataRow row = turnos.Rows[i];

            turno.horaInicio = row["Hora de inicio"].ToString();
            turno.horaFin = row["Hora de fin"].ToString();
            turno.descripcion = row["Descripcion"].ToString();
            turno.precioBase = row["Precio base"].ToString();
            turno.valorDelKm = row["Valor del kilometro"].ToString();
            turno.habilitado = Convert.ToBoolean(row["Habilitado"].ToString());
        }

        private void listarTurnos(string descripcion)
        {
            turnos.Clear();
            try
            {
                turnos.Load(DBConexion.ResolverQuery("SELECT hora_inicio_turno as 'Hora de inicio', hora_fin_turno as 'Hora de fin', "
                                                     + "descripcion as 'Descripcion', precio_base as 'Precio base', "
                                                     + "valor_del_kilometro as 'Valor del kilometro', habilitado as Habilitado "
                                                     + "FROM LOS_CHATADROIDES.Turno "
                                                     + "WHERE descripcion LIKE '%" + descripcion + "%'"));

                this.noTurnosLabel.Text = "";
            }
            catch (SinRegistrosException)
            {

                this.noTurnosLabel.Text = "No se encontraron turnos";
                return;
            }
        }

        private void setNombrePanel()
        {
            if (puedeDarDeBaja)
            {
                this.Text = "Baja Turno";
                this.bajaOModificacion.Text = "Dar de baja";
                this.rehabilitar.Visible = false;
            }
            else
            {
                this.Text = "Modificar Turno";
                this.bajaOModificacion.Text = "Modificar";
            }
        }

        private void buscarTodos(string descripcion)
        {
            this.validarCampos();
            if (this.errores != "")
            {
                MessageBox.Show(errores);
                this.errores = "";
                return;
            }
            this.listarTurnos(descripcion);

            this.turnosGrid.DataSource = turnos;
        }
        
        private void descripcion_TextChanged(object sender, EventArgs e)
        {
            this.buscarTodos(this.descripcion.Text);
        }
        
    }
}
