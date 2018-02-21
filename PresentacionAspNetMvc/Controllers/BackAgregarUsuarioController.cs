using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;

namespace PresentacionAspNetMvc.Controllers
{
    public class BackAgregarUsuarioController : Controller
    {
        // GET: BackAgregarUsuario
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MAgregarUsuario(string Nick, string Password)
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            IUsuario NuevoUsuario= new Usuario(ln.BuscarTodosUsuarios().OrderByDescending(u => u.Id).First().Id + 1, Nick,Password);
            ln.AltaUsuario(NuevoUsuario);
            return RedirectToAction("Index", "BackAgregarUsuario"); //orde: medoto Controlador
        }
    }
}