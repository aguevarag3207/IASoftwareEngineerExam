using IASoftwareEngineerExam.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASoftwareEngineerExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class MenuController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            MenuModel obj = new MenuModel();
            List<MenuModel> ObtieneLstMenu = obj.Menu();
            return Ok(ObtieneLstMenu);
        }
    }
}
