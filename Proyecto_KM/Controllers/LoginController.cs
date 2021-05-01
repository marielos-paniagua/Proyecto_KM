using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_KM.Models;
using Proyecto_KM.Utils;

namespace Proyecto_KM.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [TempData]
        public string mensajeInicioSesion { get; set; }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                string Departamento = collection["Departamento"];
                string Municipio = collection["Municipio"];
                Region usuarioActual = new Region();
                Storage.Instance.regionRegistrada.Add(usuarioActual);

                if (usuarioActual.registroUsuario(Departamento, Municipio) != null)
                {
                    if (usuarioActual.inicioSesionUsuario(Municipio) == null)
                    {
                        mensajeInicioSesion = "Seleccione una región";
                        return RedirectToAction("Index");

                }
                else
                {
                    mensajeInicioSesion = "";
                    Storage.Instance.regionActual = usuarioActual.inicioSesionUsuario(Municipio);
                    return RedirectToAction("Index", "Home");
                    
                }
                }

                return View();

            }
            catch
            {
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            Region usuarioDefault = new Region();
            usuarioDefault.tareasAgendadas.colaPrioridad.Clear();
            Storage.Instance.regionActual = usuarioDefault;
            return View("Index");
        }

    }
}
