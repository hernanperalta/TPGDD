using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Chofer
{
    public class Chofer
    {
        /*
         telefono NUMERIC(18,0) PRIMARY KEY,
	    localidad VARCHAR(20) NOT NULL DEFAULT 'Sin Especificar',
	    direccion VARCHAR(255) NOT NULL,
	    nombre VARCHAR(255) NOT NULL,
	    apellido VARCHAR(255) NOT NULL,
	    dni NUMERIC(18,0) NOT NULL,
	    fecha_de_nacimiento DATETIME NOT NULL,
	    mail VARCHAR(50),
	    username VARCHAR(50) UNIQUE NOT NULL FOREIGN KEY REFERENCES LOS_CHATADROIDES.Usuario(username),
	    habilitado BIT NOT NULL DEFAULT 1,
         */
        public int telefono;
        public string localidad;
        public string direccion;
        public string nombre;
        public string apellido;
        public int dni;
        public DateTime fechaNac;
        public string mail;
        public short nroPiso;

        public Chofer() 
        {
                 
        }

    }
}
