using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Dulce : Producto
    {
        public Dulce(EMarca marca, string codigo, ConsoleColor color):base(marca,codigo,color)
        {
        }
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CODIGO DE BARRAS: ");
            sb.AppendLine(base._codigoDeBarras);
            sb.Append("MARCA           : ");
            sb.AppendLine(base._marca.ToString());
            sb.Append("COLOR EMPAQUE   : ");
            sb.AppendLine(base._colorPrimarioEmpaque.ToString());
            sb.Append("CALORIAS        : ");
            sb.AppendLine(this.CantidadCalorias.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
