using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_KM.Models;

namespace Proyecto_KM.Utils
{
    public class IngresoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                string Nombre = collection["Nombre"];//llenar variebles con los datos enviados
                string Apellido = collection["Apellido"];
                string DPI = collection["DPI"];
                string Prioridad = collection["Labor"];
                int Priority = 0;

                switch (Prioridad)//dar valor a cada fase indicada por el paciente
                {
                    case "1a":
                        {
                            Priority = 1;
                        }
                        break;
                    case "1b":
                        {
                            Priority = 2;
                        }
                        break;
                    case "1c":
                        {
                            Priority = 3;
                        }
                        break;
                    case "1d":
                        {
                            Priority = 4;
                        }
                        break;
                    case "1e":
                        {
                            Priority = 5;
                        }
                        break;
                    case "1f":
                        {
                            Priority = 6;
                        }
                        break;
                    case "2a":
                        {
                            Priority = 7;
                        }
                        break;
                    case "2b":
                        {
                            Priority = 8;
                        }
                        break;
                    case "3a":
                        {
                            Priority = 9;
                        }
                        break;
                    case "3b":
                        {
                            Priority = 10;
                        }
                        break;
                    case "3c":
                        {
                            Priority = 11;
                        }
                        break;
                    case "3d":
                        {
                            Priority = 12;
                        }
                        break;
                    case "4a":
                        {
                            Priority = 13;
                        }
                        break;
                    case "4b":
                        {
                            Priority = 14;
                        }
                        break;
                }

                Task taskRegistered = new Models.Task()//registrar paciente
                {
                    Nombre = Nombre.Replace(',', ' '),
                    Apellido = Apellido.Replace(',', ' '),
                    DPI = DPI.Replace(',', ' '),
                    Prioridad = Priority,
                    Fase = Prioridad,
                };


                CeldaHash taskContainer = new CeldaHash();

                int numberOfTasks = Storage.Instance.regionActual.tareasAgendadas.tareasAgendadas();//cantidad de pacientes ingresados

                if (numberOfTasks <= 10)
                {                   

                    if (taskContainer.insert(Nombre, taskRegistered))//ingresar paciente a tabla hash
                    {

                        Storage.Instance.regionActual.tareasAgendadas.Encolar(taskRegistered);//encolar al paciente

                        Arbol nodoArbolN = new Arbol();//árbol AVL para búsquedas por nombre
                        nodoArbolN.Nombre = Nombre;//insertar nombre
                        nodoArbolN.key = Nombre;//insertar clave
                        Storage.Instance.regionActual.ArbolAVLN.insertar(nodoArbolN, nodoArbolN.CompararNombreF);//insertar en árbol AVL

                        Arbol nodoArbolA = new Arbol();//árbol AVL para búsquedas por apellido
                        nodoArbolA.Nombre = Apellido;//insertar apellido
                        nodoArbolA.key = Nombre;//insertar clave
                        Storage.Instance.regionActual.ArbolAVLA.insertar(nodoArbolA, nodoArbolA.CompararNombreF);//insertar en árbol AVL

                        Arbol nodoArbolD = new Arbol();//árbol AVL para búsquedas por DPI
                        nodoArbolD.Nombre = DPI;//insertar DPI
                        nodoArbolD.key = Nombre;//insertar clave
                        Storage.Instance.regionActual.ArbolAVLD.insertar(nodoArbolD, nodoArbolD.CompararNombreF);//insertar en árbol AVL

                        return RedirectToAction("Index", "Agenda");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }
       
    }
}
