using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Menu
{
    public class FuncionalidadABM
    {
        private Func<Form, Form> ventanaAlta;
        private Func<Form, Form> ventanaBaja;
        private Func<Form, Form> ventanaModificacion;

        public FuncionalidadABM(Func<Form, Form> ventanaAlta, Func<Form, Form> ventanaBaja, Func<Form, Form> ventanaModificacion)
        {
            this.ventanaAlta = ventanaAlta;
            this.ventanaBaja = ventanaBaja;
            this.ventanaModificacion = ventanaModificacion;
        }

        internal void abrirVentanaModificar(Form parentABM)
        {
            this.ventanaModificacion.Invoke(parentABM).Show();
        }

        internal void abrirVentanaBaja(Form parentABM)
        {
            this.ventanaBaja.Invoke(parentABM).Show();
        }

        internal void abrirVentanaAlta(Form parentABM)
        {
            this.ventanaAlta.Invoke(parentABM).Show();
        }
    }
}


