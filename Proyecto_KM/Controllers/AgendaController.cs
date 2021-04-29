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

        public ActionResult finalizarTask()
        {
            CeldaHash taskContainer = new CeldaHash();
            Models.Task taskToDelete = Storage.Instance.tareasAgendadas.Peek();
            int i = 0;
            bool found = false;
            int index = 0;
            while (!found)
            {

                index = taskContainer.HashF(taskToDelete.Nombre, i);

                if (Storage.Instance.hashTable[index].key.Equals(taskToDelete.Nombre))
                {
                    found = true;
                    Storage.Instance.hashTable[index].key = null;
                    Storage.Instance.hashTable[index].taskDetails = null;
                    Storage.Instance.hashTable[index].state = CeldaHash.cellState.vacio;
                }
                else
                {
                    found = false;
                }
            }

            Storage.Instance.tareasAgendadas.DesEncolar();

            //Storage.Instance.ArbolAVL.Eliminar(Busqueda.elemento.NombreFarmaco,
              //  Storage.Instance.ArbolAVL.padre.valorFarmaco.buscarEliminacionFarmacoBinario);


            return View("Index");
        }
    }
}
