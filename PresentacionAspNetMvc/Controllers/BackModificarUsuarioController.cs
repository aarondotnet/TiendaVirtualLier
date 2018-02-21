using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;

namespace PresentacionAspNetMvc.Controllers
{
    public class BackModificarUsuarioController : Controller
    {
        // GET: BackModificarUsuario
        public ActionResult Index(int Id)
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            return View(ln.BuscarUsuarioPorId(Id));
        }

        public ActionResult Modificar(int Id,string Nick, string Password)
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            IUsuario ModiUsuario = new Usuario();
            ModiUsuario.Id = Id;
            ModiUsuario.Nick = Nick;
            ModiUsuario.Password = Password;
            ln.ModificarUsuario(ModiUsuario);
            return RedirectToAction("Index","BackUsuarios");
        }
        public ActionResult Eliminar(int Id)
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            ln.BajaUsuario(ln.BuscarUsuarioPorId(Id));
            return RedirectToAction("Index", "BackUsuarios");
        }
    }
}