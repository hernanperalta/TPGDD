using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Chofer
{
    public class UpdateBuilder
    {
        private string condicion;
        private string query;
        private bool tieneSets = false;

        public UpdateBuilder(string tabla, string condicion)
        {
            this.condicion = condicion;
            this.query = "UPDATE " + tabla + " SET ";
        }

        public string obtenerUpdate()
        {
            if (!this.tieneSets)
                throw new ElUpdateNoTieneSetsException("La query que pidio no tiene sets");

            return this.query + " " + this.condicion;
        }

        public bool tieneSetsAgregados()
        {
            return this.tieneSets;
        }

        public void agregarFiltro(string nombreDeCampo, string valorNuevo, string wrap)
        {
            string prefijo = "";

            if (this.tieneSets)
                prefijo = ",";
                
            query += prefijo + nombreDeCampo + " = " + wrap + valorNuevo + wrap;

            this.tieneSets = true;
        }

    }
}
