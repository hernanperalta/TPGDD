using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    class ErrorTextBox
    {
        public TextBox contenedor;
        public string descripcionError;

        public ErrorTextBox(TextBox contenedor, string descripcionError){
            this.contenedor = contenedor;
            this.descripcionError = descripcionError;
        }

        public void limpiarContenedor() {
            this.contenedor.Clear();
        }
    }
}
