﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.Conexion;
using UberFrba.Facturacion;

namespace UberFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBConexion.Conectar();
       
            //new Listado_Estadistico.Listado_Estadistico("admin", "Administrador").Show();
            //new Alta_de_Usuario.Alta_de_Usuario("admin", "Administrador").Show();
            new Abm_Cliente.Baja_o_Modificacion(false,"admin", "Administrador").Show();

            //new Facturacion.Facturacion_Cliente("admin", "Administrador").Show();

            Application.Run();

            
            
        }
    }
}