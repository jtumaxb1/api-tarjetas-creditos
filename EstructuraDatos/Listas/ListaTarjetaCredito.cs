using EstructuraDatos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Listas
{
    public class ListaTarjetaCredito
    {
        public NodoListaTarjetaCredito primero;

        public ListaTarjetaCredito()
        {
            primero = null;
        }

        public void insertarCabezaLista(TarjetaCredito dato)
        {
            NodoListaTarjetaCredito nuevo;
            nuevo = new NodoListaTarjetaCredito(dato);
            nuevo.enlance = primero;
            primero = nuevo;
        }

        public ListaTarjetaCredito insertarUltimo(TarjetaCredito testigo, TarjetaCredito entrada)
        {
            NodoListaTarjetaCredito nuevo, anterior;
            // anterior = buscarLista(testigo);
            anterior = new NodoListaTarjetaCredito(testigo);
            if (anterior != null)
            {
                nuevo = new NodoListaTarjetaCredito(entrada);
                nuevo.enlance = anterior.enlance;
                anterior.enlance = nuevo;
            }
            return this;
        }

        public ListaTarjetaCredito insertarLista(TarjetaCredito testigo, TarjetaCredito entrada)
        {
            NodoListaTarjetaCredito nuevo, anterior;
            anterior = buscarLista(testigo);
            if (anterior != null)
            {
                nuevo = new NodoListaTarjetaCredito(entrada);
                nuevo.enlance = anterior.enlance;
                anterior.enlance = nuevo;
            }
            return this;
        }

        public NodoListaTarjetaCredito buscarLista(TarjetaCredito destino) {
            NodoListaTarjetaCredito indice;
            for(indice = primero; indice != null; indice = indice.enlance)
            {
                if (destino.Equals(indice.dato))
                {
                    return indice;
                }
            }
            return null;
        }

    }
}
