using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string path, string txt)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Write(txt.ToString());
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        public bool Leer(string path, out string txt)
        {           
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    if (File.Exists(path))
                    {
                        txt = sr.ReadToEnd();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);  
            }
            txt = default(string);
            return false;
        }
    }
}