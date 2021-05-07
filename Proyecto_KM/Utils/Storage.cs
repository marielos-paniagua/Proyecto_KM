using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_KM.Models;
using System.Threading.Tasks;
using LibFarmacos;

namespace Proyecto_KM.Utils
{
    public class Storage
    {
        private static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public CeldaHash hashTableInitialization = new CeldaHash();//inicialización de tabla hash
        public List<CeldaHash> hashTable = new List<CeldaHash>();//tabla hash
        public List<Region> regionRegistrada = new List<Region>();//registro de región ingresadas
        public Region regionActual = new Region();//región en la que inicia sesión
        public List<Models.Task> vacunados = new List<Models.Task>();

    }
}
