using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASoftwareEngineerExam.Models
{
    public class MenuModel
    {
        public int idMenu { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Tipo Tipo { get; set; }
        public TamanioModel Tamanio { get; set; }
        public decimal Precio { get; set; }

        public List<MenuModel> Menu()
        {
            TamanioModel tamM = new TamanioModel();
            List<TamanioModel> obj = tamM.Tamanio();
            List<MenuModel> lst = new List<MenuModel>();

            lst.Add(new MenuModel {idMenu=1,Nombre = "Hamburguesa Sencilla",Descripcion="Solo carne",Tipo=Tipo.Comida,Tamanio= obj.Find(x=>x.Nombre=="Estandar"), Precio= 50.00M });
            lst.Add(new MenuModel { idMenu = 2, Nombre = "Hamburguesa Doble", Descripcion = "Doble carne", Tipo = Tipo.Comida, Tamanio = obj.Find(x => x.Nombre == "Estandar"), Precio = 65.00M });
            lst.Add(new MenuModel { idMenu = 3, Nombre = "Hamburguesa C/Queso", Descripcion = "Una Carne con queso", Tipo = Tipo.Comida, Tamanio = obj.Find(x => x.Nombre == "Estandar"), Precio = 75.00M });

            lst.Add(new MenuModel { idMenu = 4, Nombre = "Soda CH", Descripcion = "Soda chica", Tipo = Tipo.Bebida, Tamanio = obj.Find(x => x.Nombre == "Chico"), Precio = 20.00M });
            lst.Add(new MenuModel { idMenu = 5, Nombre = "Soda M", Descripcion = "Soda Mediana", Tipo = Tipo.Bebida, Tamanio = obj.Find(x => x.Nombre == "Mediano"), Precio = 30.00M });
            lst.Add(new MenuModel { idMenu = 6, Nombre = "Soda G", Descripcion = "Soda Grande", Tipo = Tipo.Bebida, Tamanio = obj.Find(x => x.Nombre == "Grande"), Precio = 40.00M });

            lst.Add(new MenuModel { idMenu = 7, Nombre = "Papas CH", Descripcion = "Papas chica", Tipo = Tipo.Complemento, Tamanio = obj.Find(x => x.Nombre == "Chico"), Precio = 15.00M });
            lst.Add(new MenuModel { idMenu = 8, Nombre = "Papas M", Descripcion = "Papas Mediana", Tipo = Tipo.Complemento, Tamanio = obj.Find(x => x.Nombre == "Mediano"), Precio = 25.00M });
            lst.Add(new MenuModel { idMenu = 9, Nombre = "Papas G", Descripcion = "Papas Grande", Tipo = Tipo.Complemento, Tamanio = obj.Find(x => x.Nombre == "Grande"), Precio = 35.00M });

            return lst;
        }
    }
}
