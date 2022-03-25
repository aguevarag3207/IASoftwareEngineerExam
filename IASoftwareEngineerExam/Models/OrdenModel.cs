using IASoftwareEngineerExam.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASoftwareEngineerExam.Models
{
    public class OrdenModel
    {
        public class Orden
        {
            public int NumOden { get; set; }
            public List<DetalleOrden> DetalleOrden { get; set; }
            public decimal Total { get; set; }
            public Estados_Orden EstadoOrden { get; set; }
        }

        public class DetalleOrden
        {
            public MenuModel Menu { get; set; }
            public int Cantidad { get; set; }
        }
    }

}
