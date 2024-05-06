using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Clases
{
    public class Pago
    {
        public string numeroTarjeta { get; set; }
        public string descripcion { get; set; }
        public decimal montoFinal { get; set; }
    }
}
