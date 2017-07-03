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
using UberFrba.Login_Usuario;
using System.Configuration;

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
            
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //DBConexion.Conectar();

            new Login().Show();
            //new Abm_Rol.Baja(new Form()).Show();
            
            Application.Run();

            
            //DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateFormat"]);
            //var appDate = DateTime.Parse(value);


          

        }
    }
}