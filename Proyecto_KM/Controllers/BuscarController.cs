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

        public string mensajeResultado { get; set; }


        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                string tipo = collection["tipoBusqueda"];
                string busqueda = collection["Busqueda"];

                switch (tipo)
                {
                    case "nombre":

                        LibFarmacos.Nodo<Arbol> nodoEncontrado = Storage.Instance.ArbolAVLN.Buscar(Storage.Instance.ArbolAVLN.padre,
                busqueda, Storage.Instance.ArbolAVLN.padre.valorFarmaco.buscarBinario);

                        Models.Task Busqueda = new Models.Task();
                        CeldaHash taskContainer = new CeldaHash();
                        if (taskContainer.BuscarHash(busqueda, ref Busqueda))
                        {
                            return View("ResultadoBusqueda", Busqueda);
                        }

                        return View();
                        break;
                    case "apellido":

                        LibFarmacos.Nodo<Arbol> nodoEncontradoA = Storage.Instance.ArbolAVLA.Buscar(Storage.Instance.ArbolAVLA.padre,
                            busqueda, Storage.Instance.ArbolAVLA.padre.valorFarmaco.buscarBinario);

                        busqueda = nodoEncontradoA.valorFarmaco.key;

                        Models.Task BusquedaA = new Models.Task();
                        CeldaHash taskContainerA = new CeldaHash();
                        if (taskContainerA.BuscarHash(busqueda, ref BusquedaA))
                        {
                            return View("ResultadoBusqueda", BusquedaA);
                        }


                        return View();

                        break;
                    case "DPI":

                        LibFarmacos.Nodo<Arbol> nodoEncontradoD = Storage.Instance.ArbolAVLD.Buscar(Storage.Instance.ArbolAVLD.padre,
                busqueda, Storage.Instance.ArbolAVLD.padre.valorFarmaco.buscarBinario);

                        busqueda = nodoEncontradoD.valorFarmaco.key;

                        Models.Task BusquedaD = new Models.Task();
                        CeldaHash taskContainerD = new CeldaHash();
                        if (taskContainerD.BuscarHash(busqueda, ref BusquedaD))
                        {
                            return View("ResultadoBusqueda", BusquedaD);
                        }

                        return View();

                        break;
                    default:
                        break;
                }

                return View();

            }
            catch
            {
                return View();
            }
        }
    }
}
