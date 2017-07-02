using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Registro_Viajes
{
    public partial class Domicilio
    {
        public string direccion;
        public string nroPiso;
        public string depto;
        public string localidad;

        public Domicilio(string direccion, string nroPiso, string depto, string localidad) 
        {
            this.direccion = direccion;
            this.nroPiso = nroPiso;
            this.depto = depto;
            this.localidad = localidad;
        }
    }
}
