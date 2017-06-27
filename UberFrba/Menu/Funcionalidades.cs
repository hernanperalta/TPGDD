using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Menu
{
    public class Funcionalidades
    {
        private String username;
        private String rol;
        private List<Funcionalidad> ventanas;

        public Funcionalidades(String username, String rol)
        {
            this.rol = rol;
            this.username = username;
            this.ventanas = new List<Funcionalidad> { 
                new Funcionalidad(1, "ABM de Rol", this.crearABMRol()),
                new Funcionalidad(3, "ABM de Cliente", this.crearABMCliente()),
                new Funcionalidad(4, "ABM de Automovil", this.crearABMAuto()), 
                new Funcionalidad(5, "ABM de Chofer", this.crearABMChofer()),
                new Funcionalidad(2, "Registro de Usuario", new Alta_de_Usuario.Alta_de_Usuario(this.username, this.rol)),
                new Funcionalidad(6, "Registro de Viajes", new Registro_Viajes.Registro_Viajes(this.username, this.rol)),
                new Funcionalidad(7, "Rendicion de cuenta del Chofer", new Rendicion_Al_Chofer.Rendicion_Al_Chofer(this.username, this.rol)),
                new Funcionalidad(8, "Listado Estadistico", new Facturacion_Cliente.Listado_Estadistico(this.username, this.rol)),
                new Funcionalidad(9, "Facturacion a Cliente", new Facturacion_Cliente.Facturacion_Cliente(this.username, this.rol))
            };
        }

        private Menu_ABM crearABMRol() {
            return new Menu_ABM("Rol", this.username, this.rol, new FuncionalidadABM(new Abm_Rol.Alta(this.username, this.rol), new Abm_Rol.Baja_Rol(this.username, this.rol) , new Abm_Rol.Modificacion(this.username, this.rol)));
        }

        private Menu_ABM crearABMCliente() {
            return new Menu_ABM("Cliente", this.username, this.rol, new FuncionalidadABM(new Abm_Cliente.Alta(this.username, this.rol), new Abm_Cliente.Baja_o_Modificacion(true, this.username, this.rol), new Abm_Cliente.Baja_o_Modificacion(false, this.username, this.rol)));
        }

        private Menu_ABM crearABMAuto() {
            return new Menu_ABM("Automovil", this.username, this.rol, new FuncionalidadABM(new Abm_Automovil.Alta(this.username, this.rol), new Abm_Automovil.Baja_o_Modificacion(true, this.username, this.rol), new Abm_Automovil.Baja_o_Modificacion(false, this.username, this.rol)));
        }

        private Menu_ABM crearABMChofer() {
            return new Menu_ABM("Chofer", this.username, this.rol, new FuncionalidadABM(new Abm_Chofer.Alta(this.username, this.rol), new Abm_Chofer.Baja_o_Modificacion(true, this.username, this.rol), new Abm_Chofer.Baja_o_Modificacion(false, this.username, this.rol)));
        }

        public Funcionalidad obtenerFuncionalidad(short codigo)
        { 
            return this.ventanas.Find(func => func.codigo == codigo);
        }
    }
}