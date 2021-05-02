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

        public string mensajeResultado { get; set; }//que mensaje enviar


        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                string tipo = collection["tipoBusqueda"];//llenar variales con los datos enviados
                string busqueda = collection["Busqueda"];

                switch (tipo)
                {
                    case "nombre"://si es una busqueda por nombre:

                        LibFarmacos.Nodo<Arbol> nodoEncontrado = Storage.Instance.ArbolAVLN.Buscar(Storage.Instance.ArbolAVLN.padre,
                busqueda, Storage.Instance.ArbolAVLN.padre.valorFarmaco.buscarBinario);//hallar paciente en el árbol AVL

                        Models.Task Busqueda = new Models.Task();//datos del paciente
                        CeldaHash taskContainer = new CeldaHash();
                        if (taskContainer.BuscarHash(busqueda, ref Busqueda))//si se encuentra el paciente en la tabla hash
                        {
                            return View("ResultadoBusqueda", Busqueda);//devolver el resultado de la busqueda
                        }

                        return View();
                        break;
                    case "apellido"://si es una busqueda por apellido:

                        LibFarmacos.Nodo<Arbol> nodoEncontradoA = Storage.Instance.ArbolAVLA.Buscar(Storage.Instance.ArbolAVLA.padre,
                            busqueda, Storage.Instance.ArbolAVLA.padre.valorFarmaco.buscarBinario);//hallar paciente en el árbol AVL

                        busqueda = nodoEncontradoA.valorFarmaco.key;//utilizar la clave

                        Models.Task BusquedaA = new Models.Task();//datos de paciente
                        CeldaHash taskContainerA = new CeldaHash();
                        if (taskContainerA.BuscarHash(busqueda, ref BusquedaA))//si se encuentra el paciente en la tabla hash
                        {
                            return View("ResultadoBusqueda", BusquedaA);//devolver el resultado de la busqueda
                        }


                        return View();

                        break;
                    case "DPI":

                        LibFarmacos.Nodo<Arbol> nodoEncontradoD = Storage.Instance.ArbolAVLD.Buscar(Storage.Instance.ArbolAVLD.padre,
                busqueda, Storage.Instance.ArbolAVLD.padre.valorFarmaco.buscarBinario);//hallar paciente en el árbol AVL

                        busqueda = nodoEncontradoD.valorFarmaco.key;//utilizar la clave

                        Models.Task BusquedaD = new Models.Task();//datos de paciente
                        CeldaHash taskContainerD = new CeldaHash();
                        if (taskContainerD.BuscarHash(busqueda, ref BusquedaD))//si se encuentra el paciente en la tabla hash
                        {
                            return View("ResultadoBusqueda", BusquedaD);//devolver el resultado de la busqueda
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
