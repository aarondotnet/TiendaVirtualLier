using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;

namespace PresentacionAspNetMvc.Controllers
{
    public class BackModificarProductoController : Controller
    {
        // GET: BackModificarProducto
        public ActionResult Index(int Id)
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            return View(ln.BuscarProductoPorId(Id));
            
        }
        public ActionResult Modificar(int Id, string Nombre, decimal Precio)
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            Producto ModiProducto = new Producto(Id,Nombre,Precio);
            ln.ModificarProducto(ModiProducto);
            return RedirectToAction("Index", "BackProducto");
        }
        public ActionResult Eliminar(int Id)
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            ln.BajaProducto(Id);
            return RedirectToAction("Index", "BackProducto");
        }
    }
}