using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Calculadora
    {
        

        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double retorno = 0;
            switch (operador)
            {
                case "+":
                    retorno = numero1.numero + numero2.numero;
                    break;
                case "-":
                    retorno = numero1.numero - numero2.numero;
                    break;
                case "*":
                    retorno = numero1.numero * numero2.numero;
                    break;
                case "/":
                    if (numero2.numero == 0)
                    {
                        retorno = 0;
                        break;
                    }
                    else
                    {
                        retorno = numero1.numero / numero2.numero;
                        break;
                    }
                default:
                    break;
            }
            return retorno;
        }
        public static string validarOperador(string operador)
        {
            string retorno;
            if(operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                retorno = "+";
            }
            else 
            {
                retorno = operador;
            }
            return retorno;
        }

    }
}
