using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Automovil
{
    class Turno
    {
        private String horaInicio;
        private String horaFin;
        private String descripcion;

        public Turno(String horaInicio, String horaFin, String descripcion) {
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.descripcion = descripcion;
        }


        public override string ToString() {
            return "De: " + this.horaInicio + " A: " + this.horaFin + " (" + this.descripcion + ")";
        }
    }
}
