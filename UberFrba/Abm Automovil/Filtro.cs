using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    class Filtro
    {
        public string filtroActual = "";
     
        private string tituloCampo;

        public Filtro(string tituloCampo)
        {

            this.tituloCampo = tituloCampo;
        }

        public void agregarFiltro(string nuevoFiltro) {

            if (string.IsNullOrEmpty(nuevoFiltro))
            {
                this.filtroActual = "";
            }
            else
            {
                if (nuevoFiltro.All(char.IsDigit))
                {
                    filtroActual = string.Format("Convert([{0}], 'System.String') LIKE '%{1}%'", this.tituloCampo, nuevoFiltro);

                }
                else
                {
                    filtroActual = string.Format("{0} LIKE '%{1}%'", this.tituloCampo, nuevoFiltro);
                }

            }
        }

    }
}
