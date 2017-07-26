using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Numero
    {

        public double numero;

        public Numero() {}
        public Numero(string numero)
        {
            setNumero(numero);
        }
        public Numero(double n)
        {
            this.numero = n;
        }
			
        private double validarNumero(string numeroString)
        {
            double retorno;
            double.TryParse(numeroString, out retorno);
            return retorno;
        }
        private void setNumero(string numero)
        {
            this.numero = validarNumero(numero);
        }



    }
}
