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
            //SqlDataReader reader = DBConexion.ResolverConsulta("LOS_CHATADROIDES.Hashear_Password('lihue')");
            //reader.Read();
            //String s = reader.GetString(0);
            //reader.Close();
            //MessageBox.Show(s);
            //String s = (String) DBConexion.ResolverFuncion("SELECT LOS_CHATADROIDES.Hashear_Password('lihue')");
            //MessageBox.Show(s);
            new Login_Usuario.Login().Show();
            Application.Run();


            
        }
    }
}