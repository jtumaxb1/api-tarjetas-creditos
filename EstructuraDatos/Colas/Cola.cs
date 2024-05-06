using EstructuraDatos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Colas
{
    public class Cola
    {
        public NodoCola? inicio;
        public NodoCola? fin;

        public Cola()
        {
            inicio = fin = null;
        }

        public Boolean colaVacio()
        {
            return (inicio == null);
        }

        public void insertar(Object x)
        {
            NodoCola a;
            a = new NodoCola(x);
            if (colaVacio())
            {
                inicio = a;
            } else
            {
                fin.siguiente = a;
            }
            fin = a;
        }

        public void quitar()
        {
            if (!colaVacio())
            {
                inicio = inicio.siguiente;
            } else
            {
                throw new Exception("Eliminar de una cola vacia");
            }
        }

        public void borrarCola()
        {
            for (;inicio != null;)
            {
                inicio = inicio.siguiente;
            }
        }

        public Object frenteCola()
        {
            if (colaVacio())
            {
                throw new Exception("Error => cola vacia");
            }

            return (inicio.elemento);

        }

        public List<Pago> recorrerPagos()
        {
            NodoCola indice;
            List<Pago> pagos = new List<Pago>();
            for (indice = inicio; indice != null; indice = indice.siguiente)
            {
                pagos.Add((Pago)indice.elemento);
            }

            return pagos;
        }

        public List<Notificacion> recorrerNotificaciones()
        {
            NodoCola indice;
            List<Notificacion> notificaciones = new List<Notificacion>();
            for (indice = inicio; indice != null; indice = indice.siguiente)
            {
                notificaciones.Add((Notificacion)indice.elemento);
            }

            return notificaciones;
        }

    }
}
