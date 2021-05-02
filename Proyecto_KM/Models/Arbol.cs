using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_KM.Models
{
    public class Arbol
    {
        public string Nombre { get; set; }//variables
        public string key { get; set; }
        public int CompareTo(object Paciente2)
        {
            return Nombre.CompareTo(((Arbol)Paciente2).Nombre);
        }
        public Comparison<Arbol> CompararNombreF = delegate (Arbol InventarioF, Arbol InventarioF2)
        {
            return InventarioF.Nombre.CompareTo(InventarioF2.Nombre);//comparación para insertar
        };

        public int buscarBinario(Arbol InventarioF, string InventarioF2)
        {
            return InventarioF2.CompareTo(InventarioF.Nombre);//comparación para hallar busqueda
        }

        public int buscarEliminacionBinario(string InventarioF2, Arbol InventarioF)
        {
            return InventarioF2.CompareTo(InventarioF.key);//comparación para hallar nodo a eliminar
        }
    }
}
