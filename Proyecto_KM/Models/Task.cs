using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_KM.Models
{
    public class Task : IComparable<Task>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DPI { get; set; }
        public string Departamento { get; set; }       
        public string MunicipioResidencia { get; set; }
        public int Prioridad { get; set; }


        public int CompareTo(Task other)
        {
            if (this.Prioridad < other.Prioridad)
            {
                return -1;
            }
            else if (this.Prioridad > other.Prioridad)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }


    }
}
