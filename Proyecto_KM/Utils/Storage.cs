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

        public ColaPrioridad<Models.Task> tareasAgendadas = new ColaPrioridad<Models.Task>();
        public CeldaHash hashTableInitialization = new CeldaHash();
        public List<CeldaHash> hashTable = new List<CeldaHash>();

        public AVL<Arbol> ArbolAVL = new AVL<Arbol>();
    }
}
