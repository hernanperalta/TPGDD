﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Conexion;

namespace UberFrba.Listado_Estadistico
{
    public partial class Listado_Estadistico : Form
    {

        private String username;
        private String rol;
        private DataTable listado = new DataTable();

        public Listado_Estadistico(String username, String rol)
        {
            InitializeComponent();
            this.rol = rol;
            this.username = username;
            anio.Format = DateTimePickerFormat.Custom;
            anio.CustomFormat = "yyyy";
            anio.ShowUpDown = true;

            this.listados.Items.Add(new Listado("Chóferes con mayor recaudación", "SELECT TOP 5 C.telefono, nombre, apellido, dni, SUM(importe_total) "
                                                                                + "FROM LOS_CHATADROIDES.Chofer C JOIN LOS_CHATADROIDES.Viaje V "
	                                                                            + "ON(C.telefono = V.telefono_chofer) "
	                                                                            + "JOIN LOS_CHATADROIDES.Rendicion R "
     		                                                                    + "ON(V.nro_rendicion = R.nro_rendicion) "
                                                                                + "WHERE YEAR(V.fecha_y_hora_inicio_viaje) = anioSeleccionado "
                                                                                + "AND LOS_CHATADROIDES.Esta_en_trimestre(MONTH(fecha_y_hora_inicio_viaje), trimestreSeleccionado) = 1 "
                                                                                + "GROUP BY telefono, nombre, apellido, dni "
                                                                                + "ORDER BY 5 DESC"));

            this.listados.Items.Add(new Listado(, "SELECT TOP 5 telefono, nombre, apellido, dni, numero_viaje, kilometros_del_viaje "
                                                                                + "FROM LOS_CHATADROIDES.Chofer C JOIN LOS_CHATADROIDES.Viaje V "
	                                                                            + "ON(C.telefono = V.telefono_chofer) "
                                                                                + "WHERE YEAR(V.fecha_y_hora_inicio_viaje) = anioSeleccionado "
                                                                                + "AND LOS_CHATADROIDES.Esta_en_trimestre(MONTH(fecha_y_hora_inicio_viaje), trimestreSeleccionado) = 1 "
                                                                                + "ORDER BY 6 DESC"));
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
            if (anio.Value.Year > DateTime.Today.Year)
            {
                MessageBox.Show("El año no puede ser superior al actual");
                this.anio.Value = DateTime.Today;
                return;
            }
        }

        private void consultar_Click(object sender, EventArgs e)
        {
            //this.listadoEstadistico.DataSource = (this.listados.SelectedItem as Listado).obtenerListado(this.anio.Value.Year.ToString(), this.trimestre.Text);
            /*listado.Clear();
            listado = (this.listados.SelectedItem as Listado).obtenerListado(this.anio.Value.Year.ToString(), this.trimestre.Text);
            this.listadoEstadistico.DataSource = listado;*/

            listado.Clear();

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
