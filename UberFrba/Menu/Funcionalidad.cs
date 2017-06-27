using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Menu
{
    public class Funcionalidad
    {
        public short codigo;
        public String nombre;        
        private Form ventana;
        private String username;
        private String rol;

        public Funcionalidad(short codigo, String nombre, Form ventana)
        {
            this.nombre = nombre;
            this.codigo = codigo;
            this.ventana = ventana;
        }

        public void abrirVentana() {
            ventana.Show();
        }

        public override string ToString() {
            return nombre;
        }

    }
}

