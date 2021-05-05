using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_KM.Utils;
using Proyecto_KM.Models;


namespace Proyecto_KM.Controllers
{
    public class AgendaController : Controller
    {
     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult finalizarTask()//eliminar el paciente con mayor prioridad
        {
            CeldaHash taskContainer = new CeldaHash();
            Models.Task taskToDelete = Storage.Instance.regionActual.tareasAgendadas.Peek();//hallar paciente con mayor prioridad
            int i = 0;
            bool found = false;
            int index = 0;
            while (!found)//mientras no sea encontrado
            {

                index = taskContainer.HashF(taskToDelete.Nombre, i);//hallar posición por medio de la función

                if (Storage.Instance.hashTable[index].key.Equals(taskToDelete.Nombre))//si se halla
                {

                    Storage.Instance.regionActual.ArbolAVLN.Eliminar(taskToDelete.Nombre,
                        Storage.Instance.regionActual.ArbolAVLN.padre.valorFarmaco.buscarEliminacionBinario);
                    Storage.Instance.regionActual.ArbolAVLA.Eliminar(taskToDelete.Nombre,
                        Storage.Instance.regionActual.ArbolAVLA.padre.valorFarmaco.buscarEliminacionBinario);
                    Storage.Instance.regionActual.ArbolAVLD.Eliminar(taskToDelete.Nombre,
                        Storage.Instance.regionActual.ArbolAVLD.padre.valorFarmaco.buscarEliminacionBinario);

                    found = true;
                    Storage.Instance.hashTable[index].key = null;//eliminar la clave
                    Storage.Instance.hashTable[index].taskDetails = null;//eliminar datos del paciente
                    Storage.Instance.hashTable[index].state = CeldaHash.cellState.vacio;//desocupar celda
                }
                else
                {
                    found = false;
                }
            }

            Storage.Instance.regionActual.tareasAgendadas.DesEncolar();//desencolar de la cola de prioridad
                     
            return View("Index");
        }
    }
}
