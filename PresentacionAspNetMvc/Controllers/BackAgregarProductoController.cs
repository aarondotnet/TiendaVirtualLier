using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;

namespace PresentacionAspNetMvc.Controllers
{
    public class BackAgregarProductoController : Controller
    {
        // GET: BackAgregarProducto
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MAgregarProducto(string Nombre, string Precio)
        {
            var ln = (ILogicaNegocio)HttpContext.Application["logicaNegocio"];
            decimal.TryParse(Precio, out decimal result);

            Producto NuevoProducto = new Producto(ln.ListadoProductos().OrderByDescending(p => p.Id).First().Id+1, Nombre, result );
            ln.AltaProducto(NuevoProducto);
            return RedirectToAction("Index", "BackProducto"); //orde: medoto Controlador
        }
    }
}