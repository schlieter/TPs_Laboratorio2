using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        private Profesor()
            : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
        }
        static Profesor()
        {
            Profesor._random = new Random();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        private void _randomClases()
        {
            int i = 0;
            while (i < 2)
            {
                this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(1, 4));
                i++;
            }
        }
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\n" + this.ParticiparEnClase();
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i._clasesDelDia.Contains(clase);
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA ");
            foreach (Universidad.EClases c in this._clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
