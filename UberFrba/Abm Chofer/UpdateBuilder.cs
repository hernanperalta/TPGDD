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
        private string queryConSets;
        private bool tieneSets = false;

        public UpdateBuilder(string tabla, string condicion)
        {
            this.condicion = condicion;
            this.query = "UPDATE " + tabla + " SET ";
            this.queryConSets = query;
        }

        public string obtenerUpdate()
        {
            if (!this.tieneSets)
                throw new ElUpdateNoTieneSetsException("La query que pidio no tiene sets");

            return this.queryConSets + " " + this.condicion;
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

            queryConSets += prefijo + nombreDeCampo + " = " + wrap + valorNuevo + wrap;

            this.tieneSets = true;
        }

        public void resetearUpdate()
        {
            this.queryConSets = this.query;
            this.tieneSets = false;
        }

    }
}
