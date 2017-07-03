using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Registro_Viajes
{
    public partial class Chofer
    {
        public Persona datos;
        public Domicilio domicilio;
        public string telefono;
        public string username;
        public bool habilitado;
        public string patente;
        
        public Chofer(Persona datos, Domicilio domicilio, string telefono, string username, bool habilitado, string patente) 
        {
            this.datos = datos;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.username = username;
            this.habilitado = habilitado;
            this.patente = patente;
        }
        public Chofer()
        { }

    }
}
