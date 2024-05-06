using EstructuraDatos.Arbol;
using EstructuraDatos.Clases;
using EstructuraDatos.Colas;
using EstructuraDatos.interfaces;
using EstructuraDatos.Listas;
using EstructuraDatos.Pilas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ApiProyecto.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TarjetaCreditoController : Controller
    {

        private readonly ILogger<TarjetaCreditoController> logger;
        private readonly InterfaceProyecto interfaceProyecto;

        public TarjetaCreditoController(ILogger<TarjetaCreditoController> logger, InterfaceProyecto interfaceProyecto)
        {
            this.logger = logger;
            this.interfaceProyecto = interfaceProyecto;
        }

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
                    interfaceProyecto.listaTarjetasCredito.insertarCabezaLista(tarjeta);
                    interfaceProyecto.pilaLimiteCredito.insertar(tarjeta);
                }

                foreach(var estadoCuenta in estadosCuentas)
                {
                    interfaceProyecto.arbolEstadoCuentas.insertar(estadoCuenta);
                }

                foreach(var movimiento in movimientos)
                {
                    interfaceProyecto.pilaMovimiento.insertar(movimiento);
                }

                foreach(var notificacion in notificaciones)
                {
                    interfaceProyecto.colaNotificaciones.insertar(notificacion);
                }

                foreach(var bloqueo in bloqueosTemporales)
                {
                    interfaceProyecto.arbolBloqueEstado.insertar(bloqueo);
                }

                return "Informacion cargada";
            } catch (Exception ex)
            {
                return $"Error => ${ex.Message}";
            }
        }

        [HttpPost("almacenarSaldo")]
        public string Post(TarjetaCredito body)
        {
            interfaceProyecto.listaTarjetasCredito.insertarCabezaLista(body);
            return "Nuevo saldo almacenado";
        }

        [HttpGet("obtenerSaldo")]
        public List<TarjetaCredito> GetObtenerSaldo()
        {
            List<TarjetaCredito> tarjetas = interfaceProyecto.listaTarjetasCredito.recorrer();
            return tarjetas;
        }

        [HttpPost("almacenarPago")]
        public string PostPago(Pago pago)
        {
            interfaceProyecto.colaPagos.insertar(pago);
            interfaceProyecto.listaTarjetasCredito.buscarActualizarSaldoLista(pago, pago.montoFinal);
            return "Pago encolado";
        }

        [HttpGet("obtenerPago")]
        public List<Pago> GetObtenerPago()
        {
            List<Pago> pagos = interfaceProyecto.colaPagos.recorrer();
            return pagos;
        }

        [HttpPost("almacenarEstadoCuenta")]
        public string PostMovimiento(EstadoCuenta estadoCuenta)
        {
            EstadoCuenta newEstado = estadoCuenta;
            Random rnd = new Random();
            newEstado.id = rnd.Next();
            interfaceProyecto.arbolEstadoCuentas.insertar(estadoCuenta);
            return "Estado de cuenta almacenado";
        }

        [HttpGet("obtenerEstadoCuenta")]
        public List<EstadoCuenta> GetObtenerEstadoCuenta()
        {
            return interfaceProyecto.arbolEstadoCuentas.recorrerEstadoCuenta(interfaceProyecto.arbolEstadoCuentas.raizArbol(), new List<EstadoCuenta>());
        }


    }
}
 