using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    [Serializable]
    public class Universidad
    {
        private List<Alumno> _alumnos;
        private List<Profesor> _profesores;
        private List<Jornada> _jornada;

        public enum EClases { Legislacion, Programacion, Laboratorio,  SPD, }

        public List<Alumno> Alumnos { get { return this._alumnos; } set { this._alumnos = value; } }
        public List<Profesor> Instructores { get { return this._profesores; } set { this._profesores = value; } }
        public List<Jornada> Jornadas { get { return this._jornada; } set { this._jornada = value; } }
        public Jornada this[int i] { get { return this._jornada[i]; } set { this._jornada[i] = value; } }

        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._profesores = new List<Profesor>();
            this._jornada = new List<Jornada>();
        }
        public static Universidad Leer()
        {
            Universidad u;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(@"C:\Users\nahuel\Desktop\TP3\Universidad.xml", out u);
            return u;

        }
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(@"C:\Users\nahuel\Desktop\TP3\Universidad.xml", gim);
        }
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----PROFESORES---------------------------");
            foreach (Profesor i in gim.Instructores)
            {
                sb.AppendLine(i.ToString());
            }
            sb.AppendLine("----ALUMNOS---------------------------");
            foreach (Alumno a in gim.Alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            sb.AppendLine("----JORNADAS---------------------------");
            foreach (Jornada j in gim.Jornadas)
            {
                sb.AppendLine(j.ToString());
            }
            sb.AppendLine("-------------------------------");
            return sb.ToString();
        }
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g._alumnos.Contains(a);
        }
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
            {
                if (p == clase)
                    return p;
            }
            throw new SinProfesorException();
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g._profesores.Contains(i);
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            return g == clase;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = (g == clase);
            Jornada jornada = new Jornada(clase, profesor);
            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase)
                {
                    jornada = jornada + item;
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }
    }
}
