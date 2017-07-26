using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string path, T d)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(sw, d);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        public bool Leer(string path, out T d)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                XmlSerializer xml = new XmlSerializer(typeof(T));
                d = (T)xml.Deserialize(sr);
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
