using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASoftwareEngineerExam.Enum
{
   public enum Estados_Orden : sbyte
    {
        Cancelado = 0,
        Pendiente = 1,
        Proceso = 2,
        Completado = 3,
        Entregado = 4
    }
}
