using IASoftwareEngineerExam.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IASoftwareEngineerExam.Logica
{
    public class LogicaOrden
    {
        private static string _path = Directory.GetCurrentDirectory() + @"\Models\Orden.json";

        public int GeneraNumero(List<OrdenModel.Orden> OrdenCompra)
        {
            
            CRUD cargaJson = new CRUD();
            int ultimo = OrdenCompra.Last().NumOden +1;
            
            return ultimo;
        }

        public decimal GeneraTotal(List<OrdenModel.DetalleOrden> DetallenCompra)
        {
            decimal total = 0;
            foreach (var item in DetallenCompra)
            {
                decimal totalXCantidad = item.Menu.Precio * item.Cantidad;
                total += totalXCantidad;
            }
            return total;
        }

        public List<OrdenModel.DetalleOrden> obtieneMenu(List<OrdenModel.DetalleOrden> detalle)
        {
            //Se obtiene Menu
            MenuModel obj = new MenuModel();
            List<MenuModel> ObtieneLstMenu = obj.Menu();


            List<OrdenModel.DetalleOrden> DetalleOrden = new List<OrdenModel.DetalleOrden>();

            foreach (var item in detalle)
            {
                MenuModel MenuSeleccionado = new MenuModel();
                

                MenuSeleccionado = ObtieneLstMenu.Find(x => x.idMenu == item.Menu.idMenu);
                OrdenModel.DetalleOrden det = new OrdenModel.DetalleOrden();
                det.Menu = MenuSeleccionado;
                det.Cantidad = item.Cantidad;
                DetalleOrden.Add(det);
            }

            
            return DetalleOrden;
        }
    }
}
