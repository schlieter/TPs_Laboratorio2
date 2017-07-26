using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        public Universitario() : base() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            return base.ToString() + " Legajo: " + this._legajo.ToString();
        }
        
        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.GetType() == pg2.GetType() && (pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo))
                return true;
            else
                return false;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

    }
}
