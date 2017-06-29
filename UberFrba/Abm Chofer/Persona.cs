using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Chofer
{
    public class Persona
    {
        public string nombre;
        public string apellido;
        public string dni;
        public string mail;
        public DateTime fechaNac;

        public Persona(string nombre, string apellido, string dni, string mail, DateTime fechaNac)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.mail = mail;
            this.fechaNac = fechaNac;
        }

    }
}
