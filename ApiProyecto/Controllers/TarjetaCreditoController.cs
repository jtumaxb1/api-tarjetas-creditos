using EstructuraDatos.Arbol;
using EstructuraDatos.Clases;
using EstructuraDatos.Colas;
using EstructuraDatos.Listas;
using EstructuraDatos.Pilas;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProyecto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarjetaCreditoController : Controller
    {

        ListaTarjetaCredito listaTarjetasCredito = new ListaTarjetaCredito();
        Pila pilaLimiteCredito = new Pila();
        Pila pilaMovimiento = new Pila();
        Cola colaPagos = new Cola();
        Cola colaNotificaciones = new Cola();
        ArbolBinarioBusqueda arbolEstadoCuentas = new ArbolBinarioBusqueda();
        ArbolBinarioBusqueda arbolBloqueEstado = new ArbolBinarioBusqueda();

        [HttpGet(Name = "tarjetaCredito")]

        public string Get()
        {
            try
            {
                List<TarjetaCredito> tarjetas = new List<TarjetaCredito>();
                List<EstadoCuenta> estadosCuentas = new List<EstadoCuenta>();
                List<Movimiento> movimientos = new List<Movimiento>();
                List<Notificacion> notificaciones = new List<Notificacion>();
                List<BloqueoTemporal> bloqueosTemporales = new List<BloqueoTemporal>();
                string fileJsonTarjetas = @"C:\archivos\tarjetasCreditos.json";
                string fileJsonEstadoCuentas = @"C:\archivos\estadosCuentas.json";
                string fileJsonMovimientos = @"C:\archivos\movimientos.json";
                string fileJsonNotificaciones = @"C:\archivos\notificaciones.json";
                string fileJsonBloqueoTemporal = @"C:\archivos\bloqueoTemporal.json";
                using (StreamReader jsonStream = System.IO.File.OpenText(fileJsonTarjetas))
                {
                    var json = jsonStream.ReadToEnd();
                    tarjetas = JsonConvert.DeserializeObject<List<TarjetaCredito>>(json);
                }
                using (StreamReader jsonStream = System.IO.File.OpenText(fileJsonEstadoCuentas))
                {
                    var json = jsonStream.ReadToEnd();
                    estadosCuentas = JsonConvert.DeserializeObject<List<EstadoCuenta>>(json);
                }
                using (StreamReader jsonStream = System.IO.File.OpenText(fileJsonMovimientos))
                {
                    var json = jsonStream.ReadToEnd();
                    movimientos = JsonConvert.DeserializeObject<List<Movimiento>>(json);
                }
                using (StreamReader jsonStream = System.IO.File.OpenText(fileJsonNotificaciones))
                {
                    var json = jsonStream.ReadToEnd();
                    notificaciones = JsonConvert.DeserializeObject<List<Notificacion>>(json);
                }
                using (StreamReader jsonStream = System.IO.File.OpenText(fileJsonBloqueoTemporal))
                {
                    var json = jsonStream.ReadToEnd();
                    bloqueosTemporales = JsonConvert.DeserializeObject<List<BloqueoTemporal>>(json);
                }
                foreach (var tarjeta in tarjetas)
                {
                    listaTarjetasCredito.insertarCabezaLista(tarjeta);
                    colaPagos.insertar(tarjeta);
                    pilaLimiteCredito.insertar(tarjeta);
                }

                foreach(var estadoCuenta in estadosCuentas)
                {
                    arbolEstadoCuentas.insertar(estadoCuenta);
                }

                foreach(var movimiento in movimientos)
                {
                    pilaMovimiento.insertar(movimiento);
                }

                foreach(var notificacion in notificaciones)
                {
                    colaNotificaciones.insertar(notificacion);
                }

                foreach(var bloqueo in bloqueosTemporales)
                {
                    arbolBloqueEstado.insertar(bloqueo);
                }

                return "Informacion cargada";
            } catch (Exception ex)
            {
                return $"Error => ${ex.Message}";
            }
        }

    }
}
