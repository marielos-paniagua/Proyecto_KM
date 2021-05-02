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
        public string mensajeInicioSesion { get; set; }//que mensaje dar

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                string Departamento = collection["Departamento"];//llenar variables con datos enviados
                string Municipio = collection["Municipio"];
                Region usuarioActual = new Region();//crear un usuario para la región
                Storage.Instance.regionRegistrada.Add(usuarioActual);//agregar región registrada

                if (usuarioActual.registroUsuario(Departamento, Municipio) != null)//realizar registro de región
                {
                    if (usuarioActual.inicioSesionUsuario(Municipio) == null)//si no existe municipio
                    {
                        mensajeInicioSesion = "Seleccione una región";//pedir que ingrese municipio
                        return RedirectToAction("Index");

                }
                else
                {
                    mensajeInicioSesion = "";//mensaje vacío
                    Storage.Instance.regionActual = usuarioActual.inicioSesionUsuario(Municipio);//iniciar sesión con la región
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

        public ActionResult CerrarSesion()//cerrar sesión
        {
            Region usuarioDefault = new Region();
            usuarioDefault.tareasAgendadas.colaPrioridad.Clear();
            Storage.Instance.regionActual = usuarioDefault;
            return View("Index");
        }

    }
}
