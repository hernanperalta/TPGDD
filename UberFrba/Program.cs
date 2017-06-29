using System;
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
using UberFrba.Listado_Estadistico;

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
       
            new Listado_Estadistico.Listado_Estadistico("admin", "Administrador").Show();

            //new Abm_Cliente.Alta("admin", "Administrador").Show();

            Application.Run();

            
            
        }
    }
}