using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASoftwareEngineerExam.Models
{
    public class TamanioModel
    {
        public int IdTamanio { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public int Peso { get; set; }
        public Enum.MedidasProductos Medidas { get; set; }

        public List<TamanioModel> Tamanio()
        {
            
            List<TamanioModel> lst = new List<TamanioModel>();
            lst.Add(new TamanioModel { IdTamanio=1,Nombre="Chico",Siglas="CH",Peso=250,Medidas = Enum.MedidasProductos.ml});
            lst.Add(new TamanioModel { IdTamanio = 2, Nombre = "Mediano", Siglas = "M", Peso = 350, Medidas = Enum.MedidasProductos.ml });
            lst.Add(new TamanioModel { IdTamanio = 3, Nombre = "Grande", Siglas = "G", Peso = 500, Medidas = Enum.MedidasProductos.ml });
            lst.Add(new TamanioModel { IdTamanio = 4, Nombre = "Estandar", Siglas = "E", Peso = 0, Medidas = Enum.MedidasProductos.pz });

            return lst;
        }
    }
}
