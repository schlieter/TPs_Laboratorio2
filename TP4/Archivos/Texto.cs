using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string file;

        public Texto(string datos)
        {
            this.file = datos;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(this.file, true);
                sw.WriteLine(datos);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al guardar el archivo: " + this.file + "\n" + e.Message);
                return false;
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(this.file);
                while (!sr.EndOfStream)
                {
                    datos.Add(sr.ReadLine());
                }
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al leer el archivo: " + this.file + "\n" + e.Message);
                return false;
            }
        }
    }
}