using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.interfaces
{
    public interface Comparador
    {
        // Buscado
        bool igualQue(string q);
        bool menorQue(string q);
        bool mayorQue(string q);

        // Insertar y eliminar

        bool igualQue(Object q);
        bool menorQue(Object q);
        bool mayorQue(Object q);
    }
}
