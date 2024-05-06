using EstructuraDatos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void insertarCabezaLista(Object dato)
        {
            NodoListaTarjetaCredito nuevo;
            nuevo = new NodoListaTarjetaCredito(dato);
            nuevo.enlance = primero;
            primero = nuevo;
        }

        public ListaTarjetaCredito insertarUltimo(Object testigo, Object entrada)
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

        public ListaTarjetaCredito insertarLista(Object testigo, Object entrada)
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

        public List<TarjetaCredito> recorrer()
        {
            NodoListaTarjetaCredito indice;
            List<TarjetaCredito> tarjetas = new List<TarjetaCredito>();
            for (indice = primero; indice != null; indice = indice.enlance)
            {
                tarjetas.Add((TarjetaCredito)indice.dato);
            }
            return tarjetas;
        }

        public List<CambioPin> recorrerPin()
        {
            NodoListaTarjetaCredito indice;
            List<CambioPin> cambioPins = new List<CambioPin>();
            for (indice = primero; indice != null; indice = indice.enlance)
            {
                cambioPins.Add((CambioPin)indice.dato);
            }
            return cambioPins;
        }

        public NodoListaTarjetaCredito buscarLista(Object destino) {
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

        public void buscarActualizarSaldoLista(Object destino, decimal dato)
        {
            NodoListaTarjetaCredito indice;
            for (indice = primero; indice != null; indice = indice.enlance)
            {
                Pago destinoPago = (Pago)destino;
                TarjetaCredito tarjeta1 = (TarjetaCredito)indice.dato;
                if (tarjeta1.numeroTarjeta == destinoPago.numeroTarjeta)
                {
                    TarjetaCredito tarjeta = (TarjetaCredito)indice.dato;
                    tarjeta.saldo = tarjeta.saldo - dato;
                    indice.dato = tarjeta;
                }
            }
        }

        public void buscarActualizarLimiteCreditoLista(Object destino, decimal dato)
        {
            NodoListaTarjetaCredito indice;
            for (indice = primero; indice != null; indice = indice.enlance)
            {
                LimiteCredito destinoPago = (LimiteCredito)destino;
                TarjetaCredito tarjeta1 = (TarjetaCredito)indice.dato;
                if (tarjeta1.numeroTarjeta == destinoPago.numeroTarjeta)
                {
                    TarjetaCredito tarjeta = (TarjetaCredito)indice.dato;
                    tarjeta.limiteCredito = dato;
                    indice.dato = tarjeta;
                }
            }
        }

        public void buscarActualizarPinLista(Object destino, int nuevoPin)
        {
            NodoListaTarjetaCredito indice;
            for (indice = primero; indice != null; indice = indice.enlance)
            {
                CambioPin destinoCambio = (CambioPin)destino;
                TarjetaCredito tarjeta1 = (TarjetaCredito)indice.dato;
                if (tarjeta1.numeroTarjeta == destinoCambio.numeroTarjeta)
                {
                    TarjetaCredito tarjeta = (TarjetaCredito)indice.dato;
                    tarjeta.pin = nuevoPin;
                    indice.dato = tarjeta;
                }
            }
        }

    }
}
