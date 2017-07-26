using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;


namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public delegate void DescargaCompleta(string resultado);
        public delegate void Progreso(int progreso);

        public event DescargaCompleta descargaCompleta;
        public event Progreso progreso;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progreso(e.ProgressPercentage);
        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
                this.descargaCompleta(this.html);
            }
            catch (Exception error)
            {
                this.descargaCompleta("Error de acceso, " + error.InnerException.Message);
            }
        }
    }
}