using EstructuraDatos.Arbol;
using EstructuraDatos.Colas;
using EstructuraDatos.interfaces;
using EstructuraDatos.Listas;
using EstructuraDatos.Pilas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Clases
{
    public class ProyectoDBMemoria : InterfaceProyecto
    {
        public ListaTarjetaCredito listaTarjetasCredito { get; } = new ListaTarjetaCredito();

        public Pila pilaLimiteCredito { get; } = new Pila();

        public Pila pilaMovimiento { get; } = new Pila();

        public Cola colaPagos { get; } = new Cola();

        public Cola colaNotificaciones { get; } = new Cola();

        public ArbolBinarioBusqueda arbolEstadoCuentas { get; } = new ArbolBinarioBusqueda();

        public ArbolBinarioBusqueda arbolBloqueEstado { get; } = new ArbolBinarioBusqueda();
    }
}
