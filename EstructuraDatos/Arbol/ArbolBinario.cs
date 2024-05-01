using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Arbol
{
    public class ArbolBinario
    {
        protected Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        public ArbolBinario(Nodo raiz)
        {
            this.raiz = raiz;
        }

        public Nodo raizArbol()
        {
            return raiz;
        }

        bool esVacio()
        {
            return raiz == null;
        }

        public static Nodo nuevoArbol(Nodo ramaIzda, Object dato, Nodo ramaDrcha)
        {
            return new Nodo(ramaIzda, dato, ramaDrcha);
        }

        public static int numNodos(Nodo raiz)
        {
            if (raiz == null)
            {
                return 0;
            } else
            {
                return 1 + numNodos(raiz.subArbolIzdo()) + numNodos(raiz.subArbolDcho());
            }
        }

    }
}
