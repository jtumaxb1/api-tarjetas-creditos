using EstructuraDatos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Pilas
{
    public class NodoPila
    {
        public Object elemento;
        public NodoPila? siguiente;

        public NodoPila(Object elemento)
        {
            this.elemento = elemento;
            siguiente = null;
        }
    }
}
