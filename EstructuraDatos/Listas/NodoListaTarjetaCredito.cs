using EstructuraDatos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Listas
{
    public class NodoListaTarjetaCredito
    {
        public Object dato;
        public NodoListaTarjetaCredito enlance;

        public NodoListaTarjetaCredito(Object dato)
        {
            this.dato = dato;
            this.enlance = null;
        }
    }
}
