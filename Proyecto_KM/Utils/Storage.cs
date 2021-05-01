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

        public CeldaHash hashTableInitialization = new CeldaHash();
        public List<CeldaHash> hashTable = new List<CeldaHash>();
        public List<Region> regionRegistrada = new List<Region>();
        public Region regionActual = new Region();

        public AVL<Arbol> ArbolAVLN = new AVL<Arbol>();
        public AVL<Arbol> ArbolAVLA = new AVL<Arbol>();
        public AVL<Arbol> ArbolAVLD = new AVL<Arbol>();
    }
}
