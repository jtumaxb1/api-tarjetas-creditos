using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Arbol
{
    public class Nodo
    {
        protected Object dato;
        protected Nodo izdo;
        protected Nodo dcho;

        public Nodo(Object valor)
        {
            dato = valor;
            izdo = dcho = null;
        }

        public Nodo(Nodo ramaizdo, Object valor, Nodo ramaDcho)
        {
            this.dato = valor;
            this.izdo = ramaizdo;
            this.dcho = ramaDcho;
        }

        public Object valorNodo()
        {
            return dato;
        }

        public Nodo subArbolIzdo()
        {
            return izdo;
        }

        public Nodo subArbolDcho()
        {
            return dcho;
        }

        public void nuevoValor(Object d)
        {
            dato = d;
        }

        public void ramaIzdo(Nodo n)
        {
            izdo = n;
        }

        public void ramaDcho(Nodo n)
        {
            dcho = n;
        }

        public string visitar()
        {
            return dato.ToString();
        }

    }
}
