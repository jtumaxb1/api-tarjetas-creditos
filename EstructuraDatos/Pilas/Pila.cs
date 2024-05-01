using EstructuraDatos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Pilas
{
    public class Pila
    {
        protected NodoPila? cima;

        public Pila()
        {
            cima = null;
        }

        public Boolean pilaVacia()
        {
            return cima == null;
        }

        public void insertar(Object elemento)
        {
            NodoPila nuevo;
            nuevo = new NodoPila(elemento);
            nuevo.siguiente = cima;
            cima = nuevo;
        }

        public void quitar()
        {
            if (pilaVacia())
            {
                throw new Exception("Pila vacia, no se puede extraer.");
            }
            cima = cima.siguiente;
        }

        public Object cimaPila()
        {
            if (pilaVacia())
            {
                throw new Exception("Pila vacia, no se puede leer cima.");
            }
            return cima.elemento;
        }

        public void limpiarPila()
        {
            NodoPila t;
            while(!pilaVacia())
            {
                t = cima;
                cima = cima.siguiente;
                t.siguiente = null;
            }
        }

    }
}
