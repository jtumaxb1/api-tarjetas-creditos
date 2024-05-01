using EstructuraDatos.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Clases
{
    public class BloqueoTemporal : Comparador
    {
        public int id { get; set; }
        public string comentario { get; set; }
        public string numeroTarjeta { get; set; }
        public string fechaBloqueo { get; set; }
        public string fechaDesbloqueo { get; set; }
        public string nombre { get; set; }

        public bool igualQue(string q)
        {
            return this.numeroTarjeta == q;
        }

        public bool igualQue(object q)
        {
            BloqueoTemporal q2 = (BloqueoTemporal)q;
            return this.id == q2.id;
        }

        public bool mayorQue(string q)
        {
            if (this.numeroTarjeta.CompareTo(q) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool mayorQue(object q)
        {
            BloqueoTemporal q2 = (BloqueoTemporal)q;
            if (this.id < q2.id)
                return true;
            else
                return false;
        }

        public bool menorQue(string q)
        {
            if (this.numeroTarjeta.CompareTo(numeroTarjeta) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool menorQue(object q)
        {
            BloqueoTemporal q2 = (BloqueoTemporal)q;
            if (this.id > q2.id)
                return true;
            else
                return false;
        }
    }
}
