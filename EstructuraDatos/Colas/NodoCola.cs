using EstructuraDatos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Colas
{
    public class NodoCola
    {
        public Object elemento;
        public NodoCola? siguiente;

        public NodoCola(Object elemento)
        {
            this.elemento = elemento;
            this.siguiente = null;
        }
    }
}
