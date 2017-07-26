using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        public ETipo _tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color): base(marca, codigo, color)
        {
            this._tipo = ETipo.Entera;
        }
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo t): base(marca, codigo, color)
        {
            this._tipo = t;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 20;
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
            sb.Append("TIPO            : ");
            sb.AppendLine(this._tipo.ToString());
            sb.Append("CALORIAS        : ");
            sb.AppendLine(this.CantidadCalorias.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
