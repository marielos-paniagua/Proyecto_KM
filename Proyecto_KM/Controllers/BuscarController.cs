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
    public class BuscarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult buscar(IFormCollection collection)
        {
            string busqueda = collection["Busqueda"];


            LibFarmacos.Nodo<Arbol> nodoEncontrado = Storage.Instance.ArbolAVL.Buscar(Storage.Instance.ArbolAVL.padre,
                busqueda, Storage.Instance.ArbolAVL.padre.valorFarmaco.buscarBinario);

            Models.Task Busqueda = new Models.Task();
            CeldaHash taskContainer = new CeldaHash();
            if (taskContainer.BuscarHash(busqueda, ref Busqueda))
            {
                return View("ResultadoBusqueda", Busqueda);
            }

            
            return View();
        }
    }
}
