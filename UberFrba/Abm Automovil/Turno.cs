using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Automovil
{
    class Turno
    {
        public String horaInicio;
        public String horaFin;
        public String descripcion;

        public Turno(String horaInicio, String horaFin, String descripcion) {
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.descripcion = descripcion;
        }

        public Double horaInicioDouble() {
            return Convert.ToDouble(this.horaInicio);
        }

        public Double horaFinDouble() {
            return Convert.ToDouble(this.horaFin);
        }

        public override string ToString() {
            if(!this.horaInicio.Equals("") && !this.horaFin.Equals(""))
                return "De: " + this.horaInicio + " A: " + this.horaFin + " (" + this.descripcion + ")";
            return "No posee un turno asignado.";
        }
    }
}
