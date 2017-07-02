using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Registro_Viajes
{
    class Turno
    {
        public string descripcion;
        public string horaInicioTurno;
        public string horaFinTurno;

        public Turno(string horaInicioTurno, string horaFinTurno,string descripcion ) 
        {
            this.descripcion = descripcion;
            this.horaInicioTurno = horaInicioTurno;
            this.horaFinTurno = horaFinTurno;
        }
        public override string ToString()
        {
            return this.descripcion;
        }
    }
}
