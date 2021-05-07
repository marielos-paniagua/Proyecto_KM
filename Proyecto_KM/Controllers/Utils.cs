using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Proyecto_KM.Utils;

namespace Proyecto_KM.Controllers
{
    public class Utils : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public Utils(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        public FileResult Descargar()
        {

            string text = "Lista de espera" + "\r\n";
            foreach (Models.Task item in Storage.Instance.regionActual.tareasAgendadas.colaPrioridad)
            {
                text += (item.logEspera() + Environment.NewLine);

            }
            text += "\r\n" + "Lista de vacunados" + "\r\n";
            foreach (Models.Task item in Storage.Instance.vacunados)
            {
                text += (item.logVacunados() + Environment.NewLine);

            }
            double porcentaje = (Storage.Instance.vacunados.Count * 100) / (Storage.Instance.vacunados.Count + Storage.Instance.regionActual.tareasAgendadas.colaPrioridad.Count);

            text += "\r\n" + "Porcentaje de vacunados" + "\r\n" + porcentaje.ToString() + "%";


            return File(Encoding.UTF8.GetBytes(text), "text/plain", "Reporte.txt");
        }


    }
}
