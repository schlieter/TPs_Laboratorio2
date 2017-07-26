using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoExcepction : Exception
    {
        static string mensajeBase = "DNI invalido";

        public DniInvalidoExcepction() : this(mensajeBase) { }

        public DniInvalidoExcepction(Exception e) : base(mensajeBase, e) { }

        public DniInvalidoExcepction(string message) : base(message) { }

        public DniInvalidoExcepction(string message, Exception e) : base(message, e) { }
    }
}

