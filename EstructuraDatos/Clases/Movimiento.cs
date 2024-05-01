using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Clases
{
    public class Movimiento
    {
        public string nombreMovimiento { get; set; }
        public string numeroTarjeta { get; set; }
        public DateTime fechaMovimiento { get; set; }
        public decimal montoTotal { get; set; }
        public string nombre { get; set; }
    }
}
