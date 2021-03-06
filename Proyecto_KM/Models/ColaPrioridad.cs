using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_KM.Models;
using Proyecto_KM.Utils;

namespace Proyecto_KM.Models
{
    public class ColaPrioridad<Task> where Task: IComparable<Task>
    {
        public List<Task> colaPrioridad = new List<Task>();
        public IEnumerable<Task> IenumColaPrioridad;

        public ColaPrioridad()
        {
            IenumColaPrioridad = (IEnumerable<Task>)colaPrioridad;
        }

        public int hora = 7;//hora de inicio cita pacientes
        public void Encolar(Task tareaParaAgendar)//encolar pacientes
        {
            colaPrioridad.Add(tareaParaAgendar);//agregar paciente a la cola de prioridad

            int ci = colaPrioridad.Count - 1;//contador de ingresos en la cola
            while (ci > 0)//cuando se agregan dos o más hacer:
            {
                int pi = (ci - 1) / 2;//hallar posición para el nuevo paciente

                if (colaPrioridad[ci].CompareTo(colaPrioridad[pi]) >= 0)//si el padre es menor al ingresado salir
                {
                    break;
                }//si no:

                Task tmp = colaPrioridad[ci];//crear temporal
                colaPrioridad[ci] = colaPrioridad[pi];//realizar cambio
                colaPrioridad[pi] = tmp;//realizar cambio con el temporal
                ci = pi;//igualar
            }

            int j = 0, k = 0, minuto = 00;//variables
            for (int i = 0; i < colaPrioridad.Count; i++)//repetir asignación de horario para cada paciente
            {
                if (j == 3)//si hay tres pacientes a una hora
                {
                    j = 0;//igualar a 0
                    k++;//aumentar los minutos
                    minuto = k * 15;//dar minutos a pacientes
                    if (minuto >= 60)//si se pasa de 60:
                    {
                        hora++;//aumentar hora
                        minuto = minuto - 60;//devolver minutos
                    }
                }
                Storage.Instance.regionActual.tareasAgendadas.colaPrioridad[i].hora = hora;//dar valor a la hora
                Storage.Instance.regionActual.tareasAgendadas.colaPrioridad[i].minuto = minuto;//dar valor a los minutos
                j++;//aumentar pacientes
            }
        }
       
        public Task DesEncolar()//eliminar paciente
        {

            int li = colaPrioridad.Count - 1;//última posición
            Task tareaDesAgendada = colaPrioridad[0];//solo se elimina el de mayor prioridad
            colaPrioridad[0] = colaPrioridad[li];//cambiar por el nodo en la última posición
            Task dato = colaPrioridad[li];//tomar el dato de la última pocisión
            colaPrioridad.RemoveAt(li);//eliminarlo

            --li;//disminuir la cantidad de pacientes en 1
            int pi = 0;
            while (true)//hacer hasta que el arbol se encuentre ordenado con el padre siendo menor
            {
                int ci = pi * 2 + 1;//hallar posición hijo
                if (ci > li)//si es mayor al último nodo salir
                {
                    break;
                }
                int rc = ci + 1;//hijo derecho
                if (rc <= li && colaPrioridad[rc].CompareTo(colaPrioridad[ci]) < 0)//si es menor al último y es menor al otro hijo
                {
                    ci = rc;//igualar
                }

                if (colaPrioridad[pi].CompareTo(colaPrioridad[ci]) <= 0)//si el padre es menor al hijo salir
                {
                    break;
                }
                Task tmp = colaPrioridad[pi];//crear temporal
                colaPrioridad[pi] = colaPrioridad[ci];//realizar cambio
                colaPrioridad[ci] = tmp;//realizar cambio por el temporal
                pi = ci;//igualar
            }
            return tareaDesAgendada;
        }


        public int tareasAgendadas()//cantidad de pacientes asignados
        {
            return colaPrioridad.Count;
        }

        public Task Peek()//paciente con mayor prioridad
        {
            Task tareaPrioritaria = colaPrioridad[0];
            return tareaPrioritaria;
        }
    }
}
