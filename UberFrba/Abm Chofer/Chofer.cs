using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Chofer
{
    public partial class Chofer
    {
        public Persona datos;
        public Domicilio domicilio;
        public string telefono;
        public string username;
        public bool habilitado;
        public string patente;

        public Chofer(Persona datos, Domicilio domicilio, string telefono, string username, string patente, bool habilitado) 
        {
            this.datos = datos;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.username = username;
            this.habilitado = habilitado;
            this.patente = patente;
        }

        public Chofer(Persona datos, Domicilio domicilio, string telefono, string username, bool habilitado)
        {
            this.datos = datos;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.username = username;
            this.habilitado = habilitado;
        }

        public Chofer()
        { }

    }
}
