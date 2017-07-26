using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos 
        { 
            get 
            { 
                return this._alumnos; 
            } 
            set 
            { 
                this._alumnos = value; 
            } 
        }
        public Universidad.EClases Clase 
        { 
            get 
            { 
                return this._clase; 
            } 
            set 
            { 
                this._clase = value; 
            } 
        }
        public Profesor Instructor 
        { 
            get 
            { 
                return this._instructor; 
            } 
            set 
            { 
                this._instructor = value; 
            } 
        }

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();
            return t.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString());
        }
        public static string Leer()
        {
            string s;
            Texto t = new Texto();
            t.Leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out s);
            return s;
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno b in j._alumnos)
            {
                if (b == a)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
                return j;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Clase.ToString());
            sb.AppendLine(this.Instructor.ToString());
            foreach (Alumno a in this.Alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }
    }
}
