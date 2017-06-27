using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UberFrba.Login_Usuario
{
    class PasswordInvalidaException : Exception
    {
        public PasswordInvalidaException(String msg) : base(msg) { 
        
        }
    }
}
