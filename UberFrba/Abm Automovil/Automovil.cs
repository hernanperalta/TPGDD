using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Automovil
{
    class Automovil
    {

        public string patente;
        public string telefono_chofer;
        public string marca;
        public string modelo;
        public string licencia;
        public string rodado;
        public bool habilitado;

        public Automovil(string patente, string telefono_chofer, string marca, string modelo, string licencia, string rodado, bool habilitado)
        {
            this.patente = patente;
            this.telefono_chofer = telefono_chofer;
            this.marca = marca;
            this.modelo = modelo;
            this.licencia = licencia;
            this.rodado = rodado;
            this.habilitado = habilitado;
        }


    }
}
