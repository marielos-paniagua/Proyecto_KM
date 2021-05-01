using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_KM.Utils;
using Proyecto_KM.Models;

namespace Proyecto_KM.Models
{
    public class Region
    {
        public string Departamento { get; set; }
        public string Municipio { get; set; }

        public ColaPrioridad<Task> tareasAgendadas = new ColaPrioridad<Task>();

        public Region registroUsuario(string departamento, string municipio)
        {
            this.Departamento = departamento;
            this.Municipio = municipio;
            return this;
            
        }

        public Region inicioSesionUsuario(string nombre)
        {
            if (!Storage.Instance.regionRegistrada.Exists(user => user.Municipio.Equals(nombre)))
            {
                return null;
            }
            else
            {
                return Storage.Instance.regionRegistrada.Find(user => user.Municipio.Equals(nombre));
            }
        }

    }
}
