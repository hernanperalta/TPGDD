using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UberFrba.Conexion;
using System.Data.SqlClient;
using System.Configuration;

namespace UberFrba.Facturacion
{
    public partial class Facturacion_Cliente : Form
    {

        private String username;
        private String rol;
        private string errores = "";
        private DataTable viajesSinFacturar = new DataTable();
        private DateTime fechaFacturacion = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["Fecha"]);

        public Facturacion_Cliente(String username, String rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.username = username;
            this.fechaInicio.Value = new DateTime(fechaFacturacion.Year, fechaFacturacion.Month, 1);
            this.fechaFin.Value = new DateTime(fechaFacturacion.Year, fechaFacturacion.Month, DateTime.DaysInMonth(fechaFacturacion.Year, fechaFacturacion.Month));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void validarCampoSegunTipo(int tamanio, string regex, string texto, string nombreDeCampo, string mensajeNoMatcheo)
        {
            if (texto.Equals(""))
                errores += "-El campo" + nombreDeCampo + " esta vacio \n";

            if (!Regex.IsMatch(texto, regex))
                errores += "-El campo " + nombreDeCampo + " " + mensajeNoMatcheo + "\n";

            if (texto.Length > tamanio)
                errores += "-El campo " + nombreDeCampo + " no puede tener más de " + tamanio + " dígitos\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.viajesSinFacturarGrid.RowCount == 0)
            {
                MessageBox.Show("Primero debe cargar los datos");
                return;
            }
            if (this.telefonoTB.Text.Equals(""))
                MessageBox.Show("Ingrese el telefono del cliente para facturar.");
            else
            {
                this.cargarDatosDeClienteYFactura();
                // ACA HACER QUE FACTURE => INSERT
                try
                {
                    DBConexion.ResolverNonQuery("EXEC LOS_CHATADROIDES.Crear_factura " + this.telefonoTB.Text + ", " + this.importeTotal.Text.Replace(",", ".") + ", '" + this.fechaFacturacion + "', '" + this.fechaInicio.Value + "', '" + this.fechaFin.Value + "'");
                    MessageBox.Show("Facturacion realizada");
                } catch (SqlException)
                {
                    MessageBox.Show("No se pudo facturar");
                }

                //MessageBox.Show(this.fechaInicio.Value.ToString());
                
            }

        }

        private void cargarDatosDeLaFactura() {

            string query =
            "SELECT numero_viaje as 'Numero Viaje', "
            + "telefono_chofer as 'Telefono Chofer', "
            + "fecha_y_hora_inicio_viaje 'Fecha y hora inicio viaje', "
            + "fecha_y_hora_fin_viaje as 'Fecha y hora fin viaje' , "
            + "descripcion as Descripcion, valor_del_kilometro as 'Valor del kilometro', "
            + "precio_base as 'Precio base', kilometros_del_viaje as 'Kilometros del viaje' , "
            + "valor_del_kilometro * kilometros_del_viaje + precio_base as 'Importe del viaje' " +
            "FROM LOS_CHATADROIDES.Viaje V " +
            "JOIN LOS_CHATADROIDES.Turno T " +
                "ON(V.hora_inicio_turno = T.hora_inicio_turno AND V.hora_fin_turno = T.hora_fin_turno) " +
                "WHERE id_factura IS NULL AND telefono_cliente = " + this.telefonoTB.Text ;

            double importeFactura = 0.0;
            
             try
            {
                SqlDataReader reader = DBConexion.ResolverQuery(query);
               
                viajesSinFacturar.Load(reader);
                this.viajesSinFacturarGrid.DataSource = viajesSinFacturar;

                foreach (DataGridViewRow viaje in this.viajesSinFacturarGrid.Rows)
                {
                    double aux = 0.0;
                    Double.TryParse(viaje.Cells[8].Value.ToString(), out aux);
                    importeFactura += aux;
                }

                this.importeTotal.Text = String.Format("{0:0.00}", importeFactura);



            }
            catch (SinRegistrosException)
            {
               MessageBox.Show("No hay viajes pendientes de facturacion.");
            }
          

           

        }

        private void validarSiExisteElCliente() {
            this.viajesSinFacturar.Clear();
            try
            {
                SqlDataReader reader = DBConexion.ResolverQuery("SELECT CONVERT(VARCHAR(20), telefono), nombre, apellido, username FROM LOS_CHATADROIDES.Cliente WHERE telefono = " + this.telefonoTB.Text);
                reader.Read();
                this.completarDatosCliente(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                reader.Close();
                this.cargarDatosDeLaFactura();
              
            }
            catch (SinRegistrosException) 
            {
                MessageBox.Show("No existe el cliente con numero de telefono " + this.nombreUsuarioTB.Text);
            }
        }

        private void completarDatosCliente(string telefono, string nombre, string apellido, string nombreUsuario) {
            this.telefonoTB.Text = telefono;
            this.nombreTB.Text = nombre;
            this.apellidoTB.Text = apellido;
            this.nombreUsuarioTB.Text = nombreUsuario;
        }

        private void cargarDatos_Click(object sender, EventArgs e)
        {
            this.cargarDatosDeClienteYFactura();
            
        }

        private void cargarDatosDeClienteYFactura(){
            this.validarCampoSegunTipo(18, "^[0-9]+$", this.telefonoTB.Text, "Telefono del cliente", "contiene caracteres invalidos");

            if (!errores.Equals(""))
            {
                MessageBox.Show(errores);
                errores = "";
                return;
            }

            this.validarSiExisteElCliente();
            
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox)
                    (ctrl as TextBox).Clear();
            this.viajesSinFacturar.Clear();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
