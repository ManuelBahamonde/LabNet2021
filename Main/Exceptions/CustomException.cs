using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2.Exceptions
{
    public class CustomException : Exception
    {
        public override string Message => $"Excepcion personalizada - {base.Message}";

        public CustomException(string message) : base(message) { }
    }
}
