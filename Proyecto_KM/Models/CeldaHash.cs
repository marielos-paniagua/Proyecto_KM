using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_KM.Utils;
using System.Threading.Tasks;

namespace Proyecto_KM.Models
{
    public class CeldaHash
    {
        public enum cellState//estado de la celda
        {
            vacio, ocupado, borrado
        }
        public int hashTableLenght = 50;//tamaño del arreglo para tabla hash
        public string key { get; set; }//variables
        public Task taskDetails { get; set; }

        internal cellState state;

        public CeldaHash()//inicializar como vacío
        {
            state = cellState.vacio;
        }

        public int HashF(string cadena, int intento)//función hash
        {

            int suma = 0;
            int indice = 0;
            foreach (var posicion in cadena)//tomar los valores de la cadena del nombre
            {
                char posicionChar = posicion;
                suma = suma + posicionChar + intento;//ir sumando, si hay colición el intento aumenta desde el método de insertar
            }

            indice = (suma + intento) % hashTableLenght;//función para hallar posición en el arreglo

            return indice;
        }

        public void insertEmptyCells()//agregar celdas vacías
        {
            for (int i = 0; i < hashTableLenght; i++)
            {
                CeldaHash hashtest = new CeldaHash();
                hashtest.taskDetails = null;
                hashtest.key = null;
                hashtest.state = cellState.vacio;
                Storage.Instance.hashTable.Add(hashtest);
            }
        }

        public bool insert(string key, Task task)//insertar en el tabla hash
        {
            int i = 0;
            int indice = 0;
            bool ocupado = false;

            while (ocupado == false)//hacer mientras la celda se encuentre desocupada:
            {
                indice = HashF(key, i);//buscar pocisión por medio de la función hash

                if (Storage.Instance.hashTable[indice].state == cellState.vacio)//si la posición está vacia:
                {

                    Storage.Instance.hashTable[indice].key = key;//insertar la clave (nombre utilizado)
                    Storage.Instance.hashTable[indice].taskDetails = task;//insertar los datos del paciente
                    Storage.Instance.hashTable[indice].state = cellState.ocupado;//cambiar el estado a ocupado
                    ocupado = true;
                    return true;
                }
                else//si no está la celda vacía:
                {
                    if (Storage.Instance.hashTable[indice].key == key)//si la clave es igua salir
                    {
                        break;
                    }
                    else//si no es igual aumentar el número de intentos para hallar la nueva posición con la función
                    {
                        i++;
                    }

                }

            }
            return false;
        }

        public bool BuscarHash(string key, ref Task task)//buscar en la tabla hash
        {
            int i = 0;
            int indice = 0;
            bool encontrado = false;

            while (encontrado == false)//hacer mientras no se encuentre:
            {
                indice = HashF(key, i);//buscar la función hash por el nombre

                if (Storage.Instance.hashTable[indice].key == key)//si el nombre coincide:
                {
                    task = Storage.Instance.hashTable[indice].taskDetails;//mandar por referencia los datos del paciente
                    encontrado = true;
                    return true;
                }
                else//si el nombre no coincide:
                {
                    i++;//aumentar el número de intentos para hallar la nueva posición con la función
                }

            }
            return false;
        }
    }
}
