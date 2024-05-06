using EstructuraDatos.Clases;
using EstructuraDatos.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Arbol
{
    public class ArbolBinarioBusqueda : ArbolBinario
    {
        public ArbolBinarioBusqueda() : base() {
            
        }

        public ArbolBinarioBusqueda(Nodo nodo) : base(nodo)
        {

        }

        protected Object buscarEstadoCuenta(Nodo raizSub, string buscado)
        {
            try
            {
                EstadoCuenta dato = (EstadoCuenta)raizSub.valorNodo();
                if (raizSub == null)
                {
                    return null;
                }
                else if (dato.igualQue(buscado))
                {
                    return dato;
                }
                else if (dato.menorQue(buscado))
                {
                    return buscarEstadoCuenta(raizSub.subArbolDcho(), buscado);
                }
                else
                {
                    return buscarEstadoCuenta(raizSub.subArbolIzdo(), buscado);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<EstadoCuenta> recorrerEstadoCuenta(Nodo r, List<EstadoCuenta> lista)
        {
            if (r != null)
            {
                lista.Add((EstadoCuenta)r.valorNodo());
                if (r.subArbolIzdo() != null)
                {
                    recorrerEstadoCuenta(r.subArbolIzdo(), lista);
                }
                if (r.subArbolDcho() != null)
                {
                    recorrerEstadoCuenta(r.subArbolDcho(), lista);
                }
            }
            return lista;
        }

        public Object buscarEstadoCuenta(string dato)
        {
            if (raiz == null)
            {
                return null;
            }
            else
            {
                return buscarEstadoCuenta(raizArbol(), dato);
            }
        }

        public void insertar(Object valor)
        {
            Comparador dato;
            dato = (Comparador)valor;
            raiz = insertar(raiz, dato);
        }

        protected Nodo insertar(Nodo raizSub, Comparador dato)
        {
            if (raizSub == null)
            {
                raizSub = new Nodo(dato);
            }
            else if (dato.menorQue(raizSub.valorNodo()))
            {
                Nodo iz;
                iz = insertar(raizSub.subArbolIzdo(), dato);
                raizSub.ramaIzdo(iz);
            }
            else if (dato.mayorQue(raizSub.valorNodo()))
            {
                Nodo dr;
                dr = insertar(raizSub.subArbolDcho(), dato);
                raizSub.ramaDcho(dr);
            }
            else throw new Exception("Nodo duplicado");
            return raizSub;
        }

        public void eliminar(Object valor)
        {
            Comparador dato;
            dato = (Comparador)valor;
            raiz = eliminar(raiz, dato);
        }

        protected Nodo eliminar(Nodo raizSub, Comparador dato)
        {
            if (raizSub == null)
            {
                throw new Exception("No encontrado el nodo con la clave");
            }
            else if (dato.menorQue(raizSub.valorNodo()))
            {
                Nodo iz;
                iz = eliminar(raizSub.subArbolIzdo(), dato);
                raizSub.ramaIzdo(iz);
            }
            else if (dato.mayorQue(raizSub.valorNodo()))
            {
                Nodo dr;
                dr = eliminar(raizSub.subArbolDcho(), dato);
                raizSub.ramaDcho(dr);
            }
            else
            {
                Nodo q;
                q = raizSub;
                if (q.subArbolIzdo() == null)
                {
                    raizSub = q.subArbolDcho();
                }
                else if (q.subArbolIzdo() == null)
                {
                    raizSub = q.subArbolIzdo();
                }
                else
                {
                    q = reemplazar(q);
                }
                q = null;
            }

            return raizSub;
        }

        private Nodo reemplazar(Nodo act)
        {
            Nodo a, p;
            p = act;
            a = act.subArbolIzdo();
            while (a.subArbolDcho() != null)
            {
                p = a;
                a = a.subArbolDcho();
            }
            act.nuevoValor(a.valorNodo());
            if (p == act)
            {
                p.ramaIzdo(a.subArbolIzdo());
            }
            else
            {
                p.ramaDcho(a.subArbolDcho());
            }
            return a;
        }

    }
}
