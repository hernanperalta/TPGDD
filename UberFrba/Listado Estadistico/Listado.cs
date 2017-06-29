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

namespace UberFrba.Listado_Estadistico
{
    class Listado
    {
        private string nombre;
        private string query;
        //DataTable listado = new DataTable();

        public Listado(string nombre, string query)
        {
            this.nombre = nombre;
            this.query = query;
        }

        public void setQuery(string query)
        {
            this.query = query;
        }

        public DataTable obtenerListado(string anio, string trimestre)
        {

            DataTable listado = new DataTable();
            listado.Load(DBConexion.ResolverQuery(this.query.Replace("anioSeleccionado", anio)
                                                               .Replace("trimestreSeleccionado", trimestre)));

            return listado;
        }

        public override string ToString()
        {
            return this.nombre;
        }

    }
}
