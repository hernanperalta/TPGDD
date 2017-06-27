using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Login_Usuario
{
    class UsuarioDeshabilitadoException : Exception
    {
        public UsuarioDeshabilitadoException(string msg) : base(msg)
        {
        }
    }
}
