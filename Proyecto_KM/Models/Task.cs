using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_KM.Models
{
    public class Task : IComparable<Task>
    {
        public string Nombre { get; set; }//variables
        public string Apellido { get; set; }
        public string DPI { get; set; }
        public int Prioridad { get; set; }
        public string Fase { get; set; }
        public int hora { get; set; }
        public int minuto { get; set; }
        public string NVacuna { get; set; }
        public string Fecha { get; set; }
        public string Dosis { get; set; }



        public int CompareTo(Task other)//comparar las prioridades
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
