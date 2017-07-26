using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        public Alumno() : base() { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\n" + this._estadoCuenta.ToString() + "\n " + this.ParticiparEnClase() + "\n ";
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma != clase)
            {
                return true;
            }
            else
                return false;
        }
    }
}