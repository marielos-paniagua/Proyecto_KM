using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_KM.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Proyecto_KM.Utils
{
    public class Ingreso : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public Ingreso(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                string Nombre = collection["Nombre"];
                string Apellido = collection["Apellido"];
                string DPI = collection["DPI"];
                string Departamento = collection["Departamento"];
                string MunicipioResidencia = collection["Municipio"];
                string Prioridad = collection["Labor"];
                int Priority = 0;

                switch (Prioridad)
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

                Task taskRegistered = new Models.Task()
                {
                    Nombre = Nombre.Replace(',', ' '),
                    Apellido = Apellido.Replace(',', ' '),
                    DPI = DPI.Replace(',', ' '),
                    Departamento = Departamento.Replace(',', ' '),
                    MunicipioResidencia = MunicipioResidencia.Replace(',', ' '),
                    Prioridad = Priority,
                };


                CeldaHash taskContainer = new CeldaHash();

                int numberOfTasks = Storage.Instance.tareasAgendadas.tareasAgendadas();

                if (numberOfTasks <= 10)
                {                   

                    if (taskContainer.insert(Nombre, taskRegistered))
                    {

                        Storage.Instance.tareasAgendadas.Encolar(taskRegistered);

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
