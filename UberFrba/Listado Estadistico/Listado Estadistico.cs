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
using System.Configuration;

namespace UberFrba.Listado_Estadistico
{
    public partial class Listado_Estadistico : Form
    {

        private String username;
        private String rol;
        private DataTable listado = new DataTable();
        private DateTime fechaActual = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["Fecha"]);

        public Listado_Estadistico(String username, String rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.username = username;
            anio.Format = DateTimePickerFormat.Custom;
            anio.CustomFormat = "yyyy";
            anio.ShowUpDown = true;
            anio.MaxDate = fechaActual;
            this.listados.DropDownStyle = ComboBoxStyle.DropDownList;

            this.listados.Items.Add(new Listado("Choferes con mayor recaudación", "SELECT TOP 5 C.telefono as Telefono, nombre as Nombre, apellido as Apellido, dni as DNI, SUM(importe_total) as Recaudacion "
                                                                                + "FROM LOS_CHATADROIDES.Chofer C JOIN LOS_CHATADROIDES.Viaje V "
	                                                                            + "ON(C.telefono = V.telefono_chofer) "
	                                                                            + "JOIN LOS_CHATADROIDES.Rendicion R "
     		                                                                    + "ON(V.nro_rendicion = R.nro_rendicion) "
                                                                                + "WHERE YEAR(V.fecha_y_hora_inicio_viaje) = anioSeleccionado "
                                                                                + "AND LOS_CHATADROIDES.Esta_en_trimestre(MONTH(fecha_y_hora_inicio_viaje), trimestreSeleccionado) = 1 "
                                                                                + "GROUP BY telefono, nombre, apellido, dni "
                                                                                + "ORDER BY 5 DESC"));

            this.listados.Items.Add(new Listado("Choferes con el viaje más largo realizado", "SELECT TOP 5 telefono as Telefono, nombre as Nombre, apellido as Apellido, dni as DNI, numero_viaje as 'Numero viaje', kilometros_del_viaje as 'Kilometros de viaje' "
                                                                                            + "FROM LOS_CHATADROIDES.Chofer C JOIN LOS_CHATADROIDES.Viaje V "
	                                                                                        + "ON(C.telefono = V.telefono_chofer) "
                                                                                            + "WHERE YEAR(V.fecha_y_hora_inicio_viaje) = anioSeleccionado "
                                                                                            + "AND LOS_CHATADROIDES.Esta_en_trimestre(MONTH(fecha_y_hora_inicio_viaje), trimestreSeleccionado) = 1 "
                                                                                            + "ORDER BY 6 DESC"));


            this.listados.Items.Add(new Listado("Clientes con mayor consumo", "SELECT TOP 5 telefono as Telefono, nombre as Nombre, apellido as Apellido, dni as DNI, COUNT(numero_viaje) 'Cantidad de viajes' "
                                                                            + "FROM LOS_CHATADROIDES.Cliente C JOIN LOS_CHATADROIDES.Viaje V "
                                                                            + "ON(C.telefono = V.telefono_cliente) "
                                                                            + "WHERE YEAR(V.fecha_y_hora_inicio_viaje) = anioSeleccionado "
                                                                            + "AND LOS_CHATADROIDES.Esta_en_trimestre(MONTH(fecha_y_hora_inicio_viaje), trimestreSeleccionado) = 1 "
                                                                            + "GROUP BY telefono, nombre, apellido, dni "
                                                                            + "ORDER BY 5 DESC"));

      
            this.listados.Items.Add(new Listado("Cliente que utilizo más veces el mismo automóvil", "SELECT TOP 5 telefono as Telefono, nombre as Nombre, apellido as Apellido, dni as DNI, COUNT(DISTINCT patente) as 'Veces que uso el mismo auto' "
                                                                                                                                + "FROM LOS_CHATADROIDES.Cliente C JOIN LOS_CHATADROIDES.Viaje V "
                                                                                                                                + "ON(C.telefono = V.telefono_cliente) "
                                                                                                                                + "WHERE YEAR(V.fecha_y_hora_inicio_viaje) = anioSeleccionado "
                                                                                                                                + "AND LOS_CHATADROIDES.Esta_en_trimestre(MONTH(fecha_y_hora_inicio_viaje), trimestreSeleccionado) = 1 "
                                                                                                                                + "GROUP BY telefono, nombre, apellido, dni "
                                                                                                                                + "ORDER BY 5 DESC"));

        }

        private void trimestre_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            Form menu = new Menu.Menu(this.username, this.rol);
            menu.Show();
            this.Close();
        }

        private void anio_ValueChanged(object sender, EventArgs e)
        {
            if (anio.Value.Year > fechaActual.Year)
            {
                MessageBox.Show("El año no puede ser superior al actual");
                this.anio.Value = fechaActual;
                return;
            }
        }

        private void consultar_Click(object sender, EventArgs e)
        {
           
            listado.Clear();
            if (this.listados.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de listado para continuar.");
                return;
            }
     
            try
            {
                listado = (this.listados.SelectedItem as Listado).obtenerListado(this.anio.Value.Year.ToString(), this.trimestre.Text);
                this.listadoEstadistico.DataSource = listado;
            }
            catch (SinRegistrosException)
            {
                MessageBox.Show("No hay registros para el trimestre y año seleccionado");
                return;
            }
      
            

        } 
    }
}
