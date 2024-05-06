using EstructuraDatos.Arbol;
using EstructuraDatos.Colas;
using EstructuraDatos.Listas;
using EstructuraDatos.Pilas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.interfaces
{
    public interface InterfaceProyecto
    {
        ListaTarjetaCredito listaTarjetasCredito { get; }
        Pila pilaLimiteCredito { get; }
        Pila pilaMovimiento { get; }
        Cola colaPagos { get; }
        Cola colaNotificaciones { get; }
        ListaTarjetaCredito listaCambioPin { get; }
        ArbolBinarioBusqueda arbolEstadoCuentas { get; }
        ArbolBinarioBusqueda arbolBloqueEstado { get; }
    }
}
