using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_KM.Utils;
using Proyecto_KM.Models;
using Microsoft.AspNetCore.Http;


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
                try
                {
                    if (Storage.Instance.hashTable[index].key.Equals(taskToDelete.Nombre))//si se halla
                    {

                        Storage.Instance.regionActual.ArbolAVLN.Eliminar(taskToDelete.Nombre,
                            Storage.Instance.regionActual.ArbolAVLN.padre.valorFarmaco.buscarEliminacionBinario);//eliminar paciente del árbol AVL para Nombre
                        Storage.Instance.regionActual.ArbolAVLA.Eliminar(taskToDelete.Apellido,
                            Storage.Instance.regionActual.ArbolAVLA.padre.valorFarmaco.buscarEliminacionBinario);//eliminar paciente del árbol AVL para Apellido
                        Storage.Instance.regionActual.ArbolAVLD.Eliminar(taskToDelete.DPI,
                            Storage.Instance.regionActual.ArbolAVLD.padre.valorFarmaco.buscarEliminacionBinario);//eliminar paciente del árbol AVL para DPI 

                        found = true;
                        Storage.Instance.hashTable[index].key = null;//eliminar la clave
                        Storage.Instance.hashTable[index].taskDetails = null;//eliminar datos del paciente
                        Storage.Instance.hashTable[index].state = CeldaHash.cellState.vacio;//desocupar celda
                    }
                    else
                    {
                        i++;
                        found = false;
                    }
                }
                catch { i++; }
            }

            Storage.Instance.regionActual.tareasAgendadas.DesEncolar();//desencolar de la cola de prioridad
                     
            return View("Index");
        }
        public ActionResult Reagendar()//eliminar el paciente con mayor prioridad
        {
            CeldaHash taskcontainer = new CeldaHash();
            Models.Task taskToDelete = Storage.Instance.regionActual.tareasAgendadas.Peek();//hallar paciente con mayor prioridad
            int i = 0;
            bool found = false;
            int index = 0;
            while (!found)//mientras no sea encontrado
            {
                index = taskcontainer.HashF(taskToDelete.Nombre, i); //hallar posicion por medio la funcion
                if (Storage.Instance.hashTable[index].key.Equals(taskToDelete.Nombre))//si se encuentra
                {
                    found = true;
                }
                else
                {
                    found = false;
                    i++;
                }
            }
            Storage.Instance.regionActual.tareasAgendadas.DesEncolar(); //desencolar de la cola de prioridad
            Storage.Instance.regionActual.tareasAgendadas.Encolar(taskToDelete); //volver a encolar
            return View("Index");
        }
        public ActionResult Vacunacion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Vacunacion(IFormCollection collection)
        {
            try
            {
                string Fecha = collection["Fecha"];//recolectar datos ingresados
                string NVacuna = collection["Vacuna"];
                string Dosis = collection["Dosis"];



                Storage.Instance.regionActual.tareasAgendadas.colaPrioridad[0].NVacuna = NVacuna;//dar valor a Nombre de la vacuna
                Storage.Instance.regionActual.tareasAgendadas.colaPrioridad[0].Dosis = Dosis;//dar valor a la dosis de la vacuna
                Storage.Instance.regionActual.tareasAgendadas.colaPrioridad[0].Fecha = Fecha;//dar valor a la fecha aplicada

                Storage.Instance.vacunados.Add(Storage.Instance.regionActual.tareasAgendadas.colaPrioridad[0]);

                finalizarTask();//ir al método



                return View("Index");
            }
            catch
            {
                return View();
            }

        }
    }

}
