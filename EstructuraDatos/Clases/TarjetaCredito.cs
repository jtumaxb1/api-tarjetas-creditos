using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Clases
{
    public class TarjetaCredito
    {
        public string nombre { get; set; }
        public string numeroTarjeta { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public int codigoVencimiento { get; set; }
        public decimal saldo { get; set; }
        public int pin { get; set; }
        public decimal limiteCredito { get; set; }
    }
}
