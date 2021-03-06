﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.Conexion;
using System.Configuration;

namespace UberFrba.Abm_Cliente
{
    public partial class Alta : Form
    {
        private string errores = "";
        private Form parent;
        private DateTime fechaActual = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["Fecha"]);

        public Alta(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void crearCliente_Click(object sender, EventArgs e)
        {
            this.validarCampos();
            if (this.errores != "")
            {
                MessageBox.Show(errores);
                this.errores = "";
                return;
            }
            
            try
            {
                DBConexion.ResolverNonQuery("INSERT INTO LOS_CHATADROIDES.Cliente (localidad, direccion, nro_piso, depto, telefono, nombre, apellido, dni, fecha_de_nacimiento, mail, username, codigo_postal) VALUES ('"
                                           + this.localidadCliente.Text + "', '"
                                           + this.direccionCliente.Text + "', "
                                           + this.nroPiso.Text + ", '"
                                           + this.deptoCliente.Text + "', "
                                           + this.telefonoCliente.Text + ", '"
                                           + this.nombreCliente.Text + "', '"
                                           + this.apellidoCliente.Text + "', "
                                           + this.dniCliente.Text + ", '"
                                           + this.fechaNacCli.Value + "', "
                                           + (this.estaVacio(this.mailCliente.Text) ? "NULL" : "'" + this.mailCliente.Text + "'") + ", '"
                                           + this.usernameCliente.Text + "', '"
                                           + this.codPostal.Text + "')");
                
                MessageBox.Show("El cliente se creó con éxito!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void limpiarCampos_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
        }

        private string entreParentesis(string texto)
        {
            return "(" + texto + ")";
        }

        private bool estaVacio(string texto)
        {
            return texto.Equals("") || texto.Replace(" ", "").Equals("");
        }
       
        private void validarCampos()
        {
            this.validarCampo("telefono", this.telefonoCliente.Text, 18, "^[0-9]+$");
            this.validarCampo("DNI", this.dniCliente.Text, 18, "^[0-9]+$");
            this.validarCampo("Localidad", this.localidadCliente.Text, 20, "^[a-zA-Z0-9- ]+$");
            this.validarCampo("Departamento", this.deptoCliente.Text, 3, "^[a-zA-Z0-9]+$");
            this.validarCampo("Direccion y calle", this.direccionCliente.Text, 255, "^[a-zA-Z0-9- ]+$");
            this.validarCampo("Nombre", this.nombreCliente.Text, 255, "^[a-zA-Z-á-úÁ-Ú ]+$");
            this.validarCampo("Apellido", this.apellidoCliente.Text, 255, "^[a-zA-Z-á-úÁ-Ú ]+$");
            this.validarCampo("Codigo Postal", this.codPostal.Text, 5, "^[0-9]+$");
            this.validarCampo("Nro de Piso", this.nroPiso.Text, 5, "^[0-9]+$");
            if(!this.estaVacio(this.mailCliente.Text))
                this.validarCampo("Mail", this.mailCliente.Text, 255, "^[a-zA-Z]+[a-zA-Z0-9-._]*@[a-zA-Z]+(.[a-zA-Z]+)+$");            
            this.validarFecha();
            this.validarCampo("Nombre de usuario", this.usernameCliente.Text, 50, "^[a-zA-Z-_.0-9]+$");
        }

        private void validarFecha()
        {
            if (this.fechaNacCli.Value > fechaActual)
                errores += "-No puede ingresar una fecha de nacimiento posterior a la actual\n";
        }


        private void validarCampo(string campoError, string campo, int cantLetras, string expresion)
        {
            this.validarExpresion(expresion, campo, campoError);
            this.validarCantDigitos(cantLetras, campo, campoError);
        }

        private void validarExpresion(string expresion, string campo, string campoError) 
        {
            if (campo == "")
                errores += "El campo " + campoError + " esta vacio\n";

            else if (!System.Text.RegularExpressions.Regex.IsMatch(campo, expresion))
                {
                    errores += "El campo " + campoError + " posee caracteres invalidos\n";
                }
        }

        private void validarCantDigitos(int cantLetras, string campo, string campoError) {
            if (campo.Length > cantLetras)
            {
                errores += "El campo " + campoError + " no puede exceder los " + cantLetras + " digitos\n";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }
        private void Alta_o_Modificacion_Load(object sender, EventArgs e)
        {
        }

        private void telefonoCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void nombreCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void apellidoCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void dptoYlocalidad_TextChanged(object sender, EventArgs e)
        {
        }

        private void nroPiso_TextChanged(object sender, EventArgs e)
        {
        }

        private void calleYaltura_TextChanged(object sender, EventArgs e)
        {
        }

        private void codPostal_TextChanged(object sender, EventArgs e)
        {
        }

        private void mailCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void fechaNacCli_TextChanged(object sender, EventArgs e)
        {
        }

        private void dniCliente_TextChanged(object sender, EventArgs e)
        {
        }

        private void usernameCliente_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

