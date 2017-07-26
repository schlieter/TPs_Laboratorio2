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

        public string Apellido { get { return this._apellido; } set { this._apellido = this.ValidarNombreApellido(value); } }
        public string Nombre { get { return this._nombre; } set { this._nombre = this.ValidarNombreApellido(value); } }
        public int DNI { get { return this._dni; } set { this._dni = this.ValidarDni(this.Nacionalidad, value); } }
        public ENacionalidad Nacionalidad { get { return this._nacionalidad; } set { this._nacionalidad = value; } }
        public string StringToDNI { set { this._dni = this.ValidarDni(this.Nacionalidad, value); } }

        public Persona() { }

        /// <summary>
        /// Constructor v2.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor v3, llama al constructor v2.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor v4, llama al constructor v2.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            return "Nombre: " + this.Nombre + " Apellido: " + this.Apellido + " Nacionalidad: " + this.Nacionalidad.ToString() + " DNI: " + this.DNI.ToString();
        }

        /// <summary>
        /// Valida que el dni coincida con la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna el dni validado, caso contrario lanza una excepcion</returns>
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

        /// <summary>
        /// Valida que el dni coincida con la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna el dni validado, caso contrario lanza una excepcion</returns>
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

        /// <summary>
        /// Valida que el nonbre o apellido tenga caracteres validos.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Retorna la cadena validada, caso contrario retorna null</returns>
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
