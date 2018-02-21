using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;

namespace PresentacionAspNetMvc.Controllers
{
    public class BackUsuariosController : Controller
    {
        // GET: Backend
        public ActionResult Index()
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];

            return View(ln.BuscarTodosUsuarios());
        }
        //[HttpGet]
        //[HttpPost]       
        
    }
}