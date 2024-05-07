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
            return interfaceProyecto.listaTarjetasCredito.recorrer();
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
            return interfaceProyecto.colaPagos.recorrerPagos();
        }

        [HttpPost("almacenarEstadoCuenta")]
        public string PostEstadoCuenta(EstadoCuenta estadoCuenta)
        {
            EstadoCuenta newEstado = estadoCuenta;
            Random rnd = new Random();
            newEstado.id = rnd.Next();
            interfaceProyecto.arbolEstadoCuentas.insertar(newEstado);
            return "Estado de cuenta almacenado";
        }

        [HttpGet("obtenerEstadoCuenta")]
        public List<EstadoCuenta> GetObtenerEstadoCuenta()
        {
            return interfaceProyecto.arbolEstadoCuentas.recorrerEstadoCuenta(interfaceProyecto.arbolEstadoCuentas.raizArbol(), new List<EstadoCuenta>());
        }

        [HttpPost("almacenarMovimiento")]
        public string PostMovimiento(Movimiento movimiento)
        {
            interfaceProyecto.pilaMovimiento.insertar(movimiento);
            return "Movimiento almacenado";
        }

        [HttpGet("obtenerMovimiento")]
        public List<Movimiento> GetMovimientos()
        {
            return interfaceProyecto.pilaMovimiento.recorrer();
        }

        [HttpPost("almacenarNotificacion")]
        public string PostNotificacion(Notificacion notificacion)
        {
            interfaceProyecto.colaNotificaciones.insertar(notificacion);
            return "Notificacion almacenado";
        }

        [HttpGet("obtenerNotificacion")]
        public List<Notificacion> GetNotificacion()
        {
            return interfaceProyecto.colaNotificaciones.recorrerNotificaciones();
        }

        [HttpPost("almacenarCambioPin")]
        public string PostCambioPin(CambioPin cambioPin)
        {
            interfaceProyecto.listaCambioPin.insertarCabezaLista(cambioPin);
            interfaceProyecto.listaTarjetasCredito.buscarActualizarPinLista(cambioPin, cambioPin.nuevoPin);
            return "Cambio de pin procesado";
        }

        [HttpGet("obtenerCambioPin")]
        public List<CambioPin> GetCambioPin()
        {
            return interfaceProyecto.listaCambioPin.recorrerPin();
        }

        [HttpPost("almacenarBloqueoTemporal")]
        public string PostBloqueoTemporal(BloqueoTemporal bloqueo)
        {
            BloqueoTemporal newBloqueo = bloqueo;
            Random rnd = new Random();
            newBloqueo.id = rnd.Next();
            interfaceProyecto.arbolBloqueEstado.insertar(newBloqueo);
            return "Bloqueo Temporal almacenado";
        }

        [HttpGet("obtenerBloqueoTemporal")]
        public List<BloqueoTemporal> GetBLoqueoTempora()
        {
            return interfaceProyecto.arbolBloqueEstado.recorrerBloqueoTemporal(interfaceProyecto.arbolBloqueEstado.raizArbol(), new List<BloqueoTemporal>());
        }

        [HttpPost("almacenarSolicitudAumentoLimiteCredito")]
        public string PostSolicitudAumentoLimiteCredito(LimiteCredito limite)
        {
            interfaceProyecto.pilaLimiteCredito.insertar(limite);
            interfaceProyecto.listaTarjetasCredito.buscarActualizarLimiteCreditoLista(limite, limite.limiteCredito);
            return "Solicitud de aumento de limite de credito almacenada";
        }

        [HttpGet("obtenerLimiteCredito")]
        public List<LimiteCredito> GetLimiteCredito()
        {
            return interfaceProyecto.pilaLimiteCredito.recorrerLimiteCredito();
        }
    }
}
 