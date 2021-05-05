using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_KM.Utils;
using Proyecto_KM.Models;
using LibFarmacos;

namespace Proyecto_KM.Models
{
    public class Region
    {
        public string Departamento { get; set; }//variables
        public string Municipio { get; set; }

        public ColaPrioridad<Task> tareasAgendadas = new ColaPrioridad<Task>();//cola de prioridad para los pacientes ingresados en la region

        public AVL<Arbol> ArbolAVLN = new AVL<Arbol>(); //arbol avl para nombre
        public AVL<Arbol> ArbolAVLA = new AVL<Arbol>(); //arbol avl para apellido
        public AVL<Arbol> ArbolAVLD = new AVL<Arbol>(); //arbol avl para DPI
        public Region registroUsuario(string departamento, string municipio)//registro de la región
        {
            this.Departamento = departamento;//guardar departamento
            this.Municipio = municipio;//guardar municipio
            return this;
            
        }

        public Region inicioSesionUsuario(string nombre)//inciar sesión por reión
        {
            if (!Storage.Instance.regionRegistrada.Exists(user => user.Municipio.Equals(nombre)))//si no se encuentra la región:
            {
                return null;//devolver null
            }
            else//si sí existe:
            {
                return Storage.Instance.regionRegistrada.Find(user => user.Municipio.Equals(nombre));//devolver el municipio
            }
        }

    }
}
