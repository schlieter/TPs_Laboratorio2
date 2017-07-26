using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _nombre;
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;

        public enum ENacionalidad { Argentino, Extranjero }

        public string Apellido
        { 
            get 
            { 
                return this._apellido; 
            } 
            set 
            { 
                this._apellido = this.ValidarNombreApellido(value); 
            } 
        }
        public string Nombre 
        { 
            get 
            { 
                return this._nombre; 
            } 
            set 
            { 
                this._nombre = this.ValidarNombreApellido(value); 
            } 
        }
        public int DNI 
        { 
            get 
            { 
                return this._dni; 
            } 
            set 
            { 
                this._dni = this.ValidarDni(this.Nacionalidad, value); 
            } 
        }
        public ENacionalidad Nacionalidad 
        {
            get 
            { 
                return this._nacionalidad; 
            } 
            set 
            {
                this._nacionalidad = value;
            }
        }
        public string StringToDNI 
        { 
            set 
            { 
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            } 
        }

        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Nombre: " + this.Nombre);
            sb.AppendLine(" Apellido: " + this.Apellido);
            sb.AppendLine("Nacionalidad: " + this.Nacionalidad.ToString());
            sb.Append("DNI: " + this.DNI.ToString());
            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999))
            {
                throw new DniInvalidoExcepction();
            }
            else if (nacionalidad == ENacionalidad.Extranjero && (dato < 90000000 || dato > 100000000))
            {
                throw new NacionalidadInvalidaException();
            }
            else
            {
                return dato;
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (int.TryParse(dato, out dni))
            {
                return ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoExcepction();
            }
        }

        private string ValidarNombreApellido(string dato)
        {
            foreach (char l in dato)
            {
                if (char.IsNumber(l))
                    return null;
            }
            return dato;
        }

    }
}
