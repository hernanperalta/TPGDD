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
        private Form ventanaAlta;
        private Form ventanaBaja;
        private Form ventanaModificacion;

        public FuncionalidadABM(Form ventanaAlta, Form ventanaBaja, Form ventanaModificacion)
        {
            this.ventanaAlta = ventanaAlta;
            this.ventanaBaja = ventanaBaja;
            this.ventanaModificacion = ventanaModificacion;
        }

        internal void abrirVentanaModificar()
        {
            this.ventanaModificacion.Show();
        }

        internal void abrirVentanaBaja()
        {
            this.ventanaBaja.Show();
        }

        internal void abrirVentanaAlta()
        {
            this.ventanaAlta.Show();
        }
    }
}


