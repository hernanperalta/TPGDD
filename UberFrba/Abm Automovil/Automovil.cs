using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Automovil
{
    public class Automovil
    {

        public string patente;
        public string telefono_chofer;
        public string marca;
        public string modelo;
        public bool habilitado;

        public Automovil(string patente, string telefono_chofer, string marca, string modelo,  bool habilitado)
        {
            this.patente = patente;
            this.telefono_chofer = telefono_chofer;
            this.marca = marca;
            this.modelo = modelo;
            this.habilitado = habilitado;
        }


    }
}
