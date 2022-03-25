using IASoftwareEngineerExam.Enum;
using IASoftwareEngineerExam.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace IASoftwareEngineerExam.Logica
{
    public class CRUD
    {
        private static string _path = Directory.GetCurrentDirectory() + @"\Models\Orden.json";

        public void Guardar(List<OrdenModel.Orden>  OrdenCompra)
        {
            string OrdenArchvoJson = JsonConvert.SerializeObject(OrdenCompra);
            System.IO.File.WriteAllText(_path, OrdenArchvoJson);
        }

        public List<OrdenModel.Orden> Cargar()
        {
            List<OrdenModel.Orden> OrdenCompra = new List<OrdenModel.Orden>();
            string OrdenArchvoJson = System.IO.File.ReadAllText(_path);
            OrdenCompra = JsonConvert.DeserializeObject<List<OrdenModel.Orden>>(OrdenArchvoJson);

            return OrdenCompra;
        }

        public List<OrdenModel.Orden> Cargar(Estados_Orden EstadoOrden)
        {
            List<OrdenModel.Orden> OrdenCompra = new List<OrdenModel.Orden>();
            OrdenCompra = Cargar();
            OrdenCompra = OrdenCompra.Where(x => x.EstadoOrden == EstadoOrden).ToList();

            return OrdenCompra;
        }

        public void Insertar(OrdenModel.Orden nuevaOrden)
        {

            List<OrdenModel.Orden> OrdenCompra = new List<OrdenModel.Orden>();
            OrdenCompra = Cargar();
            LogicaOrden lOrden = new LogicaOrden();
            
            nuevaOrden.NumOden = lOrden.GeneraNumero(OrdenCompra);
            nuevaOrden.DetalleOrden = lOrden.obtieneMenu(nuevaOrden.DetalleOrden);
            nuevaOrden.Total = lOrden.GeneraTotal(nuevaOrden.DetalleOrden);
            nuevaOrden.EstadoOrden = Estados_Orden.Pendiente;
            
            OrdenCompra.Add(nuevaOrden);
            Guardar(OrdenCompra);
        }

        public List<OrdenModel.Orden> Buscar(Func<OrdenModel.Orden, bool> criterio)
        {
            List<OrdenModel.Orden> OrdenCompra = new List<OrdenModel.Orden>();
            string OrdenArchvoJson = System.IO.File.ReadAllText(_path);
            return OrdenCompra.Where(criterio).ToList();
        }

        public void Eliminar(int numOrden)
        {
            List<OrdenModel.Orden> OrdenCompra = new List<OrdenModel.Orden>();
            OrdenCompra = Cargar();
            OrdenCompra = OrdenCompra.Where(x => x.NumOden != numOrden).ToList();
            Guardar(OrdenCompra);
        }

        public void Actualizar(OrdenModel.Orden nuevo)
        {
            List<OrdenModel.Orden> OrdenCompra = new List<OrdenModel.Orden>();
            OrdenCompra = Cargar();
            var index = OrdenCompra.FindIndex(x=> x.NumOden == nuevo.NumOden);
            OrdenCompra.RemoveAt(index);
            OrdenCompra.Insert(index,nuevo);
            Guardar(OrdenCompra);
        }
    }
}
