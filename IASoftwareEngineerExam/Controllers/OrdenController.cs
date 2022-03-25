using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IASoftwareEngineerExam.Models;
using Newtonsoft.Json;
using System.IO;
using IASoftwareEngineerExam.Logica;
using IASoftwareEngineerExam.Enum;
using Microsoft.AspNetCore.Cors;

namespace IASoftwareEngineerExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class OrdenController : ControllerBase
    {
        CRUD crud = new CRUD();

        [HttpGet]
        public ActionResult Get()
        {
            List<OrdenModel.Orden> OrdenCompra = new List<OrdenModel.Orden>();
            OrdenCompra = crud.Cargar();
            return Ok(OrdenCompra);
        }

        [HttpGet ("{orden}")]
        public ActionResult Get(int orden)
        {
            Estados_Orden estado = new Estados_Orden();
            switch (orden)
            {
                case 0:
                    estado = Estados_Orden.Cancelado;
                break;
                case 1:
                    estado = Estados_Orden.Pendiente;
                    break;
                case 2:
                    estado = Estados_Orden.Proceso;
                    break;
                case 3:
                    estado = Estados_Orden.Completado;
                    break;
                case 4:
                    estado = Estados_Orden.Entregado;
                    break;
            }

            List<OrdenModel.Orden> OrdenCompra = new List<OrdenModel.Orden>();
            OrdenCompra = crud.Cargar(estado);
            return Ok(OrdenCompra);
        }

        [HttpPost]
        public ActionResult Post([FromBody] OrdenModel.Orden orden)
        {
            crud.Insertar(orden);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] OrdenModel.Orden orden)
        {
            crud.Actualizar(orden);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] OrdenModel.Orden orden)
        {
            int num = Convert.ToInt32(orden.NumOden);
            crud.Eliminar(num);
            return Ok();
        }
        
    }
}
