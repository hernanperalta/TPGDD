using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Chofer
{
    public partial class Chofer
    {
        public string nombre;
        public string apellido;
        public int dni;
        public Domicilio domicilio;
        public int telefono;
        public string mail;
        public DateTime fechaNac;
        
        public Chofer(string nombre, string apellido, int dni, Domicilio domicilio, int telefono, string mail, DateTime fechaNac) 
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.mail = mail;
            this.fechaNac = fechaNac;
        }
        
    }
}
